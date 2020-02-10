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
        public static Dictionary<int, string> userList = new Dictionary<int, string>();
        static string connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString; // Get Connection String From App.Config
        public static string Role;
      

        public static bool SignUp(User user)
        {
            SqlConnection dbConnection = new SqlConnection(connection);
            int affectedRow;
            try
            {
                
                string query = "spInsertUser";

                using (SqlCommand insertCommand = new SqlCommand(query,dbConnection))
                {
                    insertCommand.CommandType = CommandType.StoredProcedure;

                    insertCommand.Parameters.AddWithValue("@Name", user.Name);
                    insertCommand.Parameters.AddWithValue("@UserName", user.UserName);
                    insertCommand.Parameters.AddWithValue("@MailID", user.MailId);
                    insertCommand.Parameters.AddWithValue("@Password", user.Password);
                    insertCommand.Parameters.AddWithValue("@Role", user.Role);

                    dbConnection.Open();
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter();
                    sqlAdapter.InsertCommand = insertCommand;
                    affectedRow = insertCommand.ExecuteNonQuery();
                }
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


        public static User SignIn(string _userName, string _password)
        {
            userList.Clear();
            SqlConnection dbConnection = new SqlConnection(connection);
            string sqlQuery = "spCheckUserNameandPassword";

            using (SqlCommand selectCommand = new SqlCommand(sqlQuery, dbConnection))
            {
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.AddWithValue("@UserName",_userName);
                selectCommand.Parameters.AddWithValue("@Password", _password);

                selectCommand.Parameters.Add("@UserID",SqlDbType.Int);
                selectCommand.Parameters["@UserID"].Direction = ParameterDirection.Output;
                selectCommand.Parameters.Add("@Role",SqlDbType.VarChar,10);
                selectCommand.Parameters["@Role"].Direction = ParameterDirection.Output;
                dbConnection.Open();
                selectCommand.ExecuteReader();
                User user = new User( Convert.ToInt32(selectCommand.Parameters["@UserID"].Value.ToString()), selectCommand.Parameters["@Role"].Value.ToString());
                user.Role =(string) selectCommand.Parameters["@Role"].Value;
                user.UserID =Convert.ToInt32(selectCommand.Parameters["@UserID"].Value);
                return user;
            }
        }
    }
}