using CoreDataProcessing;
using NavoiKasabaUyushmasi.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelAnketaProcessorConsole
{
    public class ExcelController
    {
        public ExcelController(IDataProcessing dataProcessing)
        {
            this.dataProcessing = dataProcessing;
        }

        public void ReadAllVipiskaFiles()
        {
            //Files
            var path = Path.Combine(Directory.GetCurrentDirectory(), "IN");

            var files = Directory.GetFiles(path, "*.xls*");

            foreach (var spath in files)
            {
                Console.WriteLine(spath);

                var models = ReadFromExcel(spath);

                var cleanData = dataProcessing.ProcessData(models);

                Export2Excel(cleanData, Path.GetFileNameWithoutExtension(spath));

                if (File.Exists(spath))
                {
                    KillExcel();
                    File.Delete(spath);
                }

                Console.WriteLine("Keyingi faylni qayta ishlash? Y/N");

                string res = Console.ReadLine();

                if (!res.Equals("Y"))
                {
                    break;
                }
            }
        }

        void KillExcel()
        {
            foreach (var process in Process.GetProcessesByName("EXCEL"))
            {
                process.Kill();
            }
        }

        public List<MigrantImportModel> ReadFromExcel(string path)
        {
            var migrantImportModels = new List<MigrantImportModel>();

            Excel.Application xlApp = new Excel.Application();

            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(path);

            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            try
            {
                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                int startRow = 8;
                int totalRowsCounter = 0;
                int emptyRowsCounter = 0;

                Console.WriteLine("Excel Filedan o'qish boshlandi ...");

                while (true)
                {
                    var model = new MigrantImportModel();

                    if (emptyRowsCounter >= 5)
                    {
                        break;
                    }

                    if (xlRange.Cells[startRow, 1].Value2 == null || (xlRange.Cells[startRow, 9] == null &&
                        xlRange.Cells[startRow, 3] == null))
                    {
                        emptyRowsCounter++;
                        startRow++;
                        continue;
                    }

                    #region Initialization
                    if (xlRange.Cells[startRow, 1] != null && xlRange.Cells[startRow, 1].Value2 != null)
                    {
                        model.TartibRaqami = xlRange.Cells[startRow, 1].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 2] != null && xlRange.Cells[startRow, 2].Value2 != null)
                    {
                        model.XududNomi = xlRange.Cells[startRow, 2].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 3] != null && xlRange.Cells[startRow, 3].Value2 != null)
                    {
                        model.SorIshtirFio = xlRange.Cells[startRow, 3].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 4] != null && xlRange.Cells[startRow, 4].Value2 != null)
                    {
                        model.SorIshtirQarindoshligi = xlRange.Cells[startRow, 4].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 5] != null && xlRange.Cells[startRow, 5].Value2 != null)
                    {
                        model.SorIshtirPassportSeria = xlRange.Cells[startRow, 5].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 6] != null && xlRange.Cells[startRow, 6].Value2 != null)
                    {
                        model.SorIshtirPassportRaqam = xlRange.Cells[startRow, 6].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 7] != null && xlRange.Cells[startRow, 7].Value2 != null)
                    {
                        model.SorIshtirTelefonRaqam = xlRange.Cells[startRow, 7].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 8] != null && xlRange.Cells[startRow, 8].Value2 != null)
                    {
                        model.Jinsi = xlRange.Cells[startRow, 8].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 9] != null && xlRange.Cells[startRow, 9].Value2 != null)
                    {
                        model.Fio = xlRange.Cells[startRow, 9].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 10] != null && xlRange.Cells[startRow, 10].Value2 != null)
                    {
                        model.SeriaPassport = xlRange.Cells[startRow, 10].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 11] != null && xlRange.Cells[startRow, 11].Value2 != null)
                    {
                        model.RaqamPassport = xlRange.Cells[startRow, 11].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 12] != null && xlRange.Cells[startRow, 12].Value2 != null)
                    {
                        model.TugilganKun = xlRange.Cells[startRow, 12].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 13] != null && xlRange.Cells[startRow, 13].Value2 != null)
                    {
                        model.TugilganOy = xlRange.Cells[startRow, 13].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 14] != null && xlRange.Cells[startRow, 14].Value2 != null)
                    {
                        model.TugilganYil = xlRange.Cells[startRow, 14].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 15] != null && xlRange.Cells[startRow, 15].Value2 != null)
                    {
                        model.Yiloyat = xlRange.Cells[startRow, 15].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 16] != null && xlRange.Cells[startRow, 16].Value2 != null)
                    {
                        model.Tuman = xlRange.Cells[startRow, 16].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 17] != null && xlRange.Cells[startRow, 17].Value2 != null)
                    {
                        model.Mahalla = xlRange.Cells[startRow, 17].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 18] != null && xlRange.Cells[startRow, 18].Value2 != null)
                    {
                        model.Kocha = xlRange.Cells[startRow, 18].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 19] != null && xlRange.Cells[startRow, 19].Value2 != null)
                    {
                        model.Uy = xlRange.Cells[startRow, 19].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 20] != null && xlRange.Cells[startRow, 20].Value2 != null)
                    {
                        model.Xonadon = xlRange.Cells[startRow, 20].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 21] != null && xlRange.Cells[startRow, 21].Value2 != null)
                    {
                        model.FuqorolikXolati = xlRange.Cells[startRow, 21].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 22] != null && xlRange.Cells[startRow, 22].Value2 != null)
                    {
                        model.Malumoti = xlRange.Cells[startRow, 22].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 23] != null && xlRange.Cells[startRow, 23].Value2 != null)
                    {
                        model.Mutaxasisligi = xlRange.Cells[startRow, 23].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 24] != null && xlRange.Cells[startRow, 24].Value2 != null)
                    {
                        model.XozirgiXolati = xlRange.Cells[startRow, 24].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 25] != null && xlRange.Cells[startRow, 25].Value2 != null)
                    {
                        model.UzbgaQaytganSanasi = xlRange.Cells[startRow, 25].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 26] != null && xlRange.Cells[startRow, 26].Value2 != null)
                    {
                        model.Sogligi = xlRange.Cells[startRow, 26].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 27] != null && xlRange.Cells[startRow, 27].Value2 != null)
                    {
                        model.OilaviyXolati = xlRange.Cells[startRow, 27].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 28] != null && xlRange.Cells[startRow, 28].Value2 != null)
                    {
                        model.OilaviyMuxiti = xlRange.Cells[startRow, 28].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 29] != null && xlRange.Cells[startRow, 29].Value2 != null)
                    {
                        model.JamiFarzandlarSoni = xlRange.Cells[startRow, 29].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 30] != null && xlRange.Cells[startRow, 30].Value2 != null)
                    {
                        model.VoyagaEtmaganFarzandlarSoni = xlRange.Cells[startRow, 30].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 31] != null && xlRange.Cells[startRow, 31].Value2 != null)
                    {
                        model.VoyagaEtganFarzandlarSoni = xlRange.Cells[startRow, 31].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 32] != null && xlRange.Cells[startRow, 32].Value2 != null)
                    {
                        model.IjtimoiyXolati = xlRange.Cells[startRow, 32].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 33] != null && xlRange.Cells[startRow, 33].Value2 != null)
                    {
                        model.XorijgaKetganSanasi = xlRange.Cells[startRow, 33].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 34] != null && xlRange.Cells[startRow, 34].Value2 != null)
                    {
                        model.DavlatVaXudud = xlRange.Cells[startRow, 34].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 35] != null && xlRange.Cells[startRow, 35].Value2 != null)
                    {
                        model.IshlashRuxsatnomasiMavjudligi = xlRange.Cells[startRow, 35].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 36] != null && xlRange.Cells[startRow, 36].Value2 != null)
                    {
                        model.XorijdagiBirOylikDaromadi = xlRange.Cells[startRow, 36].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 37] != null && xlRange.Cells[startRow, 37].Value2 != null)
                    {
                        model.XorijdaBirgalikdagiOilaAzolari = xlRange.Cells[startRow, 37].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 38] != null && xlRange.Cells[startRow, 38].Value2 != null)
                    {
                        model.XorijgaKetishMaqsadi = xlRange.Cells[startRow, 38].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 39] != null && xlRange.Cells[startRow, 39].Value2 != null)
                    {
                        model.ChetEldagiIshTuri = xlRange.Cells[startRow, 39].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 40] != null && xlRange.Cells[startRow, 40].Value2 != null)
                    {
                        model.ChetEldanQaytishIstagiBorligi = xlRange.Cells[startRow, 40].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 41] != null && xlRange.Cells[startRow, 41].Value2 != null)
                    {
                        model.XorijdagiMuammolarSoni = xlRange.Cells[startRow, 41].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 42] != null && xlRange.Cells[startRow, 42].Value2 != null)
                    {
                        model.OiladagiMuammolarSoni = xlRange.Cells[startRow, 42].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 43] != null && xlRange.Cells[startRow, 43].Value2 != null)
                    {
                        model.NimaYordamBerilsaQaytadi = xlRange.Cells[startRow, 43].Value2.ToString();
                    }

                    if (xlRange.Cells[startRow, 44] != null && xlRange.Cells[startRow, 44].Value2 != null)
                    {
                        model.XorijdagiFuqaroTelefonRaqami = xlRange.Cells[startRow, 44].Value2.ToString();
                    }
                    #endregion

                    Console.WriteLine($"Row {startRow} processed");
                    Console.WriteLine(model.Fio);
                    startRow++;
                    emptyRowsCounter = 0;
                    migrantImportModels.Add(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();

                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }

            return migrantImportModels;
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
                xlWorkSheet.Cells[1, 35] = "Ishlash ruxsatnomasi mavjudligi";
                xlWorkSheet.Cells[1, 36] = "Xorijda bir oylik daromadi";
                xlWorkSheet.Cells[1, 37] = "Xorijda birgalikdagi oila azolari";
                xlWorkSheet.Cells[1, 38] = "Xorijga ketish maqsadi";
                xlWorkSheet.Cells[1, 39] = "Chet eldagi ish turi";
                xlWorkSheet.Cells[1, 40] = "Chet eldan qaytish istagi borligi";
                xlWorkSheet.Cells[1, 41] = "Xorijdagi muammolar soni";
                xlWorkSheet.Cells[1, 42] = "Oiladagi muammolar soni";
                xlWorkSheet.Cells[1, 43] = "Nima yordam berilsa qaytadi";
                xlWorkSheet.Cells[1, 44] = "Xorijdagi fuqaro telefon raqami";
                xlWorkSheet.Cells[1, 45] = "Bazada Borligi (0 - Yo'q 1 - Bor)";
                xlWorkSheet.Cells[1, 46] = "18 yoshdan katta kichik";
                #endregion

                Console.WriteLine("Excelga yozish boshlandi ...");

                int row = 2;
                foreach (var model in migrantImportModels)
                {
                    xlWorkSheet.Cells[row, 1] = model.TartibRaqami;
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
                    xlWorkSheet.Cells[row, 34] = model.DavlatVaXudud;
                    xlWorkSheet.Cells[row, 35] = model.IshlashRuxsatnomasiMavjudligi;
                    xlWorkSheet.Cells[row, 36] = model.XorijdagiBirOylikDaromadi;
                    xlWorkSheet.Cells[row, 37] = model.XorijdaBirgalikdagiOilaAzolari;
                    xlWorkSheet.Cells[row, 38] = model.XorijgaKetishMaqsadi;
                    xlWorkSheet.Cells[row, 39] = model.ChetEldagiIshTuri;
                    xlWorkSheet.Cells[row, 40] = model.ChetEldanQaytishIstagiBorligi;
                    xlWorkSheet.Cells[row, 41] = model.XorijdagiMuammolarSoni;
                    xlWorkSheet.Cells[row, 42] = model.OiladagiMuammolarSoni;
                    xlWorkSheet.Cells[row, 43] = model.NimaYordamBerilsaQaytadi;
                    xlWorkSheet.Cells[row, 44] = model.XorijdagiFuqaroTelefonRaqami;
                    xlWorkSheet.Cells[row, 45] = model.BazadaBorligi;
                    xlWorkSheet.Cells[row, 46] = model.Age18BelowOrUpper;

                    Console.WriteLine(model.Fio);
                    Console.WriteLine(row);
                    row++;
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "OUT", string.Format("{0}-{1}", fileName ?? "Migrantlar", DateTime.Now.ToString("yyyyMMddhhmmss")));
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

        private readonly IDataProcessing dataProcessing;
    }
}
