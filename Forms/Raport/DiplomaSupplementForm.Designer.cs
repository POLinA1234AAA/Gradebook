namespace SoftwareVVNZ.Forms.Raport {
  partial class DiplomaSupplementForm {
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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.FormingBtn = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.StudentCBox = new System.Windows.Forms.ComboBox();
      this.RaportTBox = new System.Windows.Forms.TextBox();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.FormingBtn);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.StudentCBox);
      this.groupBox1.Location = new System.Drawing.Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(434, 56);
      this.groupBox1.TabIndex = 118;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Виберіть студента:";
      // 
      // FormingBtn
      // 
      this.FormingBtn.Location = new System.Drawing.Point(330, 19);
      this.FormingBtn.Name = "FormingBtn";
      this.FormingBtn.Size = new System.Drawing.Size(96, 23);
      this.FormingBtn.TabIndex = 115;
      this.FormingBtn.Text = "Формувати";
      this.FormingBtn.UseVisualStyleBackColor = true;
      this.FormingBtn.Click += new System.EventHandler(this.FormingBtn_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label4.Location = new System.Drawing.Point(11, 22);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(50, 16);
      this.label4.TabIndex = 90;
      this.label4.Text = "Група:";
      // 
      // StudentCBox
      // 
      this.StudentCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.StudentCBox.FormattingEnabled = true;
      this.StudentCBox.Location = new System.Drawing.Point(75, 19);
      this.StudentCBox.Name = "StudentCBox";
      this.StudentCBox.Size = new System.Drawing.Size(240, 21);
      this.StudentCBox.TabIndex = 89;
      // 
      // RaportTBox
      // 
      this.RaportTBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.RaportTBox.Location = new System.Drawing.Point(12, 74);
      this.RaportTBox.Multiline = true;
      this.RaportTBox.Name = "RaportTBox";
      this.RaportTBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.RaportTBox.Size = new System.Drawing.Size(660, 326);
      this.RaportTBox.TabIndex = 119;
      // 
      // DiplomaSupplementForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.RaportTBox);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DiplomaSupplementForm";
      this.Text = "Додаток до диплому про вищу освіту";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button FormingBtn;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ComboBox StudentCBox;
    private System.Windows.Forms.TextBox RaportTBox;
  }
}