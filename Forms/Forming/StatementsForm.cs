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

namespace SoftwareVVNZ.Forms.Forming
{
    public partial class StatementsForm : Form
    {
        private int _selectedRowIndex = 0;
        private LogsProvider _LogsProvider = new LogsProvider();
        private ValidationMy _validation = new ValidationMy();
        private StatementsProvider _StatementsProvider = new StatementsProvider();
        private List<Statements> _StatementsList = new List<Statements>();
        private GroupsProvider _GroupsProvider = new GroupsProvider();
        private List<Groups> _GroupsList = new List<Groups>();
        private DisciplineProvider _DisciplineProvider = new DisciplineProvider();
        private List<Discipline> _DisciplineList = new List<Discipline>();
        private StudentProvider _StudentProvider = new StudentProvider();
        private List<Student> _StudentList = new List<Student>();
        private RatingsProvider _RatingsProvider = new RatingsProvider();
        private List<Ratings> _RatingsList = new List<Ratings>();

        private TeacherProvider _TeacherProvider = new TeacherProvider();
        private List<Teacher> _TeachersList = new List<Teacher>();

        public StatementsForm()
        {
            InitializeComponent();
            LoadAllDate();
            DataLoad();
        }

        private void FormingBtn_Click(object sender, EventArgs e)
        {
            if (IsDataEnteringCorrect())
            {
                FormingStatement();
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (IsDataEnteringCorrect() && _RatingsList.Count > 0)
            {
                _StatementsProvider.InsertStatements(StatementsNumberTBox.Text, 
                    Convert.ToInt32(GroupsCBox.SelectedValue), 
                    Convert.ToInt32(DisciplineCBox.SelectedValue), 
                    Convert.ToInt32(TeacherCBox.SelectedValue), 
                    DateOfCompletionDTP.Value);
                int lastStatements = _StatementsProvider.GetLastRecords();
                for (int i = 0; i < _RatingsList.Count; i++)
                {
                    _RatingsList[i].StatementsId = lastStatements;
                }
                _RatingsProvider.InsertBatchRatings(_RatingsList);
                _LogsProvider.InsertLogs(SoftwareVVNZ.Forms.Systems.LoginForm.CurrentUser.UsersId, "Користувач додав відомість із номером " + StatementsNumberTBox.Text, DateTime.Now);

                ClearAllControls();
                DataLoad();
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

            _DisciplineList = _DisciplineProvider.GetAllDiscipline();
            DisciplineCBox.DataSource = _DisciplineList;
            DisciplineCBox.ValueMember = "DisciplineId";
            DisciplineCBox.DisplayMember = "DisciplineName";

            _TeachersList = _TeacherProvider.GetAllTeachers();
            TeacherCBox.DataSource = _TeachersList;
            TeacherCBox.ValueMember = "TeacherId";
            TeacherCBox.DisplayMember = "FIO";
        }

        private void DataLoad()
        {
            int firstRowIndex = 0;
            if (StatementsGridView.FirstDisplayedScrollingRowIndex > 0)
            {
                firstRowIndex = StatementsGridView.FirstDisplayedScrollingRowIndex;
            }
            try
            {
                _StatementsList = _StatementsProvider.GetAllStatements();
                LoadDataInStatementsGridView(_StatementsList);
                if (_selectedRowIndex == StatementsGridView.Rows.Count)
                {
                    _selectedRowIndex = StatementsGridView.Rows.Count - 1;
                }
                if (_selectedRowIndex >= 0)
                {
                    StatementsGridView.FirstDisplayedScrollingRowIndex = firstRowIndex;
                    StatementsGridView.Rows[_selectedRowIndex].Selected = true;
                }
            }
            catch { }
        }

        private void LoadDataInStatementsGridView(List<Statements> StatementsList)
        {
            StatementsGridView.DataSource = null;
            StatementsGridView.Columns.Clear();
            StatementsGridView.AutoGenerateColumns = false;
            StatementsGridView.RowHeadersVisible = false;

            StatementsGridView.DataSource = StatementsList;

            if (StatementsList.Count > 0)
            {
                if (StatementsList[0].Message == NamesMy.NoDataNames.NoDataInStatements)
                {
                    DataGridViewColumn messageColumn = new DataGridViewTextBoxColumn();
                    messageColumn.DataPropertyName = "Message";
                    messageColumn.Width = StatementsGridView.Width - NamesMy.SizeOptins.MinusSizePanel;
                    StatementsGridView.Columns.Add(messageColumn);
                }
                else
                {
                    DataGridViewColumn DetailIdColumn = new DataGridViewTextBoxColumn();
                    DetailIdColumn.DataPropertyName = "StatementsId";
                    StatementsGridView.Columns.Add(DetailIdColumn);
                    StatementsGridView.Columns[0].Visible = false;

                    DataGridViewColumn StatementsNameColumn = new DataGridViewTextBoxColumn();
                    StatementsNameColumn.HeaderText = "№ відомості";
                    StatementsNameColumn.DataPropertyName = "StatementsNumber";
                    StatementsNameColumn.Width = NamesMy.SizeOptins.NameSize;
                    StatementsGridView.Columns.Add(StatementsNameColumn);

                    DataGridViewColumn DateOfCompletionColumn = new DataGridViewTextBoxColumn();
                    DateOfCompletionColumn.HeaderText = "Дата заповнення";
                    DateOfCompletionColumn.DataPropertyName = "DateOfCompletion";
                    DateOfCompletionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    DateOfCompletionColumn.Width = 150;
                    StatementsGridView.Columns.Add(DateOfCompletionColumn);

                    DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
                    deleteBtn.HeaderText = NamesMy.ProgramButtons.DeleteBtn;
                    deleteBtn.Text = NamesMy.ProgramButtons.DeleteBtn;
                    deleteBtn.UseColumnTextForButtonValue = true;
                    deleteBtn.ToolTipText = NamesMy.ProgramButtons.DeleteBtn;
                    deleteBtn.Width = NamesMy.SizeOptins.DeleteBtnSize;
                    StatementsGridView.Columns.Add(deleteBtn);
                }
                for (int i = 0; i < StatementsGridView.Columns.Count; i++)
                {
                    StatementsGridView.Columns[i].HeaderCell.Style.BackColor = Color.LightGray;
                }
            }
        }

        private void ClearAllControls()
        {
            StatementsNumberTBox.Text = String.Empty;
            _RatingsList.Clear();
            LoadDataInFormingStatementsDGV(_RatingsList);
        }

        private bool IsDataEnteringCorrect()
        {
            bool isCorrect = true;
            if (_validation.IsDataEntering(StatementsNumberTBox.Text))
            {
                StatementsNumberValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
            }
            else
            {
                StatementsNumberValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
                isCorrect = false;
            }
            return isCorrect;
        }

        private void FormingStatement()
        {
            _StudentList = _StudentProvider.GetAllStudentByGroupId(Convert.ToInt32(GroupsCBox.SelectedValue));
            for (int i = 0; i < _StudentList.Count; i++)
            {
                Ratings oneRatings = new Ratings();
                oneRatings.StudentId = _StudentList[i].StudentId;
                oneRatings.FIO = _StudentList[i].FIO;
                oneRatings.DisciplineId = Convert.ToInt32(DisciplineCBox.SelectedValue);
                oneRatings.GroupsId = Convert.ToInt32(GroupsCBox.SelectedValue);
                _RatingsList.Add(oneRatings);
            }
            LoadDataInFormingStatementsDGV(_RatingsList);
        }

        private void LoadDataInFormingStatementsDGV(List<Ratings> RatingsList)
        {
            FormingStatementsDGV.DataSource = null;
            FormingStatementsDGV.Columns.Clear();
            FormingStatementsDGV.AutoGenerateColumns = false;
            FormingStatementsDGV.RowHeadersVisible = false;

            FormingStatementsDGV.DataSource = RatingsList;

            if (RatingsList.Count > 0)
            {
                if (RatingsList[0].Message == NamesMy.NoDataNames.NoDataInRatings)
                {
                    DataGridViewColumn messageColumn = new DataGridViewTextBoxColumn();
                    messageColumn.DataPropertyName = "Message";
                    messageColumn.Width = StatementsGridView.Width - NamesMy.SizeOptins.MinusSizePanel;
                    FormingStatementsDGV.Columns.Add(messageColumn);
                }
                else
                {

                    DataGridViewColumn StatementsNameColumn = new DataGridViewTextBoxColumn();
                    StatementsNameColumn.HeaderText = "П.І.Б.";
                    StatementsNameColumn.DataPropertyName = "FIO";
                    StatementsNameColumn.Width = 260;
                    FormingStatementsDGV.Columns.Add(StatementsNameColumn);

                    DataGridViewColumn DateOfCompletionColumn = new DataGridViewTextBoxColumn();
                    DateOfCompletionColumn.HeaderText = "Оцінка";
                    DateOfCompletionColumn.DataPropertyName = "SubjectMark";
                    DateOfCompletionColumn.Name = "SubjectMark";
                    DateOfCompletionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    DateOfCompletionColumn.Width = 70;
                    FormingStatementsDGV.Columns.Add(DateOfCompletionColumn);

                    DataGridViewColumn SimbolMarkColumn = new DataGridViewTextBoxColumn();
                    SimbolMarkColumn.HeaderText = "Буквенна";
                    SimbolMarkColumn.DataPropertyName = "SimbolMark";
                    SimbolMarkColumn.Name = "SimbolMark";
                    SimbolMarkColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    SimbolMarkColumn.Width = 95;
                    SimbolMarkColumn.ReadOnly = true;
                    FormingStatementsDGV.Columns.Add(SimbolMarkColumn);

                    DataGridViewColumn FiveBallMarkColumn = new DataGridViewTextBoxColumn();
                    FiveBallMarkColumn.HeaderText = "5-ти бальна";
                    FiveBallMarkColumn.Name = "FiveBallMark";
                    FiveBallMarkColumn.DataPropertyName = "FiveBallMark";
                    FiveBallMarkColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    FiveBallMarkColumn.Width = 100;
                    FiveBallMarkColumn.ReadOnly = true;
                    FormingStatementsDGV.Columns.Add(FiveBallMarkColumn);
                }
                for (int i = 0; i < FormingStatementsDGV.Columns.Count; i++)
                {
                    FormingStatementsDGV.Columns[i].HeaderCell.Style.BackColor = Color.LightGray;
                }
            }
        }

        private void FormingStatementsDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            GetAllMark();
        }

        private void GetAllMark()
        {
            for (int i = 0; i < FormingStatementsDGV.RowCount; i++)
            {
                FormingStatementsDGV["SimbolMark", i].Value = GetSimbolMark(Convert.ToInt32(FormingStatementsDGV["SubjectMark", i].Value));
                FormingStatementsDGV["FiveBallMark", i].Value = GetFiveBallMark(Convert.ToInt32(FormingStatementsDGV["SubjectMark", i].Value));
            }
        }

        private string GetFiveBallMark(int Mark)
        {
            if (Mark >= 35 && Mark <= 59)
            {
                return "Незадов.";
            }
            else if (Mark >= 60 && Mark <= 63)
            {
                return "Задов.";
            }
            else if (Mark >= 64 && Mark <= 74)
            {
                return "Задов.";
            }
            else if (Mark >= 75 && Mark <= 81)
            {
                return "Добре.";
            }
            else if (Mark >= 82 && Mark <= 89)
            {
                return "Добре";
            }
            else if (Mark >= 90 && Mark <= 100)
            {
                return "Відмінно";
            }
            else if (Mark > 100)
            {
                return "Відмінно";
            }
            else
            {
                return "Незадов.";
            }
        }

        private string GetSimbolMark(int Mark)
        {
            if (Mark >= 35 && Mark <= 59)
            {
                return "Fx";
            }
            else if (Mark >= 60 && Mark <= 63)
            {
                return "E";
            }
            else if (Mark >= 64 && Mark <= 74)
            {
                return "D";
            }
            else if (Mark >= 75 && Mark <= 81)
            {
                return "C";
            }
            else if (Mark >= 82 && Mark <= 89)
            {
                return "B";
            }
            else if (Mark >= 90 && Mark <= 100)
            {
                return "A";
            }
            else if (Mark > 100)
            {
                return "A";
            }
            else
            {
                return "Fx";
            }
        }

        private void StatementsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (MessageBox.Show("Ви дійсно бажаєте видалити цю відомість?", "Видалити", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int selectedStatementsId = Convert.ToInt32(StatementsGridView[0, e.RowIndex].Value.ToString());
                    _StatementsProvider.DeleteStatementsByStatementsId(selectedStatementsId);
                    _RatingsProvider.DeleteRatingsByStatementsId(selectedStatementsId);
                    DataLoad();
                }
            }


        }
    }
}