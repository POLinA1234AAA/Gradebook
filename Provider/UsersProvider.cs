using SoftwareVVNZ.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareVVNZ.Provider {
  class UsersProvider {
    private EncryptData _encryptData = new EncryptData();
    private string _ConnString = System.Configuration.ConfigurationSettings.AppSettings["CONNECT"];

    public void InsertUsers(string FirstName, string LastName, string UsersName, string UsersPassword,
   int RoleId, string Description) {
      string SqlString = "INSERT INTO Users (FirstName, LastName, UsersName, UsersPassword, " +
       "RoleId, Description) Values(?, ?, ?, ?, ?, ?)";

      using (OleDbConnection conn = new OleDbConnection(_ConnString)) {
        using (OleDbCommand cmd = new OleDbCommand(SqlString, conn)) {
          cmd.CommandType = CommandType.Text;
          cmd.Parameters.AddWithValue("FirstName", FirstName);
          cmd.Parameters.AddWithValue("LastName", LastName);
          cmd.Parameters.AddWithValue("UsersName", UsersName);
          cmd.Parameters.AddWithValue("UsersPassword", _encryptData.Encrypt(UsersPassword));
          cmd.Parameters.AddWithValue("RoleId", RoleId);
          cmd.Parameters.AddWithValue("Description", Description);
          conn.Open();
          cmd.ExecuteNonQuery();
          conn.Close();
        }
      }
    }

    public List<Users> GetAllUsers() {
      int i = 0;
      string SqlString = "SELECT * FROM Users ORDER BY LastName ASC";
      List<Users> listAllUsers = new List<Users>();
      using (OleDbConnection conn = new OleDbConnection(_ConnString)) {
        using (OleDbCommand cmd = new OleDbCommand(SqlString, conn)) {
          conn.Open();
          using (OleDbDataReader reader = cmd.ExecuteReader()) {
            while (reader.Read()) {
              Users oneUsers = new Users();
              oneUsers.Number = ++i;
              oneUsers.UsersId = Convert.ToInt32(reader["UsersId"]);
              oneUsers.FirstName = reader["FirstName"].ToString();
              oneUsers.LastName = reader["LastName"].ToString();
              oneUsers.FIO = oneUsers.LastName + " " + oneUsers.FirstName;
              oneUsers.UsersName = reader["UsersName"].ToString();
              oneUsers.UsersPassword = _encryptData.Decrypt(reader["UsersPassword"].ToString());
              oneUsers.RoleId = Convert.ToInt32(reader["RoleId"]);
              oneUsers.RoleName = GetRoleName(oneUsers.RoleId);
              oneUsers.Description = reader["Description"].ToString();
              listAllUsers.Add(oneUsers);
            }
          }
          conn.Close();
        }
      }

      if (listAllUsers.Count == 0) {
        Users noUsers = new Users();
        noUsers.UsersId = 0;
        noUsers.Message = NamesMy.NoDataNames.NoDataInUsers;
        listAllUsers.Add(noUsers);
      }
      return listAllUsers;
    }

    private string GetRoleName(int RoleId) {
      RoleApp roleApp = new RoleApp();
      for (int i = 0; i < roleApp.GetRoleList().Count(); i++) {
        if (RoleId == roleApp.GetRoleList()[i].RoleId) {
          return roleApp.GetRoleList()[i].RoleName;
        }
      }
      return "";
    }

    public Users SelectedUsersByUsersId(int UsersId) {
      string SqlString = "SELECT * FROM Users WHERE UsersId=" + UsersId.ToString();

      Users oneUsers = new Users();
      using (OleDbConnection conn = new OleDbConnection(_ConnString)) {
        using (OleDbCommand cmd = new OleDbCommand(SqlString, conn)) {
          conn.Open();
          using (OleDbDataReader reader = cmd.ExecuteReader()) {
            while (reader.Read()) {
              oneUsers.UsersId = Convert.ToInt32(reader["UsersId"]);
              oneUsers.FirstName = reader["FirstName"].ToString();
              oneUsers.LastName = reader["LastName"].ToString();
              oneUsers.UsersName = reader["UsersName"].ToString();
              oneUsers.FIO = oneUsers.LastName + " " + oneUsers.FirstName;
              oneUsers.UsersPassword = _encryptData.Decrypt(reader["UsersPassword"].ToString());
              oneUsers.RoleId = Convert.ToInt32(reader["RoleId"]);
              oneUsers.Description = reader["Description"].ToString();
            }
          }
        }
        conn.Close();
      }
      return oneUsers;
    }

    public List<Users> GetAllUsersListForCBox() {
      string SqlString = "SELECT UsersId, UsersName, UsersPassword FROM Users ORDER BY UsersName ASC";
      List<Users> listAllUsers = new List<Users>();

      using (OleDbConnection conn = new OleDbConnection(_ConnString)) {
        using (OleDbCommand cmd = new OleDbCommand(SqlString, conn)) {
          conn.Open();
          using (OleDbDataReader reader = cmd.ExecuteReader()) {
            while (reader.Read()) {
              Users oneUsers = new Users();
              oneUsers.UsersId = Convert.ToInt32(reader["UsersId"].ToString());
              oneUsers.UsersName = reader["UsersName"].ToString();
              oneUsers.UsersPassword = _encryptData.Decrypt(reader["UsersPassword"].ToString());
              listAllUsers.Add(oneUsers);
            }
          }
          conn.Close();
        }
      }

      if (listAllUsers.Count == 0) {
        Users noUsers = new Users();
        noUsers.UsersId = 0;
        noUsers.Message = NamesMy.NoDataNames.NoDataInUsers;
        listAllUsers.Add(noUsers);
      }
      return listAllUsers;
    }

    public List<Users> SelectedUsersByUsersNameAndUsersPassword(string UsersName, string UsersPassword) {
      string SqlString = "SELECT * FROM Users WHERE UsersName='" + UsersName + "' AND UsersPassword='" + _encryptData.Encrypt(UsersPassword) + "'";
      List<Users> UsersList = new List<Users>();

      using (OleDbConnection conn = new OleDbConnection(_ConnString)) {
        using (OleDbCommand cmd = new OleDbCommand(SqlString, conn)) {
          conn.Open();
          using (OleDbDataReader reader = cmd.ExecuteReader()) {
            while (reader.Read()) {
              Users oneUsers = new Users();
              oneUsers.UsersId = Convert.ToInt32(reader["UsersId"]);
              oneUsers.FirstName = reader["FirstName"].ToString();
              oneUsers.LastName = reader["LastName"].ToString();
              oneUsers.UsersName = reader["UsersName"].ToString();
              oneUsers.FIO = oneUsers.LastName + " " + oneUsers.FirstName;
              oneUsers.UsersPassword = _encryptData.Decrypt(reader["UsersPassword"].ToString());
              oneUsers.RoleId = Convert.ToInt32(reader["RoleId"]);
              oneUsers.Description = reader["Description"].ToString();
              UsersList.Add(oneUsers);
            }
          }
        }
        conn.Close();
      }
      return UsersList;
    }

    public void UpdateUsers(string FirstName, string LastName, string UsersName, string UsersPassword,
   int RoleId, string Description, int UsersId) {
      string SqlString = "UPDATE Users SET FirstName=?, LastName=?, " +
   "UsersName=?, UsersPassword=?, RoleId=?, Description=? WHERE UsersId=?";

      using (OleDbConnection conn = new OleDbConnection(_ConnString)) {
        using (OleDbCommand cmd = new OleDbCommand(SqlString, conn)) {
          cmd.CommandType = CommandType.Text;
          cmd.Parameters.AddWithValue("FirstName", FirstName);
          cmd.Parameters.AddWithValue("LastName", LastName);
          cmd.Parameters.AddWithValue("UsersName", UsersName);
          cmd.Parameters.AddWithValue("UsersPassword", _encryptData.Encrypt(UsersPassword));
          cmd.Parameters.AddWithValue("RoleId", RoleId);
          cmd.Parameters.AddWithValue("Description", Description);
          cmd.Parameters.AddWithValue("UsersId", UsersId);
          conn.Open();
          cmd.ExecuteNonQuery();
          conn.Close();
        }
      }
    }

    public void DeleteUsersByUsersId(int UsersId) {
      string SqlString = "DELETE FROM Users WHERE UsersId=" + UsersId.ToString();
      using (OleDbConnection conn = new OleDbConnection(_ConnString)) {
        using (OleDbCommand cmd = new OleDbCommand(SqlString, conn)) {
          conn.Open();
          cmd.ExecuteNonQuery();
          conn.Close();
        }
      }
    }

  }
}


public class Users {
  private int _Number;
  private int _UsersId;
  private string _FirstName;
  private string _LastName;
  private string _UsersName;
  private string _FIO;
  private string _UsersPassword;
  private int _RoleId;
  private string _RoleName;
  private string _Description;
  private string _Message;

  public Users() {
    _UsersId = 0;
    _FirstName = String.Empty;
    _LastName = String.Empty;
    _UsersName = String.Empty;
    _FIO = String.Empty;
    _UsersPassword = String.Empty;
    _RoleId = 0;
    _Description = String.Empty;
  }

  public int Number {
    set { _Number = value; }
    get { return _Number; }
  }
  public int UsersId {
    set { _UsersId = value; }
    get { return _UsersId; }
  }
  public string FirstName {
    set { _FirstName = value; }
    get { return _FirstName; }
  }
  public string LastName {
    set { _LastName = value; }
    get { return _LastName; }
  }
  public string FIO {
    set { _FIO = value; }
    get { return _FIO; }
  }
  public string UsersName {
    set { _UsersName = value; }
    get { return _UsersName; }
  }
  public string UsersPassword {
    set { _UsersPassword = value; }
    get { return _UsersPassword; }
  }
  public int RoleId {
    set { _RoleId = value; }
    get { return _RoleId; }
  }
  public string RoleName {
    set { _RoleName = value; }
    get { return _RoleName; }
  }
  public string Description {
    set { _Description = value; }
    get { return _Description; }
  }
  public string Message {
    set { _Message = value; }
    get { return _Message; }
  }
}

