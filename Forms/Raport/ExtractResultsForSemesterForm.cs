using SoftwareVVNZ.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareVVNZ.Forms.Raport {
  public partial class ExtractResultsForSemesterForm : Form {
    private RaportsBLL _raport = new RaportsBLL();
    private List<RaportBLL> _RaportBLLList = new List<RaportBLL>();

    public ExtractResultsForSemesterForm() {
      InitializeComponent();
      _RaportBLLList = _raport.GetExtractResultsForSemesterForm();
      GetRaport(_RaportBLLList);

    }

    public void GetRaport(List<RaportBLL> RaportBLLList) {
      RaportTBox.Text = String.Format("{0,3}|{1, -40}|{2, -30}|{3, 12}|{4, 12}|\r\n", "№", "П.І.Б.", "Навчальна дисципліна", "Оцінка", "№ відомості");
      for (int i = 0; i < RaportBLLList.Count(); i++) {
        string raportString = String.Format("{0,3}|{1, -40}|{2, -30}|{3, 12}|{4, 12}|\r\n",
        RaportBLLList[i].Number, RaportBLLList[i].FIO, RaportBLLList[i].DisciplineName, RaportBLLList[i].SubjectMark, RaportBLLList[i].StatementsNumber);
        RaportTBox.Text += raportString;
      }
    }

  }
}
