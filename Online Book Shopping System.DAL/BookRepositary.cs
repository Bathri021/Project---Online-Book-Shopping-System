using Online_Book_Shopping_System.Entity.Books;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Shopping_System.DAL
{
    public class BookRepositary
    {
        static string connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString; // Get Connection String From App.Config
        static SqlConnection dbConnection = new SqlConnection(connection);
        public static DataTable refereshData()
        {

            string query = "Select * From Book";
            SqlCommand command = new SqlCommand(query, dbConnection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "Book");
            DataTable bookTable = dataSet.Tables["Book"];
            command.Dispose();
            return bookTable;
        }
        public static DataTable refereshSellerBookData(int id)
        {
            string query = "spSelectSellerBook";
            SqlCommand command = new SqlCommand(query, dbConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("SellerID", id);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "Book");
            DataTable bookTable = dataSet.Tables["Book"];
            command.Dispose();
            return bookTable;
        }

        public static bool deleteBook(int bookID)
        {
            dbConnection.Open();
            SqlCommand command = new SqlCommand("Delete From Book Where BookID=@id", dbConnection);
            command.Parameters.AddWithValue("id", bookID);
            int affectedRows = command.ExecuteNonQuery();
            dbConnection.Close();
            if (affectedRows>=1)
            {
                return true;
            }
            else
            {
               return false;
            }
        }
        public static bool updateBook(Book bookObj,int _ID)
        {
            dbConnection.Open();
            SqlCommand command = new SqlCommand("spUpdateBookTable", dbConnection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("title", bookObj.Title);
            command.Parameters.AddWithValue("author", bookObj.Author);
            command.Parameters.AddWithValue("genere", bookObj.Genere);
            command.Parameters.AddWithValue("price", bookObj.Price);
            command.Parameters.AddWithValue("noOfPages", bookObj.NoOfPages);
            command.Parameters.AddWithValue("id", _ID);

            int affectedRows = command.ExecuteNonQuery();
            dbConnection.Close();
            if (affectedRows>=1)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }
        public static bool insertBook(Book bookObj)
        {
            dbConnection.Open();
            SqlCommand command = new SqlCommand("spInsertBook", dbConnection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("SellerID", bookObj.UserID);
            command.Parameters.AddWithValue("Title", bookObj.Title);
            command.Parameters.AddWithValue("Author", bookObj.Author);
            command.Parameters.AddWithValue("Genere", bookObj.Genere);
            command.Parameters.AddWithValue("Price", bookObj.Price);
            command.Parameters.AddWithValue("NoOfPages", bookObj.NoOfPages);
            command.Parameters.AddWithValue("Quantity", 6);

            int affectedRows = command.ExecuteNonQuery();
            dbConnection.Close();
            if (affectedRows >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
