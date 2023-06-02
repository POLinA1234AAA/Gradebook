using SoftwareVVNZ.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareVVNZ.Provider
{
    class StatementsProvider
    {
        private string _ConnString = System.Configuration.ConfigurationSettings.AppSettings["CONNECT"];

        public void InsertStatements(string StatementsNumber, int GroupsId, int DisciplineId, int TeacherId, DateTime DateOfCompletion)
        {
            string SqlString = "INSERT INTO Statements (StatementsNumber, GroupsId, DisciplineId, TeacherId, DateOfCompletion" +
              ") Values(?, ?, ?, ?, ?)";
            using (OleDbConnection conn = new OleDbConnection(_ConnString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("StatementsNumber", StatementsNumber);
                    cmd.Parameters.AddWithValue("GroupsId", GroupsId);
                    cmd.Parameters.AddWithValue("DisciplineId", DisciplineId);
                    cmd.Parameters.AddWithValue("TeacherId", TeacherId);
                    cmd.Parameters.AddWithValue("DateOfCompletion", DateOfCompletion.ToString());
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public List<Statements> GetAllStatements()
        {
            int i = 0;
            string SqlString = "SELECT * FROM Statements";

            List<Statements> listStatements = new List<Statements>();
            using (OleDbConnection conn = new OleDbConnection(_ConnString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                {
                    conn.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Statements oneStatements = new Statements();
                            oneStatements.Number = ++i;
                            oneStatements.StatementsId = Convert.ToInt32(reader["StatementsId"]);
                            oneStatements.StatementsNumber = reader["StatementsNumber"].ToString();
                            oneStatements.GroupsId = Convert.ToInt32(reader["GroupsId"]);
                            oneStatements.DisciplineId = Convert.ToInt32(reader["DisciplineId"]);
                            oneStatements.TeacherId = Convert.ToInt32(reader["TeacherId"]);
                            oneStatements.DateOfCompletion = Convert.ToDateTime(reader["DateOfCompletion"]);
                            listStatements.Add(oneStatements);
                        }
                    }
                    conn.Close();
                }
            }

            if (listStatements.Count == 0)
            {
                Statements noStatements = new Statements();
                noStatements.StatementsId = 0;
                noStatements.Message = NamesMy.NoDataNames.NoDataInStatements;
                listStatements.Add(noStatements);
            }
            return listStatements;
        }

        public Statements SelectedStatementsByStatementsId(int StatementsId)
        {
            string SqlString = "SELECT * " +
              "FROM Statements Where StatementsId=" + StatementsId.ToString();

            Statements oneStatements = new Statements();
            using (OleDbConnection conn = new OleDbConnection(_ConnString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                {
                    conn.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            oneStatements.StatementsId = Convert.ToInt32(reader["StatementsId"]);
                            oneStatements.StatementsNumber = reader["StatementsNumber"].ToString();
                            oneStatements.GroupsId = Convert.ToInt32(reader["GroupsId"]);
                            oneStatements.DisciplineId = Convert.ToInt32(reader["DisciplineId"]);
                            oneStatements.TeacherId = Convert.ToInt32(reader["TeacherId"]);
                            oneStatements.DateOfCompletion = Convert.ToDateTime(reader["DateOfCompletion"]);
                        }
                    }
                }
                conn.Close();
            }
            return oneStatements;
        }

        public void UpdateStatements(string StatementsNumber, int GroupsId, int DisciplineId, int TechniqueId, DateTime DateOfCompletion, DateTime EndDate, int StatementsId)
        {
            string SqlString = "UPDATE Statements SET StatementsNumber=?, GroupsId=?, DisciplineId=?, TechniqueId=?, DateOfCompletion=?, EndDate=? " +
        "WHERE StatementsId=?";

            using (OleDbConnection conn = new OleDbConnection(_ConnString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("StatementsNumber", StatementsNumber);
                    cmd.Parameters.AddWithValue("GroupsId", GroupsId);
                    cmd.Parameters.AddWithValue("DisciplineId", DisciplineId);
                    cmd.Parameters.AddWithValue("TechniqueId", TechniqueId);
                    cmd.Parameters.AddWithValue("DateOfCompletion", DateOfCompletion.ToString());
                    cmd.Parameters.AddWithValue("EndDate", EndDate.ToString());
                    cmd.Parameters.AddWithValue("StatementsId", StatementsId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void DeleteStatementsByStatementsId(int StatementsId)
        {
            string SqlString = "DELETE FROM Statements WHERE StatementsId=" + StatementsId.ToString();
            using (OleDbConnection conn = new OleDbConnection(_ConnString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public int GetLastRecords()
        {
            int lastRecordNumber = 0;
            string SqlString = "Select LAST (StatementsId) From Statements ";
            using (OleDbConnection conn = new OleDbConnection(_ConnString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                {
                    conn.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lastRecordNumber = Convert.ToInt32(reader.GetValue(0));
                        }
                    }
                }
                conn.Close();
            }
            return lastRecordNumber;
        }

    }
}

public class Statements
{
    private int _Number;
    private int _StatementsId;
    private string _StatementsNumber;
    private int _GroupsId;
    private int _DisciplineId;
    private int _TeacherId;
    private DateTime _DateOfCompletion;
    private string _Message;

    public Statements()
    {
        _Number = 0;
        _StatementsId = 0;
        _StatementsNumber = String.Empty;
        _GroupsId = 0;
        _DisciplineId = 0;
        _TeacherId = 0;
        _DateOfCompletion = new DateTime();
        _Message = String.Empty;
    }

    public int Number
    {
        set { _Number = value; }
        get { return _Number; }
    }
    public int StatementsId
    {
        set { _StatementsId = value; }
        get { return _StatementsId; }
    }
    public string StatementsNumber
    {
        set { _StatementsNumber = value; }
        get { return _StatementsNumber; }
    }
    public int GroupsId
    {
        set { _GroupsId = value; }
        get { return _GroupsId; }
    }
    public int DisciplineId
    {
        set { _DisciplineId = value; }
        get { return _DisciplineId; }
    }

    public int TeacherId
    {
        set { _TeacherId = value; }
        get { return _TeacherId; }
    }

    public DateTime DateOfCompletion
    {
        set { _DateOfCompletion = value; }
        get { return _DateOfCompletion; }
    }
    public string Message
    {
        set { _Message = value; }
        get { return _Message; }
    }
}
