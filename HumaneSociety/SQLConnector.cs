using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace HumaneSociety
{
    class SQLConnector
    {
        // Member variables
        public string ConnectionString;
        SqlConnection con;
        // Constructor
        public SQLConnector()
        {
            //ConnectionString = "Server = DESKTOP-02SQATS; Database = HumaneSociety; Integrated Security = true;";
            // This connection string will only work for dylan's computer.
            con = new SqlConnection(ConnectionString);
        }
        // Member methods
        public void OpenConnection()
        {
            con.Open();
        }
        
        public void CloseConnection()
        {
            con.Close();
        }

        public void ExecuteQuery(string Query)
        {
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();
        }
    }
}
