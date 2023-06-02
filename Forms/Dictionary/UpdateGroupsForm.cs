using SoftwareVVNZ.AppCode;
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

namespace SoftwareVVNZ.Forms.Dictionary {
  public partial class UpdateGroupsForm : Form {
    private int _GroupsId = 0;
    private Groups _selectedGroups = new Groups();
    private GroupsProvider _GroupsProvider = new GroupsProvider();
    private ValidationMy _Validation = new ValidationMy();

    public UpdateGroupsForm(int GroupsId) {
      InitializeComponent();
      _GroupsId = GroupsId;
      LoadAllDate();
    }

    private void SaveBtn_Click(object sender, EventArgs e) {
      if (IsDataEnteringCorrect()) {
        _GroupsProvider.UpdateGroups(GroupsNameTBox.Text, DescriptionTBox.Text, _GroupsId);
        this.Close();
      }
    }

    private void DeleteBtn_Click(object sender, EventArgs e) {
      if (MessageBox.Show("Ви дійсно хочете видалити цей елемент?", "Видалити", MessageBoxButtons.YesNo) == DialogResult.Yes) {
        _GroupsProvider.DeleteGroupsByGroupsId(_GroupsId);
        this.Close();
      }
    }

    private void ExitBtn_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void LoadAllDate() {
      _selectedGroups = _GroupsProvider.SelectedGroupsByGroupsId(_GroupsId);
      GroupsNameTBox.Text = _selectedGroups.GroupsName;
      DescriptionTBox.Text = _selectedGroups.Description;
    }

    private bool IsDataEnteringCorrect() {
      bool isCorrect = true;
      if (_Validation.IsDataEntering(GroupsNameTBox.Text)) {
        GroupsNameValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        GroupsNameValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      return isCorrect;
    }
  }
}
