using Online_Book_Shopping_System.BL;
using Online_Book_Shopping_System.Entity;
using System;


namespace Online_Book_Shopping_System
{
    public partial class SigninPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            // UserManager userObj = new UserManager();

            //string Role;
            //Role = userObj.userLogIn(txtUserNameLogin.Text, txtPasswordLogin.Text);
            //if (Role != null)
            //{
            //    Response.Write("Login SucccessFul As " + Role);
            //}
            //else
            //{
            //    Response.Write("Login Failed");
            //}
            if (UserBL.SignIn(txtUserNameLogin.Text, txtPasswordLogin.Text))
            {
               string Role = UserBL.role;
               string id =  UserBL.id.ToString();
                Response.Write("<Script>alert('Sign In SuccessFull as "+Role+"')</Script>");
                if (Role == "Seller")
                {
                    Response.Redirect(@"~\Web Pages\SellerPage.aspx?UserID="+id);
                }
            }
            else
            {
                Response.Write("<Script>alert('Sign In Failed')</Script>");
            }
        }
    }
}