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
    class RatingsProvider
    {
        private string _ConnString = System.Configuration.ConfigurationSettings.AppSettings["CONNECT"];

        public void InsertRatings(int StudentId, int StatementsId, int DisciplineId, int SubjectMark, int GroupsId, int TeacherID)
        {
            string SqlString = "INSERT INTO Ratings (StudentId, StatementsId, DisciplineId, SubjectMark, GroupsId, TeacherId" +
              ") Values(?, ?, ?, ?, ?, ?)";
            using (OleDbConnection conn = new OleDbConnection(_ConnString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("StudentId", StudentId);
                    cmd.Parameters.AddWithValue("StatementsId", StatementsId);
                    cmd.Parameters.AddWithValue("DisciplineId", DisciplineId);
                    cmd.Parameters.AddWithValue("GroupsId", GroupsId);
                    cmd.Parameters.AddWithValue("SubjectMark", SubjectMark);
                    cmd.Parameters.AddWithValue("TeacherId", TeacherID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void InsertBatchRatings(List<Ratings> Ratings)
        {
            string SqlString = "INSERT INTO Ratings (StudentId, StatementsId, DisciplineId, SubjectMark, GroupsId, TeacherId) Values(?, ?, ?, ?, ?, ?)";
            using (OleDbConnection conn = new OleDbConnection(_ConnString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    for (int i = 0; i < Ratings.Count; i++)
                    {
                        cmd.Parameters.AddWithValue("StudentId", Ratings[i].StudentId);
                        cmd.Parameters.AddWithValue("StatementsId", Ratings[i].StatementsId);
                        cmd.Parameters.AddWithValue("DisciplineId", Ratings[i].DisciplineId);
                        cmd.Parameters.AddWithValue("SubjectMark", Ratings[i].SubjectMark);
                        cmd.Parameters.AddWithValue("GroupsId", Ratings[i].GroupsId);
                        cmd.Parameters.AddWithValue("TeacherId", Ratings[i].TeacherId);
                        cmd.ExecuteNonQuery();
                        while (cmd.Parameters.Count > 0)
                        {
                            cmd.Parameters.RemoveAt(0);
                        }
                    }
                    conn.Close();
                }
            }
        }

        public List<Ratings> GetAllRatingsByStatementsId(int StatementsId)
        {
            int i = 0;
            string SqlString = "SELECT * FROM Ratings WHERE StatementsId=" + StatementsId;

            List<Ratings> Ratings = new List<Ratings>();
            using (OleDbConnection conn = new OleDbConnection(_ConnString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                {
                    conn.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Ratings oneRatings = new Ratings();
                            oneRatings.Number = ++i;
                            oneRatings.StudentId = Convert.ToInt32(reader["StudentId"]);
                            oneRatings.StatementsId = Convert.ToInt32(reader["StatementsId"]);
                            oneRatings.DisciplineId = Convert.ToInt32(reader["DisciplineId"]);
                            oneRatings.SubjectMark = Convert.ToInt32(reader["SubjectMark"]);
                            oneRatings.GroupsId = Convert.ToInt32(reader["GroupsId"]);
                            oneRatings.TeacherId = Convert.ToInt32(reader["TeacherId"]);
                            Ratings.Add(oneRatings);
                        }
                    }
                    conn.Close();
                }
            }
            return Ratings;
        }

        public List<Ratings> GetAllRatingsByStudentId(int StudentId)
        {
            int i = 0;
            string SqlString = "SELECT * FROM Ratings WHERE StudentId=" + StudentId;

            List<Ratings> Ratings = new List<Ratings>();
            using (OleDbConnection conn = new OleDbConnection(_ConnString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                {
                    conn.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Ratings oneRatings = new Ratings();
                            oneRatings.Number = ++i;
                            oneRatings.StudentId = Convert.ToInt32(reader["StudentId"]);
                            oneRatings.StatementsId = Convert.ToInt32(reader["StatementsId"]);
                            oneRatings.DisciplineId = Convert.ToInt32(reader["DisciplineId"]);
                            oneRatings.SubjectMark = Convert.ToInt32(reader["SubjectMark"]);
                            oneRatings.GroupsId = Convert.ToInt32(reader["GroupsId"]);
                            oneRatings.TeacherId = Convert.ToInt32(reader["TeacherId"]);
                            Ratings.Add(oneRatings);
                        }
                    }
                    conn.Close();
                }
            }
            return Ratings;
        }

        public List<Ratings> GetAllRatingsByGroupsId(int GroupsId)
        {
            int i = 0;
            string SqlString = "SELECT * FROM Ratings WHERE GroupsId=" + GroupsId;

            List<Ratings> Ratings = new List<Ratings>();
            using (OleDbConnection conn = new OleDbConnection(_ConnString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                {
                    conn.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Ratings oneRatings = new Ratings();
                            oneRatings.Number = ++i;
                            oneRatings.StudentId = Convert.ToInt32(reader["StudentId"]);
                            oneRatings.StatementsId = Convert.ToInt32(reader["StatementsId"]);
                            oneRatings.DisciplineId = Convert.ToInt32(reader["DisciplineId"]);
                            oneRatings.SubjectMark = Convert.ToInt32(reader["SubjectMark"]);
                            oneRatings.GroupsId = Convert.ToInt32(reader["GroupsId"]);
                            oneRatings.TeacherId = Convert.ToInt32(reader["TeacherId"]);
                            Ratings.Add(oneRatings);
                        }
                    }
                    conn.Close();
                }
            }
            return Ratings;
        }

        public List<Ratings> GetAllRatings()
        {
            int i = 0;
            string SqlString = "SELECT * FROM Ratings ";

            List<Ratings> Ratings = new List<Ratings>();
            using (OleDbConnection conn = new OleDbConnection(_ConnString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                {
                    conn.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Ratings oneRatings = new Ratings();
                            oneRatings.Number = ++i;
                            oneRatings.StudentId = Convert.ToInt32(reader["StudentId"]);
                            oneRatings.StatementsId = Convert.ToInt32(reader["StatementsId"]);
                            oneRatings.DisciplineId = Convert.ToInt32(reader["DisciplineId"]);
                            oneRatings.SubjectMark = Convert.ToInt32(reader["SubjectMark"]);
                            oneRatings.GroupsId = Convert.ToInt32(reader["GroupsId"]);
                            oneRatings.TeacherId = Convert.ToInt32(reader["TeacherID"]);
                            Ratings.Add(oneRatings);
                        }
                    }
                    conn.Close();
                }
            }
            return Ratings;
        }

        public void DeleteRatingsByStatementsId(int StatementsId)
        {
            string SqlString = "DELETE FROM Ratings WHERE StatementsId=" + StatementsId.ToString();
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

    }
}



public class Ratings
{
    private int _Number;
    private int _RatingsId;
    private int _StudentId;
    private string _FIO;
    private int _StatementsId;
    private int _DisciplineId;
    private int _GroupsId;

    private int _TeacherId;

    private int _SubjectMark;
    private string _SimbolMark;
    private string _FiveBallMark;
    private string _Message;

    public Ratings()
    {
        _Number = 0;
        _RatingsId = 0;
        _StudentId = 0;
        _FIO = String.Empty;
        _StatementsId = 0;
        _DisciplineId = 0;
        _GroupsId = 0;
        _SubjectMark = 0;
        _TeacherId = 0;
        _SimbolMark = String.Empty;
        _FiveBallMark = String.Empty;
        _Message = String.Empty;
    }

    public int TeacherId
    {
        set { _TeacherId = value; }
        get { return _TeacherId; }
    }

    public int Number
    {
        set { _Number = value; }
        get { return _Number; }
    }
    public int RatingsId
    {
        set { _RatingsId = value; }
        get { return _RatingsId; }
    }
    public int StudentId
    {
        set { _StudentId = value; }
        get { return _StudentId; }
    }
    public string FIO
    {
        set { _FIO = value; }
        get { return _FIO; }
    }
    public int StatementsId
    {
        set { _StatementsId = value; }
        get { return _StatementsId; }
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
    public int SubjectMark
    {
        set { _SubjectMark = value; }
        get { return _SubjectMark; }
    }
    public string SimbolMark
    {
        set { _SimbolMark = value; }
        get { return _SimbolMark; }
    }
    public string FiveBallMark
    {
        set { _FiveBallMark = value; }
        get { return _FiveBallMark; }
    }
    public string Message
    {
        set { _Message = value; }
        get { return _Message; }
    }
}
