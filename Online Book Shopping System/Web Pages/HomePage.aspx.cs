using Online_Book_Shopping_System.DAL;
using Online_Book_Shopping_System.Entity.Books;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Book_Shopping_System
{
    public partial class HomePage : System.Web.UI.Page
    {    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               BindData();
            }
        }
       
        public void BindData()
        {
            GridViewBook.DataSource = BookRepositary.refereshData();
            GridViewBook.DataBind();
        }

        protected void GridViewBook_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridViewBook.DataKeys[e.RowIndex].Values["BookID"].ToString());
            if (BookRepositary.deleteBook(id))
            {
                Response.Write("<Script>alert('Book Deleted')</Script>");
                BindData();
            }
            else
            {
                Response.Write("<Script>alert('Can not Delete Book')</Script>");
            }
        }

        protected void GridViewBook_RowEditing(object sender,GridViewEditEventArgs e)
        {
            GridViewBook.EditIndex = e.NewEditIndex;
            BindData();
        }
        protected void GridViewBook_RowCancelingEdit(object sender,GridViewCancelEditEventArgs e)
        {
            GridViewBook.EditIndex = -1;
            BindData();
        }
        protected void GridViewBook_RowUpdating(object sender,GridViewUpdateEventArgs e)
        {
            TextBox txtTitle = GridViewBook.Rows[e.RowIndex].FindControl("txtTitle") as TextBox;
            TextBox txtAuthor = GridViewBook.Rows[e.RowIndex].FindControl("txtAuthor") as TextBox;
            TextBox txtGenere = GridViewBook.Rows[e.RowIndex].FindControl("txtGenere") as TextBox;
            TextBox txtPrice = GridViewBook.Rows[e.RowIndex].FindControl("txtPrice") as TextBox;
            TextBox txtNoOfPages = GridViewBook.Rows[e.RowIndex].FindControl("txtNoOfPages") as TextBox;
            int id = Convert.ToInt32(GridViewBook.DataKeys[e.RowIndex].Values["BookID"].ToString());

            Book book = new Book(8,txtTitle.Text,txtAuthor.Text,txtGenere.Text,Convert.ToInt32(txtPrice.Text.ToString()), Convert.ToInt32(txtNoOfPages.Text.ToString()));
            if (BookRepositary.updateBook(book,id))
            {
                Response.Write("<Script>alert('Book Details Updated')</Script>");
                BindData();
            }
            else
            {
                Response.Write("<Script>alert('Can not Update Book Details')</Script>");
            }
            GridViewBook.EditIndex = -1;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            TextBox txtTitle = GridViewBook.FooterRow.FindControl("txtTitle") as TextBox;
            TextBox txtAuthor = GridViewBook.FooterRow.FindControl("txtAuthor") as TextBox;
            TextBox txtGenere = GridViewBook.FooterRow.FindControl("txtGenere") as TextBox;
            TextBox txtPrice = GridViewBook.FooterRow.FindControl("txtPrice") as TextBox;
            TextBox txtNoOfPages = GridViewBook.FooterRow.FindControl("txtNoOfPages") as TextBox;

            Book book = new Book(8, txtTitle.Text, txtAuthor.Text, txtGenere.Text, Convert.ToInt32(txtPrice.Text.ToString()), Convert.ToInt32(txtNoOfPages.Text.ToString()));

            if (BookRepositary.insertBook(book))
            {
                Response.Write("<Script>alert('Book  added Successfully')</Script>");
                BindData();
            }
            else
            {
                Response.Write("<Script>alert('Can not Add Book')</Script>");
            }
        }
    }
}