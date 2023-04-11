using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management
{
    class Connection
    {
        private SqlConnection connection;

        public Connection()
        {
            connection = new SqlConnection(@"Data Source=GAD\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True");

        }

        public void openConnection()
        {
            connection.Open();
        }

        public SqlConnection getConnection()
        {
            return connection;
        }
    }
}
