namespace SoftwareVVNZ.Forms.Forming {
  partial class StatementsForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.AddPanel = new System.Windows.Forms.Panel();
            this.AddGBox = new System.Windows.Forms.GroupBox();
            this.FormingStatementsDGV = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FormingBtn = new System.Windows.Forms.Button();
            this.LastNameLbl = new System.Windows.Forms.Label();
            this.DateOfCompletionDTP = new System.Windows.Forms.DateTimePicker();
            this.StatementsNumberValiadtionLbl = new System.Windows.Forms.Label();
            this.StartDateLbl = new System.Windows.Forms.Label();
            this.StatementsNumberTBox = new System.Windows.Forms.TextBox();
            this.DisciplineCBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GroupsCBox = new System.Windows.Forms.ComboBox();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.StatementsGridView = new System.Windows.Forms.DataGridView();
            this.TeacherCBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AddPanel.SuspendLayout();
            this.AddGBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FormingStatementsDGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatementsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // AddPanel
            // 
            this.AddPanel.Controls.Add(this.AddGBox);
            this.AddPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddPanel.Location = new System.Drawing.Point(0, 0);
            this.AddPanel.Name = "AddPanel";
            this.AddPanel.Size = new System.Drawing.Size(580, 611);
            this.AddPanel.TabIndex = 96;
            // 
            // AddGBox
            // 
            this.AddGBox.Controls.Add(this.FormingStatementsDGV);
            this.AddGBox.Controls.Add(this.groupBox1);
            this.AddGBox.Controls.Add(this.ExitBtn);
            this.AddGBox.Controls.Add(this.ClearBtn);
            this.AddGBox.Controls.Add(this.AddBtn);
            this.AddGBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddGBox.Location = new System.Drawing.Point(12, 12);
            this.AddGBox.Name = "AddGBox";
            this.AddGBox.Size = new System.Drawing.Size(560, 587);
            this.AddGBox.TabIndex = 2;
            this.AddGBox.TabStop = false;
            this.AddGBox.Text = "Додати";
            // 
            // FormingStatementsDGV
            // 
            this.FormingStatementsDGV.AllowUserToAddRows = false;
            this.FormingStatementsDGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.FormingStatementsDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.FormingStatementsDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FormingStatementsDGV.GridColor = System.Drawing.SystemColors.Control;
            this.FormingStatementsDGV.Location = new System.Drawing.Point(16, 292);
            this.FormingStatementsDGV.MultiSelect = false;
            this.FormingStatementsDGV.Name = "FormingStatementsDGV";
            this.FormingStatementsDGV.RowHeadersWidth = 20;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormingStatementsDGV.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.FormingStatementsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.FormingStatementsDGV.Size = new System.Drawing.Size(538, 222);
            this.FormingStatementsDGV.TabIndex = 116;
            this.FormingStatementsDGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.FormingStatementsDGV_CellEndEdit);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TeacherCBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.FormingBtn);
            this.groupBox1.Controls.Add(this.LastNameLbl);
            this.groupBox1.Controls.Add(this.DateOfCompletionDTP);
            this.groupBox1.Controls.Add(this.StatementsNumberValiadtionLbl);
            this.groupBox1.Controls.Add(this.StartDateLbl);
            this.groupBox1.Controls.Add(this.StatementsNumberTBox);
            this.groupBox1.Controls.Add(this.DisciplineCBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.GroupsCBox);
            this.groupBox1.Location = new System.Drawing.Point(16, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 253);
            this.groupBox1.TabIndex = 115;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Нова відомість:";
            // 
            // FormingBtn
            // 
            this.FormingBtn.Location = new System.Drawing.Point(302, 213);
            this.FormingBtn.Name = "FormingBtn";
            this.FormingBtn.Size = new System.Drawing.Size(96, 23);
            this.FormingBtn.TabIndex = 115;
            this.FormingBtn.Text = "Формувати";
            this.FormingBtn.UseVisualStyleBackColor = true;
            this.FormingBtn.Click += new System.EventHandler(this.FormingBtn_Click);
            // 
            // LastNameLbl
            // 
            this.LastNameLbl.AutoSize = true;
            this.LastNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LastNameLbl.Location = new System.Drawing.Point(22, 36);
            this.LastNameLbl.Name = "LastNameLbl";
            this.LastNameLbl.Size = new System.Drawing.Size(89, 16);
            this.LastNameLbl.TabIndex = 1;
            this.LastNameLbl.Text = "№ відомості:";
            // 
            // DateOfCompletionDTP
            // 
            this.DateOfCompletionDTP.Location = new System.Drawing.Point(158, 175);
            this.DateOfCompletionDTP.Name = "DateOfCompletionDTP";
            this.DateOfCompletionDTP.Size = new System.Drawing.Size(162, 22);
            this.DateOfCompletionDTP.TabIndex = 114;
            // 
            // StatementsNumberValiadtionLbl
            // 
            this.StatementsNumberValiadtionLbl.AutoSize = true;
            this.StatementsNumberValiadtionLbl.ForeColor = System.Drawing.Color.Red;
            this.StatementsNumberValiadtionLbl.Location = new System.Drawing.Point(131, 36);
            this.StatementsNumberValiadtionLbl.Name = "StatementsNumberValiadtionLbl";
            this.StatementsNumberValiadtionLbl.Size = new System.Drawing.Size(13, 16);
            this.StatementsNumberValiadtionLbl.TabIndex = 22;
            this.StatementsNumberValiadtionLbl.Text = "*";
            // 
            // StartDateLbl
            // 
            this.StartDateLbl.AutoSize = true;
            this.StartDateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartDateLbl.Location = new System.Drawing.Point(22, 181);
            this.StartDateLbl.Name = "StartDateLbl";
            this.StartDateLbl.Size = new System.Drawing.Size(125, 16);
            this.StartDateLbl.TabIndex = 113;
            this.StartDateLbl.Text = "Дата заповнення:";
            // 
            // StatementsNumberTBox
            // 
            this.StatementsNumberTBox.Location = new System.Drawing.Point(161, 33);
            this.StatementsNumberTBox.MaxLength = 200;
            this.StatementsNumberTBox.Name = "StatementsNumberTBox";
            this.StatementsNumberTBox.Size = new System.Drawing.Size(110, 22);
            this.StatementsNumberTBox.TabIndex = 1;
            this.StatementsNumberTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // DisciplineCBox
            // 
            this.DisciplineCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DisciplineCBox.FormattingEnabled = true;
            this.DisciplineCBox.Location = new System.Drawing.Point(158, 97);
            this.DisciplineCBox.Name = "DisciplineCBox";
            this.DisciplineCBox.Size = new System.Drawing.Size(240, 24);
            this.DisciplineCBox.TabIndex = 91;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(22, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 90;
            this.label4.Text = "Група:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(22, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 16);
            this.label1.TabIndex = 92;
            this.label1.Text = "Назва дисципліни:";
            // 
            // GroupsCBox
            // 
            this.GroupsCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GroupsCBox.FormattingEnabled = true;
            this.GroupsCBox.Location = new System.Drawing.Point(158, 65);
            this.GroupsCBox.Name = "GroupsCBox";
            this.GroupsCBox.Size = new System.Drawing.Size(240, 24);
            this.GroupsCBox.TabIndex = 89;
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(473, 532);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(81, 23);
            this.ExitBtn.TabIndex = 6;
            this.ExitBtn.Text = "Вихід";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // ClearBtn
            // 
            this.ClearBtn.Location = new System.Drawing.Point(374, 532);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(81, 23);
            this.ClearBtn.TabIndex = 5;
            this.ClearBtn.Text = "Очистити";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(272, 532);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(81, 23);
            this.AddBtn.TabIndex = 4;
            this.AddBtn.Text = "Зберегти";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // StatementsGridView
            // 
            this.StatementsGridView.AllowUserToAddRows = false;
            this.StatementsGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.StatementsGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.StatementsGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.StatementsGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StatementsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatementsGridView.GridColor = System.Drawing.SystemColors.Control;
            this.StatementsGridView.Location = new System.Drawing.Point(580, 0);
            this.StatementsGridView.MultiSelect = false;
            this.StatementsGridView.Name = "StatementsGridView";
            this.StatementsGridView.ReadOnly = true;
            this.StatementsGridView.RowHeadersWidth = 20;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatementsGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.StatementsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.StatementsGridView.Size = new System.Drawing.Size(512, 611);
            this.StatementsGridView.TabIndex = 97;
            this.StatementsGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StatementsGridView_CellClick);
            // 
            // TeacherCBox
            // 
            this.TeacherCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TeacherCBox.FormattingEnabled = true;
            this.TeacherCBox.Location = new System.Drawing.Point(158, 132);
            this.TeacherCBox.Name = "TeacherCBox";
            this.TeacherCBox.Size = new System.Drawing.Size(240, 24);
            this.TeacherCBox.TabIndex = 116;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(22, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 117;
            this.label2.Text = "Викладач:";
            // 
            // StatementsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 611);
            this.Controls.Add(this.StatementsGridView);
            this.Controls.Add(this.AddPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StatementsForm";
            this.Text = "Відомості";
            this.AddPanel.ResumeLayout(false);
            this.AddGBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FormingStatementsDGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatementsGridView)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel AddPanel;
    private System.Windows.Forms.GroupBox AddGBox;
    private System.Windows.Forms.TextBox StatementsNumberTBox;
    private System.Windows.Forms.Label StatementsNumberValiadtionLbl;
    private System.Windows.Forms.Label LastNameLbl;
    private System.Windows.Forms.Button ExitBtn;
    private System.Windows.Forms.Button ClearBtn;
    private System.Windows.Forms.Button AddBtn;
    private System.Windows.Forms.DataGridView StatementsGridView;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button FormingBtn;
    private System.Windows.Forms.DateTimePicker DateOfCompletionDTP;
    private System.Windows.Forms.Label StartDateLbl;
    private System.Windows.Forms.ComboBox DisciplineCBox;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox GroupsCBox;
    private System.Windows.Forms.DataGridView FormingStatementsDGV;
        private System.Windows.Forms.ComboBox TeacherCBox;
        private System.Windows.Forms.Label label2;
    }
}