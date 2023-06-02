namespace SoftwareVVNZ.Forms.Dictionary
{
    partial class TeacherForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.AddPanel = new System.Windows.Forms.Panel();
            this.AddGBox = new System.Windows.Forms.GroupBox();
            this.AddressTBox = new System.Windows.Forms.TextBox();
            this.EmailTBox = new System.Windows.Forms.TextBox();
            this.EmailLbl = new System.Windows.Forms.Label();
            this.AddressLbl = new System.Windows.Forms.Label();
            this.PhoneValiadtionLbl = new System.Windows.Forms.Label();
            this.LastNameTBox = new System.Windows.Forms.TextBox();
            this.LastNameValiadtionLbl = new System.Windows.Forms.Label();
            this.FirstNameValiadtionLbl = new System.Windows.Forms.Label();
            this.LastNameLbl = new System.Windows.Forms.Label();
            this.PhoneTBox = new System.Windows.Forms.TextBox();
            this.FirstNameTBox = new System.Windows.Forms.TextBox();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.PhoneLbl = new System.Windows.Forms.Label();
            this.FirstNameLbl = new System.Windows.Forms.Label();
            this.TeacherGridView = new System.Windows.Forms.DataGridView();
            this.AddPanel.SuspendLayout();
            this.AddGBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TeacherGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // AddPanel
            // 
            this.AddPanel.Controls.Add(this.AddGBox);
            this.AddPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddPanel.Location = new System.Drawing.Point(0, 0);
            this.AddPanel.Name = "AddPanel";
            this.AddPanel.Size = new System.Drawing.Size(381, 598);
            this.AddPanel.TabIndex = 96;
            // 
            // AddGBox
            // 
            this.AddGBox.Controls.Add(this.AddressTBox);
            this.AddGBox.Controls.Add(this.EmailTBox);
            this.AddGBox.Controls.Add(this.EmailLbl);
            this.AddGBox.Controls.Add(this.AddressLbl);
            this.AddGBox.Controls.Add(this.PhoneValiadtionLbl);
            this.AddGBox.Controls.Add(this.LastNameTBox);
            this.AddGBox.Controls.Add(this.LastNameValiadtionLbl);
            this.AddGBox.Controls.Add(this.FirstNameValiadtionLbl);
            this.AddGBox.Controls.Add(this.LastNameLbl);
            this.AddGBox.Controls.Add(this.PhoneTBox);
            this.AddGBox.Controls.Add(this.FirstNameTBox);
            this.AddGBox.Controls.Add(this.ExitBtn);
            this.AddGBox.Controls.Add(this.ClearBtn);
            this.AddGBox.Controls.Add(this.AddBtn);
            this.AddGBox.Controls.Add(this.PhoneLbl);
            this.AddGBox.Controls.Add(this.FirstNameLbl);
            this.AddGBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddGBox.Location = new System.Drawing.Point(12, 12);
            this.AddGBox.Name = "AddGBox";
            this.AddGBox.Size = new System.Drawing.Size(346, 321);
            this.AddGBox.TabIndex = 2;
            this.AddGBox.TabStop = false;
            this.AddGBox.Text = "Додати";
            // 
            // AddressTBox
            // 
            this.AddressTBox.Location = new System.Drawing.Point(100, 139);
            this.AddressTBox.MaxLength = 300;
            this.AddressTBox.Multiline = true;
            this.AddressTBox.Name = "AddressTBox";
            this.AddressTBox.Size = new System.Drawing.Size(240, 89);
            this.AddressTBox.TabIndex = 28;
            // 
            // EmailTBox
            // 
            this.EmailTBox.Location = new System.Drawing.Point(100, 111);
            this.EmailTBox.MaxLength = 200;
            this.EmailTBox.Name = "EmailTBox";
            this.EmailTBox.Size = new System.Drawing.Size(240, 22);
            this.EmailTBox.TabIndex = 27;
            // 
            // EmailLbl
            // 
            this.EmailLbl.AutoSize = true;
            this.EmailLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EmailLbl.Location = new System.Drawing.Point(6, 114);
            this.EmailLbl.Name = "EmailLbl";
            this.EmailLbl.Size = new System.Drawing.Size(49, 16);
            this.EmailLbl.TabIndex = 26;
            this.EmailLbl.Text = "E-mail:";
            // 
            // AddressLbl
            // 
            this.AddressLbl.AutoSize = true;
            this.AddressLbl.Location = new System.Drawing.Point(5, 142);
            this.AddressLbl.Name = "AddressLbl";
            this.AddressLbl.Size = new System.Drawing.Size(59, 16);
            this.AddressLbl.TabIndex = 25;
            this.AddressLbl.Text = "Адреса:";
            // 
            // PhoneValiadtionLbl
            // 
            this.PhoneValiadtionLbl.AutoSize = true;
            this.PhoneValiadtionLbl.ForeColor = System.Drawing.Color.Red;
            this.PhoneValiadtionLbl.Location = new System.Drawing.Point(77, 81);
            this.PhoneValiadtionLbl.Name = "PhoneValiadtionLbl";
            this.PhoneValiadtionLbl.Size = new System.Drawing.Size(13, 16);
            this.PhoneValiadtionLbl.TabIndex = 24;
            this.PhoneValiadtionLbl.Text = "*";
            // 
            // LastNameTBox
            // 
            this.LastNameTBox.Location = new System.Drawing.Point(101, 21);
            this.LastNameTBox.MaxLength = 200;
            this.LastNameTBox.Name = "LastNameTBox";
            this.LastNameTBox.Size = new System.Drawing.Size(240, 22);
            this.LastNameTBox.TabIndex = 1;
            // 
            // LastNameValiadtionLbl
            // 
            this.LastNameValiadtionLbl.AutoSize = true;
            this.LastNameValiadtionLbl.ForeColor = System.Drawing.Color.Red;
            this.LastNameValiadtionLbl.Location = new System.Drawing.Point(78, 24);
            this.LastNameValiadtionLbl.Name = "LastNameValiadtionLbl";
            this.LastNameValiadtionLbl.Size = new System.Drawing.Size(13, 16);
            this.LastNameValiadtionLbl.TabIndex = 22;
            this.LastNameValiadtionLbl.Text = "*";
            // 
            // FirstNameValiadtionLbl
            // 
            this.FirstNameValiadtionLbl.AutoSize = true;
            this.FirstNameValiadtionLbl.ForeColor = System.Drawing.Color.Red;
            this.FirstNameValiadtionLbl.Location = new System.Drawing.Point(78, 56);
            this.FirstNameValiadtionLbl.Name = "FirstNameValiadtionLbl";
            this.FirstNameValiadtionLbl.Size = new System.Drawing.Size(13, 16);
            this.FirstNameValiadtionLbl.TabIndex = 23;
            this.FirstNameValiadtionLbl.Text = "*";
            // 
            // LastNameLbl
            // 
            this.LastNameLbl.AutoSize = true;
            this.LastNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LastNameLbl.Location = new System.Drawing.Point(6, 24);
            this.LastNameLbl.Name = "LastNameLbl";
            this.LastNameLbl.Size = new System.Drawing.Size(73, 16);
            this.LastNameLbl.TabIndex = 1;
            this.LastNameLbl.Text = "Прізвище:";
            // 
            // PhoneTBox
            // 
            this.PhoneTBox.Location = new System.Drawing.Point(101, 78);
            this.PhoneTBox.MaxLength = 15;
            this.PhoneTBox.Name = "PhoneTBox";
            this.PhoneTBox.Size = new System.Drawing.Size(240, 22);
            this.PhoneTBox.TabIndex = 3;
            // 
            // FirstNameTBox
            // 
            this.FirstNameTBox.Location = new System.Drawing.Point(101, 50);
            this.FirstNameTBox.MaxLength = 200;
            this.FirstNameTBox.Name = "FirstNameTBox";
            this.FirstNameTBox.Size = new System.Drawing.Size(240, 22);
            this.FirstNameTBox.TabIndex = 2;
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(259, 289);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(81, 23);
            this.ExitBtn.TabIndex = 6;
            this.ExitBtn.Text = "Вихід";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // ClearBtn
            // 
            this.ClearBtn.Location = new System.Drawing.Point(160, 289);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(81, 23);
            this.ClearBtn.TabIndex = 5;
            this.ClearBtn.Text = "Очистити";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(58, 289);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(81, 23);
            this.AddBtn.TabIndex = 4;
            this.AddBtn.Text = "Додати";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // PhoneLbl
            // 
            this.PhoneLbl.AutoSize = true;
            this.PhoneLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PhoneLbl.Location = new System.Drawing.Point(6, 84);
            this.PhoneLbl.Name = "PhoneLbl";
            this.PhoneLbl.Size = new System.Drawing.Size(54, 16);
            this.PhoneLbl.TabIndex = 3;
            this.PhoneLbl.Text = "№ тел.:";
            // 
            // FirstNameLbl
            // 
            this.FirstNameLbl.AutoSize = true;
            this.FirstNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirstNameLbl.Location = new System.Drawing.Point(6, 53);
            this.FirstNameLbl.Name = "FirstNameLbl";
            this.FirstNameLbl.Size = new System.Drawing.Size(33, 16);
            this.FirstNameLbl.TabIndex = 0;
            this.FirstNameLbl.Text = "Ім\'я:";
            // 
            // TeacherGridView
            // 
            this.TeacherGridView.AllowUserToAddRows = false;
            this.TeacherGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.TeacherGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.TeacherGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.TeacherGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TeacherGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TeacherGridView.GridColor = System.Drawing.SystemColors.Control;
            this.TeacherGridView.Location = new System.Drawing.Point(381, 0);
            this.TeacherGridView.MultiSelect = false;
            this.TeacherGridView.Name = "TeacherGridView";
            this.TeacherGridView.ReadOnly = true;
            this.TeacherGridView.RowHeadersWidth = 20;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TeacherGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.TeacherGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TeacherGridView.Size = new System.Drawing.Size(510, 598);
            this.TeacherGridView.TabIndex = 97;
            this.TeacherGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TeacherGridView_CellClick);
            // 
            // TeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 598);
            this.Controls.Add(this.TeacherGridView);
            this.Controls.Add(this.AddPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TeacherForm";
            this.Text = "Викладачі";
            this.AddPanel.ResumeLayout(false);
            this.AddGBox.ResumeLayout(false);
            this.AddGBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TeacherGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel AddPanel;
        private System.Windows.Forms.GroupBox AddGBox;
        private System.Windows.Forms.TextBox AddressTBox;
        private System.Windows.Forms.TextBox EmailTBox;
        private System.Windows.Forms.Label EmailLbl;
        private System.Windows.Forms.Label AddressLbl;
        private System.Windows.Forms.Label PhoneValiadtionLbl;
        private System.Windows.Forms.TextBox LastNameTBox;
        private System.Windows.Forms.Label LastNameValiadtionLbl;
        private System.Windows.Forms.Label FirstNameValiadtionLbl;
        private System.Windows.Forms.Label LastNameLbl;
        private System.Windows.Forms.TextBox PhoneTBox;
        private System.Windows.Forms.TextBox FirstNameTBox;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Label PhoneLbl;
        private System.Windows.Forms.Label FirstNameLbl;
        private System.Windows.Forms.DataGridView TeacherGridView;
    }
}