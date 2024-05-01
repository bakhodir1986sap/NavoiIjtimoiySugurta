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

            if (!IsInEditMode)
            {
                CurrentModel = new MigrantImportModel
                {
                    XududNomi = cbxTumanNomi.SelectedItem.ToString(),
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
                    Sogligi = IsPersonOut ? Sogligi : string.Empty,
                    OilaviyXolati = IsPersonOut ? OilaviyXolati : string.Empty,
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
                    Age18BelowOrUpper = Age18BelowOrUpper,
                    OiladagiMuammolari = IsPersonOut ? OiladagiMuammolari : string.Empty,
                    XorijdagiMuammolari = IsPersonOut ? XorijdagiMuammolari : string.Empty,
                    ChetEldagiIshTuriBoshqalari = IsPersonOut ? txbWorkOutsiteTypeOthers.Text : string.Empty,
                    OiladagiMuammolariBoshqalari = IsPersonOut ? txbFamilyProblemsOthers.Text : string.Empty,
                    XorijdagiMuammolariBoshqalari = IsPersonOut ? txbchbOutPersonProblemsOthers.Text : string.Empty,
                    NimaYordamBerilsaQaytadiBoshqalari = IsPersonOut ? txbHowHelpMedicalOther.Text : string.Empty,
                    XorijgaKetishMaqsadiBoshqalari = IsPersonOut ? txbLeaveReasonOthers.Text : string.Empty,
                    DavlatVaXududBoshqalari = IsPersonOut ? txbLeaveCountryOthers.Text : string.Empty,
                };
            }
            else
            {
                    CurrentModel.XududNomi = cbxTumanNomi.SelectedItem.ToString();
                    CurrentModel.KiritayotganMFY = txbMahallaNomi.Text;
                    CurrentModel.SorIshtirFio = txbSorFio.Text;
                    CurrentModel.SorIshtirQarindoshligi = txbQarindoshligi.Text;
                    CurrentModel.SorIshtirPassportSeria = txbSorPassSeria.Text;
                    CurrentModel.SorIshtirPassportRaqam = txbSorPassNumber.Text;
                    CurrentModel.SorIshtirTelefonRaqam = txbSorTelNumber.Text;
                    CurrentModel.Jinsi = Jinsi;
                    CurrentModel.Fio = txbFio.Text;
                    CurrentModel.SeriaPassport = txbPassSeria.Text;
                    CurrentModel.RaqamPassport = txbPassNum.Text;
                    CurrentModel.TugilganKun = dtpBirthDate.Value.Day.ToString();
                    CurrentModel.TugilganOy = dtpBirthDate.Value.Month.ToString();
                    CurrentModel.TugilganYil = dtpBirthDate.Value.Year.ToString();
                    CurrentModel.Yiloyat = txbAddressViloyat.Text;
                    CurrentModel.Tuman = txbAddressTuman.Text;
                    CurrentModel.Mahalla = txbAddressMFY.Text;
                    CurrentModel.Kocha = txbAddressKucha.Text;
                    CurrentModel.Uy = txbAddressUy.Text;
                    CurrentModel.Xonadon = txbAddressXonadon.Text;
                    CurrentModel.FuqorolikXolati = FuqorolikXolati;
                    CurrentModel.Malumoti = Malumoti;
                    CurrentModel.Mutaxasisligi = txbSpeciality.Text;
                    CurrentModel.XozirgiXolati = XozirgiXolati;
                    CurrentModel.UzbgaQaytganSanasi = IsPersonOut ? string.Empty : dtpReturnDate.Checked ?
                    dtpReturnDate.Value.ToString("dd.MM.yyyy")
                    : DateTime.Now.ToString("dd.MM.yyyy");
                    CurrentModel.Sogligi = IsPersonOut ? Sogligi : string.Empty;
                    CurrentModel.OilaviyXolati = IsPersonOut ? OilaviyXolati : string.Empty;
                    CurrentModel.OilaviyMuxiti = IsPersonOut ? OilaviyMuxiti : string.Empty;
                    CurrentModel.JamiFarzandlarSoni = IsPersonOut ? txbChildrenCount.Text : "0";
                    CurrentModel.VoyagaEtmaganFarzandlarSoni = IsPersonOut ? txbChildrenUnder18.Text : "0";
                    CurrentModel.IjtimoiyXolati = IsPersonOut ? IjtimoiyXolati : string.Empty;
                    CurrentModel.XorijgaKetganSanasi = IsPersonOut ? dtpLeaveDate.Checked ?
                            dtpLeaveDate.Value.ToString("dd.MM.yyyy") : string.Empty : string.Empty;
                    CurrentModel.DavlatVaXudud = IsPersonOut ? DavlatVaXudud : string.Empty;
                    CurrentModel.IshlashRuxsatnomasiMavjudligi = IsPersonOut ? IshlashRuxsatnomasiMavjudligi : string.Empty;
                    CurrentModel.XorijdagiBirOylikDaromadi = IsPersonOut ? txbIncomeValue.Text : string.Empty;
                    CurrentModel.XorijdaBirgalikdagiOilaAzolari = IsPersonOut ? XorijdaBirgalikdagiOilaAzolari : string.Empty;
                    CurrentModel.XorijgaKetishMaqsadi = IsPersonOut ? XorijgaKetishMaqsadi : string.Empty;
                    CurrentModel.ChetEldagiIshTuri = IsPersonOut ? ChetEldagiIshTuri : string.Empty;
                    CurrentModel.ChetEldanQaytishIstagiBorligi = IsPersonOut ? ChetEldanQaytishIstagiBorligi : string.Empty;
                    CurrentModel.OiladagiMuammolarSoni = IsPersonOut ? OiladagiMuammolarSoni : "0";
                    CurrentModel.XorijdagiMuammolarSoni = IsPersonOut ? XorijdagiMuammolarSoni : "0";
                    CurrentModel.NimaYordamBerilsaQaytadi = IsPersonOut ? NimaYordamBerilsaQaytadi : string.Empty;
                    CurrentModel.XorijdagiFuqaroTelefonRaqami = IsPersonOut ? txbForeignPersonPhone.Text : string.Empty;
                    CurrentModel.Age18BelowOrUpper = Age18BelowOrUpper;
                    CurrentModel.ChetEldagiIshTuriBoshqalari = IsPersonOut ? txbWorkOutsiteTypeOthers.Text : string.Empty;
                    CurrentModel.OiladagiMuammolariBoshqalari = IsPersonOut ? txbFamilyProblemsOthers.Text : string.Empty;
                    CurrentModel.XorijdagiMuammolariBoshqalari = IsPersonOut ? txbchbOutPersonProblemsOthers.Text : string.Empty;
                    CurrentModel.NimaYordamBerilsaQaytadiBoshqalari = IsPersonOut ? txbHowHelpMedicalOther.Text : string.Empty;
                    CurrentModel.XorijgaKetishMaqsadiBoshqalari = IsPersonOut ? txbLeaveReasonOthers.Text : string.Empty;
                    CurrentModel.DavlatVaXududBoshqalari = IsPersonOut ? txbLeaveCountryOthers.Text : string.Empty;
            }


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
                    return rdbAyol.Text;
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

        private string OiladagiMuammolari
        {
            get
            {
                string result = string.Empty;

                if (chbFamilyProblemsWorkless.Checked)
                {
                    result += chbFamilyProblemsWorkless.Text + ",";
                }

                if (chbFamilyProblemsEducation.Checked)
                {
                    result += chbFamilyProblemsEducation.Text + ",";
                }

                if (chbFamilyProblemsTreatment.Checked)
                {
                    result += chbFamilyProblemsTreatment.Text + ",";
                }

                if (chbFamilyProblemsFamily.Checked)
                {
                    result += chbFamilyProblemsFamily.Text + ",";
                }

                if (chbFamilyProblemsPlaceToLive.Checked)
                {
                    result += chbFamilyProblemsPlaceToLive.Text + ",";
                }

                if (chbFamilyProblemsRepairment.Checked)
                {
                    result += chbFamilyProblemsRepairment.Text + ",";
                }

                if (chbFamilyProblemsOthers.Checked)
                {
                    result += chbFamilyProblemsOthers.Text + ",";
                }

                return result;
            }
        }

        private string XorijdagiMuammolari
        {
            get
            {
                string result = string.Empty;

                if (chbOutPersonProblemsLostPassport.Checked)
                {
                    result += chbOutPersonProblemsLostPassport.Text + ",";
                }

                if (chbOutPersonProblemsWorkless.Checked)
                {
                    result += chbOutPersonProblemsWorkless.Text + ",";
                }

                if (chbOutPersonProblemsNoPayment.Checked)
                {
                    result += chbOutPersonProblemsNoPayment.Text + ",";
                }

                if (chbOutPersonProblemsPersonSold.Checked)
                {
                    result += chbOutPersonProblemsPersonSold.Text + ",";
                }

                if (chbOutPersonProblemsLivePermitless.Checked)
                {
                    result += chbOutPersonProblemsLivePermitless.Text + ",";
                }

                if (chbOutPersonProblemsWorkPermitless.Checked)
                {
                    result += chbOutPersonProblemsWorkPermitless.Text + ",";
                }

                if (chbOutPersonProblemsOthers.Checked)
                {
                    result += chbOutPersonProblemsOthers.Text + ",";
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
               string result = string.Empty;

                if (chbrHowHelpWork.Checked)
                {
                    result += chbrHowHelpWork.Text + ",";
                }

                if (chbHowHelpEducation.Checked)
                {
                    result += chbHowHelpEducation.Text + ",";
                }

                if (chbHowHelpMedicalTreatment.Checked)
                {
                    result += chbHowHelpMedicalTreatment.Text + ",";
                }

                if (chbHowHelpMedicalFamily.Checked)
                {
                    result += chbHowHelpMedicalFamily.Text + ",";
                }

                if (chbHowHelpMedicalHouse.Checked)
                {
                    result += chbHowHelpMedicalHouse.Text + ",";
                }

                if (chbHowHelpMedicalRepairment.Checked)
                {
                    result += chbHowHelpMedicalRepairment.Text + ",";
                }

                if (chbHowHelpMedicalWeddings.Checked)
                {
                    result += chbHowHelpMedicalWeddings.Text + ",";
                }

                if (chbHowHelpMedicalOther.Checked)
                {
                    result += chbHowHelpMedicalOther.Text + ",";
                }

                return result;
            }
        }

        private string Age18BelowOrUpper
        {
            get
            {
                if (dtpBirthDate.Value.Year < 2007)
                {
                    return "18 ва ундан юкори";
                }
                else if (dtpBirthDate.Value.Year == 2007)
                {
                    if (dtpBirthDate.Value.Month <= 4)
                    {
                        return "18 ва ундан юкори";
                    }
                    else
                    {
                        return "18 ёшгача";
                    }
                }
                else
                {
                    return "18 ёшгача";
                }
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(cbxTumanNomi.SelectedItem.ToString()))
            {
                MessageBox.Show("Tuman nomini kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedTab = tabPage1;
                cbxTumanNomi.Focus();
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

            //if (string.IsNullOrEmpty(txbSorFio.Text))
            //{
            //    MessageBox.Show("So'rovnoma ishtirokchisini kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    tabControl1.SelectedTab = tabPage1;
            //    txbSorFio.Focus();
            //    return false;
            //}

            //if (string.IsNullOrEmpty(txbSorPassSeria.Text))
            //{
            //    MessageBox.Show("So'rovnoma ishtirokchisi Passport Seria kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    tabControl1.SelectedTab = tabPage1;
            //    txbSorPassSeria.Focus();
            //    return false;
            //}

            //if (string.IsNullOrEmpty(txbSorPassNumber.Text))
            //{
            //    MessageBox.Show("So'rovnoma ishtirokchisi Passport Nomer kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    tabControl1.SelectedTab = tabPage1;
            //    txbSorPassNumber.Focus();
            //    return false;
            //}

            //if (string.IsNullOrEmpty(txbSorTelNumber.Text))
            //{
            //    MessageBox.Show("So'rovnoma ishtirokchisi telefon raqamini kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    tabControl1.SelectedTab = tabPage1;
            //    txbSorTelNumber.Focus();
            //    return false;
            //}

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

            if (rdbCurStateOut.Checked)
            {
                if (string.IsNullOrEmpty(Sogligi))
                {
                    MessageBox.Show("Sogligini kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tabControl1.SelectedTab = tabPage3;
                    return false;
                }

                if (string.IsNullOrEmpty(OilaviyXolati))
                {
                    MessageBox.Show("Oilaviy Xolatini kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tabControl1.SelectedTab = tabPage3;
                    return false;
                }

                if (string.IsNullOrEmpty(OilaviyMuxiti))
                {
                    MessageBox.Show("Oilaviy Muxitini kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tabControl1.SelectedTab = tabPage3;
                    return false;
                }

                if (string.IsNullOrEmpty(IjtimoiyXolati))
                {
                    MessageBox.Show("Ijtimoiy Xolatini kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tabControl1.SelectedTab = tabPage3;
                    return false;
                }

                if (string.IsNullOrEmpty(DavlatVaXudud))
                {
                    MessageBox.Show("Davlat Xudud kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tabControl1.SelectedTab = tabPage3;
                    return false;
                }

                if (string.IsNullOrEmpty(IshlashRuxsatnomasiMavjudligi))
                {
                    MessageBox.Show("Ishlashga Ruxsatnomasi Mavjudligi kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tabControl1.SelectedTab = tabPage3;
                    return false;
                }

                if (string.IsNullOrEmpty(txbIncomeValue.Text))
                {
                    MessageBox.Show("Oylik Daromadini kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tabControl1.SelectedTab = tabPage3;
                    return false;
                }

                if (rdbLeaveReasonOthers.Checked)
                {
                    if (string.IsNullOrEmpty(txbLeaveReasonOthers.Text))
                    {
                        MessageBox.Show("Boshqalarni kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tabControl1.SelectedTab = tabPage4;
                        txbLeaveReasonOthers.Focus();
                        return false;
                    }
                }

                if (rdbWorkOutsiteTypeOthers.Checked)
                {
                    if (string.IsNullOrEmpty(txbWorkOutsiteTypeOthers.Text))
                    {
                        MessageBox.Show("Boshqalarni kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tabControl1.SelectedTab = tabPage4;
                        txbWorkOutsiteTypeOthers.Focus();
                        return false;
                    }
                }

                if (chbFamilyProblemsOthers.Checked)
                {
                    if (string.IsNullOrEmpty(txbFamilyProblemsOthers.Text))
                    {
                        MessageBox.Show("Boshqalarni kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tabControl1.SelectedTab = tabPage4;
                        txbFamilyProblemsOthers.Focus();
                        return false;
                    }
                }

                if (chbOutPersonProblemsOthers.Checked)
                {
                    if (string.IsNullOrEmpty(txbchbOutPersonProblemsOthers.Text))
                    {
                        MessageBox.Show("Boshqalarni kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tabControl1.SelectedTab = tabPage4;
                        txbchbOutPersonProblemsOthers.Focus();
                        return false;
                    }
                }

                if (chbHowHelpMedicalOther.Checked)
                {
                    if (string.IsNullOrEmpty(txbHowHelpMedicalOther.Text))
                    {
                        MessageBox.Show("Boshqalarni kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tabControl1.SelectedTab = tabPage4;
                        txbHowHelpMedicalOther.Focus();
                        return false;
                    }
                }

                if (rdbLeaveCountryOthers.Checked)
                {
                    if (string.IsNullOrEmpty(txbLeaveCountryOthers.Text))
                    {
                        MessageBox.Show("Boshqalarni kiriting!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tabControl1.SelectedTab = tabPage3;
                        txbLeaveCountryOthers.Focus();
                        return false;
                    }
                }
            }

            return true;
        }

        public MigrantImportModel CurrentModel { get; set; }

        private void rdbCurStateReturn_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCurStateReturn.Checked)
            {
                dtpReturnDate.Checked = true;
                dtpReturnDate.Enabled = true;
                tabPage3.Enabled = false;
                tabPage4.Enabled = false;
                tabPage5.Enabled = false;
            }
        }

        public bool IsInEditMode { get; set; }

        private void AnketaForm_Load(object sender, EventArgs e)
        {
            if (IsInEditMode)
            {
                cbxTumanNomi.SelectedItem = CurrentModel.XududNomi;
                txbMahallaNomi.Text = CurrentModel.KiritayotganMFY;
                txbSorFio.Text = CurrentModel.SorIshtirFio;
                txbQarindoshligi.Text = CurrentModel.SorIshtirQarindoshligi;
                txbSorPassSeria.Text = CurrentModel.SorIshtirPassportSeria;
                txbSorPassNumber.Text = CurrentModel.SorIshtirPassportRaqam;
                txbSorTelNumber.Text = CurrentModel.SorIshtirTelefonRaqam;
                txbFio.Text = CurrentModel.Fio;
                txbPassSeria.Text = CurrentModel.SeriaPassport;
                txbPassNum.Text = CurrentModel.RaqamPassport;
                dtpBirthDate.Value = new DateTime(int.Parse(CurrentModel.TugilganYil), int.Parse(CurrentModel.TugilganOy), int.Parse(CurrentModel.TugilganKun));
                txbAddressViloyat.Text = CurrentModel.Yiloyat;
                txbAddressTuman.Text = CurrentModel.Tuman;
                txbAddressMFY.Text = CurrentModel.Mahalla;
                txbAddressKucha.Text = CurrentModel.Kocha;
                txbAddressUy.Text = CurrentModel.Uy;
                txbAddressXonadon.Text = CurrentModel.Xonadon;
                txbSpeciality.Text = CurrentModel.Mutaxasisligi;
                txbChildrenCount.Text = CurrentModel.JamiFarzandlarSoni;
                txbChildrenUnder18.Text = CurrentModel.VoyagaEtmaganFarzandlarSoni;
                txbIncomeValue.Text = CurrentModel.XorijdagiBirOylikDaromadi;
                txbForeignPersonPhone.Text = CurrentModel.XorijdagiFuqaroTelefonRaqami;
                SetJinsiValue(CurrentModel.Jinsi);
                SetFuqorolikXolati(CurrentModel.FuqorolikXolati);
                SetMalumoti(CurrentModel.Malumoti);
                SetXozirgiXolati(CurrentModel.XozirgiXolati);
                SetSogligi(CurrentModel.Sogligi);
                SetOilaviyXolati(CurrentModel.OilaviyXolati);
                SetOilaviyMuxiti(CurrentModel.OilaviyMuxiti);
                SetIjtimoiyXolati(CurrentModel.IjtimoiyXolati);
                SetDavlatVaXudud(CurrentModel.DavlatVaXudud);
                SetIshlashRuxsatnomasiMavjudligi(CurrentModel.IshlashRuxsatnomasiMavjudligi);
                SetXorijgaKetishMaqsadi(CurrentModel.XorijgaKetishMaqsadi);
                SetChetEldagiIshTuri(CurrentModel.ChetEldagiIshTuri);
                SetChetEldanQaytishIstagiBorligi(CurrentModel.ChetEldanQaytishIstagiBorligi);
                SetNimaYordamBerilsaQaytadi(CurrentModel.NimaYordamBerilsaQaytadi);
                SetXorijdaBirgalikdagiOilaAzolari(CurrentModel.XorijdaBirgalikdagiOilaAzolari);
                SetOiladagiMuammolari(CurrentModel.OiladagiMuammolari);
                SetXorijdagiMuammolari(CurrentModel.XorijdagiMuammolari);
                txbLeaveCountryOthers.Text = CurrentModel.DavlatVaXududBoshqalari;
                txbchbOutPersonProblemsOthers.Text = CurrentModel.XorijdagiMuammolariBoshqalari;
                txbFamilyProblemsOthers.Text = CurrentModel.OiladagiMuammolariBoshqalari;
                txbHowHelpMedicalOther.Text = CurrentModel.NimaYordamBerilsaQaytadiBoshqalari;
                txbWorkOutsiteTypeOthers.Text = CurrentModel.ChetEldagiIshTuriBoshqalari;
                txbLeaveReasonOthers.Text = CurrentModel.XorijgaKetishMaqsadiBoshqalari;
            }
            else
            {
                if (!string.IsNullOrEmpty(DefaultTuman))
                {
                    cbxTumanNomi.SelectedItem = DefaultTuman;
                }

                if (!string.IsNullOrEmpty(DefaultMahalla))
                {
                    txbMahallaNomi.Text = DefaultMahalla;
                }

                dtpReturnDate.Enabled = false;
                dtpReturnDate.Checked = false;
                tabPage3.Enabled = true;
                tabPage4.Enabled = true;
                tabPage5.Enabled = true;
            }
        }

        private void SetJinsiValue(string value)
        {
            SetRDButtonValue(rdbErkak, value);
            SetRDButtonValue(rdbAyol, value);
        }

        private void SetFuqorolikXolati(string value)
        {
            SetRDButtonValue(rdbUzbCitizen, value);
            SetRDButtonValue(rdbForeign, value);
            SetRDButtonValue(rdbNoCitizen, value);
        }

        private void SetMalumoti(string value)
        {
            SetRDButtonValue(rdbEducationHigh, value);
            SetRDButtonValue(rdbEducationAverageSpec, value);
            SetRDButtonValue(rdbEducationAverage, value);
            SetRDButtonValue(rdbEducationNo, value);
        }

        private void SetXozirgiXolati(string value)
        {
            SetRDButtonValue(rdbCurStateOut, value);
            SetRDButtonValue(rdbCurStateOutJIEM, value);
            SetRDButtonValue(rdbCurStateLost, value);
            SetRDButtonValue(rdbCurStateReturn, value);
            SetRDButtonValue(rdbCurStateDied, value);
            SetRDButtonValue(rdbCurStateWanted, value);
        }

        private void SetSogligi(string value)
        {
            SetRDButtonValue(rdbHealthGood, value);
            SetRDButtonValue(rdbHealthIllPerm, value);
            SetRDButtonValue(rdbHealthInvalid, value);
        }

        private void SetOilaviyXolati(string value)
        {
            SetRDButtonValue(rdbFamilyStateFamily, value);
            SetRDButtonValue(rdbFamilyStateNoFamily, value);
            SetRDButtonValue(rdbFamilyStateDevorsed, value);
            SetRDButtonValue(rdbFamilyStateLoanlyMother, value);
            SetRDButtonValue(rdbFamilyStateSpouseDied, value);
        }

        private void SetOilaviyMuxiti(string value)
        {
            SetRDButtonValue(rdbFamilyEnvironmentQuite, value);
            SetRDButtonValue(rdbFamilyEnvironmentNonQuite, value);
        }

        private void SetIjtimoiyXolati(string value)
        {
            SetRDButtonValue(rdbSocialStatePoor, value);
            SetRDButtonValue(rdbSocialStateAvarage, value);
            SetRDButtonValue(rdbSocialStateGood, value);
        }

        private void SetDavlatVaXudud(string value)
        {
            SetRDButtonValue(rdbLeaveCountryRussia, value);
            SetRDButtonValue(rdbLeaveCountryKazakstan, value);
            SetRDButtonValue(rdbLeaveCountryTurkey, value);
            SetRDButtonValue(rdbLeaveCountryKorea, value);
            SetRDButtonValue(rdbLeaveCountryOthers, value);
        }

        private void SetIshlashRuxsatnomasiMavjudligi(string value)
        {
            SetRDButtonValue(rdbWorkPermitExists, value);
            SetRDButtonValue(rdbWorkPermitNotExists, value);
        }

        private void SetXorijgaKetishMaqsadi(string value)
        {
            SetRDButtonValue(rdbLeaveReasonWork, value);
            SetRDButtonValue(rdbLeaveReasonTreatment, value);
            SetRDButtonValue(rdbLeaveReasonEducation, value);
            SetRDButtonValue(rdbLeaveReasonTempLive, value);
            SetRDButtonValue(rdbLeaveReasonTravel, value);
            SetRDButtonValue(rdbLeaveReasonMerriage, value);
            SetRDButtonValue(rdbLeaveReasonOthers, value);
            SetRDButtonValue(rdbLeaveReasonPermanentLive, value);
        }

        private void SetChetEldagiIshTuri(string value)
        {
            SetRDButtonValue(rdbWorkOutsiteTypeBuilder, value);
            SetRDButtonValue(rdbWorkOutsiteTypeSeller, value);
            SetRDButtonValue(rdbWorkOutsiteTypeTruck, value);
            SetRDButtonValue(rdbWorkOutsiteTypeCare, value);
            SetRDButtonValue(rdbWorkOutsiteTypeCleaning, value);
            SetRDButtonValue(rdbWorkOutsiteTypeBeautySalon, value);
            SetRDButtonValue(rdbWorkOutsiteTypeGoverment, value);
            SetRDButtonValue(rdbWorkOutsiteTypeEnterprieneur, value);
            SetRDButtonValue(rdbWorkOutsiteTypeOthers, value);
        }

        private void SetChetEldanQaytishIstagiBorligi(string value)
        {
            SetRDButtonValue(rdbHaveAWillToReturnBackYes, value);
            SetRDButtonValue(rdbHaveAWillToReturnBackNo, value);
        }

        private void SetNimaYordamBerilsaQaytadi(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            string[] values = value.Split(',');
            SetCheckBoxValue(chbrHowHelpWork, values);
            SetCheckBoxValue(chbHowHelpEducation, values);
            SetCheckBoxValue(chbHowHelpMedicalTreatment, values);
            SetCheckBoxValue(chbHowHelpMedicalHouse, values);
            SetCheckBoxValue(chbHowHelpMedicalRepairment, values);
            SetCheckBoxValue(chbHowHelpMedicalFamily, values);
            SetCheckBoxValue(chbHowHelpMedicalWeddings, values);
            SetCheckBoxValue(chbHowHelpMedicalOther, values);
        }

        private void SetRDButtonValue(RadioButton radioButton, string value)
        {
            if (radioButton.Text == value)
            {
                radioButton.Checked = true;
            }
        }

        private void SetCheckBoxValue(CheckBox checkBox, string value)
        {
            if (checkBox.Text == value)
            {
                checkBox.Checked = true;
            }
        }

        private void SetCheckBoxValue(CheckBox checkBox, string[] values)
        {
            foreach (var value in values)
            {
                if (checkBox.Text == value)
                {
                    checkBox.Checked = true;
                }
            }
        }

        private void SetXorijdaBirgalikdagiOilaAzolari(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            string[] values = value.Split(',');
            SetCheckBoxValue(chbOutTogatherSpouse, values);
            SetCheckBoxValue(chbOutTogatherChild, values);
            SetCheckBoxValue(chbOutTogatherFather, values);
            SetCheckBoxValue(chbOutTogatherMother, values);
            SetCheckBoxValue(chbOutTogatherBrother, values);
            SetCheckBoxValue(chbOutTogatherSister, values);
            SetCheckBoxValue(chbOutTogatherOthers, values);
        }

        private void SetOiladagiMuammolari(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            string[] values = value.Split(',');
            SetCheckBoxValue(chbFamilyProblemsWorkless, values);
            SetCheckBoxValue(chbFamilyProblemsEducation, values);
            SetCheckBoxValue(chbFamilyProblemsTreatment, values);
            SetCheckBoxValue(chbFamilyProblemsFamily, values);
            SetCheckBoxValue(chbFamilyProblemsPlaceToLive, values);
            SetCheckBoxValue(chbFamilyProblemsRepairment, values);
            SetCheckBoxValue(chbFamilyProblemsOthers, values);
        }

        private void SetXorijdagiMuammolari(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            string[] values = value.Split(',');
            SetCheckBoxValue(chbOutPersonProblemsLostPassport, values);
            SetCheckBoxValue(chbOutPersonProblemsWorkless, values);
            SetCheckBoxValue(chbOutPersonProblemsNoPayment, values);
            SetCheckBoxValue(chbOutPersonProblemsPersonSold, values);
            SetCheckBoxValue(chbOutPersonProblemsLivePermitless, values);
            SetCheckBoxValue(chbOutPersonProblemsWorkPermitless, values);
            SetCheckBoxValue(chbOutPersonProblemsOthers, values);
        }

        public DatabaseContext databaseContext { get; set; }

        private void btnCheckDb_Click(object sender, EventArgs e)
        {
            try
            {
                string pspEntered = $"{txbPassSeria.Text}{txbPassNum.Text}";

                var ichkiMigrantlar = databaseContext.IchkiIshlarBazaDannixes.Where(x => x.psp == pspEntered).ToList();

                if (ichkiMigrantlar.Count > 0)
                {
                    var ichkiMigrant = ichkiMigrantlar.First();
                    MessageBox.Show("Mijoz bazada mavjud! " + $"Ismi: {ichkiMigrant.name_latin} - Pinfl: {ichkiMigrant.pinpp} - Address: {ichkiMigrant.address} -Qaysi davlatda: {ichkiMigrant.country_out}", "Xabar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Mijoz bazada mavjud emas!", "Xabar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                 MessageBox.Show("Mijoz bazada mavjud emas! " + ex.Message, "Xabar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void dtpReturnDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpReturnDate.Checked)
            {
                //MessageBox.Show("Ўзбекистонга қайтган фуқаро тўғрисидаги маълумотлар фақат анкетанинг 10 банддан сўнг тўлдирилмайди.");

                tabPage3.Enabled = false;
                tabPage4.Enabled = false;
                tabPage5.Enabled = false;
            }
            else
            {
                tabPage3.Enabled = true;
                tabPage4.Enabled = true;
                tabPage5.Enabled = true;
            }
        }

        public string DefaultTuman {  get; set; }

        public string DefaultMahalla { get; set; }

        private void txbSorPassSeria_TextChanged(object sender, EventArgs e)
        {
            txbSorPassSeria.Text = txbSorPassSeria.Text.ToUpper();
            txbSorPassSeria.SelectionStart = txbSorPassSeria.Text.Length;
        }

        private void txbPassSeria_TextChanged(object sender, EventArgs e)
        {
            txbPassSeria.Text = txbPassSeria.Text.ToUpper();
            txbPassSeria.SelectionStart = txbPassSeria.Text.Length;
        }

        private void rdbCurStateOut_CheckedChanged(object sender, EventArgs e)
        {
            dtpReturnDate.Checked = false;
            dtpReturnDate.Enabled = false;
            tabPage3.Enabled = true;
            tabPage4.Enabled = true;
            tabPage5.Enabled = true;
            dtpLeaveDate.Checked = true;
        }

        private void rdbCurStateOutJIEM_CheckedChanged(object sender, EventArgs e)
        {
            dtpReturnDate.Checked = false;
            dtpReturnDate.Enabled = false;
            tabPage3.Enabled = false;
            tabPage4.Enabled = false;
            tabPage5.Enabled = false;
        }

        private void rdbCurStateLost_CheckedChanged(object sender, EventArgs e)
        {
            dtpReturnDate.Checked = false;
            dtpReturnDate.Enabled = false;
            tabPage3.Enabled = false;
            tabPage4.Enabled = false;
            tabPage5.Enabled = false;
        }

        private void rdbCurStateDied_CheckedChanged(object sender, EventArgs e)
        {
            dtpReturnDate.Checked = false;
            dtpReturnDate.Enabled = false;
            tabPage3.Enabled = false;
            tabPage4.Enabled = false;
            tabPage5.Enabled = false;
        }

        private void rdbCurStateWanted_CheckedChanged(object sender, EventArgs e)
        {
            dtpReturnDate.Checked = false;
            dtpReturnDate.Enabled = false;
            tabPage3.Enabled = false;
            tabPage4.Enabled = false;
            tabPage5.Enabled = false;
        }

        private void rdbLeaveReasonOthers_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbLeaveReasonOthers.Checked)
            {
                txbLeaveReasonOthers.Visible = true;
            }
            else
            {
                txbLeaveReasonOthers.Visible = false;
            }
        }

        private void rdbWorkOutsiteTypeOthers_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbWorkOutsiteTypeOthers.Checked)
            {
                txbWorkOutsiteTypeOthers.Visible = true;
            }
            else
            {
                txbWorkOutsiteTypeOthers.Visible = false;
            }
        }

        private void chbFamilyProblemsOthers_CheckedChanged(object sender, EventArgs e)
        {
            if (chbFamilyProblemsOthers.Checked)
            {
                txbFamilyProblemsOthers.Visible = true;
            }
            else
            {
                txbFamilyProblemsOthers.Visible = false;
            }
        }

        private void chbOutPersonProblemsOthers_CheckedChanged(object sender, EventArgs e)
        {
            if (chbOutPersonProblemsOthers.Checked)
            {
                txbchbOutPersonProblemsOthers.Visible = true;
            }
            else
            {
                txbchbOutPersonProblemsOthers.Visible = false;
            }
        }

        private void rdbHowHelpMedicalOther_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbLeaveCountryOthers_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbLeaveCountryOthers.Checked)
            {
                txbLeaveCountryOthers.Visible = true;
            }
            else
            {
                txbLeaveCountryOthers.Visible = false;
            }   
        }

        private void chbHowHelpMedicalOther_CheckedChanged(object sender, EventArgs e)
        {
            if (chbHowHelpMedicalOther.Checked)
            {
                txbHowHelpMedicalOther.Visible = true;
            }
            else
            {
                txbHowHelpMedicalOther.Visible = false;
            }
        }
    }
}
