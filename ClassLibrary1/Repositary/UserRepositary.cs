using Online_Book_Shopping_System.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Online_Book_Shopping_System.Repositary
{
    public class UserRepositary
    {
        public static Dictionary<int, User> userList = new Dictionary<int, User>();
        static string connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString; // Get Connection String From App.Config

      

        public static bool SignUp(User user)
        {
            SqlConnection dbConnection = new SqlConnection(connection);
            int affectedRow;
            try
            {
                dbConnection.Open();
                string query = "spInsertUser";

                using (SqlCommand insertCommand = new SqlCommand(query,dbConnection))
                {
                    insertCommand.CommandType = CommandType.StoredProcedure;

                    insertCommand.Parameters.AddWithValue("@Name", user.Name);
                    insertCommand.Parameters.AddWithValue("@UserName", user.UserName);
                    insertCommand.Parameters.AddWithValue("@MailID", user.MailId);
                    insertCommand.Parameters.AddWithValue("@Password", user.Password);
                    insertCommand.Parameters.AddWithValue("@Role", user.Role);

                    SqlDataAdapter sqlAdapter = new SqlDataAdapter();
                    sqlAdapter.InsertCommand = insertCommand;
                    affectedRow = insertCommand.ExecuteNonQuery();
                }
                addUserIntoList();
                if (affectedRow >= 1)
                {
                    return true;
                }else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public static void addUserIntoList()
        {
            SqlConnection dbConnection = new SqlConnection(connection);
            string sqlQuery = "Select * From _User";

            using (SqlCommand selectCommand = new SqlCommand(sqlQuery,dbConnection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = selectCommand;
                DataSet userDataset = new DataSet();
                adapter.Fill(userDataset, "User");
                DataTable userDataTable = userDataset.Tables["User"];
                // Iterate through the Data table to fetch the Row 
                foreach (DataRow row in userDataTable.Rows)
                {
                    User user = new User(
                        row[0].ToString(),
                        row[1].ToString(),
                        row[2].ToString(),
                        row[3].ToString(),
                        row[4].ToString()
                      //  int.Parse(row[5].ToString())
                   );
                    userList.Add(user.UserID, user);  // Add into the List
                }
            }
        }
    }
}