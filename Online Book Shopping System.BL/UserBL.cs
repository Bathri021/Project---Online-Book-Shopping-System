using Online_Book_Shopping_System.Entity;
using Online_Book_Shopping_System.Repositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Shopping_System.BL
{
    public static class UserBL
    {
        public static string role;
        public static int id;

        public static bool SignUp(User user)
        {
            return UserRepositary.SignUp(user);
        }
        public static bool SignIn(string userName,string password)
        {
           int userID = UserRepositary.SignIn(userName, password);
           string role = user.Role.ToString();
           int id = user.UserID;
            if (user.Role!=null)
            {
                return true;
            }else
            {
                return false;
            }
           
        }
    }
}
