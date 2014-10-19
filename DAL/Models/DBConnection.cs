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
        public Dictionary<string, OleDbCommand> Cmds { get; set; }
        public OleDbDataReader Reader { get; set; }
        public DBConnection()
        {
            string projectPath = @"|DataDirectory|\UserLevelsAndCustomerOrders2014.mdb;";
            string conStr = "Provider = Microsoft.Jet.OLEDB.4.0;" + "Data Source = " + projectPath;

            Connection = new OleDbConnection();
            Connection.ConnectionString = conStr;

            Cmds = new Dictionary<string, OleDbCommand>();
            var cmd = new OleDbCommand();
            cmd.Connection = Connection;
            cmd.CommandType = CommandType.Text;
            Cmds.Add("default", cmd);
        }

        public void ExecuteCmd(string query, string cmdIdentifier = "default")
        {
            Open();
            if (!String.IsNullOrEmpty(query))
                Cmds[cmdIdentifier].CommandText = query;

            Reader = Cmds[cmdIdentifier].ExecuteReader();
        }

        public void ExecuteNonQuery(string query, string cmdIdentifier = "default")
        {
            Open();
            if (!String.IsNullOrEmpty(query))
                Cmds[cmdIdentifier].CommandText = query;

            Cmds[cmdIdentifier].ExecuteNonQuery();
        }

        public void AddCmd(string cmdIdentifier)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = Connection;
            cmd.CommandType = CommandType.Text;

            Cmds.Add(cmdIdentifier, cmd);
        }

        public void Open()
        {
            if (!Connection.State.Equals(ConnectionState.Open))
                Connection.Open();
        }

        public void Close()
        {
            if (!Connection.State.Equals(ConnectionState.Closed))
                Connection.Close();
        }

        // SEE UsersDAL.GetAllUsers FOR EXAMPLE
        // string query: SQL query to execute
        // BuildObject: Function for mapping the object
        public IEnumerable<T> ExecuteTypedList<T>(string query, Func<IDataRecord, T> BuildObject, string cmdIdentifier = "default")
        {
            Open();
            if (!String.IsNullOrEmpty(query))
                Cmds[cmdIdentifier].CommandText = query;

            Reader = Cmds[cmdIdentifier].ExecuteReader();

            try
            {
                while (Reader.Read())
                {
                    yield return BuildObject(Reader);
                }
            }
            finally
            {
                Reader.Dispose();
            }
        }

        public static IEnumerable<T> GetData<T>(IDataReader reader, Func<IDataRecord, T> BuildObject)
        {
            try
            {
                while (reader.Read())
                {
                    yield return BuildObject(reader);
                }
            }
            finally
            {
                reader.Dispose();
            }
        }
    }
}