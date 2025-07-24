﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <th>Name</th>
                <asp:HiddenField ID="hdn" runat="server" />
                <td> <asp:TextBox ID="txtName" runat="server" Required></asp:TextBox></td>
            </tr>
            <tr>
                <th>Age</th>
                <th><asp:TextBox ID="txtAge" runat="server" Required></asp:TextBox></th>
            </tr>
            <tr>
                <th>Courses</th>
                <td>
                    <asp:DropDownList ID="ddleCourses" runat="server" Required>
                        <asp:ListItem Text="--Select Value--" Value=""></asp:ListItem>
                        <asp:ListItem Text="BA" Value="BA"></asp:ListItem>
                         <asp:ListItem Text="BCA" Value="BCA"></asp:ListItem>
                         <asp:ListItem Text="MCA" Value="MCA"></asp:ListItem>
                         <asp:ListItem Text="MTECH" Value="MTECH"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>Gender</th>
                <td>
                    <asp:RadioButtonList ID="rbnGender" runat="server" Required>
                        <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                        <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                        <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <th>City</th>
                <td>
                    <asp:CheckBoxList ID="chkCity" runat="server" Required>
                        <asp:ListItem Text="Delhi" Value="Delhi"></asp:ListItem>
                        <asp:ListItem Text="Mumbai" Value="Mumbai"></asp:ListItem>
                        <asp:ListItem Text="lucknow" Value="lucknow"></asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td><asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></td>
            </tr>
        </table>
         <asp:GridView ID="grid" runat="server" AutoGenerateColumns="false" OnRowCommand="grid_RowCommand">
            <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                        <%# Eval("name") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Age">
                        <ItemTemplate>
                        <%# Eval("age") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Courses">
                         <ItemTemplate>
                        <%# Eval("courses") %>
                         </ItemTemplate>
                        </asp:TemplateField>

                     <asp:TemplateField HeaderText="Gender">
                         <ItemTemplate>
                             <%#Eval("gender") %>
                         </ItemTemplate>
                     </asp:TemplateField>

                    <asp:TemplateField HeaderText="City">
                        <ItemTemplate>
                            <%# Eval("city") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Action">
                         <ItemTemplate>
                       <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteRecord" CommandArgument='<%#Eval("id") %>'></asp:LinkButton>
                         </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                      <asp:LinkButton ID="btnEdit" runat="server" Text="Edit" CommandName="EditRecord" CommandArgument='<%# Eval("id") %>'></asp:LinkButton>
                         </ItemTemplate>
                       </asp:TemplateField>
                     </Columns>
            </asp:GridView>
         </form>
</body>
</html>
