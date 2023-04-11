namespace School_Management
{
    partial class AddStudentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.studentGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            this.classe_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.option = new System.Windows.Forms.DataGridViewButtonColumn();
            this.printBulletinButton = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.studentGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // studentGrid
            // 
            this.studentGrid.AllowUserToAddRows = false;
            this.studentGrid.AllowUserToDeleteRows = false;
            this.studentGrid.AllowUserToResizeColumns = false;
            this.studentGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.studentGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.studentGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.studentGrid.BackgroundColor = System.Drawing.Color.White;
            this.studentGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.studentGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.studentGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.studentGrid.ColumnHeadersHeight = 36;
            this.studentGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.classe_name,
            this.option});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.studentGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.studentGrid.EnableHeadersVisualStyles = false;
            this.studentGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(195)))));
            this.studentGrid.Location = new System.Drawing.Point(226, 203);
            this.studentGrid.Name = "studentGrid";
            this.studentGrid.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.studentGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.studentGrid.RowHeadersVisible = false;
            this.studentGrid.RowTemplate.DividerHeight = 1;
            this.studentGrid.RowTemplate.Height = 35;
            this.studentGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.studentGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.studentGrid.Size = new System.Drawing.Size(1293, 306);
            this.studentGrid.TabIndex = 1;
            this.studentGrid.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.studentGrid.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.studentGrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.studentGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.studentGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.studentGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.studentGrid.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.studentGrid.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(196)))), ((int)(((byte)(195)))));
            this.studentGrid.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(224)))));
            this.studentGrid.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.studentGrid.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentGrid.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.studentGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.studentGrid.ThemeStyle.HeaderStyle.Height = 36;
            this.studentGrid.ThemeStyle.ReadOnly = true;
            this.studentGrid.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.studentGrid.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.studentGrid.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentGrid.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.studentGrid.ThemeStyle.RowsStyle.Height = 35;
            this.studentGrid.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.White;
            this.studentGrid.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // classe_name
            // 
            this.classe_name.DataPropertyName = "class_name";
            this.classe_name.FillWeight = 114.9695F;
            this.classe_name.HeaderText = "Classe";
            this.classe_name.Name = "classe_name";
            this.classe_name.ReadOnly = true;
            this.classe_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // option
            // 
            this.option.FillWeight = 93.75846F;
            this.option.HeaderText = "Option";
            this.option.Name = "option";
            this.option.ReadOnly = true;
            this.option.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.option.Text = "Action";
            this.option.UseColumnTextForButtonValue = true;
            // 
            // printBulletinButton
            // 
            this.printBulletinButton.BorderRadius = 2;
            this.printBulletinButton.CheckedState.Parent = this.printBulletinButton;
            this.printBulletinButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.printBulletinButton.CustomImages.Parent = this.printBulletinButton;
            this.printBulletinButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(67)))));
            this.printBulletinButton.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printBulletinButton.ForeColor = System.Drawing.Color.White;
            this.printBulletinButton.HoverState.Parent = this.printBulletinButton;
            this.printBulletinButton.Image = global::School_Management.Properties.Resources.printer;
            this.printBulletinButton.Location = new System.Drawing.Point(848, 120);
            this.printBulletinButton.Name = "printBulletinButton";
            this.printBulletinButton.ShadowDecoration.Parent = this.printBulletinButton;
            this.printBulletinButton.Size = new System.Drawing.Size(238, 45);
            this.printBulletinButton.TabIndex = 8;
            this.printBulletinButton.Text = "Imprimer le bulletin";
            // 
            // AddStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1745, 712);
            this.Controls.Add(this.printBulletinButton);
            this.Controls.Add(this.studentGrid);
            this.Name = "AddStudentForm";
            this.Text = "AddStudentForm";
            this.Load += new System.EventHandler(this.AddStudentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.studentGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView studentGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn classe_name;
        private System.Windows.Forms.DataGridViewButtonColumn option;
        private Guna.UI2.WinForms.Guna2Button printBulletinButton;
    }
}