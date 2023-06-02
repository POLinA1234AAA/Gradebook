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
    public partial class GroupsForm : Form
    {
        private int _selectedRowIndex = 0;
        private ValidationMy _validation = new ValidationMy();
        private GroupsProvider _GroupsProvider = new GroupsProvider();
        private List<Groups> _GroupsList = new List<Groups>();

        public GroupsForm()
        {
            InitializeComponent();
            DataLoad();
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
                _GroupsProvider.InsertGroups(GroupsNameTBox.Text, DescriptionTBox.Text);
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

        private void DataLoad()
        {
            int firstRowIndex = 0;
            if (GroupsGridView.FirstDisplayedScrollingRowIndex > 0)
            {
                firstRowIndex = GroupsGridView.FirstDisplayedScrollingRowIndex;
            }
            try
            {
                _GroupsList = _GroupsProvider.GetAllGroups();
                LoadDataInGroupsGridView(_GroupsList);
                if (_selectedRowIndex == GroupsGridView.Rows.Count)
                {
                    _selectedRowIndex = GroupsGridView.Rows.Count - 1;
                }
                if (_selectedRowIndex >= 0)
                {
                    GroupsGridView.FirstDisplayedScrollingRowIndex = firstRowIndex;
                    GroupsGridView.Rows[_selectedRowIndex].Selected = true;
                }
            }
            catch { }
        }

        private void LoadDataInGroupsGridView(List<Groups> GroupsList)
        {
            GroupsGridView.DataSource = null;
            GroupsGridView.Columns.Clear();
            GroupsGridView.AutoGenerateColumns = false;
            GroupsGridView.RowHeadersVisible = false;

            GroupsGridView.DataSource = GroupsList;

            if (GroupsList.Count > 0)
            {
                if (GroupsList[0].Message == NamesMy.NoDataNames.NoDataInGroups)
                {
                    DataGridViewColumn messageColumn = new DataGridViewTextBoxColumn();
                    messageColumn.DataPropertyName = "Message";
                    messageColumn.Width = GroupsGridView.Width - NamesMy.SizeOptins.MinusSizePanel;
                    GroupsGridView.Columns.Add(messageColumn);
                }
                else
                {
                    DataGridViewColumn DetailIdColumn = new DataGridViewTextBoxColumn();
                    DetailIdColumn.DataPropertyName = "GroupsId";
                    GroupsGridView.Columns.Add(DetailIdColumn);
                    GroupsGridView.Columns[0].Visible = false;

                    DataGridViewColumn numberColumn = new DataGridViewTextBoxColumn();
                    numberColumn.HeaderText = "№ ";
                    numberColumn.DataPropertyName = "Number";
                    numberColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    numberColumn.Width = NamesMy.SizeOptins.NumberSize;
                    GroupsGridView.Columns.Add(numberColumn);

                    DataGridViewColumn GroupsNameColumn = new DataGridViewTextBoxColumn();
                    GroupsNameColumn.HeaderText = "Навчальні групи";
                    GroupsNameColumn.DataPropertyName = "GroupsName";
                    GroupsNameColumn.Width = NamesMy.SizeOptins.NameSize;
                    GroupsGridView.Columns.Add(GroupsNameColumn);


                }
                for (int i = 0; i < GroupsGridView.Columns.Count; i++)
                {
                    GroupsGridView.Columns[i].HeaderCell.Style.BackColor = Color.LightGray;
                }
            }
        }

        private void ClearAllControls()
        {
            GroupsNameTBox.Text = String.Empty;
            DescriptionTBox.Text = String.Empty;
        }

        private bool IsDataEnteringCorrect()
        {
            bool isCorrect = true;
            if (_validation.IsDataEntering(GroupsNameTBox.Text))
            {
                GroupsNameValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
            }
            else
            {
                GroupsNameValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
                isCorrect = false;
            }
            return isCorrect;
        }

        private void GroupsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (LoginForm.CurrentUser.RoleId == 3)
            { return; }

            if (e.RowIndex >= 0 && GroupsGridView[0, e.RowIndex].Value.ToString() != _GroupsList[0].Message)
            {
                _selectedRowIndex = e.RowIndex;
                UpdateGroupsForm updateGroupsForm = new UpdateGroupsForm(Convert.ToInt32(GroupsGridView[0, e.RowIndex].Value.ToString()));
                updateGroupsForm.ShowDialog();
                DataLoad();
            }
        }
    }
}
