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
    public partial class DisciplineForm : Form
    {
        private int _selectedRowIndex = 0;
        private ValidationMy _validation = new ValidationMy();
        private DisciplineProvider _DisciplineProvider = new DisciplineProvider();
        private List<Discipline> _DisciplineList = new List<Discipline>();

        public DisciplineForm()
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
                _DisciplineProvider.InsertDiscipline(DisciplineNameTBox.Text, DescriptionTBox.Text);
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
            if (DisciplineGridView.FirstDisplayedScrollingRowIndex > 0)
            {
                firstRowIndex = DisciplineGridView.FirstDisplayedScrollingRowIndex;
            }
            try
            {
                _DisciplineList = _DisciplineProvider.GetAllDiscipline();
                LoadDataInDisciplineGridView(_DisciplineList);
                if (_selectedRowIndex == DisciplineGridView.Rows.Count)
                {
                    _selectedRowIndex = DisciplineGridView.Rows.Count - 1;
                }
                if (_selectedRowIndex >= 0)
                {
                    DisciplineGridView.FirstDisplayedScrollingRowIndex = firstRowIndex;
                    DisciplineGridView.Rows[_selectedRowIndex].Selected = true;
                }
            }
            catch { }
        }

        private void LoadDataInDisciplineGridView(List<Discipline> DisciplineList)
        {
            DisciplineGridView.DataSource = null;
            DisciplineGridView.Columns.Clear();
            DisciplineGridView.AutoGenerateColumns = false;
            DisciplineGridView.RowHeadersVisible = false;

            DisciplineGridView.DataSource = DisciplineList;

            if (DisciplineList.Count > 0)
            {
                if (DisciplineList[0].Message == NamesMy.NoDataNames.NoDataInDiscipline)
                {
                    DataGridViewColumn messageColumn = new DataGridViewTextBoxColumn();
                    messageColumn.DataPropertyName = "Message";
                    messageColumn.Width = DisciplineGridView.Width - NamesMy.SizeOptins.MinusSizePanel;
                    DisciplineGridView.Columns.Add(messageColumn);
                }
                else
                {
                    DataGridViewColumn DetailIdColumn = new DataGridViewTextBoxColumn();
                    DetailIdColumn.DataPropertyName = "DisciplineId";
                    DisciplineGridView.Columns.Add(DetailIdColumn);
                    DisciplineGridView.Columns[0].Visible = false;

                    DataGridViewColumn numberColumn = new DataGridViewTextBoxColumn();
                    numberColumn.HeaderText = "№ ";
                    numberColumn.DataPropertyName = "Number";
                    numberColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    numberColumn.Width = NamesMy.SizeOptins.NumberSize;
                    DisciplineGridView.Columns.Add(numberColumn);

                    DataGridViewColumn DisciplineNameColumn = new DataGridViewTextBoxColumn();
                    DisciplineNameColumn.HeaderText = "Дисципліни";
                    DisciplineNameColumn.DataPropertyName = "DisciplineName";
                    DisciplineNameColumn.Width = NamesMy.SizeOptins.NameSize;
                    DisciplineGridView.Columns.Add(DisciplineNameColumn);


                }
                for (int i = 0; i < DisciplineGridView.Columns.Count; i++)
                {
                    DisciplineGridView.Columns[i].HeaderCell.Style.BackColor = Color.LightGray;
                }
            }
        }

        private void ClearAllControls()
        {
            DisciplineNameTBox.Text = String.Empty;
            DescriptionTBox.Text = String.Empty;
        }

        private bool IsDataEnteringCorrect()
        {
            bool isCorrect = true;
            if (_validation.IsDataEntering(DisciplineNameTBox.Text))
            {
                DisciplineNameValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
            }
            else
            {
                DisciplineNameValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
                isCorrect = false;
            }
            return isCorrect;
        }

        private void DisciplineGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (LoginForm.CurrentUser.RoleId == 3)
            { return; }

            if (e.RowIndex >= 0 && DisciplineGridView[0, e.RowIndex].Value.ToString() != _DisciplineList[0].Message)
            {
                _selectedRowIndex = e.RowIndex;
                UpdateDisciplineForm updateDisciplineForm = new UpdateDisciplineForm(Convert.ToInt32(DisciplineGridView[0, e.RowIndex].Value.ToString()));
                updateDisciplineForm.ShowDialog();
                DataLoad();
            }
        }
    }
}
