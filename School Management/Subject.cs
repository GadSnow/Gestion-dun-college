using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management
{
    class Subject: QueryBuilder
    {
        private Connection connection;
        public Subject(string tableName): base(tableName)
        {
            connection = new Connection();
            connection.openConnection();
        }
    }
}
