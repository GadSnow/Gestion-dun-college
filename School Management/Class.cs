using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Management
{
    class Class : QueryBuilder
    {
        private Connection connection;

        public Class(string tableName) : base (tableName)
        {
            connection = new Connection();
            connection.openConnection();
        }

    }
}
