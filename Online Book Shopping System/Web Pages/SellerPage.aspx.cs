using Online_Book_Shopping_System.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Book_Shopping_System.Web_Pages
{
    public partial class SellerPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int UserID =Convert.ToInt32(Request.QueryString["UserID"]);
            if (!Page.IsPostBack)
            {
                BindData(UserID);
            }
        }

        public void BindData(int id)
        {
            GridViewBook.DataSource = BookRepositary.refereshSellerBookData(id);
            GridViewBook.DataBind();
        }
    }
}