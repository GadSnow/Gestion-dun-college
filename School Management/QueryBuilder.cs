using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Management
{
    class QueryBuilder
    {
        protected string tableName;

        private SqlCommand sc;
        private Connection connection;
        private SqlDataReader sdr;

        private DataTable dt = null;
        private SqlDataAdapter sda;

        private string username;

        public QueryBuilder(string tableName)
        {
            this.tableName = tableName;
            connection = new Connection();
            connection.openConnection();
        }

        public string checkAuth(string username, string password)
        {
            string query = $"SELECT auth_username, auth_password FROM {tableName}";
            sc = new SqlCommand(query, connection.getConnection());
            sdr  = sc.ExecuteReader();

            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    if (sdr["auth_username"].ToString() == username && sdr["auth_password"].ToString() == password)
                    {
                        this.username = sdr["auth_username"].ToString();
                        sdr.Close();
                        return this.username;
                    }
                }
                
            }

            sdr.Close();

            return "";
        }

        public string getUsername()
        {
            return username;
        }

        public QueryBuilder select(DataGridView grid, string table)
        {
            dt = new DataTable();
            string query = $"SELECT * FROM {table}";
            sda = new SqlDataAdapter(query, connection.getConnection());
            sda.Fill(dt);
            grid.DataSource = dt;

            return this;
        }


        public void selectByClassname(DataGridView grid, string className, string table)
        {
            dt = new DataTable();
            string query = $"SELECT * FROM {table} WHERE class_name = '{className}'";
            sda = new SqlDataAdapter(query, connection.getConnection());
            sda.Fill(dt);
            grid.DataSource = dt;
        }

       
        public int ExecuteQuery(string query, string message = null)
        {
            int numberOfLinesExecuted = 0;

            try
            {
                sc = new SqlCommand(query, connection.getConnection());
                numberOfLinesExecuted = sc.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return numberOfLinesExecuted;

        }

        public QueryBuilder insert(string[] columns, dynamic[] values)
        {
            int numberOfLinesExecuted = 0;
            string query = $"INSERT INTO {tableName} VALUES ( ";
            for (int i = 0; i < columns.Length; i++)
            {
                query += $"'{values[i]}',";
            }
            query = query.Remove(query.Length - 1);

            query += " )";
            

            numberOfLinesExecuted = ExecuteQuery(query);

            return this;
        }
        
        public QueryBuilder update(string[] columns, dynamic[] values, string columnName, int id)
        {
            int numberOfLinesExecuted = 0;
            string query = $"UPDATE {tableName} SET ";
            for (int i = 0; i < columns.Length; i++)
            {
                query += $"{columns[i]} = '{values[i]}',";
            }
            query = query.Remove(query.Length - 1);
            query += $" WHERE {columnName} = {id}";
            query = string.Format(query, id);

            MessageBox.Show(query);
            

            numberOfLinesExecuted = ExecuteQuery(query);

            return this;
        }

        public QueryBuilder updateMarks(string[] columns, dynamic[] values, string columnName, int id, int subject)
        {
            int numberOfLinesExecuted = 0;
            string query = $"UPDATE {tableName} SET ";
            for (int i = 0; i < columns.Length; i++)
            {
                query += $"{columns[i]} = '{values[i]}',";
            }
            query = query.Remove(query.Length - 1);
            query += $" WHERE {columnName} = {id} and subject_id = {subject}";
            query = string.Format(query, id);


            numberOfLinesExecuted = ExecuteQuery(query);

            return this;
        }

        public QueryBuilder delete(string columnName, dynamic id)
        {
            int numberOfLinesExecuted = 0;
            string query = $"DELETE FROM {tableName} WHERE {columnName} = {id}";

            numberOfLinesExecuted = ExecuteQuery(query);

            return this;
        }

        public QueryBuilder search(DataGridView grid, string column, dynamic value)
        {
            dt = new DataTable();
            string query = $"SELECT * FROM {tableName} WHERE {column} LIKE '%{value}%'";
            sda = new SqlDataAdapter(query, connection.getConnection());
            MessageBox.Show(query);
            sda.Fill(dt);
            grid.DataSource = dt;

            return this;
        }

        public QueryBuilder search(DataGridView grid, string table, string column, dynamic value)
        {
            dt = new DataTable();
            string query = $"SELECT * FROM {table} WHERE {column} LIKE '%{value}%'";
            sda = new SqlDataAdapter(query, connection.getConnection());
            sda.Fill(dt);
            grid.DataSource = dt;

            return this;
        }

        public void showMarksOfOneStudent(DataGridView grid, string student_id)
        {
            dt = new DataTable();
            string query = $"SELECT subject_name as Matières, mark as Moyennes, subject_coefficient as Coeff, mark * subject_coefficient as Notes_Coeff,  teacher_lastname + ' ' + teacher_firstname  as Professeur FROM Subject, Student, Student_Subject, Teacher, Teacher_Class_Subject WHERE Student.student_id = Student_Subject.student_id AND Subject.subject_id = Student_Subject.subject_id AND Student_Subject.student_id = {student_id} AND Teacher_Class_Subject.subject_id = Subject.subject_id AND Teacher_Class_Subject.teacher_id = Teacher.teacher_id AND Student.class_id = Teacher_Class_Subject.class_id";
            sda = new SqlDataAdapter(query, connection.getConnection());
            sda.Fill(dt);
            grid.DataSource = dt;

        }

        public void showMarksOfAllStudent(DataGridView grid, int class_id)
        {
            dt = new DataTable();
            string query = $"SELECT student_firstname + ' ' + student_lastname as 'Nom et Prénom', ROUND(SUM (mark) / 9, 2) AS Moyenne FROM student_subject, Student, Class WHERE Student.student_id = student_subject.student_id AND Class.class_id = Student.class_id AND Student.class_id = {class_id} GROUP BY student_firstname, student_lastname ORDER BY ROUND(SUM (mark) / 9, 2) DESC";
            sda = new SqlDataAdapter(query, connection.getConnection());
            sda.Fill(dt);
            grid.DataSource = dt;
        }

        public void paymentHistory(DataGridView grid, string student_id)
        {
            dt = new DataTable();
            string query = $"SELECT date_of_payment, paid, method FROM Student_Payment WHERE student_id = {student_id}";
            sda = new SqlDataAdapter(query, connection.getConnection());
            sda.Fill(dt);
            grid.DataSource = dt;
        }

        public int getNumberOfItems(string query, string columnName)
        {
            dynamic count = "";

            sc = new SqlCommand(query, connection.getConnection());
            sdr = sc.ExecuteReader();

            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    count = sdr[columnName].ToString();
                }

            }
            count = int.Parse(count);

            sdr.Close();

            return count;
        }


        public int getTeacherID()
        {
            int teacher_id = 0;
            string query = $"SELECT teacher_id FROM {tableName}";
            sc = new SqlCommand(query, connection.getConnection());
            sdr = sc.ExecuteReader();

            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    teacher_id = int.Parse(sdr["teacher_id"].ToString());
                }

            }
            sdr.Close();

            return teacher_id;
        }

        public int getStudentMark(string id)
        {

            int student_mark = 0;
            string query = $"SELECT mark FROM {tableName} WHERE student_id = {id}";
            sc = new SqlCommand(query, connection.getConnection());
            sdr = sc.ExecuteReader();

            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    student_mark = int.Parse(sdr["mark"].ToString());
                    break;
                }

            }
            sdr.Close();


            return student_mark;

        }

        public void printNumberOfItems(Label number, Label text, string message)
        {
            string columnName = "columnCount";
            string query = $"SELECT COUNT(*) as {columnName} FROM {tableName}";
            int numberOfItems = getNumberOfItems(query, columnName);
            if (numberOfItems < 10)
            {
                number.Text = $"0{numberOfItems}";
                if (numberOfItems <= 1)
                {
                    text.Text = message;
                }
            }
            else
            {
                number.Text = $"{numberOfItems}";
            }

        }

        public void printNumberOfItems(Label number, Label text, string message, string status)
        {
            string columnName = "columnCount";
            string query = $"SELECT COUNT(*) as {columnName} FROM {tableName} WHERE status = '{status}'";
            int numberOfItems = getNumberOfItems(query, columnName);
            if (numberOfItems < 10)
            {
                number.Text = $"0{numberOfItems}";
                if (numberOfItems <= 1)
                {
                    text.Text = message;
                }
            }
            else
            {
                number.Text = $"{numberOfItems}";
            }

        }


        public void sumOfNotes(string columnName)
        {
            string query = $"SELECT SUM{columnName} FROM {tableName}";
        }
    }
}
