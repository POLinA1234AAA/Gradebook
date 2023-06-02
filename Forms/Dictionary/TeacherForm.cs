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
    public partial class TeacherForm : Form
    {
        private int _selectedRowIndex = 0;
        private ValidationMy _validation = new ValidationMy();
        TeacherProvider _TeacherProvider = new TeacherProvider();
        List<Teacher> _TeacherList = new List<Teacher>();
        //private GroupsProvider _GroupsProvider = new GroupsProvider();
        //private List<Groups> _GroupsList = new List<Groups>();



        public TeacherForm()
        {
            InitializeComponent();
            DataLoad();
            EnabledFalse();
            //LoadAllDate();
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
                _TeacherProvider.InsertTeacher(LastNameTBox.Text, FirstNameTBox.Text, PhoneTBox.Text, AddressTBox.Text, EmailTBox.Text);
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

        //private void LoadAllDate()
        //{
        //    _GroupsList = _GroupsProvider.GetAllGroups();
        //    GroupsCBox.DataSource = _GroupsList;
        //    GroupsCBox.ValueMember = "GroupsId";
        //    GroupsCBox.DisplayMember = "GroupsName";
        //}

        private void DataLoad()
        {
            int firstRowIndex = 0;
            if (TeacherGridView.FirstDisplayedScrollingRowIndex > 0)
            {
                firstRowIndex = TeacherGridView.FirstDisplayedScrollingRowIndex;
            }
            try
            {
                _TeacherList = _TeacherProvider.GetAllTeachers();
                LoadDataInTeacherGridView(_TeacherList);
                if (_selectedRowIndex == TeacherGridView.Rows.Count)
                {
                    _selectedRowIndex = TeacherGridView.Rows.Count - 1;
                }
                if (_selectedRowIndex >= 0)
                {
                    TeacherGridView.FirstDisplayedScrollingRowIndex = firstRowIndex;
                    TeacherGridView.Rows[_selectedRowIndex].Selected = true;
                }
            }
            catch { }
        }

        private void LoadDataInTeacherGridView(List<Teacher> TeacherList)
        {
            TeacherGridView.DataSource = null;
            TeacherGridView.Columns.Clear();
            TeacherGridView.AutoGenerateColumns = false;
            TeacherGridView.RowHeadersVisible = false;

            TeacherGridView.DataSource = TeacherList;

            if (TeacherList.Count > 0)
            {
                if (TeacherList[0].Message == NamesMy.NoDataNames.NoDataInStudent)
                {
                    DataGridViewColumn messageColumn = new DataGridViewTextBoxColumn();
                    messageColumn.DataPropertyName = "Message";
                    messageColumn.Width = TeacherGridView.Width - NamesMy.SizeOptins.MinusSizePanel;
                    TeacherGridView.Columns.Add(messageColumn);
                }
                else
                {
                    DataGridViewColumn DetailIdColumn = new DataGridViewTextBoxColumn();
                    DetailIdColumn.DataPropertyName = "TeacherId";
                    TeacherGridView.Columns.Add(DetailIdColumn);
                    TeacherGridView.Columns[0].Visible = false;

                    DataGridViewColumn numberColumn = new DataGridViewTextBoxColumn();
                    numberColumn.HeaderText = "№ ";
                    numberColumn.DataPropertyName = "Number";
                    numberColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    numberColumn.Width = NamesMy.SizeOptins.NumberSize;
                    TeacherGridView.Columns.Add(numberColumn);

                    DataGridViewColumn LastNameColumn = new DataGridViewTextBoxColumn();
                    LastNameColumn.HeaderText = "Прізвище";
                    LastNameColumn.DataPropertyName = "LastName";
                    LastNameColumn.Width = 200;
                    TeacherGridView.Columns.Add(LastNameColumn);

                    DataGridViewColumn FirstNameColumn = new DataGridViewTextBoxColumn();
                    FirstNameColumn.HeaderText = "Ім'я";
                    FirstNameColumn.DataPropertyName = "FirstName";
                    FirstNameColumn.Width = 200;
                    TeacherGridView.Columns.Add(FirstNameColumn);

                    DataGridViewColumn PhoneColumn = new DataGridViewTextBoxColumn();
                    PhoneColumn.HeaderText = "№ телефону";
                    PhoneColumn.DataPropertyName = "Phone";
                    PhoneColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    PhoneColumn.Width = 150;
                    TeacherGridView.Columns.Add(PhoneColumn);

                }
                for (int i = 0; i < TeacherGridView.Columns.Count; i++)
                {
                    TeacherGridView.Columns[i].HeaderCell.Style.BackColor = Color.LightGray;
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

        private void TeacherGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (LoginForm.CurrentUser.RoleId == 3)
            { return; }

            if (e.RowIndex >= 0 && TeacherGridView[0, e.RowIndex].Value.ToString() != _TeacherList[0].Message)
            {
                _selectedRowIndex = e.RowIndex;
                UpdateTeacherForm updateTeacherForm = new UpdateTeacherForm(Convert.ToInt32(TeacherGridView[0, e.RowIndex].Value.ToString()));
                updateTeacherForm.ShowDialog();
                DataLoad();
            }
        }
    }
}
