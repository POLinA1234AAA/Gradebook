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
  public partial class SummaryStatementGroupForm : Form {
    private GroupsProvider _WorkProvider = new GroupsProvider();
    private List<Groups> GroupsList = new List<Groups>();
    private RaportsBLL _raport = new RaportsBLL();
    private List<RaportBLL> _RaportBLLList = new List<RaportBLL>();

    public SummaryStatementGroupForm() {
      InitializeComponent();
      LoadAllDate();
    }

    private void FormingBtn_Click(object sender, EventArgs e) {
      _RaportBLLList = _raport.GetStatementForGroup(Convert.ToInt32(GroupsCBox.SelectedValue.ToString()));
      GetRaport(_RaportBLLList);
    }

    private void LoadAllDate() {
      GroupsList = _WorkProvider.GetAllGroups();
      GroupsCBox.DataSource = GroupsList;
      GroupsCBox.ValueMember = "GroupsId";
      GroupsCBox.DisplayMember = "GroupsName";
    }

    public void GetRaport(List<RaportBLL> RaportBLLList) {

      RaportTBox.Text = String.Format("{0,3}|{1, -60}|{2, 12}|{3, 12}|{4, 12}|\r\n", "№", "Студент", "Оцінка", "Буквена", "5-ти бальна");
      for (int i = 0; i < RaportBLLList.Count(); i++) {
        string raportString = String.Format("{0,3}|{1, -60}|{2, 12}|{3, 12}|{4, 12}|\r\n",
        RaportBLLList[i].Number, RaportBLLList[i].FIO, RaportBLLList[i].MediumMark, RaportBLLList[i].SimbolMark, RaportBLLList[i].FiveBallMark);
        RaportTBox.Text += raportString;
      }
    }

  }
}
