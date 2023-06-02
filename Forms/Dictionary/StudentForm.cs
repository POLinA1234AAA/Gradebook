using SoftwareVVNZ.AppCode;
using SoftwareVVNZ.Forms.Systems;
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
    public partial class StudentForm : Form
    {
        private int _selectedRowIndex = 0;
        private ValidationMy _validation = new ValidationMy();
        StudentProvider _StudentProvider = new StudentProvider();
        List<Student> _StudentList = new List<Student>();
        private GroupsProvider _GroupsProvider = new GroupsProvider();
        private List<Groups> _GroupsList = new List<Groups>();



        public StudentForm()
        {
            InitializeComponent();
            DataLoad();
            LoadAllDate();
            EnabledFalse();
        }

        private void EnabledFalse()
        {
            if (LoginForm.CurrentUser.RoleId == 3)
            {
                AddGBox.Enabled = false;
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (IsDataEnteringCorrect())
            {
                _StudentProvider.InsertStudent(LastNameTBox.Text, FirstNameTBox.Text, PhoneTBox.Text, AddressTBox.Text, EmailTBox.Text, Convert.ToInt32(GroupsCBox.SelectedValue));
                DataLoad();
                ClearAllControls();
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ClearAllControls();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadAllDate()
        {
            _GroupsList = _GroupsProvider.GetAllGroups();
            GroupsCBox.DataSource = _GroupsList;
            GroupsCBox.ValueMember = "GroupsId";
            GroupsCBox.DisplayMember = "GroupsName";
        }

        private void DataLoad()
        {
            int firstRowIndex = 0;
            if (StudentGridView.FirstDisplayedScrollingRowIndex > 0)
            {
                firstRowIndex = StudentGridView.FirstDisplayedScrollingRowIndex;
            }
            try
            {
                _StudentList = _StudentProvider.GetAllStudent();
                LoadDataInStudentGridView(_StudentList);
                if (_selectedRowIndex == StudentGridView.Rows.Count)
                {
                    _selectedRowIndex = StudentGridView.Rows.Count - 1;
                }
                if (_selectedRowIndex >= 0)
                {
                    StudentGridView.FirstDisplayedScrollingRowIndex = firstRowIndex;
                    StudentGridView.Rows[_selectedRowIndex].Selected = true;
                }
            }
            catch { }
        }

        private void LoadDataInStudentGridView(List<Student> StudentList)
        {
            StudentGridView.DataSource = null;
            StudentGridView.Columns.Clear();
            StudentGridView.AutoGenerateColumns = false;
            StudentGridView.RowHeadersVisible = false;

            StudentGridView.DataSource = StudentList;

            if (StudentList.Count > 0)
            {
                if (StudentList[0].Message == NamesMy.NoDataNames.NoDataInStudent)
                {
                    DataGridViewColumn messageColumn = new DataGridViewTextBoxColumn();
                    messageColumn.DataPropertyName = "Message";
                    messageColumn.Width = StudentGridView.Width - NamesMy.SizeOptins.MinusSizePanel;
                    StudentGridView.Columns.Add(messageColumn);
                }
                else
                {
                    DataGridViewColumn DetailIdColumn = new DataGridViewTextBoxColumn();
                    DetailIdColumn.DataPropertyName = "StudentId";
                    StudentGridView.Columns.Add(DetailIdColumn);
                    StudentGridView.Columns[0].Visible = false;

                    DataGridViewColumn numberColumn = new DataGridViewTextBoxColumn();
                    numberColumn.HeaderText = "№ ";
                    numberColumn.DataPropertyName = "Number";
                    numberColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    numberColumn.Width = NamesMy.SizeOptins.NumberSize;
                    StudentGridView.Columns.Add(numberColumn);

                    DataGridViewColumn LastNameColumn = new DataGridViewTextBoxColumn();
                    LastNameColumn.HeaderText = "Прізвище";
                    LastNameColumn.DataPropertyName = "LastName";
                    LastNameColumn.Width = 200;
                    StudentGridView.Columns.Add(LastNameColumn);

                    DataGridViewColumn FirstNameColumn = new DataGridViewTextBoxColumn();
                    FirstNameColumn.HeaderText = "Ім'я";
                    FirstNameColumn.DataPropertyName = "FirstName";
                    FirstNameColumn.Width = 200;
                    StudentGridView.Columns.Add(FirstNameColumn);

                    DataGridViewColumn PhoneColumn = new DataGridViewTextBoxColumn();
                    PhoneColumn.HeaderText = "№ телефону";
                    PhoneColumn.DataPropertyName = "Phone";
                    PhoneColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    PhoneColumn.Width = 150;
                    StudentGridView.Columns.Add(PhoneColumn);

                }
                for (int i = 0; i < StudentGridView.Columns.Count; i++)
                {
                    StudentGridView.Columns[i].HeaderCell.Style.BackColor = Color.LightGray;
                }
            }
        }

        private void ClearAllControls()
        {
            LastNameTBox.Text = String.Empty;
            FirstNameTBox.Text = String.Empty;
            PhoneTBox.Text = String.Empty;
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

        private void StudentGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (LoginForm.CurrentUser.RoleId == 3)
            { return; }

            if (e.RowIndex >= 0 && StudentGridView[0, e.RowIndex].Value.ToString() != _StudentList[0].Message)
            {
                _selectedRowIndex = e.RowIndex;
                UpdateStudentForm updateStudentForm = new UpdateStudentForm(Convert.ToInt32(StudentGridView[0, e.RowIndex].Value.ToString()));
                updateStudentForm.ShowDialog();
                DataLoad();
            }
        }
    }
}
