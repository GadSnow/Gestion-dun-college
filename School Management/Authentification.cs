using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management
{
    class Authentification: QueryBuilder
    {
        private Connection connection;
        public Authentification(string tableName): base(tableName)
        {
            connection = new Connection();
            connection.openConnection();
        }
    }
}
