using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareVVNZ.AppCode {
  class ValidationMy {
    public bool IsDataEntering(string dataEnter) {
      if (String.IsNullOrEmpty(dataEnter) || dataEnter == "") {
        return false;
      } else {
        return true;
      }
    }

    public bool IsDataSelected(int SelectedIndex) {
      if ((SelectedIndex == 0)) {
        return false;
      } else {
        return true;
      }
    }

    public bool IsDataInThisScope(int MinValue, int MaxValue, int Data) {
      if ((Data >= MinValue) && (Data <= MaxValue)) {
        return true;
      } else {
        return false;
      }
    }

    public bool IsDataConvertToInt(string dataEnter) {
      try {
        Convert.ToInt64(dataEnter);
        return true;
      } catch {
        return false;
      }
    }

    public bool IsDataConvertToDouble(string dataEnter) {
      try {
        Convert.ToDouble(dataEnter);
        return true;
      } catch {
        return false;
      }
    }

    public bool IsDataDateTime(string dataEnter) {
      if (!String.IsNullOrEmpty(dataEnter)) {
        try {
          DateTime myDateTime = Convert.ToDateTime(dataEnter);
          return true;
        } catch { return false; }
      } else if (dataEnter == "") {
        return false;
      } else {
        return false;
      }
    }

    public bool IsPasswordMatch(string password, string rePassword) {
      if (String.Compare(password, rePassword) == 0) {
        return true;
      } else {
        return false;
      }
    }

    public bool IsDateOff(DateTime TermDate) {
      if (DateTime.Now > TermDate) {
        return false;
      } else {
        return true;
      }
    }

    public bool IsDataYear(string dataEnter) {
      if (!String.IsNullOrEmpty(dataEnter)) {
        try {
          int Year = Convert.ToInt32(dataEnter);
          if ((Year >= 1980) && (Year <= DateTime.Now.Year)) {
            return true;
          } else {
            return false;
          }
        } catch { return false; }
      } else if (dataEnter == "") {
        return true;
      } else {
        return false;
      }
    }

    public bool IsDataHour(string dataEnter) {
      if (!String.IsNullOrEmpty(dataEnter) && IsDataConvertToInt(dataEnter)) {
        if (Convert.ToInt16(dataEnter) > 0 && Convert.ToInt16(dataEnter) < 24) {
          return true;
        } else {
          return false;
        }
      } else { return false; }
    }

    public bool IsDataMinuts(string dataEnter) {
      if (!String.IsNullOrEmpty(dataEnter) && IsDataConvertToInt(dataEnter)) {
        if (Convert.ToInt16(dataEnter) > 0 && Convert.ToInt16(dataEnter) < 60) {
          return true;
        } else {
          return false;
        }
      } else { return false; }
    }

  }
}
