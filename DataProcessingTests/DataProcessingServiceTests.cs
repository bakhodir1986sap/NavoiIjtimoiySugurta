using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreDataProcessing;
using NavoiKasabaUyushmasi.Model;
using System.Collections.Generic;
using Moq;
using Castle.Core.Logging;

namespace CoreDataProcessing.Tests
{
    [TestClass]
    public class DataProcessingServiceTests
    {
        [TestMethod]
        public void ProcessData_NullInput_ReturnsEmptyList()
        {
            // Arrange
            var service = new DataProcessingService(null, null);
            List<MigrantImportModel> migrantImportModels = null;

            // Act
            var result = service.ProcessData(migrantImportModels);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void ProcessData_ValidInput_ReturnsProcessedRows()
        {
            // Arrange
            var prevExperienceProviderMock = new Mock<IPrevExperienceProvider>();
            var databaseDataCheckProviderMock = new Mock<IDatabaseDataCheckProvider>();

            prevExperienceProviderMock.Setup(x => x.GetPrevExperienceResolveValue(It.IsAny<int>(), It.IsAny<string>()))
                .Returns("value");
            prevExperienceProviderMock.Setup(x => x.SetPrevExperienceResolveValue(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()));
            databaseDataCheckProviderMock.Setup(x => x.GetIchkiIshlarBazaDannix(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new IchkiIshlarBazaDannix());

            var service = new DataProcessingService(prevExperienceProviderMock.Object, databaseDataCheckProviderMock.Object);
            var migrantImportModels = new List<MigrantImportModel>
            {
                new MigrantImportModel {
                TartibRaqami = "1",
                XududNomi = "Навбаҳор туман",
                SorIshtirFio= "Шокиров Толиб Фаттаевич",
                SorIshtirQarindoshligi = "Акаси",
                SorIshtirPassportSeria = "АВ",
                SorIshtirPassportRaqam = "4152438",
                SorIshtirTelefonRaqam = "930022872",
                Jinsi= "Эркак",
                Fio= "Шокиров Толмас Фаттаевич",
                SeriaPassport= "AB",
                RaqamPassport= "838796",
                TugilganKun= "22",
                TugilganOy= "3",
                TugilganYil= "1977",
                Yiloyat= "Навоий",
                Tuman= "Навбаҳор",
                Mahalla= "Мирзо Улуғбек ",
                Kocha= "Ватан ",
                Uy= "1",
                Xonadon= "1",
                FuqorolikXolati = "Ўзбекистон Республикаси фуқароси",
                Malumoti = "ўрта ",
                Mutaxasisligi = "йўқ ",
                XozirgiXolati = "Чет элда ",
                UzbgaQaytganSanasi = "0",
                Sogligi = "Соғлом",
                OilaviyXolati = "оилали",
                OilaviyMuxiti = "тинч",
                JamiFarzandlarSoni= "3",
                VoyagaEtmaganFarzandlarSoni = "2",
                VoyagaEtganFarzandlarSoni = "1",
                IjtimoiyXolati = "ўрта",
                XorijgaKetganSanasi = "6.10.2023 йил ",
                DavlatVaXudud= "Россия, С.Петербург",
                IshlashRuxsatnomasiMavjudligi = "Ҳа ",
                XorijdagiBirOylikDaromadi = "1000",
                XorijdaBirgalikdagiOilaAzolari = "турмуш ўртоғи",
                XorijgaKetishMaqsadi = "Ишлаш учун",
                ChetEldagiIshTuri = "Аэрапортда ишчи ",
                ChetEldanQaytishIstagiBorligi = "ҳа ",
                XorijdagiMuammolarSoni = "йўқ ",
                OiladagiMuammolarSoni = "йўқ ",
                NimaYordamBerilsaQaytadi = "",
                XorijdagiFuqaroTelefonRaqami = "998977777777"
                }
            };

            // Act
            var result = service.ProcessData(migrantImportModels);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(migrantImportModels.Count, result.Count);
            foreach (var model in result)
            {
                Assert.AreEqual(RowStatus.Processed, model.RowStatus);
            }
        }

        [TestMethod]
        public void GetProcessedRow_NullInput_ReturnsErrorModel()
        {
            // Arrange
            var service = new DataProcessingService(null, null);
            MigrantImportModel migrantImportModel = null;

            // Act
            var result = service.GetProcessedRow(migrantImportModel);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(RowStatus.Error, result.RowStatus);
        }

        [TestMethod]
        public void GetProcessedRow_ValidInput_ReturnsProcessedModel()
        {
            // Arrange
            var prevExperienceProviderMock = new Mock<IPrevExperienceProvider>();
            var databaseDataCheckProviderMock = new Mock<IDatabaseDataCheckProvider>();

            prevExperienceProviderMock.Setup(x => x.GetPrevExperienceResolveValue(It.IsAny<int>(), It.IsAny<string>()))
                .Returns("");
            prevExperienceProviderMock.Setup(x => x.SetPrevExperienceResolveValue(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()));
            databaseDataCheckProviderMock.Setup(x => x.GetIchkiIshlarBazaDannix(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new IchkiIshlarBazaDannix());

            var service = new DataProcessingService(prevExperienceProviderMock.Object, databaseDataCheckProviderMock.Object);
            var migrantImportModel = new MigrantImportModel { 
                TartibRaqami = "1",
                XududNomi = "Навбаҳор туман",
                SorIshtirFio= "Шокиров Толиб Фаттаевич",
                SorIshtirQarindoshligi = "Акаси",
                SorIshtirPassportSeria = "АВ",
                SorIshtirPassportRaqam = "4152438",
                SorIshtirTelefonRaqam = "930022872",
                Jinsi= "Эркак",
                Fio= "Шокиров Толмас Фаттаевич",
                SeriaPassport= "AB",
                RaqamPassport= "838796",
                TugilganKun= "22",
                TugilganOy= "3",
                TugilganYil= "1977",
                Yiloyat= "Навоий",
                Tuman= "Навбаҳор",
                Mahalla= "Мирзо Улуғбек ",
                Kocha= "Ватан ",
                Uy= "1",
                Xonadon= "1",
                FuqorolikXolati = "Ўзбекистон Республикаси фуқароси",
                Malumoti = "ўрта ",
                Mutaxasisligi = "йўқ ",
                XozirgiXolati = "Чет элда ",
                UzbgaQaytganSanasi = "0",
                Sogligi = "Соғлом",
                OilaviyXolati = "оилали",
                OilaviyMuxiti = "тинч",
                JamiFarzandlarSoni= "3",
                VoyagaEtmaganFarzandlarSoni = "2",
                VoyagaEtganFarzandlarSoni = "1",
                IjtimoiyXolati = "ўрта",
                XorijgaKetganSanasi = "6.10.2023 йил ",
                DavlatVaXudud= "Россия, С.Петербург",
                IshlashRuxsatnomasiMavjudligi = "Ҳа ",
                XorijdagiBirOylikDaromadi = "1000",
                XorijdaBirgalikdagiOilaAzolari = "турмуш ўртоғи",
                XorijgaKetishMaqsadi = "Ишлаш учун",
                ChetEldagiIshTuri = "Аэрапортда ишчи ",
                ChetEldanQaytishIstagiBorligi = "ҳа ",
                XorijdagiMuammolarSoni = "йўқ ",
                OiladagiMuammolarSoni = "йўқ ",
                NimaYordamBerilsaQaytadi = "",
                XorijdagiFuqaroTelefonRaqami = "998977777777"
            };

            // Act
            var result = service.GetProcessedRow(migrantImportModel);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(RowStatus.Processed, result.RowStatus);
        }
    }
}
