using SoftwareVVNZ.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareVVNZ.Provider {
  class LogsProvider {
    private string _ConnString = System.Configuration.ConfigurationSettings.AppSettings["CONNECT"];
    public void InsertLogs(int UsersId, string EventNameShow, DateTime EvendDate) {
      string SqlString = "INSERT INTO Logs (UsersId, EventNameShow, EvendDate) Values(?, ?, ?)";
      using (OleDbConnection conn = new OleDbConnection(_ConnString)) {
        using (OleDbCommand cmd = new OleDbCommand(SqlString, conn)) {
          cmd.CommandType = CommandType.Text;
          cmd.Parameters.AddWithValue("UsersId", UsersId);
          cmd.Parameters.AddWithValue("EventNameShow", EventNameShow);
          cmd.Parameters.AddWithValue("EvendDate", EvendDate.ToString());
          conn.Open();
          cmd.ExecuteNonQuery();
          conn.Close();
        }
      }
    }

    public List<Logs> GetAllLogs() {
      int i = 0;
      string SqlString = "SELECT Logs.LogsId, Logs.UsersId, Logs.EventNameShow, Logs.EvendDate, Users.UsersName " +
      "FROM Logs INNER JOIN Users ON Users.UsersId = Logs.UsersId  ORDER BY Logs.EvendDate DESC";
      List<Logs> listAllLogs = new List<Logs>();
      using (OleDbConnection conn = new OleDbConnection(_ConnString)) {
        using (OleDbCommand cmd = new OleDbCommand(SqlString, conn)) {
          conn.Open();
          using (OleDbDataReader reader = cmd.ExecuteReader()) {
            while (reader.Read()) {
              Logs oneLogs = new Logs();
              oneLogs.Number = ++i;
              oneLogs.LogsId = Convert.ToInt32(reader["LogsId"]);
              oneLogs.UsersId = Convert.ToInt32(reader["UsersId"]);
              oneLogs.EventNameShow = reader["EventNameShow"].ToString();
              oneLogs.EvendDate = Convert.ToDateTime(reader["EvendDate"]);
              oneLogs.UsersName = reader["UsersName"].ToString();
              listAllLogs.Add(oneLogs);
            }
          }
          conn.Close();
        }
      }

      if (listAllLogs.Count == 0) {
        Logs noLogs = new Logs();
        noLogs.LogsId = 0;
        noLogs.Message = NamesMy.NoDataNames.NoDataInLogs;
        listAllLogs.Add(noLogs);
      }
      return listAllLogs;

    }

  }
}



public class Logs {
  private int _Number;
  private int _LogsId;
  private int _UsersId;
  private string _UsersName;
  private string _EventNameShow;
  private DateTime _EvendDate;
  private string _Message;

  public Logs() {
    _Number = 0;
    _LogsId = 0;
    _UsersId = 0;
    _UsersName = String.Empty;
    _EventNameShow = String.Empty;
    _EvendDate = new DateTime();
    _Message = String.Empty;
  }

  public int Number {
    set { _Number = value; }
    get { return _Number; }
  }
  public int LogsId {
    set { _LogsId = value; }
    get { return _LogsId; }
  }
  public int UsersId {
    set { _UsersId = value; }
    get { return _UsersId; }
  }
  public string UsersName {
    set { _UsersName = value; }
    get { return _UsersName; }
  }
  public string EventNameShow {
    set { _EventNameShow = value; }
    get { return _EventNameShow; }
  }
  public DateTime EvendDate {
    set { _EvendDate = value; }
    get { return _EvendDate; }
  }
  public string Message {
    set { _Message = value; }
    get { return _Message; }
  }
}
