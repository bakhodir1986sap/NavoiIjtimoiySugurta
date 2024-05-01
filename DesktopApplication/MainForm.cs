using CoreDataProcessing;
using NavoiKasabaUyushmasi.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace DesktopApplication
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void btn_Search_Click(object sender, EventArgs e)
        {
            var Fio = txbSearch.Text;

            if (string.IsNullOrEmpty(Fio))
            {
                dgvMigrants.Rows.Clear();

                MigrantImportModels = await db.MigrantImportModels.ToListAsync();

                foreach (var item in MigrantImportModels)
                {
                    dgvMigrants.Rows.Add(item.Id, item.Fio, item.SeriaPassport, item.RaqamPassport);
                }

                return;
            }

            var migrants = db.MigrantImportModels.Where(x => x.Fio.Contains(Fio));

            if (await migrants.AnyAsync())
            {
                dgvMigrants.Rows.Clear();

                foreach (var migrant in migrants)
                {
                    dgvMigrants.Rows.Add(migrant.Id, migrant.Fio, migrant.SeriaPassport, migrant.RaqamPassport);
                }
            }
            else
            {
                MessageBox.Show("Migrant not found");
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var lastMigrant = await db.MigrantImportModels.OrderByDescending(i => i.Id).FirstOrDefaultAsync();

            AnketaForm anketaForm = new AnketaForm();
            anketaForm.IsInEditMode = false;
            anketaForm.databaseContext = db;
            anketaForm.DefaultTuman = lastMigrant?.XududNomi;
            anketaForm.DefaultMahalla = lastMigrant?.KiritayotganMFY;
            anketaForm.ShowDialog(this);

            if (anketaForm.DialogResult == DialogResult.OK)
            {
                SelectedModel = anketaForm.CurrentModel;

                string pspEntered = $"{SelectedModel.SeriaPassport}{SelectedModel.RaqamPassport}";

                var isExist = await db.IchkiIshlarBazaDannixes.FirstOrDefaultAsync(x => x.psp == pspEntered);

                SelectedModel.BazadaBorligi = isExist != null ? "1" : "0";

                MigrantImportModels.Add(SelectedModel);

                db.MigrantImportModels.Add(SelectedModel);

                await db.SaveChangesAsync();

                dgvMigrants.Rows.Clear();

                foreach (var item in MigrantImportModels)
                {
                    dgvMigrants.Rows.Add(item.Id, item.Fio, item.SeriaPassport, item.RaqamPassport);
                }
            }
        }

        private async void btnModify_Click(object sender, EventArgs e)
        {
            if (dgvMigrants.SelectedRows.Count == 0)
            {
                MessageBox.Show("Iltimos qatorni tanlang");
                return;
            }

            var Id = int.Parse(dgvMigrants.SelectedRows[0].Cells[0].Value.ToString());
            var Fio =  dgvMigrants.SelectedRows[0].Cells[1].Value.ToString();
            var passSeria = dgvMigrants.SelectedRows[0].Cells[2].Value.ToString();
            var passNumber = dgvMigrants.SelectedRows[0].Cells[3].Value.ToString();

            SelectedModel = await  db.MigrantImportModels.FirstOrDefaultAsync(x => x.Id == Id);

            if (SelectedModel == null)
            {
                MessageBox.Show("Migrant not found");
                return;
            }

            AnketaForm anketaForm = new AnketaForm
            {
                IsInEditMode = true,
                CurrentModel = SelectedModel,
                databaseContext = db
            };
            anketaForm.ShowDialog(this);

            if (anketaForm.DialogResult == DialogResult.OK)
            {
                SelectedModel = anketaForm.CurrentModel;

                string pspEntered = $"{SelectedModel.SeriaPassport}{SelectedModel.RaqamPassport}";

                var isExist = await db.IchkiIshlarBazaDannixes.FirstOrDefaultAsync(x => x.psp == pspEntered);

                SelectedModel.BazadaBorligi = isExist != null ? "1" : "0";

                await db.SaveChangesAsync();

                dgvMigrants.Rows.Clear();

                foreach (var item in MigrantImportModels)
                {
                    dgvMigrants.Rows.Add(item.Id, item.Fio, item.SeriaPassport, item.RaqamPassport);
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMigrants.SelectedRows.Count == 0)
            {
                MessageBox.Show("Iltimos qatorni tanlang");
                return;
            }

            var Fio = dgvMigrants.SelectedRows[0].Cells[1].Value.ToString();
            var passSeria = dgvMigrants.SelectedRows[0].Cells[2].Value.ToString();
            var passNumber = dgvMigrants.SelectedRows[0].Cells[3].Value.ToString();

            SelectedModel = await db.MigrantImportModels.FirstOrDefaultAsync(x => x.Fio == Fio && x.SeriaPassport == passSeria && x.RaqamPassport == passNumber);

            if (SelectedModel == null)
            {
                MessageBox.Show("Migrant not found");
                return;
            }

            db.MigrantImportModels.Remove(SelectedModel);

            await db.SaveChangesAsync();

            dgvMigrants.Rows.Clear();

            MigrantImportModels = await db.MigrantImportModels.ToListAsync();

            foreach (var item in MigrantImportModels)
            {
                dgvMigrants.Rows.Add(item.Id, item.Fio, item.SeriaPassport, item.RaqamPassport);
            }
        }

        private async void btnExcel_Click(object sender, EventArgs e)
        {
            MigrantImportModels = db.MigrantImportModels.ToList();

            await Task.Run(() => Export2Excel(MigrantImportModels, "Migrantlar"));

            MessageBox.Show("Migrantlar Excelga yozildi OUT catalogni tekshiring");
        }

        public void Export2Excel(List<MigrantImportModel> migrantImportModels, string fileName)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;

            try
            {
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);

                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                #region Export
                xlWorkSheet.Cells[1, 1] = "N#";
                xlWorkSheet.Cells[1, 2] = "Xudud nomi";
                xlWorkSheet.Cells[1, 3] = "Sor ishtirokchi FIO";
                xlWorkSheet.Cells[1, 4] = "Sor ishtirokchi qarindoshligi";
                xlWorkSheet.Cells[1, 5] = "Sor ishtirokchi passport seriya";
                xlWorkSheet.Cells[1, 6] = "Sor ishtirokchi passport raqam";
                xlWorkSheet.Cells[1, 7] = "Sor ishtirokchi telefon raqam";
                xlWorkSheet.Cells[1, 8] = "Jinsi";
                xlWorkSheet.Cells[1, 9] = "FIO";
                xlWorkSheet.Cells[1, 10] = "Seria passport";
                xlWorkSheet.Cells[1, 11] = "Raqam passport";
                xlWorkSheet.Cells[1, 12] = "Tugilgan kun";
                xlWorkSheet.Cells[1, 13] = "Tugilgan oy";
                xlWorkSheet.Cells[1, 14] = "Tugilgan yil";
                xlWorkSheet.Cells[1, 15] = "Yiloyat";
                xlWorkSheet.Cells[1, 16] = "Tuman";
                xlWorkSheet.Cells[1, 17] = "Mahalla";
                xlWorkSheet.Cells[1, 18] = "Kocha";
                xlWorkSheet.Cells[1, 19] = "Uy";
                xlWorkSheet.Cells[1, 20] = "Xonadon";
                xlWorkSheet.Cells[1, 21] = "Fuqorolik xolati";
                xlWorkSheet.Cells[1, 22] = "Malumoti";
                xlWorkSheet.Cells[1, 23] = "Mutaxasisligi";
                xlWorkSheet.Cells[1, 24] = "Xozirgi xolati";
                xlWorkSheet.Cells[1, 25] = "Uzbga qaytgan sanasi";
                xlWorkSheet.Cells[1, 26] = "Sogligi";
                xlWorkSheet.Cells[1, 27] = "Oilaviy xolati";
                xlWorkSheet.Cells[1, 28] = "Oilaviy muxiti";
                xlWorkSheet.Cells[1, 29] = "Jami farzandlar soni";
                xlWorkSheet.Cells[1, 30] = "Voyaga etmagan farzandlar soni";
                xlWorkSheet.Cells[1, 31] = "Voyaga etgan farzandlar soni";
                xlWorkSheet.Cells[1, 32] = "Ijtimoiy xolati";
                xlWorkSheet.Cells[1, 33] = "Xorijga ketgan sanasi";
                xlWorkSheet.Cells[1, 34] = "Davlat va xudud"; 
                xlWorkSheet.Cells[1, 35] = "Davlat Boshqalar";
                xlWorkSheet.Cells[1, 36] = "Ishlash ruxsatnomasi mavjudligi";
                xlWorkSheet.Cells[1, 37] = "Xorijda bir oylik daromadi";
                xlWorkSheet.Cells[1, 38] = "Xorijda birgalikdagi oila azolari";
                xlWorkSheet.Cells[1, 39] = "Xorijga ketish maqsadi";
                xlWorkSheet.Cells[1, 40] = "Xorijga ketish maqsadi Boshqalar";
                xlWorkSheet.Cells[1, 41] = "Chet eldagi ish turi";
                xlWorkSheet.Cells[1, 42] = "Chet eldagi ish turi Boshqalar";
                xlWorkSheet.Cells[1, 43] = "Chet eldan qaytish istagi borligi";
                xlWorkSheet.Cells[1, 44] = "Xorijdagi muammolar soni"; 
                xlWorkSheet.Cells[1, 45] = "Xorijdagi muammolar ruyxati";
                xlWorkSheet.Cells[1, 46] = "Xorijdagi muammolar soni Boshqalar";
                xlWorkSheet.Cells[1, 47] = "Oiladagi muammolar soni";
                xlWorkSheet.Cells[1, 48] = "Oiladagi muammolar ruyxati";
                xlWorkSheet.Cells[1, 49] = "Oiladagi muammolar soni Boshqalar";
                xlWorkSheet.Cells[1, 50] = "Nima yordam berilsa qaytadi";
                xlWorkSheet.Cells[1, 51] = "Nima yordam berilsa qaytadi Boshqalar";
                xlWorkSheet.Cells[1, 52] = "Xorijdagi fuqaro telefon raqami";
                xlWorkSheet.Cells[1, 53] = "Bazada Borligi (0 - Yo'q 1 - Bor)";
                xlWorkSheet.Cells[1, 54] = "18 yoshdan katta kichik";
                #endregion

                Console.WriteLine("Excelga yozish boshlandi ...");

                int row = 2;
                foreach (var model in migrantImportModels)
                {
                    xlWorkSheet.Cells[row, 1] = row - 1;
                    xlWorkSheet.Cells[row, 2] = model.XududNomi;
                    xlWorkSheet.Cells[row, 3] = model.SorIshtirFio;
                    xlWorkSheet.Cells[row, 4] = model.SorIshtirQarindoshligi;
                    xlWorkSheet.Cells[row, 5] = model.SorIshtirPassportSeria;
                    xlWorkSheet.Cells[row, 6] = model.SorIshtirPassportRaqam;
                    xlWorkSheet.Cells[row, 7] = model.SorIshtirTelefonRaqam;
                    xlWorkSheet.Cells[row, 8] = model.Jinsi;
                    xlWorkSheet.Cells[row, 9] = model.Fio;
                    xlWorkSheet.Cells[row, 10] = model.SeriaPassport;
                    xlWorkSheet.Cells[row, 11] = model.RaqamPassport;
                    xlWorkSheet.Cells[row, 12] = model.TugilganKun;
                    xlWorkSheet.Cells[row, 13] = model.TugilganOy;
                    xlWorkSheet.Cells[row, 14] = model.TugilganYil;
                    xlWorkSheet.Cells[row, 15] = model.Yiloyat;
                    xlWorkSheet.Cells[row, 16] = model.Tuman;
                    xlWorkSheet.Cells[row, 17] = model.Mahalla;
                    xlWorkSheet.Cells[row, 18] = model.Kocha;
                    xlWorkSheet.Cells[row, 19] = model.Uy;
                    xlWorkSheet.Cells[row, 20] = model.Xonadon;
                    xlWorkSheet.Cells[row, 21] = model.FuqorolikXolati;
                    xlWorkSheet.Cells[row, 22] = model.Malumoti;
                    xlWorkSheet.Cells[row, 23] = model.Mutaxasisligi;
                    xlWorkSheet.Cells[row, 24] = model.XozirgiXolati;
                    xlWorkSheet.Cells[row, 25] = model.UzbgaQaytganSanasi;
                    xlWorkSheet.Cells[row, 26] = model.Sogligi;
                    xlWorkSheet.Cells[row, 27] = model.OilaviyXolati;
                    xlWorkSheet.Cells[row, 28] = model.OilaviyMuxiti;
                    xlWorkSheet.Cells[row, 29] = model.JamiFarzandlarSoni;
                    xlWorkSheet.Cells[row, 30] = model.VoyagaEtmaganFarzandlarSoni;
                    xlWorkSheet.Cells[row, 31] = model.VoyagaEtganFarzandlarSoni;
                    xlWorkSheet.Cells[row, 32] = model.IjtimoiyXolati;
                    xlWorkSheet.Cells[row, 33] = model.XorijgaKetganSanasi;
                    xlWorkSheet.Cells[row, 34] = model.DavlatVaXudud;//
                    xlWorkSheet.Cells[row, 35] = model.DavlatVaXududBoshqalari;
                    xlWorkSheet.Cells[row, 36] = model.IshlashRuxsatnomasiMavjudligi;
                    xlWorkSheet.Cells[row, 37] = model.XorijdagiBirOylikDaromadi;
                    xlWorkSheet.Cells[row, 38] = model.XorijdaBirgalikdagiOilaAzolari;
                    xlWorkSheet.Cells[row, 39] = model.XorijgaKetishMaqsadi;
                    xlWorkSheet.Cells[row, 40] = model.XorijgaKetishMaqsadiBoshqalari;
                    xlWorkSheet.Cells[row, 41] = model.ChetEldagiIshTuri;
                    xlWorkSheet.Cells[row, 42] = model.ChetEldagiIshTuriBoshqalari;
                    xlWorkSheet.Cells[row, 43] = model.ChetEldanQaytishIstagiBorligi;
                    xlWorkSheet.Cells[row, 44] = model.XorijdagiMuammolarSoni;
                    xlWorkSheet.Cells[row, 45] = model.XorijdagiMuammolari;
                    xlWorkSheet.Cells[row, 46] = model.XorijdagiMuammolariBoshqalari;
                    xlWorkSheet.Cells[row, 47] = model.OiladagiMuammolarSoni;
                    xlWorkSheet.Cells[row, 48] = model.OiladagiMuammolari;
                    xlWorkSheet.Cells[row, 49] = model.OiladagiMuammolariBoshqalari;
                    xlWorkSheet.Cells[row, 50] = model.NimaYordamBerilsaQaytadi;
                    xlWorkSheet.Cells[row, 51] = model.NimaYordamBerilsaQaytadiBoshqalari;
                    xlWorkSheet.Cells[row, 52] = model.XorijdagiFuqaroTelefonRaqami;
                    xlWorkSheet.Cells[row, 53] = model.BazadaBorligi;
                    xlWorkSheet.Cells[row, 54] = model.Age18BelowOrUpper;

                    Console.WriteLine(model.Fio);
                    Console.WriteLine(row);
                    row++;
                }

                var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "OUT", string.Format("{0}-{1}", fileName ?? "Migrantlar", DateTime.Now.ToString("yyyyMMddhhmmss")));
                xlWorkBook.SaveAs(path);
                xlApp.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //xlApp.Quit();
                xlWorkBook = null;
                xlApp = null;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (db != null)
            {
                db.Dispose();
            }

            this.Close();
        }

        public MigrantImportModel SelectedModel { get; set; }
        public List<MigrantImportModel> MigrantImportModels { get; set; } = new List<MigrantImportModel>();

        private async void MainForm_Load(object sender, EventArgs e)
        {
            MigrantImportModels = await db.MigrantImportModels.ToListAsync();

            foreach (var item in MigrantImportModels)
            {
                dgvMigrants.Rows.Add(item.Id, item.Fio, item.SeriaPassport, item.RaqamPassport);
            }

        }

        private DatabaseContext db = new DatabaseContext();
    }
}
