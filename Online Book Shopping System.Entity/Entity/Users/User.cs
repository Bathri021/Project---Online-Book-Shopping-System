namespace Online_Book_Shopping_System.Entity
{
    public class User
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string MailId { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int UserID;

        public User(string name,string userName,string mailID,string password,string role,int userID)
        {
            this.Name = name;
            this.UserName = userName;
            this.MailId = mailID;
            this.Password = password;
            this.Role = role;
            this.UserID = userID;
        }
        public User(string name, string userName, string mailID, string password, string role)
        {
            this.Name = name;
            this.UserName = userName;
            this.MailId = mailID;
            this.Password = password;
            this.Role = role;
        }

    }
}