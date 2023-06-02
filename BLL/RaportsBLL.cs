using SoftwareVVNZ.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareVVNZ.BLL {
  class RaportsBLL {
    private RatingsProvider _RatingsProvider = new RatingsProvider();
    private StudentProvider _StudentProvider = new StudentProvider();
    private GroupsProvider _GroupsProvider = new GroupsProvider();
    private StatementsProvider _StatementsProvider = new StatementsProvider();
    private DisciplineProvider _DisciplineProvider = new DisciplineProvider();

    public List<RaportBLL> GetStatementForGroup(int GroupId) {
      List<RaportBLL> raportBLLList = new List<RaportBLL>();
      List<Ratings> ratingsList = new List<Ratings>();
      List<Student> studentList = new List<Student>();
      ratingsList = _RatingsProvider.GetAllRatingsByGroupsId(GroupId);
      studentList = _StudentProvider.GetAllStudentByGroupId(GroupId);

      for (int i = 0; i < studentList.Count; i++) {
        RaportBLL oneRaportBLL = new RaportBLL();
        oneRaportBLL.Number = i + 1;
        oneRaportBLL.FIO = studentList[i].FIO;
        oneRaportBLL.MediumMark = GetMediumMark(studentList[i].StudentId, ratingsList);
        oneRaportBLL.FiveBallMark = GetFiveBallMark(oneRaportBLL.MediumMark);
        oneRaportBLL.SimbolMark = GetSimbolMark(oneRaportBLL.MediumMark);
        raportBLLList.Add(oneRaportBLL);
      }

      return raportBLLList;
    }

    public List<RaportBLL> GetRatingStudentsMajoring() {
      List<RaportBLL> raportBLLList = new List<RaportBLL>();
      List<Ratings> ratingsList = new List<Ratings>();
      List<Student> studentList = new List<Student>();
      List<Groups> groupsList = new List<Groups>();

      ratingsList = _RatingsProvider.GetAllRatings();
      studentList = _StudentProvider.GetAllStudent();
      groupsList = _GroupsProvider.GetAllGroups();

      for (int i = 0; i < studentList.Count; i++) {
        RaportBLL oneRaportBLL = new RaportBLL();
        oneRaportBLL.Number = i + 1;
        oneRaportBLL.FIO = studentList[i].FIO;
        oneRaportBLL.MediumMark = GetMediumMark(studentList[i].StudentId, ratingsList);
        oneRaportBLL.GroupsName = GetGroupsName(studentList[i].GroupsId, groupsList);
        raportBLLList.Add(oneRaportBLL);
      }

      return raportBLLList;
    }

    public List<RaportBLL> GetScholarship() {
      List<RaportBLL> raportBLLList = new List<RaportBLL>();
      List<Ratings> ratingsList = new List<Ratings>();
      List<Student> studentList = new List<Student>();
      List<Groups> groupsList = new List<Groups>();

      ratingsList = _RatingsProvider.GetAllRatings();
      studentList = _StudentProvider.GetAllStudent();
      groupsList = _GroupsProvider.GetAllGroups();

      for (int i = 0; i < studentList.Count; i++) {
        RaportBLL oneRaportBLL = new RaportBLL();
        oneRaportBLL.Number = i + 1;
        oneRaportBLL.FIO = studentList[i].FIO;
        oneRaportBLL.MediumMark = GetMediumMark(studentList[i].StudentId, ratingsList);
        oneRaportBLL.GroupsName = GetGroupsName(studentList[i].GroupsId, groupsList);
        oneRaportBLL.FiveBallMark = GetFiveBallMark(oneRaportBLL.MediumMark);
        raportBLLList.Add(oneRaportBLL);
      }

      return raportBLLList;
    }

    public List<RaportBLL> GetExtractResultsForSemesterForm() {
      List<RaportBLL> raportBLLList = new List<RaportBLL>();
      List<Ratings> ratingsList = new List<Ratings>();
      List<Student> studentList = new List<Student>();

      List<Statements> statementsList = new List<Statements>();
      List<Discipline> disciplineList = new List<Discipline>();

      ratingsList = _RatingsProvider.GetAllRatings();
      studentList = _StudentProvider.GetAllStudent();
      statementsList = _StatementsProvider.GetAllStatements();
      disciplineList = _DisciplineProvider.GetAllDiscipline();

      for (int i = 0; i < ratingsList.Count; i++) {
        RaportBLL oneRaportBLL = new RaportBLL();
        oneRaportBLL.Number = i + 1;
        oneRaportBLL.FIO = GetStudentFIO(ratingsList[i].StudentId, studentList);
        oneRaportBLL.SubjectMark = ratingsList[i].SubjectMark;
        oneRaportBLL.DisciplineName = GetDisciplineName(ratingsList[i].DisciplineId, disciplineList);
        oneRaportBLL.StatementsNumber = GetStatementsNumber(ratingsList[i].StatementsId, statementsList);
        raportBLLList.Add(oneRaportBLL);
      }

      return raportBLLList;

    }

    public List<RaportBLL> GetDiplomaSupplement(int StudentId) {
      List<RaportBLL> raportBLLList = new List<RaportBLL>();
      List<Discipline> disciplineList = new List<Discipline>();
      List<Ratings> ratingsList = new List<Ratings>();

      disciplineList = _DisciplineProvider.GetAllDiscipline();
      ratingsList = _RatingsProvider.GetAllRatingsByStudentId(StudentId);

      for (int i = 0; i < ratingsList.Count; i++) {
        RaportBLL oneRaportBLL = new RaportBLL();
        oneRaportBLL.Number = i + 1;
        oneRaportBLL.SubjectMark = ratingsList[i].SubjectMark;
        oneRaportBLL.DisciplineName = GetDisciplineName(ratingsList[i].DisciplineId, disciplineList);
        raportBLLList.Add(oneRaportBLL);
      }

      return raportBLLList;
    }

    private string GetFiveBallMark(int Mark) {
      if (Mark >= 35 && Mark <= 59) {
        return "Незадов.";
      } else if (Mark >= 60 && Mark <= 63) {
        return "Задов.";
      } else if (Mark >= 64 && Mark <= 74) {
        return "Задов.";
      } else if (Mark >= 75 && Mark <= 81) {
        return "Добре.";
      } else if (Mark >= 82 && Mark <= 89) {
        return "Добре";
      } else if (Mark >= 90 && Mark <= 100) {
        return "Відмінно";
      } else if (Mark > 100) {
        return "Відмінно";
      } else {
        return "Незадов.";
      }
    }

    private string GetSimbolMark(int Mark) {
      if (Mark >= 35 && Mark <= 59) {
        return "Fx";
      } else if (Mark >= 60 && Mark <= 63) {
        return "E";
      } else if (Mark >= 64 && Mark <= 74) {
        return "D";
      } else if (Mark >= 75 && Mark <= 81) {
        return "C";
      } else if (Mark >= 82 && Mark <= 89) {
        return "B";
      } else if (Mark >= 90 && Mark <= 100) {
        return "A";
      } else if (Mark > 100) {
        return "A";
      } else {
        return "Fx";
      }
    }

    private int GetMediumMark(int StudentId, List<Ratings> RatingsList) {
      int amount = 0;
      int mediumMark = 0;
      if (RatingsList.Count > 0) {
        for (int i = 0; i < RatingsList.Count; i++) {
          if (StudentId == RatingsList[i].StudentId) {
            amount++;
            mediumMark += RatingsList[i].SubjectMark;
          }
        }
        if (amount != 0) {
          mediumMark /= amount;
        }
      }
      return mediumMark;
    }

    private string GetStudentFIO(int StudentId, List<Student> StudentList) {
      for (int i = 0; i < StudentList.Count; i++) {
        if (StudentId == StudentList[i].StudentId) {
          return StudentList[i].FIO;
        }
      }
      return "";
    }

    private string GetGroupsName(int GroupsNameId, List<Groups> GroupsNameList) {
      for (int i = 0; i < GroupsNameList.Count; i++) {
        if (GroupsNameId == GroupsNameList[i].GroupsId) {
          return GroupsNameList[i].GroupsName;
        }
      }
      return "";
    }

    private string GetDisciplineName(int DisciplineId, List<Discipline> DisciplineList) {
      for (int i = 0; i < DisciplineList.Count; i++) {
        if (DisciplineId == DisciplineList[i].DisciplineId) {
          return DisciplineList[i].DisciplineName;
        }
      }
      return "";
    }

    private string GetStatementsNumber(int StatementsId, List<Statements> StatementsList) {
      for (int i = 0; i < StatementsList.Count; i++) {
        if (StatementsId == StatementsList[i].StatementsId) {
          return StatementsList[i].StatementsNumber;
        }
      }
      return "";
    }

  }
}

public class RaportBLL: Ratings {
  private int _MediumMark;
  private string _GroupsName;
  private string _DisciplineName;
  private string _StatementsNumber;
 public  RaportBLL() {
    _MediumMark = 0;
    _GroupsName = String.Empty;
    _DisciplineName = String.Empty;
    _StatementsNumber = String.Empty;
  }

  public int MediumMark {
    set { _MediumMark = value; }
    get { return _MediumMark; }
  }

  public string GroupsName {
    set { _GroupsName = value; }
    get { return _GroupsName; }
  }
  public string DisciplineName {
    set { _DisciplineName = value; }
    get { return _DisciplineName; }
  }
  public string StatementsNumber {
    set { _StatementsNumber = value; }
    get { return _StatementsNumber; }
  }
}