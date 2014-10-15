using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;

namespace DAL
{
    public class OrdersDAL
    {
        public static DBConnection GetOrders(User user)
        {
            DBConnection dbConnection = new DBConnection();
            dbConnection.AddCmd();
            switch (user.UserLevel)
            {
                case UserLevel.Admin:
                    dbConnection.Cmds[0].CommandText = "SELECT * FROM Orders";
                    break;
                case UserLevel.Seller:
                    dbConnection.ExecuteCmd("SELECT * FROM Salesmen WHERE Name='" + user.UserName + "'", 1);
                    dbConnection.Reader.Read();

                    dbConnection.Cmds[0].CommandText = "SELECT * FROM Orders WHERE CustID IN (SELECT CustID FROM Customer WHERE Area='" + dbConnection.Reader["Area"].ToString() + "')";
                    break;
                case UserLevel.Client:
                    dbConnection.ExecuteCmd("SELECT * FROM Customer WHERE Name='" + user.UserName + "'", 1);
                    dbConnection.Reader.Read();

                    dbConnection.Cmds[0].CommandText = "SELECT * FROM Orders WHERE CustID=" + dbConnection.Reader["CustID"].ToString() + "";
                    break;
            }
            dbConnection.Connection.Close();

            return dbConnection;
        }
    }
}