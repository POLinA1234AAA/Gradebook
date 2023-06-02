using SoftwareVVNZ.AppCode;
using SoftwareVVNZ.Provider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareVVNZ.Forms.Dictionary {
  public partial class UpdateStudentForm : Form {
    private int _StudentId = 0;
    private Student _selectedStudent = new Student();
    private StudentProvider _StudentProvider = new StudentProvider();
    private ValidationMy _validation = new ValidationMy();
    private GroupsProvider _GroupsProvider = new GroupsProvider();
    private List<Groups> _GroupsList = new List<Groups>();


    public UpdateStudentForm(int StudentId) {
      InitializeComponent();
      _StudentId = StudentId;
      LoadAllDate();
    }

    private void SaveBtn_Click(object sender, EventArgs e) {
      if (IsDataEnteringCorrect()) {
        _StudentProvider.UpdateStudent(LastNameTBox.Text, FirstNameTBox.Text, PhoneTBox.Text, AddressTBox.Text, EmailTBox.Text, Convert.ToInt32(GroupsCBox.SelectedValue), _StudentId);
        this.Close();
      }
    }

    private void DeleteBtn_Click(object sender, EventArgs e) {
      if (MessageBox.Show("Ви дійсно хочете видалити цей елемент?", "Видалити", MessageBoxButtons.YesNo) == DialogResult.Yes) {
        _StudentProvider.DeleteStudentByStudentId(_StudentId);
        this.Close();
      }
    }

    private void ExitBtn_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void LoadAllDate() {
      _GroupsList = _GroupsProvider.GetAllGroups();
      GroupsCBox.DataSource = _GroupsList;
      GroupsCBox.ValueMember = "GroupsId";
      GroupsCBox.DisplayMember = "GroupsName";


      _selectedStudent = _StudentProvider.SelectedStudentByStudentId(_StudentId);
      LastNameTBox.Text = _selectedStudent.LastName;
      FirstNameTBox.Text = _selectedStudent.FirstName;
      PhoneTBox.Text = _selectedStudent.Phone;
      AddressTBox.Text = _selectedStudent.Address;
      EmailTBox.Text = _selectedStudent.Email;
    }

    private bool IsDataEnteringCorrect() {
      bool isCorrect = true;
      if (_validation.IsDataEntering(LastNameTBox.Text)) {
        LastNameValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        LastNameValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataEntering(FirstNameTBox.Text)) {
        FirstNameValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        FirstNameValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataEntering(PhoneTBox.Text)) {
        PhoneValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        PhoneValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      return isCorrect;
    }
  }
}
