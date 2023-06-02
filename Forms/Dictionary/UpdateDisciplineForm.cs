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
  public partial class UpdateDisciplineForm : Form {
    private int _DisciplineId = 0;
    private Discipline _selectedDiscipline = new Discipline();
    private DisciplineProvider _DisciplineProvider = new DisciplineProvider();
    private ValidationMy _Validation = new ValidationMy();

    public UpdateDisciplineForm(int DisciplineId) {
      InitializeComponent();
      _DisciplineId = DisciplineId;
      LoadAllDate();
    }

    private void SaveBtn_Click(object sender, EventArgs e) {
      if (IsDataEnteringCorrect()) {
        _DisciplineProvider.UpdateDiscipline(DisciplineNameTBox.Text, DescriptionTBox.Text, _DisciplineId);
        this.Close();
      }
    }

    private void DeleteBtn_Click(object sender, EventArgs e) {
      if (MessageBox.Show("Ви дійсно хочете видалити цей елемент?", "Видалити", MessageBoxButtons.YesNo) == DialogResult.Yes) {
        _DisciplineProvider.DeleteDisciplineByDisciplineId(_DisciplineId);
        this.Close();
      }
    }

    private void ExitBtn_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void LoadAllDate() {
      _selectedDiscipline = _DisciplineProvider.SelectedDisciplineByDisciplineId(_DisciplineId);
      DisciplineNameTBox.Text = _selectedDiscipline.DisciplineName;
      DescriptionTBox.Text = _selectedDiscipline.Description;
    }

    private bool IsDataEnteringCorrect() {
      bool isCorrect = true;
      if (_Validation.IsDataEntering(DisciplineNameTBox.Text)) {
        DisciplineNameValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        DisciplineNameValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      return isCorrect;
    }

  }
}
