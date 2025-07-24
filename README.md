# Student Registration System – ASP.NET Web Forms (C# + SQL Server)

This is a basic **CRUD-based Web Application** built using **ASP.NET Web Forms** and **C#**, connected to a **SQL Server** database. The app allows users to create, read, update, and delete student records.

---

## 🚀 Features

- Add new students with fields: Name, Age, Course, Gender, and City
- View all student records in a GridView
- Edit existing records directly from the grid
- Delete records with confirmation
- Backend database integration using **ADO.NET**
- User interface built using **Web Forms controls** (TextBox, DropDownList, CheckBoxList, etc.)

---

## 🛠️ Technologies Used

- ASP.NET Web Forms (C#)
- SQL Server (ADO.NET)
- HTML, GridView, Server Controls
- Visual Studio 2022 (or higher)
- SQL Server Management Studio (SSMS)

---

## 🧠 How It Works

1. User enters student details into a form
2. Data is saved to a SQL Server table (`Students`)
3. GridView displays all entries with edit/delete options
4. Edit populates fields; Delete removes the row from DB

---

## 📸 Screenshots

> *(Add screenshots of your form and GridView here)*

---

## ⚙️ Setup Instructions

1. Clone or download this repository
2. Open the project in **Visual Studio**
3. Ensure **SQL Server** is running and create a database named `StudentDB`
4. Create a `Students` table using the following schema:

```sql
CREATE TABLE Students (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(100),
    age INT,
    courses NVARCHAR(50),
    gender NVARCHAR(20),
    city NVARCHAR(200)
)

5. Update the connection string in Default.aspx.cs:

string constrng = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=true;";

6. Run the project using Visual Studio


🙋‍♀️ Author
Shreya Singh
Aspiring .NET Developer & Data Analyst
