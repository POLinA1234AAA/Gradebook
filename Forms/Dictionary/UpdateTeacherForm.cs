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

namespace SoftwareVVNZ.Forms.Dictionary
{
    public partial class UpdateTeacherForm : Form
    {
        private int _TeacherId = 0;
        private Teacher _selectedTeacher = new Teacher();
        private TeacherProvider _TeacherProvider = new TeacherProvider();
        private ValidationMy _validation = new ValidationMy();
        //private GroupsProvider _GroupsProvider = new GroupsProvider();
        //private List<Groups> _GroupsList = new List<Groups>();


        public UpdateTeacherForm(int TeacherId)
        {
            InitializeComponent();
            _TeacherId = TeacherId;
            LoadAllDate();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (IsDataEnteringCorrect())
            {
                _TeacherProvider.UpdateTeacher(LastNameTBox.Text, FirstNameTBox.Text, PhoneTBox.Text, AddressTBox.Text, EmailTBox.Text,  _TeacherId);
                this.Close();
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ви дійсно хочете видалити цей елемент?", "Видалити", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _TeacherProvider.DeleteTeacherByTeacherId(_TeacherId);
                this.Close();
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadAllDate()
        {
            //_GroupsList = _GroupsProvider.GetAllGroups();
            //GroupsCBox.DataSource = _GroupsList;
            //GroupsCBox.ValueMember = "GroupsId";
            //GroupsCBox.DisplayMember = "GroupsName";

            _selectedTeacher = _TeacherProvider.SelectedStudentByStudentId(_TeacherId);
            LastNameTBox.Text = _selectedTeacher.LastName;
            FirstNameTBox.Text = _selectedTeacher.FirstName;
            PhoneTBox.Text = _selectedTeacher.Phone;
            AddressTBox.Text = _selectedTeacher.Address;
            EmailTBox.Text = _selectedTeacher.Email;
        }

        private bool IsDataEnteringCorrect()
        {
            bool isCorrect = true;
            if (_validation.IsDataEntering(LastNameTBox.Text))
            {
                LastNameValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
            }
            else
            {
                LastNameValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
                isCorrect = false;
            }
            if (_validation.IsDataEntering(FirstNameTBox.Text))
            {
                FirstNameValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
            }
            else
            {
                FirstNameValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
                isCorrect = false;
            }
            if (_validation.IsDataEntering(PhoneTBox.Text))
            {
                PhoneValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
            }
            else
            {
                PhoneValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
                isCorrect = false;
            }
            return isCorrect;
        }
    }
}
