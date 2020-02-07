<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignInForm.aspx.cs" Inherits="Online_Book_Shopping_System.SignInForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="SignupSigninStyleSheet.css"/>
</head>
<body>
        <div id="divForm">
        <form id="loginForm" runat="server">
             <h2 class="formTitle">Sign In</h2>
            <div>
                <table>
                    <tr>
                        <td class="labletxt">User Name</td>
                        <td>
                            <asp:TextBox ID="txtUserNameLogin" CssClass="txtField" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="labletxt">Password</td>
                        <td>
                            <asp:TextBox ID="txtPasswordLogin" CssClass="txtField" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <br />
                    <tr>
                        <td>
                            <asp:Button ID="btnSignIn" Class="btnsubmit" runat="server" Text="Sign In" OnClick="btnSignIn_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </form>
        </div>
</body>
</html>
