using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management
{
    class Teacher_Class_Subject: QueryBuilder
    {
        private Connection connection;
        public Teacher_Class_Subject(string tableName): base(tableName)
        {
            connection = new Connection();
            connection.openConnection();
        }

 

    }
}
