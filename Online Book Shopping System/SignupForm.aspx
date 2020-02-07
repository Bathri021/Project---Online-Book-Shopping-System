<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignupForm.aspx.cs" Inherits="Online_Book_Shopping_System.RegistrationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="SignupSigninStyleSheet.css"/>
</head>
<body>
    <div id="divForm">
        <form id="registrationForm" runat="server">
        <h2 class="formTitle">Sign Up</h2>
            <div>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblName" CssClass="labletxt" runat="server" Text="Name"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" CssClass="txtField" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="valName" runat="server" ControlToValidate="txtName" ErrorMessage="Please Enter your Name">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblUserName" CssClass="labletxt" runat="server" Text="User Name"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserName" CssClass="txtField" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="valUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="Please Enter your User Name">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEmail" CssClass="labletxt" runat="server" Text="Email"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" CssClass="txtField" runat="server" AutoCompleteType="Email"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="valEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please Enter your Email ID">*</asp:RequiredFieldValidator>

                            <asp:RegularExpressionValidator ID="reEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please Enter Valid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">* </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPassword" CssClass="labletxt" runat="server" Text="Password"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassword" CssClass="txtField" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="valPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please Enter Password">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label class="labletxt" >Confirm Password</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRePassword" CssClass="txtField" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                        <td>
                            <asp:CompareValidator ID="cmpPassword" runat="server" ControlToValidate="txtPassword" ControlToCompare="txtRePassword" Operator="Equal" ErrorMessage="Password Is Not Matching">*</asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblRole" runat="server" Text="Role"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddUser" runat="server">
                                <asp:ListItem Value="Customer">Customer</asp:ListItem>
                                <asp:ListItem Value="Seller">Seller</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                   <tr></tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnSignUp" CssClass="btnsubmit" runat="server" Text="Sign Up" allign="Center" OnClick="btnSignUp_Click" />
                        </td>
                    </tr>
                    <tr>
                         <td>
                            <asp:ValidationSummary ID="valSum" runat="server"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h3>Already have an account?</h3>
                            <a href="SignInForm.aspx" target="_self">LogIn</a>
                        </td>
                    </tr>
                </table>
            </div>
        </form>
       
    </div>
</body>
</html>
