using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management
{
    class Teacher : QueryBuilder
    {
        private Connection connection;

        public Teacher(string tableName) : base (tableName)
        {
            connection = new Connection();
            connection.openConnection();
        }


    }
}
