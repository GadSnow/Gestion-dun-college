using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Management
{
    class Student: QueryBuilder
    {
        private Connection connection;
        private SqlDataReader sdr;
        private SqlCommand sc;
        public Student(string tableName): base(tableName)
        {
            connection = new Connection();
            connection.openConnection();
        }

        public int getClassID()
        {
            int class_id = 0;
            string query = $"SELECT class_id FROM {tableName}";
            sc = new SqlCommand(query, connection.getConnection());
            sdr = sc.ExecuteReader();

            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    class_id = int.Parse(sdr["class_id"].ToString());
                }

                sdr.Close();
            }

            return class_id;
        }

        public string findClass(int class_id)
        {
            string className = "";
            string query = $"SELECT class_name FROM Class c, Student s WHERE c.class_id= s.class_id";
            sc = new SqlCommand(query, connection.getConnection());
            sdr = sc.ExecuteReader();

            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    className = sdr["class_name"].ToString();
                }

                sdr.Close();
            }
            return className;
        }




    }
}
