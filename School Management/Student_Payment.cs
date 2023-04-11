using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management
{
    class Student_Payment: QueryBuilder
    {
        private Connection connection;
        public Student_Payment(string tableName): base(tableName)
        {
            connection = new Connection();
            connection.openConnection();
        }
    }
}
