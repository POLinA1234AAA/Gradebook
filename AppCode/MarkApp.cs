using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareVVNZ.AppCode {
  class MarkApp {
    public List<Mark> GeMarkList() {
      List<Mark> MarkList = new List<Mark>();
      MarkList.Add(new Mark(1, 35, 59, "Fx", "Незадов."));
      MarkList.Add(new Mark(1, 60, 63, "E", "Задов."));
      MarkList.Add(new Mark(1, 64, 74, "D", "Задов."));
      MarkList.Add(new Mark(1, 75, 81, "C", "Добре"));
      MarkList.Add(new Mark(1, 82, 89, "B", "Добре"));
      MarkList.Add(new Mark(1, 90, 100, "A", "Відмінно"));
      return MarkList;
    }
  }
}


public class Mark {
  private int _MarkId;
  private int _MinMark;
  private int _MaxMark;
  private string _SimbolMark;
  private string _FiveBallMark;

  public Mark() {
    _MarkId = 0;
    _MinMark = 0;
    _MaxMark = 0;
    _SimbolMark = String.Empty;
    _FiveBallMark = String.Empty;
  }
  public Mark(int MarkId, int MinMark, int MaxMark, string SimbolMark, string FiveBallMark) {
    _MarkId = MarkId;
    _MinMark = MinMark;
    _MaxMark = MaxMark;
    _SimbolMark = SimbolMark;
    _FiveBallMark = FiveBallMark;
  }

  public int MarkId {
    set { _MarkId = value; }
    get { return _MarkId; }
  }
  public int MinMark {
    set { _MinMark = value; }
    get { return _MinMark; }
  }
  public int MaxMark {
    set { _MaxMark = value; }
    get { return _MaxMark; }
  }
  public string SimbolMark {
    set { _SimbolMark = value; }
    get { return _SimbolMark; }
  }
  public string FiveBallMark {
    set { _FiveBallMark = value; }
    get { return _FiveBallMark; }
  }
}