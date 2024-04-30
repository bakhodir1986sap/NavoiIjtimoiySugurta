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
    public partial class AnketaForm : Form
    {
        public AnketaForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                return;
            }

            CurrentModel = new MigrantImportModel
            {
                XududNomi = txbTumanNomi.Text,
                KiritayotganMFY = txbMahallaNomi.Text,
                SorIshtirFio = txbSorFio.Text,
                SorIshtirQarindoshligi = txbQarindoshligi.Text,
                SorIshtirPassportSeria = txbSorPassSeria.Text,
                SorIshtirPassportRaqam = txbSorPassNumber.Text,
                SorIshtirTelefonRaqam = txbSorTelNumber.Text,
                Jinsi = Jinsi,
                Fio = txbFio.Text,
                SeriaPassport = txbPassSeria.Text,
                RaqamPassport = txbPassNum.Text,
                TugilganKun = dtpBirthDate.Value.Day.ToString(),
                TugilganOy = dtpBirthDate.Value.Month.ToString(),
                TugilganYil = dtpBirthDate.Value.Year.ToString(),
                Yiloyat = txbAddressViloyat.Text,
                Tuman = txbAddressTuman.Text,
                Mahalla = txbAddressMFY.Text,
                Kocha = txbAddressKucha.Text,
                Uy = txbAddressUy.Text,
                Xonadon = txbAddressXonadon.Text,
                FuqorolikXolati = FuqorolikXolati,
                Malumoti = Malumoti,
                Mutaxasisligi = txbSpeciality.Text,
                XozirgiXolati = XozirgiXolati,
                UzbgaQaytganSanasi = IsPersonOut ? string.Empty : dtpReturnDate.Checked ? 
                dtpReturnDate.Value.ToString("dd.MM.yyyy")
                : DateTime.Now.ToString("dd.MM.yyyy"),
                Sogligi = IsPersonOut ?  Sogligi : string.Empty,
                OilaviyXolati = IsPersonOut ?  OilaviyXolati : string.Empty,
                OilaviyMuxiti = IsPersonOut ? OilaviyMuxiti : string.Empty,
                JamiFarzandlarSoni = IsPersonOut ? txbChildrenCount.Text : "0",
                VoyagaEtmaganFarzandlarSoni = IsPersonOut ? txbChildrenUnder18.Text : "0",
                IjtimoiyXolati = IsPersonOut ? IjtimoiyXolati : string.Empty,
                XorijgaKetganSanasi = IsPersonOut ? dtpLeaveDate.Checked ?
                        dtpLeaveDate.Value.ToString("dd.MM.yyyy") : string.Empty : string.Empty,
                DavlatVaXudud = IsPersonOut ? DavlatVaXudud : string.Empty,
                IshlashRuxsatnomasiMavjudligi = IsPersonOut ? IshlashRuxsatnomasiMavjudligi : string.Empty,
                XorijdagiBirOylikDaromadi = IsPersonOut ? txbIncomeValue.Text : string.Empty,
                XorijdaBirgalikdagiOilaAzolari = IsPersonOut ? XorijdaBirgalikdagiOilaAzolari : string.Empty,
                XorijgaKetishMaqsadi = IsPersonOut ? XorijgaKetishMaqsadi : string.Empty,
                ChetEldagiIshTuri = IsPersonOut ? ChetEldagiIshTuri : string.Empty,
                ChetEldanQaytishIstagiBorligi = IsPersonOut ? ChetEldanQaytishIstagiBorligi : string.Empty,
                OiladagiMuammolarSoni = IsPersonOut ? OiladagiMuammolarSoni : "0",
                XorijdagiMuammolarSoni = IsPersonOut ? XorijdagiMuammolarSoni : "0",
                NimaYordamBerilsaQaytadi = IsPersonOut ? NimaYordamBerilsaQaytadi : string.Empty,
                XorijdagiFuqaroTelefonRaqami = IsPersonOut ? txbForeignPersonPhone.Text : string.Empty,
            };

            DialogResult = DialogResult.OK;
        }

        private string Jinsi
        {
            get
            {
                if (rdbErkak.Checked)
                {
                    return rdbErkak.Text;
                }

                if (rdbAyol.Checked)
                {
                    return rdbErkak.Text;
                }

                return string.Empty;
            }
        }

        private string FuqorolikXolati
        {
            get
            {
                if (rdbUzbCitizen.Checked)
                {
                    return rdbUzbCitizen.Text;
                }

                if (rdbForeign.Checked)
                {
                    return rdbForeign.Text;
                }

                if (rdbNoCitizen.Checked)
                {
                    return rdbNoCitizen.Text;
                }

                return string.Empty;
            }
        }

        private string Malumoti
        {
            get
            {
                if (rdbEducationHigh.Checked)
                {
                    return rdbEducationHigh.Text;
                }

                if (rdbEducationAverageSpec.Checked)
                {
                    return rdbEducationAverageSpec.Text;
                }

                if (rdbEducationAverage.Checked)
                {
                    return rdbEducationAverage.Text;
                }

                if (rdbEducationNo.Checked)
                {
                    return rdbEducationNo.Text;
                }

                return string.Empty;
            }
        }

        private string XozirgiXolati
        {
            get
            {
                if (rdbCurStateOut.Checked)
                {
                    return rdbCurStateOut.Text;
                }

                if (rdbCurStateOutJIEM.Checked)
                {
                    return rdbCurStateOutJIEM.Text;
                }

                if (rdbCurStateLost.Checked)
                {
                    return rdbCurStateLost.Text;
                }

                if (rdbCurStateReturn.Checked)
                {
                    return rdbCurStateReturn.Text;
                }

                if (rdbCurStateDied.Checked)
                {
                    return rdbCurStateDied.Text;
                }

                if (rdbCurStateWanted.Checked)
                {
                    return rdbCurStateWanted.Text;
                }

                return string.Empty;
            }
        }

        private bool IsPersonOut
        {
            get
            {
                return rdbCurStateOut.Checked || rdbCurStateOutJIEM.Checked;
            }
        }

        private string Sogligi
        {
            get
            {
                if (rdbHealthGood.Checked)
                {
                    return rdbHealthGood.Text;
                }

                if (rdbHealthIllPerm.Checked)
                {
                    return rdbHealthIllPerm.Text;
                }

                if (rdbHealthInvalid.Checked)
                {
                    return rdbHealthInvalid.Text;
                }

                return string.Empty;
            }
        }

        private string OilaviyXolati
        {
            get
            {
                if (rdbFamilyStateFamily.Checked)
                {
                    return rdbFamilyStateFamily.Text;
                }

                if (rdbFamilyStateNoFamily.Checked)
                {
                    return rdbFamilyStateNoFamily.Text;
                }

                if (rdbFamilyStateDevorsed.Checked)
                {
                    return rdbFamilyStateDevorsed.Text;
                }

                if (rdbFamilyStateLoanlyMother.Checked)
                {
                    return rdbFamilyStateLoanlyMother.Text;
                }

                if (rdbFamilyStateSpouseDied.Checked)
                {
                    return rdbFamilyStateSpouseDied.Text;
                }

                return string.Empty;
            }
        }

        private string OilaviyMuxiti
        {
            get
            {
                if (rdbFamilyEnvironmentQuite.Checked)
                {
                    return rdbFamilyEnvironmentQuite.Text;
                }

                if (rdbFamilyEnvironmentNonQuite.Checked)
                {
                    return rdbFamilyEnvironmentNonQuite.Text;
                }

                return string.Empty;
            }
        }

        private string IjtimoiyXolati
        {
            get
            {
                if (rdbSocialStatePoor.Checked)
                {
                    return rdbSocialStatePoor.Text;
                }

                if (rdbSocialStateAvarage.Checked)
                {
                    return rdbSocialStateAvarage.Text;
                }

                if (rdbSocialStateGood.Checked)
                {
                    return rdbSocialStateGood.Text;
                }

                return string.Empty;
            }
        }

        private string DavlatVaXudud
        {
            get
            {
                if (rdbLeaveCountryRussia.Checked)
                {
                    return rdbLeaveCountryRussia.Text;
                }

                if (rdbLeaveCountryKazakstan.Checked)
                {
                    return rdbLeaveCountryKazakstan.Text;
                }

                if (rdbLeaveCountryTurkey.Checked)
                {
                    return rdbLeaveCountryTurkey.Text;
                }

                if (rdbLeaveCountryKorea.Checked)
                {
                    return rdbLeaveCountryKorea.Text;
                }

                if (rdbLeaveCountryOthers.Checked)
                {
                    return rdbLeaveCountryOthers.Text;
                }

                return string.Empty;
            }
        }

        private string IshlashRuxsatnomasiMavjudligi
        {
            get
            {
                if (rdbWorkPermitExists.Checked)
                {
                    return rdbWorkPermitExists.Text;
                }

                if (rdbWorkPermitNotExists.Checked)
                {
                    return rdbWorkPermitNotExists.Text;
                }

                return string.Empty;
            }
        }

        private string XorijdaBirgalikdagiOilaAzolari
        {
            get
            {
                string result = string.Empty;

                if (chbOutTogatherSpouse.Checked)
                {
                    result += chbOutTogatherSpouse.Text + ",";
                }

                if (chbOutTogatherChild.Checked)
                {
                    result += chbOutTogatherChild.Text + ",";
                }

                if (chbOutTogatherFather.Checked)
                {
                    result += chbOutTogatherFather.Text + ",";
                }

                if (chbOutTogatherMother.Checked)
                {
                    result += chbOutTogatherMother.Text + ",";
                }

                if (chbOutTogatherBrother.Checked)
                {
                    result += chbOutTogatherBrother.Text + ",";
                }

                if (chbOutTogatherSister.Checked)
                {
                    result += chbOutTogatherSister.Text + ",";
                }

                if (chbOutTogatherOthers.Checked)
                {
                    result += chbOutTogatherOthers.Text + ",";
                }

                return result;
            }
        }

        private string XorijgaKetishMaqsadi
        {
            get
            {
                if (rdbLeaveReasonWork.Checked)
                {
                    return rdbLeaveReasonWork.Text;
                }

                if (rdbLeaveReasonTreatment.Checked)
                {
                    return rdbLeaveReasonTreatment.Text;
                }

                if (rdbLeaveReasonEducation.Checked)
                {
                    return rdbLeaveReasonEducation.Text;
                }

                if (rdbLeaveReasonTempLive.Checked)
                {
                    return rdbLeaveReasonTempLive.Text;
                }

                if (rdbLeaveReasonTravel.Checked)
                {
                    return rdbLeaveReasonTravel.Text;
                }

                if (rdbLeaveReasonMerriage.Checked)
                {
                    return rdbLeaveReasonMerriage.Text;
                }

                if (rdbLeaveReasonOthers.Checked)
                {
                    return rdbLeaveReasonOthers.Text;
                }

                if (rdbLeaveReasonPermanentLive.Checked)
                {
                    return rdbLeaveReasonPermanentLive.Text;
                }

                return string.Empty;
            }
        }

        private string ChetEldagiIshTuri
        {
            get
            {
                if (rdbWorkOutsiteTypeBuilder.Checked)
                {
                    return rdbWorkOutsiteTypeBuilder.Text;
                }

                if (rdbWorkOutsiteTypeSeller.Checked)
                {
                    return rdbWorkOutsiteTypeSeller.Text;
                }

                if (rdbWorkOutsiteTypeTruck.Checked)
                {
                    return rdbWorkOutsiteTypeTruck.Text;
                }

                if (rdbWorkOutsiteTypeCare.Checked)
                {
                    return rdbWorkOutsiteTypeCare.Text;
                }

                if (rdbWorkOutsiteTypeCleaning.Checked)
                {
                    return rdbWorkOutsiteTypeCleaning.Text;
                }

                if (rdbWorkOutsiteTypeBeautySalon.Checked)
                {
                    return rdbWorkOutsiteTypeBeautySalon.Text;
                }

                if (rdbWorkOutsiteTypeGoverment.Checked)
                {
                    return rdbWorkOutsiteTypeGoverment.Text;
                }

                if (rdbWorkOutsiteTypeEnterprieneur.Checked)
                {
                    return rdbWorkOutsiteTypeEnterprieneur.Text;
                }

                if (rdbWorkOutsiteTypeOthers.Checked)
                {
                    return rdbWorkOutsiteTypeOthers.Text;
                }

                return string.Empty;
            }
        }

        private string ChetEldanQaytishIstagiBorligi
        {
            get
            {
                if (rdbHaveAWillToReturnBackYes.Checked)
                {
                    return rdbHaveAWillToReturnBackYes.Text;
                }

                if (rdbHaveAWillToReturnBackNo.Checked)
                {
                    return rdbHaveAWillToReturnBackNo.Text;
                }

                return string.Empty;
            }
        }

        private string OiladagiMuammolarSoni
        {
            get
            {
                int result = 0;
                if (chbFamilyProblemsWorkless.Checked)
                {
                    result++;
                }

                if (chbFamilyProblemsEducation.Checked)
                {
                    result++;
                }

                if (chbFamilyProblemsTreatment.Checked)
                {
                    result++;
                }

                if (chbFamilyProblemsFamily.Checked)
                {
                    result++;
                }

                if (chbFamilyProblemsPlaceToLive.Checked)
                {
                    result++;
                }

                if (chbFamilyProblemsRepairment.Checked)
                {
                    result++;
                }

                if (chbFamilyProblemsOthers.Checked)
                {
                    result++;
                }

                return result.ToString();
            }
        }

        private string XorijdagiMuammolarSoni
        {
            get
            {
                int result = 0;
                if (chbOutPersonProblemsLostPassport.Checked)
                {
                    result++;
                }

                if (chbOutPersonProblemsWorkless.Checked)
                {
                    result++;
                }

                if (chbOutPersonProblemsNoPayment.Checked)
                {
                    result++;
                }

                if (chbOutPersonProblemsPersonSold.Checked)
                {
                    result++;
                }

                if (chbOutPersonProblemsLivePermitless.Checked)
                {
                    result++;
                }

                if (chbOutPersonProblemsWorkPermitless.Checked)
                {
                    result++;
                }

                if (chbOutPersonProblemsOthers.Checked)
                {
                    result++;
                }

                return result.ToString();
            }
        }

        private string NimaYordamBerilsaQaytadi
        {
            get
            {
                if (rdbHowHelpWork.Checked)
                {
                    return rdbHowHelpWork.Text;
                }

                if (rdbHowHelpEducation.Checked)
                {
                    return rdbHowHelpEducation.Text;
                }

                if (rdbHowHelpMedicalTreatment.Checked)
                {
                    return rdbHowHelpMedicalTreatment.Text;
                }

                if (rdbHowHelpMedicalHouse.Checked)
                {
                    return rdbHowHelpMedicalHouse.Text;
                }

                if (rdbHowHelpMedicalRepairment.Checked)
                {
                    return rdbHowHelpMedicalRepairment.Text;
                }

                if (rdbHowHelpMedicalFamily.Checked)
                {
                    return rdbHowHelpMedicalFamily.Text;
                }

                if (rdbHowHelpMedicalWeddings.Checked)
                {
                    return rdbHowHelpMedicalWeddings.Text;
                }

                if (rdbHowHelpMedicalOther.Checked)
                {
                    return rdbHowHelpMedicalOther.Text;
                }

                return string.Empty;
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(txbTumanNomi.Text))
            {
                MessageBox.Show("Tuman nomini kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedTab = tabPage1;
                txbTumanNomi.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txbMahallaNomi.Text))
            {
                MessageBox.Show("Mahalla nomini kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedTab = tabPage1;
                txbMahallaNomi.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txbFio.Text))
            {
                MessageBox.Show("F.I.O. ni kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedTab = tabPage2;
                txbFio.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txbSorFio.Text))
            {
                MessageBox.Show("So'rovnoma ishtirokchisini kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedTab = tabPage1;
                txbSorFio.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txbSorPassSeria.Text))
            {
                MessageBox.Show("So'rovnoma ishtirokchisi Passport Seria kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedTab = tabPage1;
                txbSorPassSeria.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txbSorPassNumber.Text))
            {
                MessageBox.Show("So'rovnoma ishtirokchisi Passport Nomer kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedTab = tabPage1;
                txbSorPassNumber.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txbSorTelNumber.Text))
            {
                MessageBox.Show("So'rovnoma ishtirokchisi telefon raqamini kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedTab = tabPage1;
                txbSorTelNumber.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txbPassSeria.Text))
            {
                MessageBox.Show("Xorijdagi fuqaro passport seriasini kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedTab = tabPage2;
                txbPassSeria.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txbPassNum.Text))
            {
                MessageBox.Show("Xorijdagi fuqaro passport nomerini kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedTab = tabPage2;
                txbPassNum.Focus();
                return false;
            }

            return true;
        }

        public MigrantImportModel CurrentModel { get; set; }

        private void rdbCurStateReturn_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCurStateReturn.Checked)
            {
                dtpReturnDate.Checked = true;
            }
            else
            {
                dtpReturnDate.Checked = false;
            }
        }
    }
}
