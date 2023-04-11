using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Management
{
    public partial class DashboardForm : Form
    {
        private LoginForm loginForm;
        private Authentification auth;
        private Student student;
        private Class classe;
        private Teacher teacher;
        private Subject subject;
        private Student_Subject student_subject;
        private Teacher_Class_Subject teacher_class_subject;
        private Student_Payment student_payment;

        private bool studentButtonState = false;
        private bool examButtonState = false;
        private bool userToEditPasswordState = true;
        private bool passwordFieldState = true;
        private string marksClassname;
        private string showMarksClassname;
        private string className;



        private int currentStudentRow;
        private int currentTeacherRow;
        private int currentPaymentRow;
        private int studentPaymentID = 0;
        private int currentMarksRow;
        private int currentUserRow;
        public DashboardForm(string username)
        {
            InitializeComponent();
            this.username.Text = username;
            checkAdminConnected();

            loginForm = new LoginForm();
            auth = new Authentification("Authentification");
            student = new Student("Student");
            classe = new Class("Class");
            teacher = new Teacher("Teacher");
            subject = new Subject("Subject");
            student_subject = new Student_Subject("Student_Subject");
            teacher_class_subject = new Teacher_Class_Subject("Teacher_Class_Subject");
            student_payment = new Student_Payment("Student_Payment");
        }

        public void checkAdminConnected()
        {
            if (username.Text != "admin")
            {
                createNewUserButton.Visible = false;
                usersOnDashboard.Visible = false;
                adminOnDashboard.Visible = false;
                usersMngButton.Visible = false;
            }
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'projectDataSet34.Authentification'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
            this.authentificationTableAdapter.Fill(this.projectDataSet34.Authentification);
            // TODO: cette ligne de code charge les données dans la table 'projectDataSet33.view_students_payments'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
            this.view_students_paymentsTableAdapter1.Fill(this.projectDataSet33.view_students_payments);
            // TODO: cette ligne de code charge les données dans la table 'projectDataSet32.view_students_payments'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
            this.view_students_paymentsTableAdapter.Fill(this.projectDataSet32.view_students_payments);
            // TODO: cette ligne de code charge les données dans la table 'projectDataSet31.view_payments'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
            this.view_paymentsTableAdapter1.Fill(this.projectDataSet31.view_payments);
            // TODO: cette ligne de code charge les données dans la table 'projectDataSet30.Student_Payment'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
            this.student_PaymentTableAdapter1.Fill(this.projectDataSet30.Student_Payment);
            // TODO: cette ligne de code charge les données dans la table 'projectDataSet29.view_payments'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
            this.view_paymentsTableAdapter.Fill(this.projectDataSet29.view_payments);
            // TODO: cette ligne de code charge les données dans la table 'projectDataSet28.Student_Payment'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
            this.student_PaymentTableAdapter.Fill(this.projectDataSet28.Student_Payment);

            // TODO: cette ligne de code charge les données dans la table 'projectDataSet27.view_teacher'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
            this.view_teacherTableAdapter1.Fill(this.projectDataSet27.view_teacher);
            // TODO: cette ligne de code charge les données dans la table 'projectDataSet24.Teacher'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
            this.teacherTableAdapter1.Fill(this.projectDataSet24.Teacher);
            this.subjectTableAdapter3.Fill(this.projectDataSet16.Subject);
            // TODO: cette ligne de code charge les données dans la table 'projectDataSet15.Subject'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
            this.subjectTableAdapter2.Fill(this.projectDataSet15.Subject);
            // TODO: cette ligne de code charge les données dans la table 'projectDataSet14.Subject'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
            this.subjectTableAdapter1.Fill(this.projectDataSet14.Subject);
            // TODO: cette ligne de code charge les données dans la table 'projectDataSet13.Teacher'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
            this.teacherTableAdapter.Fill(this.projectDataSet13.Teacher);
            // TODO: cette ligne de code charge les données dans la table 'projectDataSet9.student_class'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
            this.student_classTableAdapter.Fill(this.projectDataSet9.student_class);
            // TODO: cette ligne de code charge les données dans la table 'projectDataSet8.Student'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
            this.studentTableAdapter2.Fill(this.projectDataSet8.Student);
            // TODO: cette ligne de code charge les données dans la table 'projectDataSet2.Student'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
            this.studentTableAdapter.Fill(this.projectDataSet2.Student);
            // TODO: cette ligne de code charge les données dans la table 'projectDataSet1.Class'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
            this.classTableAdapter.Fill(this.projectDataSet1.Class);

            student.printNumberOfItems(numberOfStudents, studentText, "Elève");
            classe.printNumberOfItems(numberOfClassrooms, classText, "Classe");
            teacher.printNumberOfItems(numberOfTeachers, teacherText, "Professeur");
            subject.printNumberOfItems(numberOfSubjects, subjectText, "Matière");
            auth.printNumberOfItems(numberOfAdmin, adminText, "Administrateur", "Administrateur");
            auth.printNumberOfItems(numberOfUsers, usersText, "Utilisateur", "Utilisateur");

            studentPanel.Height = studentButton.Bottom;
            examMngPanel.Height = marksMng.Bottom;
            examMngPanel.Top = studentPanel.Bottom;
            teacherButton.Top = examMngPanel.Bottom;
            paymentButton.Top = teacherButton.Bottom;
            usersMngButton.Top = paymentButton.Bottom;
            studentContentPanel.Visible = false;


            classMarks.SelectedItem = null;
            classMarks.SelectedText = "---Sélectionner une classe---";
            studentFilter.SelectedIndex = 0;
            studentSex.SelectedIndex = 0;
            studentToEditSex.SelectedIndex = 0;
            nameToSearchBy.SelectedIndex = 0;


        }
        public void countNumberOfItems(DataGridView grid, string column)
        {
            foreach (DataGridViewRow dr in grid.Rows)
            {
                dr.Cells[column].Value = dr.Index + 1;
            }
        }

        public void emptyFields(string firstname, string lastname, string birthday, string sex)
        {

        }

        private void classButton_Click(object sender, EventArgs e)
        {
            studentContentPanel.AutoScroll = false;
            marksContentPanel.Visible = false;
            studentContentPanel.Visible = true;
            addStudentContentPanel.Visible = true;
            studentEditContentPanel.Visible = true;
            classContentPanel.Visible = true;
            printMarksContentPanel.Visible = false;
            teacherConentPanel.Visible = false;
        }

        private void dashboardButton_Click(object sender, EventArgs e)
        {
            studentContentPanel.AutoScroll = false;
            studentContentPanel.Visible = false;
            dashboardContentPanel.Visible = true;

        }

        private void studentButton_Click(object sender, EventArgs e)
        {
            if (studentButtonState == false)
            {
                studentPanel.Height = 110;
                studentButtonState = !studentButtonState;
            }
            else
            {
                studentPanel.Height = studentButton.Bottom;
                studentButtonState = !studentButtonState;
            }

            studentPanel.Top = classButton.Bottom;
            examMngPanel.Top = studentPanel.Bottom;
            teacherButton.Top = examMngPanel.Bottom;
            paymentButton.Top = teacherButton.Bottom;
            usersMngButton.Top = paymentButton.Bottom;
            //classContentPanel.Visible = true;
            ////studentContentPanel.Visible = true;
            //int class_id = student.getClassID();
            //string className = student.findClass(class_id);

        }

        private void deleteStudentButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = studentGrid.Rows[currentStudentRow];
                int id = int.Parse(selectedRow.Cells["student_ref"].Value.ToString());
                DialogResult deleteConfirmation = MessageBox.Show("Voulez-vous vraiment supprimer cet élève ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (deleteConfirmation == DialogResult.Yes)
                {

                    if (studentFilter.SelectedItem.ToString() != "Tous les élèves")
                    {
                        className = studentFilter.SelectedItem.ToString();
                        student.delete("Student_id", id).selectByClassname(studentGrid, className, "student_class");
                        MessageBox.Show("Suppression effectuée.", "Confirmation de suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        student.delete("Student_id", id).select(studentGrid, "student_class");
                        MessageBox.Show("Supression effectuée.", "Confirmation de suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void listOfStudents_Click(object sender, EventArgs e)
        {
            studentContentPanel.AutoScroll = true;
            countNumberOfItems(studentGrid, "number");
            addStudentContentPanel.Visible = false;
            studentContentPanel.Visible = true;
            printMarksContentPanel.Visible = false;
            teacherConentPanel.Visible = false;


        }

        private void addStudentButton_Click(object sender, EventArgs e)
        {
            studentContentPanel.AutoScroll = false;
            studentEditContentPanel.Visible = false;
            addStudentContentPanel.Visible = true;

        }

        private void editStudent_Click(object sender, EventArgs e)
        {
    

            try
            {
                DataGridViewRow selectedRow = studentGrid.Rows[currentStudentRow];
                studentToEditLastname.Text = selectedRow.Cells["student_lastname"].Value.ToString();
                studentToEditFirstname.Text = selectedRow.Cells["student_firstname"].Value.ToString();
                studentToEditBirthday.Text = selectedRow.Cells["student_birthday"].Value.ToString();
                studentToEditSex.SelectedIndex = studentToEditSex.FindStringExact(selectedRow.Cells["student_sex"].Value.ToString());
                studentToEditClass.SelectedIndex = studentToEditClass.FindStringExact(selectedRow.Cells["class_name"].Value.ToString());

                studentContentPanel.AutoScroll = false;
                classContentPanel.Visible = false;
                studentContentPanel.Visible = true;
                addStudentContentPanel.Visible = true;
                studentEditContentPanel.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void studentGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var heigth = 40;
            foreach (DataGridViewRow dr in studentGrid.Rows)
            {
                heigth += dr.Height;
            }
            studentGrid.Height = heigth;
        }

        private void add_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (studentFirstname.Text == "" || studentLastname.Text == "" || studentBirthday.Text == "" || studentToEditSex.SelectedIndex == -1 || studentClass.SelectedIndex == -1)
                {
                    MessageBox.Show("Veuillez remplir tous les champs.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    string[] columns = { "student_firstname", "student_lastname", "student_birthday", "student_sex", "class_id" };
                    dynamic[] values = { studentFirstname.Text, studentLastname.Text, studentBirthday.Text, studentToEditSex.SelectedItem.ToString(), studentClass.SelectedIndex + 1 };

                    student.insert(columns, values).select(studentGrid, "student_class");
                    MessageBox.Show("Ajout effectué.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    student.printNumberOfItems(numberOfStudents, studentText, "Elève");

                    studentFirstname.Text = "";
                    studentLastname.Text = "";
                    studentBirthday.Text = "";
                    studentToEditSex.SelectedIndex = 0;
                    studentClass.SelectedIndex = 0;
                }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void edit_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (studentToEditFirstname.Text == "" || studentToEditLastname.Text == "" || studentToEditBirthday.Text == "" || studentToEditSex.SelectedIndex == -1 || studentToEditClass.SelectedIndex == -1)
                {
                    MessageBox.Show("Veuillez remplir tous les champs.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DataGridViewRow selectedRow = studentGrid.Rows[currentStudentRow];
                    int student_id = int.Parse(selectedRow.Cells["student_ref"].Value.ToString());
                    string[] columns = { "student_firstname", "student_lastname", "student_birthday", "student_sex", "class_id" };
                    dynamic[] values = { studentToEditFirstname.Text, studentToEditLastname.Text, studentToEditBirthday.Text, studentToEditSex.SelectedItem.ToString(), studentToEditClass.SelectedIndex + 1 };
                    DialogResult deleteConfirmation = MessageBox.Show("Voulez-vous vraiment modifier les informations de cet élève ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (deleteConfirmation == DialogResult.Yes)
                    {
                        student.update(columns, values, "student_id", student_id).select(studentGrid, "student_class");
                        MessageBox.Show("Modification effectuée.", "Confirmation de modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    studentFirstname.Text = "";
                    studentLastname.Text = "";
                    studentBirthday.Text = "";
                    studentToEditSex.SelectedIndex = 0;
                    studentClass.SelectedIndex = 0;
                }
          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void studentGrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {           
            if (studentGrid.Columns[e.ColumnIndex].Name == "option")
            {
                DataGridViewCell currentCell = studentGrid.CurrentCell;
                ContextMenuStrip cms = currentCell.ContextMenuStrip;
                Rectangle r = currentCell.DataGridView.GetCellDisplayRectangle(currentCell.ColumnIndex, currentCell.RowIndex, false);
                Point p = new Point(r.X + r.Width, r.Y + r.Height);
                Action.Show(currentCell.DataGridView, p);

                currentStudentRow = currentCell.RowIndex;
            }
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.student_classTableAdapter.FillBy(this.projectDataSet9.student_class);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void studentFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (studentFilter.SelectedItem.ToString() != "Tous les élèves")
                {
                    className = studentFilter.SelectedItem.ToString();
                    student.selectByClassname(studentGrid, className, "student_class");
                }
                else
                {
                    student.select(studentGrid, "student_class");
                }

                countNumberOfItems(studentGrid, "number");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void studentGrid_SizeChanged(object sender, EventArgs e)
        {
            countNumberOfItems(studentGrid, "number");
        }

        private void printStudentList_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap studentList = new Bitmap(studentGrid.Width - 240, studentGrid.Height);
            studentGrid.DrawToBitmap(studentList, new Rectangle(0, 0, studentGrid.Width - 240, studentGrid.Height));
            e.Graphics.DrawImage(studentList, 25, 100);
        }

        private void validate_Click(object sender, EventArgs e)
        {
                printStudentPreviewDialog.Document = printStudentList;
                printStudentPreviewDialog.PrintPreviewControl.Zoom = 1;
                printStudentPreviewDialog.ShowDialog();
        }

        private void marks_Click(object sender, EventArgs e)
        {
            studentContentPanel.AutoScroll = false;
            classContentPanel.Visible = true;
            studentContentPanel.Visible = true;
            addStudentContentPanel.Visible = true;
            studentEditContentPanel.Visible = true;
            marksContentPanel.Visible = true;
            printMarksContentPanel.Visible = false;
            teacherConentPanel.Visible = false;



            studentMngClassname.SelectedIndex = 0;
            marksGrid.Visible = false;
            validateAll.Visible = false;
            editMarks.Visible = false;
            classnameMng.Visible = false;

        }

        private void validateSearch_Click(object sender, EventArgs e)
        {
            try
            {

                marksRegisLabel.Text = $"Enregistrement des notes : {marksClassname}";

                if (studentMngClassname.SelectedIndex < 0)
                {
                    MessageBox.Show("Veuillez choisir une matière.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    student.selectByClassname(marksGrid, marksClassname, "student_class");
                    countNumberOfItems(marksGrid, "marks_number");
                    marksGrid.Visible = true;
                    validateAll.Visible = true;
                    editMarks.Visible = true;
                    classnameMng.Text = $"Classe : {marksClassname}";
                    classnameMng.Visible = true;
                    validateAll.Top = marksGrid.Bottom;
                    editMarks.Top = marksGrid.Bottom;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void studentMngClassname_SelectedIndexChanged(object sender, EventArgs e)
        {
            marksClassname = studentMngClassname.SelectedItem.ToString();
        }

        private void marksGrid_SizeChanged(object sender, EventArgs e)
        {
        }

        private void marksGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var heigth = 40;
            foreach (DataGridViewRow dr in marksGrid.Rows)
            {
                heigth += dr.Height;
            }
            marksGrid.Height = heigth;
        }

        private void validateAll_Click(object sender, EventArgs e)
        {
            bool checkFields = true;


            foreach (DataGridViewRow dr in marksGrid.Rows)
            {
                if (dr.Cells["mark"].Value == null)
                {
                    MessageBox.Show("Veuillez saisir toutes les notes.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    checkFields = false;
                    break;
                }
                else if (student_mark_subject.SelectedIndex  < 0)
                {
                    MessageBox.Show("Veuillez choisir une matière.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    checkFields = false;
                    break;

                }
                else if (int.Parse(dr.Cells["mark"].Value.ToString()) < 0 || float.Parse(dr.Cells["mark"].Value.ToString()) > 20)
                {
                    MessageBox.Show("Toutes les notes doivent être comprises entre 0 et 20", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    checkFields = false;
                    break;
                }
                   
            }
            if (checkFields)
            {
                bool exceptionState = false;
                try
                {
                    foreach (DataGridViewRow dr in marksGrid.Rows)
                    {
                        int id = int.Parse(dr.Cells["student_mark_ref"].Value.ToString());
                        string[] columns = { "student_id", "subject_id", "mark" };
                        dynamic[] values = { int.Parse(dr.Cells["student_mark_ref"].Value.ToString()), student_mark_subject.SelectedIndex + 1, dr.Cells["mark"].Value.ToString() };
                        student_subject.insert(columns, values);
                    }
                    if (!exceptionState)
                    {
                        MessageBox.Show("Ajout effectuée.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Veuillez vous assurer que l'un des élèves ne possèdent pas déjà d'une note dans cette matière");
                    exceptionState = true;

                }
            }
          
        }

        private void studentGrid_Sorted(object sender, EventArgs e)
        {
            countNumberOfItems(studentGrid, "number");
        }

        private void marksGrid_Sorted(object sender, EventArgs e)
        {
            countNumberOfItems(marksGrid, "marks_number");
        }

        private void printMarks_Click(object sender, EventArgs e)
        {
            studentContentPanel.AutoScroll = false;
            bulletinPanel.Visible = false;
            printMarksContentPanel.Visible = true;
            marksContentPanel.Visible = true;
            studentContentPanel.Visible = true;
            addStudentContentPanel.Visible = true;
            studentEditContentPanel.Visible = true;
            classContentPanel.Visible = true;
            printMarksContentPanel.Visible = true;
            teacherConentPanel.Visible = false;


            classMarksGrid.Visible = false;
            classnameMngMarks.Visible = false;

            if (classMarks.SelectedItem != null)
            {
                classMarksGrid.Visible = true;
            }
        }
        private void teacherOnDashboard_Paint(object sender, PaintEventArgs e)
        {

            countNumberOfItems(teacherGrid, "teacher_number");
            studentContentPanel.AutoScroll = true;
            addStudentContentPanel.Visible = false;
            studentContentPanel.Visible = true;
            printMarksContentPanel.Visible = false;
        }

   

        private void studentOnDashboard_Click(object sender, EventArgs e)
        {

            countNumberOfItems(studentGrid, "number");
            studentContentPanel.AutoScroll = true;
            addStudentContentPanel.Visible = false;
            studentContentPanel.Visible = true;
            printMarksContentPanel.Visible = false;
        }

        private void classOnDashboard_Click(object sender, EventArgs e)
        {
            studentContentPanel.AutoScroll = false;
            marksContentPanel.Visible = false;
            studentContentPanel.Visible = true;
            addStudentContentPanel.Visible = true;
            studentEditContentPanel.Visible = true;
            classContentPanel.Visible = true;
            printMarksContentPanel.Visible = false;
        }

        private void registration_Click(object sender, EventArgs e)
        {
            studentContentPanel.AutoScroll = false;
            marksContentPanel.Visible = false;
            studentContentPanel.Visible = true;
            addStudentContentPanel.Visible = true;
            studentEditContentPanel.Visible = false;
            classContentPanel.Visible = true;
            printMarksContentPanel.Visible = false;
            teacherConentPanel.Visible = false;
        }

        private void marksMng_Click(object sender, EventArgs e)
        {
            if (examButtonState == false)
            {
                examMngPanel.Height = 110;
                examButtonState = !examButtonState;
            }
            else
            {
                examMngPanel.Height = marksMng.Bottom;
                examButtonState = !examButtonState;
            }

            examMngPanel.Top = studentPanel.Bottom;
            teacherButton.Top = examMngPanel.Bottom;
            paymentButton.Top = teacherButton.Bottom;
            usersMngButton.Top = paymentButton.Bottom;

        }

        private void classMarks_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                showMarksClassname = classMarks.SelectedItem.ToString();
                if (classMarks.SelectedIndex < 0)
                {
                    MessageBox.Show("Veuillez choisir une matière.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    student.selectByClassname(classMarksGrid, showMarksClassname, "student_class");
                    countNumberOfItems(classMarksGrid, "show_marks_number");
                    classMarksGrid.Visible = true;
                    printMarksContentPanel.Visible = true;
                    classnameMngMarks.Text = $"Classe : {showMarksClassname}";
                    classnameMngMarks.Visible = true;
                }
                if (classMarks.SelectedIndex < 0)
                {
                    MessageBox.Show("Veuillez choisir une matière.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    student.selectByClassname(classMarksGrid, showMarksClassname, "student_class");
                    countNumberOfItems(classMarksGrid, "show_marks_number");
                    classMarksGrid.Visible = true;
                    printMarksContentPanel.Visible = true;
                    classnameMngMarks.Text = $"Classe : {showMarksClassname}";
                    classnameMngMarks.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void validateShowMarks_Click(object sender, EventArgs e)
        {

        }

        private void classMarksGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var heigth = 40;
            foreach (DataGridViewRow dr in classMarksGrid.Rows)
            {
                heigth += dr.Height;
            }
            classMarksGrid.Height = heigth;
        }

        private void classMarksGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (classMarksGrid.Columns[e.ColumnIndex].Name == "show_marks_button")
            {
                bulletinPanel.Visible = true;
                student.showMarksOfOneStudent(marksOfOneStudent, classMarksGrid.Rows[e.RowIndex].Cells["student_ref_for_the_mark"].Value.ToString());
                studentNameOnBulletin.Text = classMarksGrid.Rows[e.RowIndex].Cells["studentLastnameOnMarksGrid"].Value.ToString();
                studentFirstnameOnBulletin.Text = classMarksGrid.Rows[e.RowIndex].Cells["studentFirstnameOnMarksGrid"].Value.ToString();
                studentID.Text = classMarksGrid.Rows[e.RowIndex].Cells["student_ref_for_the_mark"].Value.ToString();
                classnameOnBulletin.Text = showMarksClassname;
                numberOfStudentsOnBulletin.Text = classMarksGrid.RowCount.ToString();
            }
        }
        

        private void bulletinPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void marksOfOneStudent_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var heigth = 40;
            float sumOfNotes = 0, sumOfCoeff = 0, mean = 0;

            foreach (DataGridViewRow dr in marksOfOneStudent.Rows)
            {
                sumOfCoeff += float.Parse(dr.Cells[2].Value.ToString());
                sumOfNotes += float.Parse(dr.Cells[3].Value.ToString());
                heigth += dr.Height;
            }
            marksOfOneStudent.Height = heigth;
            mean = sumOfNotes / sumOfCoeff;
            average.Text = mean.ToString();
        }

        public void PrintPage(object sender, PrintPageEventArgs e)
        {
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            Bitmap bmp = new Bitmap(marksOfOneStudent.Width, marksOfOneStudent.Height);
            marksOfOneStudent.DrawToBitmap(bmp, new Rectangle(0, 0, marksOfOneStudent.Width, marksOfOneStudent.Height));
            e.Graphics.DrawImage((Image)bmp, x, y);
        }

    
        private void bulletinDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bulletin = new Bitmap(bulletinPanel.Width, bulletinPanel.Height);
            bulletinPanel.DrawToBitmap(bulletin, new Rectangle(0, 0, bulletinPanel.Width, bulletinPanel.Height));
            e.Graphics.DrawImage(bulletin, e.PageBounds);
        }

        private void printBulletinButton_Click(object sender, EventArgs e)
        {
            printBulletinButton.Visible = false;
            bulletinDialog.Document = bulletinDoc;
            bulletinDialog.PrintPreviewControl.Zoom = 1;
            bulletinDialog.ShowDialog();
            Thread.Sleep(2000);
            printBulletinButton.Visible = true;
        }

  
        private void teacherButton_Click(object sender, EventArgs e)
        {
            teacherConentPanel.AutoScroll = true;
            studentContentPanel.AutoScroll = false;
            classContentPanel.Visible = true;
            studentContentPanel.Visible = true;
            addStudentContentPanel.Visible = true;
            studentEditContentPanel.Visible = true;
            marksContentPanel.Visible = true;
            printMarksContentPanel.Visible = true;
            bulletinPanel.Visible = true;
            addTeacherContentPanel.Visible = false;
            editTeacherContentPanel.Visible = false;
            teacherConentPanel.Visible = true;


            var heigth = 40;
            foreach (DataGridViewRow dr in teacherGrid.Rows)
            {
                heigth += dr.Height;
            }
            teacherGrid.Height = heigth;


            countNumberOfItems(teacherGrid, "teacher_number");
        }

        private void searchStudentMarks_TextChanged_1(object sender, EventArgs e)
        {
           
            try
            {
                int index = int.Parse(nameToSearchBy.SelectedIndex.ToString());
                switch (index)
                {
                    case 0:
                        student.search(studentGrid, "student_class", "student_id", searchStudentMarks.Text);
                        break;
                    case 1:
                        student.search(studentGrid, "student_class", "student_firstname", searchStudentMarks.Text);
                        break;
                    case 2:
                        student.search(studentGrid, "student_class", "student_lastname", searchStudentMarks.Text);
                        break;
                    case 3:
                        student.search(studentGrid, "student_class", "class_name", searchStudentMarks.Text);
                        break;
                    default:
                        student.search(classMarksGrid, "student_class", "student_id", searchStudentMarks.Text);
                        break;
                }
                countNumberOfItems(studentGrid, "number");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void nameToSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (studentFilter.SelectedItem.ToString() != "Tous les élèves")
                {
                    string className = studentFilter.SelectedItem.ToString();
                    student.selectByClassname(studentGrid, className, "student_class");
                }
                else
                {
                    student.select(studentGrid, "student_class");
                }

                countNumberOfItems(studentGrid, "number");

                try
                {
                    int index = int.Parse(nameToSearchBy.SelectedIndex.ToString());
                    switch (index)
                    {
                        case 0:
                            student.search(studentGrid, "student_class", "student_id", searchStudentMarks.Text);
                            break;
                        case 1:
                            student.search(studentGrid, "student_class", "student_firstname", searchStudentMarks.Text);
                            break;
                        case 2:
                            student.search(studentGrid, "student_class", "student_lastname", searchStudentMarks.Text);
                            break;
                        case 3:
                            student.search(studentGrid, "student_class", "class_name", searchStudentMarks.Text);
                            break;
                        default:
                            student.search(classMarksGrid, "student_class", "student_id", searchStudentMarks.Text);
                            break;
                    }
                    countNumberOfItems(studentGrid, "number");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void addTeacher_Click(object sender, EventArgs e)
        {
            try
            {
          
                if (teacherFirstname.Text == "" || teacherLastname.Text == "" || teacherAdress.Text == "" || teacherPhone.Text == "")
                {
                    MessageBox.Show("Veuillez remplir tous les champs.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string[] columns = { "teacher_firstname", "teacher_lastname", "teacher_adress", "teacher_number_phone" };
                    dynamic[] values = { teacherFirstname.Text, teacherLastname.Text, teacherAdress.Text, teacherPhone.Text };
                    teacher.insert(columns, values).select(teacherGrid, "view_teacher");
                    MessageBox.Show("Ajout effectué.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    teacher.printNumberOfItems(numberOfTeachers, teacherText, "Professeur");

                    teacherFirstname.Text = "";
                    teacherLastname.Text = "";
                    teacherAdress.Text = "";
                    teacherPhone.Text = "";

                    Thread.Sleep(2000);

                    string[] c = { "teacher_id", "class_id", "subject_id" };
                    dynamic[] v = { teacher.getTeacherID(), classTeacherID.SelectedIndex + 1, subjectTeacherID.SelectedIndex + 1 };
                    teacher_class_subject.insert(c, v);
                }
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
       

        }

        private void addTeacherOnPanel_Click(object sender, EventArgs e)
        {
            addTeacherContentPanel.Visible = true;
        }

        private void teacherGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var heigth = 40;
            foreach (DataGridViewRow dr in teacherGrid.Rows)
            {
                heigth += dr.Height;
            }
            teacherGrid.Height = heigth;
        }

        private void teacherGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (teacherGrid.Columns[e.ColumnIndex].Name == "teacherOption")
            {
                DataGridViewCell currentCell = teacherGrid.CurrentCell;
                ContextMenuStrip cms = currentCell.ContextMenuStrip;
                Rectangle r = currentCell.DataGridView.GetCellDisplayRectangle(currentCell.ColumnIndex, currentCell.RowIndex, false);
                Point p = new Point(r.X + r.Width, r.Y + r.Height);
                teacherAction.Show(currentCell.DataGridView, p);

                currentTeacherRow = currentCell.RowIndex;
            }
        }

        private void editTeacher_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = teacherGrid.Rows[currentTeacherRow];
            teacherToEditLastname.Text = selectedRow.Cells["teacher_lastname"].Value.ToString();
            teacherToEditFirstname.Text = selectedRow.Cells["teacher_firstname"].Value.ToString();
            teacherToEditAddress.Text = selectedRow.Cells["teacher_address"].Value.ToString();
            teacherToEditPhone.Text = selectedRow.Cells["teacher_phone"].Value.ToString();
            teacherToEditClass.SelectedIndex = teacherToEditClass.FindStringExact(selectedRow.Cells["teacher_class"].Value.ToString());
            teacherToEditSubject.SelectedIndex = teacherToEditSubject.FindStringExact(selectedRow.Cells["teacher_subject"].Value.ToString());

            studentContentPanel.AutoScroll = false;
            teacherConentPanel.AutoScroll = false;
            classContentPanel.Visible = true;
            studentContentPanel.Visible = true;
            addStudentContentPanel.Visible = true;
            studentEditContentPanel.Visible = true;
            marksContentPanel.Visible = true;
            printMarksContentPanel.Visible = true;
            bulletinPanel.Visible = true;
            addTeacherContentPanel.Visible = true;
            teacherConentPanel.Visible = true;
            editTeacherContentPanel.Visible = true;
            paymentContentPanel.Visible = false;

        }

        private void editTeacherButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (teacherToEditFirstname.Text == "" || teacherToEditLastname.Text == "" || teacherToEditAddress.Text == "" || teacherToEditPhone.Text == "")
                {
                    MessageBox.Show("Veuillez remplir tous les champs.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DataGridViewRow selectedRow = teacherGrid.Rows[currentTeacherRow];
                    int teacher_id = int.Parse(selectedRow.Cells["teacher_ref"].Value.ToString());
                    string[] columns = { "teacher_firstname", "teacher_lastname", "teacher_address", "teacher_number_phone" };
                    dynamic[] values = { teacherToEditFirstname.Text, teacherToEditLastname.Text, teacherToEditAddress.Text, teacherToEditPhone.Text };
                    DialogResult deleteConfirmation = MessageBox.Show("Voulez-vous vraiment modifier les informations de ce professeur ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (deleteConfirmation == DialogResult.Yes)
                    {
                        teacher.update(columns, values, "teacher_id", teacher_id).select(teacherGrid, "view_teacher");
                        MessageBox.Show("Modification effectuée.", "Confirmation de modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    teacherToEditFirstname.Text = "";
                    teacherToEditLastname.Text = "";
                    teacherToEditAddress.Text = "";
                    teacherToEditPhone.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        

        private void deleteTeacherButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = teacherGrid.Rows[currentTeacherRow];
                int id = int.Parse(selectedRow.Cells["teacher_ref"].Value.ToString());
                DialogResult deleteConfirmation = MessageBox.Show("Voulez-vous vraiment supprimer ce professeur ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (deleteConfirmation == DialogResult.Yes)
                {
                    teacher.delete("teacher_id", id).select(teacherGrid, "view_teacher");
                    MessageBox.Show("Suppression effectuée.", "Confirmation de suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void teacherGrid_DataBindingComplete_1(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            var heigth = 40;
            foreach (DataGridViewRow dr in teacherGrid.Rows)
            {
                heigth += dr.Height;
            }
            teacherGrid.Height = heigth;
        }

        private void teacherGrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (teacherGrid.Columns[e.ColumnIndex].Name == "teacherOption")
            {
                DataGridViewCell currentCell = teacherGrid.CurrentCell;
                ContextMenuStrip cms = currentCell.ContextMenuStrip;
                Rectangle r = currentCell.DataGridView.GetCellDisplayRectangle(currentCell.ColumnIndex, currentCell.RowIndex, false);
                Point p = new Point(r.X + r.Width, r.Y + r.Height);
                teacherAction.Show(currentCell.DataGridView, p);

                currentTeacherRow = currentCell.RowIndex;
            }
        }

        private void teacherGrid_SizeChanged(object sender, EventArgs e)
        {

            countNumberOfItems(teacherGrid, "teacher_number");
        }

        private void teacherOnDashboard_Click(object sender, EventArgs e)
        {
            studentContentPanel.AutoScroll = false;
            classContentPanel.Visible = true;
            studentContentPanel.Visible = true;
            addStudentContentPanel.Visible = true;
            studentEditContentPanel.Visible = true;
            marksContentPanel.Visible = true;
            printMarksContentPanel.Visible = true;
            bulletinPanel.Visible = true;
            addTeacherContentPanel.Visible = false;
            editTeacherContentPanel.Visible = false;
            teacherConentPanel.Visible = true;


            countNumberOfItems(teacherGrid, "teacher_number");

        }

        private void teacherGrid_Sorted(object sender, EventArgs e)
        {

            countNumberOfItems(teacherGrid, "teacher_number");
        }

        private void paymentButton_Click(object sender, EventArgs e)
        {

            studentContentPanel.AutoScroll = false;
            teacherConentPanel.AutoScroll = false;
            classContentPanel.Visible = true;
            studentContentPanel.Visible = true;
            addStudentContentPanel.Visible = true;
            studentEditContentPanel.Visible = true;
            marksContentPanel.Visible = true;
            printMarksContentPanel.Visible = true;
            bulletinPanel.Visible = true;
            addTeacherContentPanel.Visible = true;
            editTeacherContentPanel.Visible = true;
            teacherConentPanel.Visible = true;
            paymentContentPanel.Visible = true;
            paymentListContentPanel.Visible = false;
            seeReceiptContentPanel.Visible = false;

            DateTime today = DateTime.Today;


            dateOfPayment.Text = today.ToString("dd/MM/yyyy");
            dateOfPayment.Enabled = false;

        }

        private void classPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            int[] student_ids = { };
            studentListPayment.Items.Clear();
            string choosenClass = classPayment.SelectedItem.ToString();
            foreach (DataGridViewRow student in studentGrid.Rows)
            {
                string classP = student.Cells["class_name"].Value.ToString();
                string studentP = student.Cells["student_firstname"].Value.ToString();
                string studentID = student.Cells["student_ref"].Value.ToString();
                if (classP == choosenClass)
                {
                    studentListPayment.Items.Add($"{studentID}-{studentP}");
                }
            }
            
            switch (choosenClass)
            {
                case "7ème année":
                    totalPayment.Text = "100000";
                    break;
                case "8ème année":
                    totalPayment.Text = "125000";
                    break;
                case "9ème année":
                    totalPayment.Text = "150000";
                    break;
                case "10ème année":
                    totalPayment.Text = "175000";
                    break;
                default:
                    totalPayment.Text = "";
                    break;
            }
            totalPayment.Enabled = false;
        }

        private void addPayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (classPayment.SelectedIndex == -1 || studentListPayment.SelectedIndex == -1 ||titleOfPayment.Text == "" || totalPayment.Text == "" || paidAmount.Text == "" || paymentStatus.SelectedIndex == -1 || paymentMethod.SelectedIndex == -1 || dateOfPayment.Text == "" || studentPaymentID == 0)
                {
                    MessageBox.Show("Veuillez remplir tous les champs.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    string[] columns = { "title", "total", "paid", "status", "method", "date_of_payment", "student_id" };
                    dynamic[] values = { titleOfPayment.Text, totalPayment.Text, paidAmount.Text, paymentStatus.SelectedItem.ToString(), paymentMethod.SelectedItem.ToString(), dateOfPayment.Text, studentPaymentID };
                    student_payment.insert(columns, values);
                    MessageBox.Show("Payement effectué.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    paymentListContentPanel.Visible = true;
                    studentPaymentID = 0;
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void studentListPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] items = studentListPayment.Text.Split('-');
            studentPaymentID = int.Parse(items[0]);

        }

        private void printReceipt_Click(object sender, EventArgs e)
        {

            studentContentPanel.AutoScroll = false;
            teacherConentPanel.AutoScroll = false;
            classContentPanel.Visible = true;
            studentContentPanel.Visible = true;
            addStudentContentPanel.Visible = true;
            studentEditContentPanel.Visible = true;
            marksContentPanel.Visible = true;
            printMarksContentPanel.Visible = true;
            bulletinPanel.Visible = true;
            addTeacherContentPanel.Visible = true;
            editTeacherContentPanel.Visible = true;
            teacherConentPanel.Visible = true;
            paymentContentPanel.Visible = true;
            paymentListContentPanel.Visible = true;
        }

        private void addPaymentOnPaymentList_Click(object sender, EventArgs e)
        {
            studentContentPanel.AutoScroll = false;
            teacherConentPanel.AutoScroll = false;
            classContentPanel.Visible = true;
            studentContentPanel.Visible = true;
            addStudentContentPanel.Visible = true;
            studentEditContentPanel.Visible = true;
            marksContentPanel.Visible = true;
            printMarksContentPanel.Visible = true;
            bulletinPanel.Visible = true;
            addTeacherContentPanel.Visible = true;
            editTeacherContentPanel.Visible = true;
            teacherConentPanel.Visible = true;
            paymentContentPanel.Visible = true;
            paymentListContentPanel.Visible = false;
        }

        private void paymentsGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (paymentsGrid.Columns[e.ColumnIndex].Name == "paymentOption")
            {
                DataGridViewCell currentCell = paymentsGrid.CurrentCell;
                ContextMenuStrip cms = currentCell.ContextMenuStrip;
                Rectangle r = currentCell.DataGridView.GetCellDisplayRectangle(currentCell.ColumnIndex, currentCell.RowIndex, false);
                Point p = new Point(r.X + r.Width, r.Y + r.Height);
                paymentAction.Show(currentCell.DataGridView, p);

                currentPaymentRow = currentCell.RowIndex;
            }
        }

        private void voirLeReçuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] membersOfDate;
            seeReceiptContentPanel.Visible = true;
            classmentContentPanel.Visible = false;
            string paymentID = paymentsGrid.Rows[currentPaymentRow].Cells["refOnPayment"].Value.ToString();
            membersOfDate = paymentsGrid.Rows[currentPaymentRow].Cells["dateOnPayment"].Value.ToString().Split(' ');
            dateOnReceipt.Text = membersOfDate[0];
            paymentTitle.Text = paymentsGrid.Rows[currentPaymentRow].Cells["titleOnPayment"].Value.ToString();
            studentWhoPaidName.Text = paymentsGrid.Rows[currentPaymentRow].Cells["studentOnPayment"].Value.ToString();
            classReceipt.Text = paymentsGrid.Rows[currentPaymentRow].Cells["classOnPayment"].Value.ToString();
            amount.Text = paymentsGrid.Rows[currentPaymentRow].Cells["totalOnPayment"].Value.ToString();
            amountPaid.Text = paymentsGrid.Rows[currentPaymentRow].Cells["amountOnPayment"].Value.ToString();

            student_payment.paymentHistory(paymentHistoryGrid, paymentID);

        }

        private void printReceiptButton_Click(object sender, EventArgs e)
        {
            printReceiptButton.Visible = false;
            printPreviewReceiptDialog.Document = printDocumentReceipt;
            printPreviewReceiptDialog.PrintPreviewControl.Zoom = 1;
            printPreviewReceiptDialog.ShowDialog();
            Thread.Sleep(2000);
            printReceiptButton.Visible = true;
        }

        private void printDocumentReceipt_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap receipt = new Bitmap(seeReceiptContentPanel.Width, seeReceiptContentPanel.Height);
            seeReceiptContentPanel.DrawToBitmap(receipt, new Rectangle(0, 0, seeReceiptContentPanel.Width, seeReceiptContentPanel.Height));
            e.Graphics.DrawImage(receipt, e.PageBounds);
        }

        private void showTeacherListOnEdit_Click(object sender, EventArgs e)
        {
            teacherConentPanel.AutoScroll = true;
            studentContentPanel.AutoScroll = false;
            classContentPanel.Visible = true;
            studentContentPanel.Visible = true;
            addStudentContentPanel.Visible = true;
            studentEditContentPanel.Visible = true;
            marksContentPanel.Visible = true;
            printMarksContentPanel.Visible = true;
            bulletinPanel.Visible = true;
            addTeacherContentPanel.Visible = false;
            editTeacherContentPanel.Visible = false;
            teacherConentPanel.Visible = true;
        }

        private void showTeacherListOnAdd_Click(object sender, EventArgs e)
        {
            teacherConentPanel.AutoScroll = true;
            studentContentPanel.AutoScroll = false;
            classContentPanel.Visible = true;
            studentContentPanel.Visible = true;
            addStudentContentPanel.Visible = true;
            studentEditContentPanel.Visible = true;
            marksContentPanel.Visible = true;
            printMarksContentPanel.Visible = true;
            bulletinPanel.Visible = true;
            addTeacherContentPanel.Visible = false;
            editTeacherContentPanel.Visible = false;
            teacherConentPanel.Visible = true;
        }

        private void showStudentsOnEdit_Click(object sender, EventArgs e)
        {
            studentContentPanel.AutoScroll = true;
            countNumberOfItems(studentGrid, "number");
            addStudentContentPanel.Visible = false;
            studentContentPanel.Visible = true;
            printMarksContentPanel.Visible = false;
            teacherConentPanel.Visible = false;
        }

        private void showStudentsOnAdd_Click(object sender, EventArgs e)
        {
            studentContentPanel.AutoScroll = true;
            countNumberOfItems(studentGrid, "number");
            addStudentContentPanel.Visible = false;
            studentContentPanel.Visible = true;
            printMarksContentPanel.Visible = false;
            teacherConentPanel.Visible = false;
        }

        private void editMarks_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow dr in marksGrid.Rows)
                {

                    if (dr.Cells["mark"].Value != null)
                    {
                        int id = int.Parse(dr.Cells["student_mark_ref"].Value.ToString());
                        string[] columns = {  "mark" };
                        dynamic[] values = {  dr.Cells["mark"].Value.ToString() };
                        student_subject.updateMarks(columns, values, "student_id", id, student_mark_subject.SelectedIndex + 1);
                    }
                    
                }
                MessageBox.Show("Mise à jour effectuée.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void classement_Click(object sender, EventArgs e)
        {

            if (classMarks.SelectedIndex  == -1)
            {
                MessageBox.Show("Veuillez choisir une classe.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                studentContentPanel.AutoScroll = false;
                teacherConentPanel.AutoScroll = false;
                classContentPanel.Visible = true;
                studentContentPanel.Visible = true;
                addStudentContentPanel.Visible = true;
                studentEditContentPanel.Visible = true;
                marksContentPanel.Visible = true;
                printMarksContentPanel.Visible = true;
                bulletinPanel.Visible = true;
                addTeacherContentPanel.Visible = true;
                editTeacherContentPanel.Visible = true;
                teacherConentPanel.Visible = true;
                paymentContentPanel.Visible = true;
                paymentListContentPanel.Visible = true;
                seeReceiptContentPanel.Visible = true;
                addUserContentPanel.Visible = false;
                classmentContentPanel.Visible = true;

                rang.DisplayIndex = 0;
                student_subject.showMarksOfAllStudent(classementGrid, classMarks.SelectedIndex + 1);
                rang.Width = 75;
                countNumberOfItems(classementGrid, "rang");
                appreciation.DisplayIndex = 3;

                foreach (DataGridViewColumn column in classementGrid.Columns)
                {
                    if (column.Name == "Moyenne")
                    {
                        column.Width = 200;
                    }
                }
                


                foreach (DataGridViewRow row in classementGrid.Rows)
                {
                    float average = float.Parse(row.Cells["moyenne"].Value.ToString());
                    if (average > 18)
                    {
                        row.Cells["appreciation"].Value = "Excellent";
                    }
                    else if (average > 14)
                    {
                        row.Cells["appreciation"].Value = "Bien";

                    }
                    else if (average > 12)
                    {
                        row.Cells["appreciation"].Value = "Assez bien";
                    }

                }

                switch (classMarks.SelectedIndex + 1)
                {
                    case 1:
                        classInTableOnBulletin.Text = "7ème année";
                        break;
                    case 2:
                        classInTableOnBulletin.Text = "8ème année";
                        break;
                    case 3:
                        classInTableOnBulletin.Text = "9ème année";
                        break;
                    case 4:
                        classInTableOnBulletin.Text = "10ème année";
                        break;
                    default:
                        classInTableOnBulletin.Text = "";
                        break;
                }

            }
        }

        private void classementGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var heigth = 40;
            foreach (DataGridViewRow dr in classementGrid.Rows)
            {
                heigth += dr.Height;
            }
            classementGrid.Height = heigth;
        }

        private void marksGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (marksGrid.Columns[e.ColumnIndex].Name == "actionOnMarksGrid")
            {
                DataGridViewCell currentCell = marksGrid.CurrentCell;
                ContextMenuStrip cms = currentCell.ContextMenuStrip;
                Rectangle r = currentCell.DataGridView.GetCellDisplayRectangle(currentCell.ColumnIndex, currentCell.RowIndex, false);
                Point p = new Point(r.X + r.Width, r.Y + r.Height);
                marksAction.Show(currentCell.DataGridView, p);

                currentMarksRow = currentCell.RowIndex;
            }
        }

        private void addOnMarksGrid_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dr = marksGrid.Rows[currentMarksRow];
                if (dr.Cells["mark"].Value != null)
                {
                    try
                    {
                        int id = int.Parse(dr.Cells["student_mark_ref"].Value.ToString());
                        string[] columns = { "student_id", "subject_id", "mark" };
                        dynamic[] values = { int.Parse(dr.Cells["student_mark_ref"].Value.ToString()), student_mark_subject.SelectedIndex + 1, dr.Cells["mark"].Value.ToString() };
                        int markInDB = student_subject.getStudentMark(dr.Cells["student_mark_ref"].Value.ToString());
                        if (markInDB > 0)
                        {
                            MessageBox.Show("Cet élève a déjà une note dans cette matière. Veuillez choisir l'option de modification.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            student_subject.insert(columns, values);
                            MessageBox.Show("Ajout effectué.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez saisir une  note.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void editOnMarksGrid_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dg = marksGrid.Rows[currentMarksRow];
                if (dg.Cells["mark"].Value != null)
                {
                    int id = int.Parse(dg.Cells["student_mark_ref"].Value.ToString());
                    string[] columns = { "mark" };
                    dynamic[] values = { dg.Cells["mark"].Value.ToString() };
                    student_subject.updateMarks(columns, values, "student_id", id, student_mark_subject.SelectedIndex + 1);
                }
                MessageBox.Show("Mise à jour effectuée.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void logout_Click(object sender, EventArgs e)
        {
            loginForm.Show();
            Thread.Sleep(200);
            Hide();
        }

        private void createNewUserButton_Click(object sender, EventArgs e)
        {
            studentContentPanel.AutoScroll = false;
            teacherConentPanel.AutoScroll = false;
            classContentPanel.Visible = true;
            studentContentPanel.Visible = true;
            addStudentContentPanel.Visible = true;
            studentEditContentPanel.Visible = true;
            marksContentPanel.Visible = true;
            printMarksContentPanel.Visible = true;
            bulletinPanel.Visible = true;
            addTeacherContentPanel.Visible = true;
            editTeacherContentPanel.Visible = true;
            teacherConentPanel.Visible = true;
            paymentContentPanel.Visible = true;
            paymentListContentPanel.Visible = true;
            seeReceiptContentPanel.Visible = true;
            classmentContentPanel.Visible = true;
            usersListContentPanel.Visible = false;
            editUserContentPanel.Visible = false;
            addUserContentPanel.Visible = true;
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
                if (usernameField.Text == "" || passwordField.Text == "" || statusField.SelectedIndex == -1)
                {
                    MessageBox.Show("Veuillez remplir tous les champs.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    string[] columns = { "username", "password", "status" };
                    dynamic[] values = { usernameField.Text, passwordField.Text, statusField.SelectedItem.ToString() };

                    auth.insert(columns, values).select(usersGrid, "Authentification");
                    MessageBox.Show("Ajout effectué.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    usernameField.Text = "";
                    passwordField.Text = "";
                    statusField.SelectedIndex = -1;

                    auth.printNumberOfItems(numberOfAdmin, adminText, "Administrateur", "Administrateur");
                    auth.printNumberOfItems(numberOfUsers, usersText, "Utilisateur", "Utilisateur");
                }

       
        }

        public void makeVisibleUsersPanel()
        {
            studentContentPanel.AutoScroll = false;
            teacherConentPanel.AutoScroll = false;
            classContentPanel.Visible = true;
            studentContentPanel.Visible = true;
            addStudentContentPanel.Visible = true;
            studentEditContentPanel.Visible = true;
            marksContentPanel.Visible = true;
            printMarksContentPanel.Visible = true;
            bulletinPanel.Visible = true;
            addTeacherContentPanel.Visible = true;
            editTeacherContentPanel.Visible = true;
            teacherConentPanel.Visible = true;
            paymentContentPanel.Visible = true;
            paymentListContentPanel.Visible = true;
            seeReceiptContentPanel.Visible = true;
            classmentContentPanel.Visible = true;
            addUserContentPanel.Visible = true;
            editUserContentPanel.Visible = false;
            usersListContentPanel.Visible = true;
            countNumberOfItems(usersGrid, "users_number");

        }

        private void usersOnDashboard_Click(object sender, EventArgs e)
        {
            makeVisibleUsersPanel();
        }

        private void adminOnDashboard_Click(object sender, EventArgs e)
        {
            makeVisibleUsersPanel();
        }

        private void usersGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var heigth = 40;
            foreach (DataGridViewRow dr in usersGrid.Rows)
            {
                heigth += dr.Height;
            }
            usersGrid.Height = heigth;
            countNumberOfItems(usersGrid, "users_number");
        }

        private void usersMngButton_Click(object sender, EventArgs e)
        {
            makeVisibleUsersPanel();
        }

        private void usersGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (usersGrid.Columns[e.ColumnIndex].Name == "optionUsers")
            {
                DataGridViewCell currentCell = usersGrid.CurrentCell;
                ContextMenuStrip cms = currentCell.ContextMenuStrip;
                Rectangle r = currentCell.DataGridView.GetCellDisplayRectangle(currentCell.ColumnIndex, currentCell.RowIndex, false);
                Point p = new Point(r.X + r.Width, r.Y + r.Height);
                usersAction.Show(currentCell.DataGridView, p);

                currentUserRow = currentCell.RowIndex;
            }
        }

        private void editUser_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = usersGrid.Rows[currentUserRow];
            userToEditName.Text = selectedRow.Cells["usernameOnUsersGrid"].Value.ToString();
            userToEditPassword.Text = selectedRow.Cells["password"].Value.ToString();
            userToEditStatus.SelectedIndex = userToEditStatus.FindStringExact(selectedRow.Cells["status"].Value.ToString());

            studentContentPanel.AutoScroll = false;
            teacherConentPanel.AutoScroll = false;
            classContentPanel.Visible = true;
            studentContentPanel.Visible = true;
            addStudentContentPanel.Visible = true;
            studentEditContentPanel.Visible = true;
            marksContentPanel.Visible = true;
            printMarksContentPanel.Visible = true;
            bulletinPanel.Visible = true;
            addTeacherContentPanel.Visible = true;
            editTeacherContentPanel.Visible = true;
            teacherConentPanel.Visible = true;
            paymentContentPanel.Visible = true;
            paymentListContentPanel.Visible = true;
            seeReceiptContentPanel.Visible = true;
            classmentContentPanel.Visible = true;
            addUserContentPanel.Visible = true;
            usersListContentPanel.Visible = true;
            editUserContentPanel.Visible = true;
        }

        private void editUserButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (userToEditName.Text == "" || userToEditPassword.Text == "" || userToEditStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Veuillez remplir tous les champs.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DataGridViewRow selectedRow = usersGrid.Rows[currentUserRow];
                    int user_id = int.Parse(selectedRow.Cells["user_ref"].Value.ToString());
                    string[] columns = { "auth_username", "auth_password", "status" };
                    dynamic[] values = { userToEditName.Text, userToEditPassword.Text, userToEditStatus.SelectedItem };
                    DialogResult confirmation = MessageBox.Show("Voulez-vous vraiment modifier les informations de cet utilisateur?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmation == DialogResult.Yes)
                    {
                        auth.update(columns, values, "auth_id", user_id).select(usersGrid, "Authentification");
                        MessageBox.Show("Modification effectuée.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        editUserContentPanel.Visible = false;
                    }
                    userToEditName.Text = "";
                    userToEditPassword.Text = "";
                    userToEditStatus.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void deleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = usersGrid.Rows[currentUserRow];
                int id = int.Parse(selectedRow.Cells["user_ref"].Value.ToString());
                DialogResult deleteConfirmation = MessageBox.Show("Voulez-vous vraiment supprimer cet utlisateur ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (deleteConfirmation == DialogResult.Yes)
                {
                    if (id == 1)
                    {
                        MessageBox.Show("Veuillez contacter votre administrateur", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                    auth.delete("auth_id", id).select(usersGrid, "Authentification");
                    MessageBox.Show("Suppression effectuée.", "Confirmation de suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);



                        auth.printNumberOfItems(numberOfAdmin, adminText, "Administrateur", "Administrateur");
                    auth.printNumberOfItems(numberOfUsers, usersText, "Utilisateur", "Utilisateur");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void addUserOnListPanel_Click(object sender, EventArgs e)
        {
            studentContentPanel.AutoScroll = false;
            teacherConentPanel.AutoScroll = false;
            classContentPanel.Visible = true;
            studentContentPanel.Visible = true;
            addStudentContentPanel.Visible = true;
            studentEditContentPanel.Visible = true;
            marksContentPanel.Visible = true;
            printMarksContentPanel.Visible = true;
            bulletinPanel.Visible = true;
            addTeacherContentPanel.Visible = true;
            editTeacherContentPanel.Visible = true;
            teacherConentPanel.Visible = true;
            paymentContentPanel.Visible = true;
            paymentListContentPanel.Visible = true;
            seeReceiptContentPanel.Visible = true;
            classmentContentPanel.Visible = true;
            usersListContentPanel.Visible = false;
            editUserContentPanel.Visible = false;
            addUserContentPanel.Visible = true;
        }

        private void seeUsersOnAddPanel_Click(object sender, EventArgs e)
        {
            makeVisibleUsersPanel();
        }

        private void seeListOfUsersOnEditPanel_Click(object sender, EventArgs e)
        {
            makeVisibleUsersPanel();
        }

        private void userToEditPassword_IconRightClick(object sender, EventArgs e)
        {
            if (!userToEditPasswordState)
            {
                userToEditPassword.UseSystemPasswordChar = false;
                userToEditPasswordState = !userToEditPasswordState;
            }
            else
            {
                userToEditPassword.UseSystemPasswordChar = true;
                userToEditPasswordState = !userToEditPasswordState;
            }


        }

        private void passwordField_IconRightClick(object sender, EventArgs e)
        {
            if (passwordFieldState)
            {
                passwordField.UseSystemPasswordChar = false;
                passwordFieldState = !passwordFieldState;
            }
            else
            {
                passwordField.UseSystemPasswordChar = true;
                passwordFieldState = !passwordFieldState;
            }
        }

        private void printClassementList_PrintPage(object sender, PrintPageEventArgs e)
        {

            Bitmap classementList = new Bitmap(classmentContentPanel.Width, classmentContentPanel.Height);
            classmentContentPanel.DrawToBitmap(classementList, new Rectangle(0, 0, classmentContentPanel.Width, classmentContentPanel.Height));
            e.Graphics.DrawImage(classementList, e.PageBounds);
        }

        private void printClassment_Click(object sender, EventArgs e)
        {
            printClassment.Visible = false;
            printStudentPreviewDialog.Document = printClassementList;
            printStudentPreviewDialog.PrintPreviewControl.Zoom = 1;
            printStudentPreviewDialog.ShowDialog();
            printClassment.Visible = true;
        }

        private void paymentsGrid_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (paymentsGrid.Columns[e.ColumnIndex].Name == "paymentOption")
            {
                DataGridViewCell currentCell = paymentsGrid.CurrentCell;
                ContextMenuStrip cms = currentCell.ContextMenuStrip;
                Rectangle r = currentCell.DataGridView.GetCellDisplayRectangle(currentCell.ColumnIndex, currentCell.RowIndex, false);
                Point p = new Point(r.X + r.Width, r.Y + r.Height);
                paymentAction.Show(currentCell.DataGridView, p);

                currentPaymentRow = currentCell.RowIndex;
            }
        }

        private void paymentsGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var heigth = 40;
            foreach (DataGridViewRow dr in paymentsGrid.Rows)
            {
                heigth += dr.Height;
            }
            paymentsGrid.Height = heigth;
        }
    }
}
