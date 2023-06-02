using SoftwareVVNZ.BLL;
using SoftwareVVNZ.Provider;
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
  public partial class DiplomaSupplementForm : Form {
    private StudentProvider _WorkProvider = new StudentProvider();
    private List<Student> StudentList = new List<Student>();
    private RaportsBLL _raport = new RaportsBLL();
    private List<RaportBLL> _RaportBLLList = new List<RaportBLL>();

    public DiplomaSupplementForm() {
      InitializeComponent();
      LoadAllDate();
    }

    private void FormingBtn_Click(object sender, EventArgs e) {
      _RaportBLLList = _raport.GetDiplomaSupplement(Convert.ToInt32(StudentCBox.SelectedValue.ToString()));
      GetRaport(_RaportBLLList);
    }

    private void LoadAllDate() {
      StudentList = _WorkProvider.GetAllStudent();
      StudentCBox.DataSource = StudentList;
      StudentCBox.ValueMember = "StudentId";
      StudentCBox.DisplayMember = "FIO";
    }

    public void GetRaport(List<RaportBLL> RaportBLLList) {
      if (RaportBLLList.Count == 0) {
        RaportTBox.Text = "По вибраному студенту ще немає відомості";
      } else {
        RaportTBox.Text = String.Format("{0,3}|{1, -60}|{2, 12}|\r\n", "№", "Назва предмету", "Оцінка");
        for (int i = 0; i < RaportBLLList.Count(); i++) {
          string raportString = String.Format("{0,3}|{1, -60}|{2, 12}|\r\n",
          RaportBLLList[i].Number, RaportBLLList[i].DisciplineName, RaportBLLList[i].SubjectMark);
          RaportTBox.Text += raportString;
        }
      }
    }

  }
}
