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
    class StudentProvider
    {
        private string _ConnString = System.Configuration.ConfigurationSettings.AppSettings["CONNECT"];
        public void InsertStudent(string LastName, string FirstName, string Phone, string Address, string Email, int GroupsId)
        {
            string SqlString = "INSERT INTO Student (LastName, FirstName, Phone, Address, " +
              "Email, GroupsId) Values(?, ?, ?, ?, ?, ?)";

            using (OleDbConnection conn = new OleDbConnection(_ConnString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("LastName", LastName);
                    cmd.Parameters.AddWithValue("FirstName", FirstName);
                    cmd.Parameters.AddWithValue("Phone", Phone);
                    cmd.Parameters.AddWithValue("Address", Address);
                    cmd.Parameters.AddWithValue("Email", Email);
                    cmd.Parameters.AddWithValue("GroupsId", GroupsId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void InsertTeacher(string LastName, string FirstName, string Phone, string Address, string Email)
        {
            string SqlString = "INSERT INTO Student (LastName, FirstName, Phone, Address, " +
              "Email) Values(?, ?, ?, ?, ?)";

            using (OleDbConnection conn = new OleDbConnection(_ConnString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("LastName", LastName);
                    cmd.Parameters.AddWithValue("FirstName", FirstName);
                    cmd.Parameters.AddWithValue("Phone", Phone);
                    cmd.Parameters.AddWithValue("Address", Address);
                    cmd.Parameters.AddWithValue("Email", Email);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }



        public List<Student> GetAllStudent()
        {
            int i = 0;
            string SqlString = "SELECT * FROM Student";

            List<Student> listAllStudent = new List<Student>();
            using (OleDbConnection conn = new OleDbConnection(_ConnString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                {
                    conn.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Student oneStudent = new Student();
                            oneStudent.Number = ++i;
                            oneStudent.StudentId = Convert.ToInt32(reader["StudentId"].ToString());
                            oneStudent.FirstName = reader["FirstName"].ToString();
                            oneStudent.LastName = reader["LastName"].ToString();
                            oneStudent.FIO = oneStudent.LastName + " " + oneStudent.FirstName;
                            oneStudent.Phone = reader["Phone"].ToString();
                            oneStudent.Address = reader["Address"].ToString();
                            oneStudent.Email = reader["Email"].ToString();
                            oneStudent.GroupsId = Convert.ToInt32(reader["GroupsId"].ToString());
                            listAllStudent.Add(oneStudent);
                        }
                    }
                    conn.Close();
                }
            }

            if (listAllStudent.Count == 0)
            {
                Student noStudent = new Student();
                noStudent.StudentId = 0;
                noStudent.Message = NamesMy.NoDataNames.NoDataInStudent;
                listAllStudent.Add(noStudent);
            }
            return listAllStudent;
        }

        public List<Student> GetAllStudentByGroupId(int GroupsId)
        {
            int i = 0;
            string SqlString = "SELECT * FROM Student WHERE GroupsId=" + GroupsId.ToString();

            List<Student> listAllStudent = new List<Student>();
            using (OleDbConnection conn = new OleDbConnection(_ConnString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                {
                    conn.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Student oneStudent = new Student();
                            oneStudent.Number = ++i;
                            oneStudent.StudentId = Convert.ToInt32(reader["StudentId"].ToString());
                            oneStudent.FirstName = reader["FirstName"].ToString();
                            oneStudent.LastName = reader["LastName"].ToString();
                            oneStudent.FIO = oneStudent.LastName + " " + oneStudent.FirstName;
                            oneStudent.Phone = reader["Phone"].ToString();
                            oneStudent.Address = reader["Address"].ToString();
                            oneStudent.Email = reader["Email"].ToString();
                            oneStudent.GroupsId = Convert.ToInt32(reader["GroupsId"].ToString());
                            listAllStudent.Add(oneStudent);
                        }
                    }
                    conn.Close();
                }
            }

            if (listAllStudent.Count == 0)
            {
                Student noStudent = new Student();
                noStudent.StudentId = 0;
                noStudent.Message = NamesMy.NoDataNames.NoDataInStudent;
                listAllStudent.Add(noStudent);
            }
            return listAllStudent;
        }

        public Student SelectedStudentByStudentId(int StudentId)
        {
            string SqlString = "SELECT * FROM Student Where StudentId=" + StudentId.ToString();

            Student oneStudent = new Student();
            using (OleDbConnection conn = new OleDbConnection(_ConnString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                {
                    conn.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            oneStudent.StudentId = Convert.ToInt32(reader["StudentId"].ToString());
                            oneStudent.FirstName = reader["FirstName"].ToString();
                            oneStudent.LastName = reader["LastName"].ToString();
                            oneStudent.FIO = oneStudent.LastName + " " + oneStudent.FirstName;
                            oneStudent.Phone = reader["Phone"].ToString();
                            oneStudent.Address = reader["Address"].ToString();
                            oneStudent.Email = reader["Email"].ToString();
                            oneStudent.GroupsId = Convert.ToInt32(reader["GroupsId"].ToString());
                        }
                    }
                }
                conn.Close();
            }
            return oneStudent;
        }

        public void UpdateStudent(string LastName, string FirstName, string Phone, string Address, string Email, int GroupsId, int StudentId)
        {
            string SqlString = "UPDATE Student SET FirstName=?, LastName=?, Phone=?, " +
        "Address=?, Email=?, GroupsId=? WHERE StudentId=?";

            using (OleDbConnection conn = new OleDbConnection(_ConnString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("FirstName", FirstName);
                    cmd.Parameters.AddWithValue("LastName", LastName);
                    cmd.Parameters.AddWithValue("Phone", Phone);
                    cmd.Parameters.AddWithValue("Address", Address);
                    cmd.Parameters.AddWithValue("Email", Email);
                    cmd.Parameters.AddWithValue("GroupsId", GroupsId);
                    cmd.Parameters.AddWithValue("StudentId", StudentId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void DeleteStudentByStudentId(int StudentId)
        {
            string SqlString = "DELETE FROM Student WHERE StudentId=" + StudentId.ToString();
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


public class Student
{
    private int _Number;
    private int _StudentId;
    private string _FirstName;
    private string _LastName;
    private string _Phone;
    private string _Address;
    private string _Email;
    private int _GroupsId;
    private string _FIO;
    private string _Message;

    public Student()
    {
        _Number = 0;
        _StudentId = 0;
        _FirstName = String.Empty;
        _LastName = String.Empty;
        _Phone = String.Empty;
        _Address = String.Empty;
        _Email = String.Empty;
        _GroupsId = 0;
        _FIO = String.Empty;
        _Message = String.Empty;
    }

    public int Number
    {
        set { _Number = value; }
        get { return _Number; }
    }
    public int StudentId
    {
        set { _StudentId = value; }
        get { return _StudentId; }
    }
    public string FirstName
    {
        set { _FirstName = value; }
        get { return _FirstName; }
    }
    public string LastName
    {
        set { _LastName = value; }
        get { return _LastName; }
    }
    public string Phone
    {
        set { _Phone = value; }
        get { return _Phone; }
    }
    public string Address
    {
        set { _Address = value; }
        get { return _Address; }
    }
    public string Email
    {
        set { _Email = value; }
        get { return _Email; }
    }
    public int GroupsId
    {
        set { _GroupsId = value; }
        get { return _GroupsId; }
    }
    public string FIO
    {
        set { _FIO = value; }
        get { return _FIO; }
    }
    public string Message
    {
        set { _Message = value; }
        get { return _Message; }
    }
}

