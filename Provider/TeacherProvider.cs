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
    class TeacherProvider
    {
        private string _ConnString = System.Configuration.ConfigurationSettings.AppSettings["CONNECT"];
        public void InsertTeacher(string LastName, string FirstName, string Phone, string Address, string Email)
        {
            string SqlString = "INSERT INTO Teachers (LastName, FirstName, Phone, Address, " +
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

        public List<Teacher> GetAllTeachers()
        {
            int i = 0;
            string SqlString = "SELECT * FROM Teachers";

            List<Teacher> listAllTeachers = new List<Teacher>();
            using (OleDbConnection conn = new OleDbConnection(_ConnString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                {
                    conn.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Teacher oneStudent = new Teacher();
                            oneStudent.Number = ++i;
                            oneStudent.TeacherId = Convert.ToInt32(reader["TeacherId"].ToString());
                            oneStudent.FirstName = reader["FirstName"].ToString();
                            oneStudent.LastName = reader["LastName"].ToString();
                            oneStudent.FIO = oneStudent.LastName + " " + oneStudent.FirstName;
                            oneStudent.Phone = reader["Phone"].ToString();
                            oneStudent.Address = reader["Address"].ToString();
                            oneStudent.Email = reader["Email"].ToString();
                            listAllTeachers.Add(oneStudent);
                        }
                    }
                    conn.Close();
                }
            }

            if (listAllTeachers.Count == 0)
            {
                Teacher noTeacher = new Teacher();
                noTeacher.TeacherId = 0;
                noTeacher.Message = NamesMy.NoDataNames.NoDataInStudent;
                listAllTeachers.Add(noTeacher);
            }
            return listAllTeachers;
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

        public Teacher SelectedStudentByStudentId(int TeacherId)
        {
            string SqlString = "SELECT * FROM Teachers Where TeacherId=" + TeacherId.ToString();

            Teacher oneTeacher = new Teacher();
            using (OleDbConnection conn = new OleDbConnection(_ConnString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                {
                    conn.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            oneTeacher.TeacherId = Convert.ToInt32(reader["TeacherId"].ToString());
                            oneTeacher.FirstName = reader["FirstName"].ToString();
                            oneTeacher.LastName = reader["LastName"].ToString();
                            oneTeacher.FIO = oneTeacher.LastName + " " + oneTeacher.FirstName;
                            oneTeacher.Phone = reader["Phone"].ToString();
                            oneTeacher.Address = reader["Address"].ToString();
                            oneTeacher.Email = reader["Email"].ToString();
                        }
                    }
                }
                conn.Close();
            }
            return oneTeacher;
        }

        public void UpdateTeacher(string LastName, string FirstName, string Phone, string Address, string Email, int TeacherId)
        {
            string SqlString = "UPDATE Teachers SET FirstName=?, LastName=?, Phone=?, " +
        "Address=?, Email=? WHERE TeacherId=?";

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
                    cmd.Parameters.AddWithValue("TeacherId", TeacherId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void DeleteTeacherByTeacherId(int TeacherId)
        {
            string SqlString = "DELETE FROM Teachers WHERE TeacherId=" + TeacherId.ToString();
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


public class Teacher
{
    private int _Number;
    private int _TeacherId;
    private string _FirstName;
    private string _LastName;
    private string _Phone;
    private string _Address;
    private string _Email;    
    private string _FIO;
    private string _Message;

    public Teacher()
    {
        _Number = 0;
        _TeacherId = 0;
        _FirstName = String.Empty;
        _LastName = String.Empty;
        _Phone = String.Empty;
        _Address = String.Empty;
        _Email = String.Empty;
        _FIO = String.Empty;
        _Message = String.Empty;
    }

    public int Number
    {
        set { _Number = value; }
        get { return _Number; }
    }
    public int TeacherId
    {
        set { _TeacherId = value; }
        get { return _TeacherId; }
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

