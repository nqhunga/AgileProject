using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace DAL.Models
{
    public class DBConnection
    {
        public OleDbConnection Connection { get; set; }
        public List<OleDbCommand> Cmds { get; set; }
        public OleDbDataReader Reader { get; set; }
        public DBConnection()
        {
            string projectPath = @"|DataDirectory|\UserLevelsAndCustomerOrders2014.mdb;";
            string conStr = "Provider = Microsoft.Jet.OLEDB.4.0;" + "Data Source = " + projectPath;

            Connection = new OleDbConnection();
            Connection.ConnectionString = conStr;

            Cmds = new List<OleDbCommand>();
            var cmd = new OleDbCommand();
            cmd.Connection = Connection;
            cmd.CommandType = CommandType.Text;
            Cmds.Add(cmd);
        }

        public void ExecuteCmd(string query, int cmdIndex = 0)
        {
            Connection.Open();
            if (!String.IsNullOrEmpty(query))
                Cmds[cmdIndex].CommandText = query;

            Reader = Cmds[cmdIndex].ExecuteReader();
        }

        public void AddCmd()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = Connection;
            cmd.CommandType = CommandType.Text;

            Cmds.Add(cmd);
        }
    }
    public class Order
    {
        public int CustId { get; set; }
        public int ProdID { get; set; }
        public int Amount { get; set; }
        public string OrderDate { get; set; }
    }
}