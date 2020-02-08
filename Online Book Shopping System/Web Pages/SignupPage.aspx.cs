using Online_Book_Shopping_System.BL;
using Online_Book_Shopping_System.Entity;
using System;

namespace Online_Book_Shopping_System
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            User userObj = new User(txtName.Text, txtUserName.Text, txtEmail.Text, ddUser.SelectedValue.ToString(), txtPassword.Text);
    
            if (UserBL.SignUp(userObj))
            {
                Response.Write("<Script>alert('Sign Up SuccessFull')</Script>");
            }
            else
            {
                Response.Write("<Script>alert('Sign Up Failed')</Script>");
            }
        }
    }
}