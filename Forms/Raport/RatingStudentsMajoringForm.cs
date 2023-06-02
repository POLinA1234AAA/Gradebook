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
  public partial class RatingStudentsMajoringForm : Form {
    private RaportsBLL _raport = new RaportsBLL();
    private List<RaportBLL> _RaportBLLList = new List<RaportBLL>();


    public RatingStudentsMajoringForm() {
      InitializeComponent();
      _RaportBLLList = _raport.GetRatingStudentsMajoring();
      GetRaport(_RaportBLLList);
    }

    public void GetRaport(List<RaportBLL> RaportBLLList) {
      RaportTBox.Text = String.Format("{0,3}|{1, -10}|{2, -60}|{3, 12}|\r\n", "№", "Група ", "П.І.Б.", "Середній бал");
      for (int i = 0; i < RaportBLLList.Count(); i++) {
        string raportString = String.Format("{0,3}|{1, -10}|{2, -60}|{3, 12}|\r\n",
        RaportBLLList[i].Number, RaportBLLList[i].GroupsName, RaportBLLList[i].FIO, RaportBLLList[i].MediumMark);
        RaportTBox.Text += raportString;
      }
    }



  }
}
