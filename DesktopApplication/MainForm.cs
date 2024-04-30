using NavoiKasabaUyushmasi.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApplication
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AnketaForm anketaForm = new AnketaForm();
            anketaForm.IsInEditMode = false;
            anketaForm.ShowDialog(this);

            if (anketaForm.DialogResult == DialogResult.OK)
            {
                SelectedModel = anketaForm.CurrentModel;

                MigrantImportModels.Add(SelectedModel);

                dgvMigrants.Rows.Clear();

                foreach (var item in MigrantImportModels)
                {
                    dgvMigrants.Rows.Add(item.Fio, item.SeriaPassport, item.RaqamPassport);
                }
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            var Fio =  dgvMigrants.SelectedRows[0].Cells[0].Value.ToString();
            var passSeria = dgvMigrants.SelectedRows[0].Cells[1].Value.ToString();
            var passNumber = dgvMigrants.SelectedRows[0].Cells[2].Value.ToString();

            SelectedModel = MigrantImportModels.FirstOrDefault(x => x.Fio == Fio && x.SeriaPassport == passSeria && x.RaqamPassport == passNumber);

            if (SelectedModel == null)
            {
                MessageBox.Show("Migrant not found");
                return;
            }

            AnketaForm anketaForm = new AnketaForm();
            anketaForm.IsInEditMode = true;
            anketaForm.CurrentModel = SelectedModel;
            anketaForm.ShowDialog(this);

            if (anketaForm.DialogResult == DialogResult.OK)
            {
                SelectedModel = anketaForm.CurrentModel;

                dgvMigrants.Rows.Clear();

                foreach (var item in MigrantImportModels)
                {
                    dgvMigrants.Rows.Add(item.Fio, item.SeriaPassport, item.RaqamPassport);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public MigrantImportModel SelectedModel { get; set; }
        public List<MigrantImportModel> MigrantImportModels { get; set; } = new List<MigrantImportModel>();
    }
}
