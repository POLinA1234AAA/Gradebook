using SoftwareVVNZ.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareVVNZ.Provider {
  class DisciplineProvider {
    private string _ConnString = System.Configuration.ConfigurationSettings.AppSettings["CONNECT"];

    public void InsertDiscipline(string DisciplineName, string Description) {
      string SqlString = "INSERT INTO Discipline (DisciplineName, Description" +
        ") Values(?, ?)";

      using (OleDbConnection conn = new OleDbConnection(_ConnString)) {
        using (OleDbCommand cmd = new OleDbCommand(SqlString, conn)) {
          cmd.CommandType = CommandType.Text;
          cmd.Parameters.AddWithValue("DisciplineName", DisciplineName);
          cmd.Parameters.AddWithValue("Description", Description);
          conn.Open();
          cmd.ExecuteNonQuery();
          conn.Close();
        }
      }
    }

    public List<Discipline> GetAllDiscipline() {
      int i = 0;
      string SqlString = "SELECT DisciplineId, DisciplineName, Description " +
        "FROM Discipline";

      List<Discipline> listDiscipline = new List<Discipline>();
      using (OleDbConnection conn = new OleDbConnection(_ConnString)) {
        using (OleDbCommand cmd = new OleDbCommand(SqlString, conn)) {
          conn.Open();
          using (OleDbDataReader reader = cmd.ExecuteReader()) {
            while (reader.Read()) {
              Discipline oneDiscipline = new Discipline();
              oneDiscipline.Number = ++i;
              oneDiscipline.DisciplineId = Convert.ToInt32(reader["DisciplineId"].ToString());
              oneDiscipline.DisciplineName = reader["DisciplineName"].ToString();
              oneDiscipline.Description = reader["Description"].ToString();
              listDiscipline.Add(oneDiscipline);
            }
          }
          conn.Close();
        }
      }

      if (listDiscipline.Count == 0) {
        Discipline noDiscipline = new Discipline();
        noDiscipline.DisciplineId = 0;
        noDiscipline.Message = NamesMy.NoDataNames.NoDataInDiscipline;
        listDiscipline.Add(noDiscipline);
      }
      return listDiscipline;
    }

    public Discipline SelectedDisciplineByDisciplineId(int DisciplineId) {
      string SqlString = "SELECT DisciplineId, DisciplineName, Description " +
        "FROM Discipline Where DisciplineId=" + DisciplineId.ToString();

      Discipline oneDiscipline = new Discipline();
      using (OleDbConnection conn = new OleDbConnection(_ConnString)) {
        using (OleDbCommand cmd = new OleDbCommand(SqlString, conn)) {
          conn.Open();
          using (OleDbDataReader reader = cmd.ExecuteReader()) {
            while (reader.Read()) {
              oneDiscipline.DisciplineId = Convert.ToInt32(reader["DisciplineId"].ToString());
              oneDiscipline.DisciplineName = reader["DisciplineName"].ToString();
              oneDiscipline.Description = reader["Description"].ToString();
            }
          }
        }
        conn.Close();
      }
      return oneDiscipline;
    }

    public void UpdateDiscipline(string DisciplineName, string Description, int DisciplineId) {
      string SqlString = "UPDATE Discipline SET DisciplineName=?, Description=?  " +
  "WHERE DisciplineId=?";

      using (OleDbConnection conn = new OleDbConnection(_ConnString)) {
        using (OleDbCommand cmd = new OleDbCommand(SqlString, conn)) {
          cmd.CommandType = CommandType.Text;
          cmd.Parameters.AddWithValue("DisciplineName", DisciplineName);
          cmd.Parameters.AddWithValue("Description", Description);
          cmd.Parameters.AddWithValue("DisciplineId", DisciplineId);
          conn.Open();
          cmd.ExecuteNonQuery();
          conn.Close();
        }
      }
    }

    public void DeleteDisciplineByDisciplineId(int DisciplineId) {
      string SqlString = "DELETE FROM Discipline WHERE DisciplineId=" + DisciplineId.ToString();
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


public class Discipline {
  private int _Number;
  private int _DisciplineId;
  private string _DisciplineName;
  private string _Description;
  private string _Message;

  public Discipline() {
    _Number = 0;
    _DisciplineId = 0;
    _DisciplineName = String.Empty;
    _Description = String.Empty;
    _Message = String.Empty;
  }

  public int Number {
    set { _Number = value; }
    get { return _Number; }
  }
  public int DisciplineId {
    set { _DisciplineId = value; }
    get { return _DisciplineId; }
  }
  public string DisciplineName {
    set { _DisciplineName = value; }
    get { return _DisciplineName; }
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

