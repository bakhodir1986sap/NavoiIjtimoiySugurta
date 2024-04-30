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
            anketaForm.ShowDialog(this);

            if (anketaForm.DialogResult == DialogResult.OK)
            {
                SelectedModel = anketaForm.CurrentModel;

                //MigrantImport
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        public MigrantImportModel SelectedModel { get; set; }
        public List<MigrantImportModel> MigrantImportModels { get; set; } = new List<MigrantImportModel>();
    }
}
