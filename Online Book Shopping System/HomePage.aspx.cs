﻿using System;
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
        static string connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString; // Get Connection String From App.Config
        SqlConnection dbConnection = new SqlConnection(connection);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                refereshData();
            }
        }
        public void refereshData()
        {

            string query = "Select * From Book";
            SqlCommand command = new SqlCommand(query, dbConnection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "Book");
            DataTable bookTable = dataSet.Tables["Book"];
            GridViewBook.DataSource = bookTable;
            GridViewBook.DataBind();
            command.Dispose();

        }

        protected void GridViewBook_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridViewBook.DataKeys[e.RowIndex].Values["BookID"].ToString());
            dbConnection.Open();
            SqlCommand command = new SqlCommand("Delete From Book Where BookID=@id", dbConnection);
            command.Parameters.AddWithValue("id", id);
            int affectedRows = command.ExecuteNonQuery();
            dbConnection.Close();
            refereshData();
        }

        protected void GridViewBook_RowEditing(object sender,GridViewEditEventArgs e)
        {
            GridViewBook.EditIndex = e.NewEditIndex;
            refereshData();
        }
        protected void GridViewBook_RowCancelingEdit(object sender,GridViewCancelEditEventArgs e)
        {
            GridViewBook.EditIndex = -1;
            refereshData();
        }
        protected void GridViewBook_RowUpdating(object sender,GridViewUpdateEventArgs e)
        {
            TextBox txtTitle = GridViewBook.Rows[e.RowIndex].FindControl("txtTitle") as TextBox;
            TextBox txtAuthor = GridViewBook.Rows[e.RowIndex].FindControl("txtAuthor") as TextBox;
            TextBox txtGenere = GridViewBook.Rows[e.RowIndex].FindControl("txtGenere") as TextBox;
            TextBox txtPrice = GridViewBook.Rows[e.RowIndex].FindControl("txtPrice") as TextBox;
            TextBox txtNoOfPages = GridViewBook.Rows[e.RowIndex].FindControl("txtNoOfPages") as TextBox;
            int id = Convert.ToInt32(GridViewBook.DataKeys[e.RowIndex].Values["id"]as TextBox);
            dbConnection.Open();
            SqlCommand command = new SqlCommand("spUpdateBookTable", dbConnection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("title", txtTitle.Text);
            command.Parameters.AddWithValue("author", txtAuthor.Text);
            command.Parameters.AddWithValue("genere", txtGenere.Text);
            command.Parameters.AddWithValue("price", txtPrice.Text);
            command.Parameters.AddWithValue("noOfPages", txtNoOfPages.Text);
            command.Parameters.AddWithValue("id", id+1);

            int i = command.ExecuteNonQuery();
            dbConnection.Close();
            GridViewBook.EditIndex = -1;
            refereshData();
        }
    }
}