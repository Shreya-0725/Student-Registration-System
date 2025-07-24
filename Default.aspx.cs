using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    String constrng = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=true;";


    protected void Page_Load(object sender, EventArgs e)
    {
        Display();
    }
    public void Display()
    {
        SqlConnection con = new SqlConnection(constrng);
        string query = "Select * from  Students";
        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        grid.DataSource = ds;
        grid.DataBind();
        con.Close();

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string box = "";
        for (int i = 0; i < chkCity.Items.Count; i++)
        {
            if (chkCity.Items[i].Selected == true)
            {
                box += chkCity.Items[i].Text + ",";
            }
        }
        box = box.TrimEnd(',');

        if (btnSave.Text == "Save")
        {
            SqlConnection con = new SqlConnection(constrng);

            string query = "insert into Students(name, age, courses, gender, city)values(@Name,@Age, @Courses, @gender, @city)";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@age", txtAge.Text);
            cmd.Parameters.AddWithValue("@Courses", ddleCourses.SelectedValue);
            cmd.Parameters.AddWithValue("@gender", rbnGender.SelectedValue);
            cmd.Parameters.AddWithValue("@city", box);
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
        }
        else if (btnSave.Text == "Update")
        {
            SqlConnection con = new SqlConnection(constrng);
            string query = "Update Students set name=@name, age=@age , Courses=@courses, gender=@gender , city=@city where id=@id";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", hdn.Value);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@age", txtAge.Text);
            cmd.Parameters.AddWithValue("@Courses", ddleCourses.SelectedValue);
            cmd.Parameters.AddWithValue("@gender", rbnGender.SelectedValue);
            cmd.Parameters.AddWithValue("@city", box);
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
        }
        btnSave.Text = "Save";
        txtName.Text = txtAge.Text = ddleCourses.SelectedValue = "";
        rbnGender.ClearSelection();
        chkCity.ClearSelection();
       


    }
    protected void grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            SqlConnection con = new SqlConnection(constrng);
            string query = "delete Students where id=@id";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", e.CommandArgument);
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
        }
        else if (e.CommandName == "EditRecord")
        {
            SqlConnection con = new SqlConnection(constrng);
            string query = "Select * from Students where id=@id";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", e.CommandArgument);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();

            txtName.Text = dt.Rows[0]["name"].ToString();
            txtAge.Text = dt.Rows[0]["age"].ToString();






            string course = dt.Rows[0]["Courses"].ToString();
            if (ddleCourses.Items.FindByValue(course) != null)
            {
                ddleCourses.SelectedValue = course;
            }



            string gender = dt.Rows[0]["gender"].ToString();
            if (rbnGender.Items.FindByValue(gender) != null)
            {
                rbnGender.SelectedValue = gender;
            }



            if (dt.Rows[0]["City"] != DBNull.Value && !string.IsNullOrEmpty(dt.Rows[0]["City"].ToString()))
            {
                string[] cities = dt.Rows[0]["City"].ToString().Split(',');
                foreach (ListItem item in chkCity.Items)
                {
                    item.Selected = cities.Contains(item.Text);
                }
            }

            btnSave.Text = "Update";
            hdn.Value = e.CommandArgument.ToString();

        }

    }

}
