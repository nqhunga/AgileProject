using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;

namespace DAL
{
    public class UsersDAL
    {
        public static User Login(string username, string password)
        {
            DBConnection dbConnection = new DBConnection();
            dbConnection.ExecuteCmd("SELECT * FROM UserData WHERE Name='" + username + "'");

            if (dbConnection.Reader.Read())
            {
                var pass = dbConnection.Reader["Password"].ToString();
                var name = dbConnection.Reader["Name"].ToString();
                var level = dbConnection.Reader["UserLevelID"].ToString();

                dbConnection.Connection.Close();

                if (!String.IsNullOrEmpty(pass) && pass == password)
                {
                    User user = new User();
                    user.UserName = name;
                    user.UserLevel = (UserLevel)Enum.Parse(typeof(UserLevel), level);

                    return user;
                }
            }

            return null;
        }
    }
}