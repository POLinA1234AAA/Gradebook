using SoftwareVVNZ.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareVVNZ.Provider {
  class GroupsProvider {
    private string _ConnString = System.Configuration.ConfigurationSettings.AppSettings["CONNECT"];

    public void InsertGroups(string GroupsName, string Description) {
      string SqlString = "INSERT INTO Groups (GroupsName, Description" +
        ") Values(?, ?)";

      using (OleDbConnection conn = new OleDbConnection(_ConnString)) {
        using (OleDbCommand cmd = new OleDbCommand(SqlString, conn)) {
          cmd.CommandType = CommandType.Text;
          cmd.Parameters.AddWithValue("GroupsName", GroupsName);
          cmd.Parameters.AddWithValue("Description", Description);
          conn.Open();
          cmd.ExecuteNonQuery();
          conn.Close();
        }
      }
    }

    public List<Groups> GetAllGroups() {
      int i = 0;
      string SqlString = "SELECT GroupsId, GroupsName, Description " +
        "FROM Groups";

      List<Groups> listGroups = new List<Groups>();
      using (OleDbConnection conn = new OleDbConnection(_ConnString)) {
        using (OleDbCommand cmd = new OleDbCommand(SqlString, conn)) {
          conn.Open();
          using (OleDbDataReader reader = cmd.ExecuteReader()) {
            while (reader.Read()) {
              Groups oneGroups = new Groups();
              oneGroups.Number = ++i;
              oneGroups.GroupsId = Convert.ToInt32(reader["GroupsId"].ToString());
              oneGroups.GroupsName = reader["GroupsName"].ToString();
              oneGroups.Description = reader["Description"].ToString();
              listGroups.Add(oneGroups);
            }
          }
          conn.Close();
        }
      }

      if (listGroups.Count == 0) {
        Groups noGroups = new Groups();
        noGroups.GroupsId = 0;
        noGroups.Message = NamesMy.NoDataNames.NoDataInGroups;
        listGroups.Add(noGroups);
      }
      return listGroups;
    }

    public Groups SelectedGroupsByGroupsId(int GroupsId) {
      string SqlString = "SELECT GroupsId, GroupsName, Description " +
        "FROM Groups Where GroupsId=" + GroupsId.ToString();

      Groups oneGroups = new Groups();
      using (OleDbConnection conn = new OleDbConnection(_ConnString)) {
        using (OleDbCommand cmd = new OleDbCommand(SqlString, conn)) {
          conn.Open();
          using (OleDbDataReader reader = cmd.ExecuteReader()) {
            while (reader.Read()) {
              oneGroups.GroupsId = Convert.ToInt32(reader["GroupsId"].ToString());
              oneGroups.GroupsName = reader["GroupsName"].ToString();
              oneGroups.Description = reader["Description"].ToString();
            }
          }
        }
        conn.Close();
      }
      return oneGroups;
    }

    public void UpdateGroups(string GroupsName, string Description, int GroupsId) {
      string SqlString = "UPDATE Groups SET GroupsName=?, Description=?  " +
  "WHERE GroupsId=?";

      using (OleDbConnection conn = new OleDbConnection(_ConnString)) {
        using (OleDbCommand cmd = new OleDbCommand(SqlString, conn)) {
          cmd.CommandType = CommandType.Text;
          cmd.Parameters.AddWithValue("GroupsName", GroupsName);
          cmd.Parameters.AddWithValue("Description", Description);
          cmd.Parameters.AddWithValue("GroupsId", GroupsId);
          conn.Open();
          cmd.ExecuteNonQuery();
          conn.Close();
        }
      }
    }

    public void DeleteGroupsByGroupsId(int GroupsId) {
      string SqlString = "DELETE FROM Groups WHERE GroupsId=" + GroupsId.ToString();
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


public class Groups {
  private int _Number;
  private int _GroupsId;
  private string _GroupsName;
  private string _Description;
  private string _Message;

  public Groups() {
    _Number = 0;
    _GroupsId = 0;
    _GroupsName = String.Empty;
    _Description = String.Empty;
    _Message = String.Empty;
  }

  public int Number {
    set { _Number = value; }
    get { return _Number; }
  }
  public int GroupsId {
    set { _GroupsId = value; }
    get { return _GroupsId; }
  }
  public string GroupsName {
    set { _GroupsName = value; }
    get { return _GroupsName; }
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

