using NavoiKasabaUyushmasi.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavoiKasabaUyushmasi.Model
{
    public class MigrantImportModel
    {
        [Field(1, true)]
        public string TartibRaqami { get; set; }

        public string XududNomi { get; set; }

        [Field(2, true, substitutionFieldNumber: 8)]
        public string SorIshtirFio { get; set; }

        [Field(3, true)]
        public string SorIshtirQarindoshligi { get; set; }

        [Field(4, true, substitutionFieldNumber: 9, maxLength: 2)]
        public string SorIshtirPassportSeria { get; set; }

        [Field(5, true, substitutionFieldNumber: 10, maxLength: 7)]
        public string SorIshtirPassportRaqam { get; set; }

        [Field(6, false)]
        public string SorIshtirTelefonRaqam { get; set; }

        [Field(7, true, defaultValue: "эркак", options: ["эркак", "аёл"])]
        public string Jinsi { get; set; }

        [Field(8, true, substitutionFieldNumber: 2)]
        public string Fio { get; set; }

        [Field(9, true, substitutionFieldNumber: 4, maxLength: 2)]
        public string SeriaPassport { get; set; }

        [Field(10, true, substitutionFieldNumber: 5, maxLength: 7)]
        public string RaqamPassport { get; set; }

        //Ёши	
        [Field(11, true)]
        public string TugilganKun { get; set; }

        [Field(12, true)]
        public string TugilganOy { get; set; }

        [Field(13, true)]
        public string TugilganYil { get; set; }

        [Field(14, false)]
        public string Yiloyat { get; set; }

        [Field(15, false)]
        public string Tuman { get; set; }

        [Field(16, false)]
        public string Mahalla { get; set; }

        [Field(17, false)]
        public string Kocha { get; set; }

        [Field(18, false)]
        public string Uy { get; set; }

        [Field(19, false)]
        public string Xonadon { get; set; }

        //Фуқаролик ҳолати 
        [Field(20, true, defaultValue: "Ўзбекистон Республикаси фуқароси", options: ["Ўзбекистон Республикаси фуқароси"
            , "чет эл фуқароси", "фуқаролиги бўлмаган шахс"])]
        public string FuqorolikXolati { get; set; }

        //Маълумоти 							
        [Field(21, false, defaultValue: "маълумотсиз", options: ["олий", "ўрта махсус", "ўрта", "маълумотсиз"])]
        public string Malumoti { get; set; }

        [Field(22, false)]
        public string Mutaxasisligi { get; set; }

        //Хорижда юрган фуқароларнинг ҳозирги ҳолати 
        [Field(23, true, options: ["чет элда", "чет элда ЖИЭМда сақланмоқда", "бедарак йўқолган", "Ўзбекистонга қайтган", "вафот этган", "қидирувда"])]
        public string XozirgiXolati { get; set; }

        //Ҳозирги кунда хорижда юрган фуқаролар сони - Сана куйилмаганлардан олинади
        [Field(24, false)]
        public string UzbgaQaytganSanasi { get; set; }

        //Соглиги
        [Field(25, true, options: ["соғлом", "сурункали касалликка чалинган", "I гуруҳ", "II гуруҳ", "III гуруҳ"], substitutionFieldNumber: 24)]
        public string Sogligi { get; set; }

        //Оилавий ҳолати 
        [Field(26, true, options: ["оилали", "оила қурмаган", "турмушга чиқмаган", "ажрашган", "ёлғиз она", "турмуш ўртоғи вафот этган"], substitutionFieldNumber: 24)]
        public string OilaviyXolati { get; set; }

        [Field(27, false, options: ["тинч", "нотинч"], substitutionFieldNumber: 24)]
        public string OilaviyMuxiti { get; set; }

        //Жами фарзандлар сони агар нулл булса 0 деб киритилади
        [Field(28, false, substitutionFieldNumber: 24)]
        public string JamiFarzandlarSoni { get; set; }

        [Field(29, false, substitutionFieldNumber: 24)]
        public string VoyagaEtmaganFarzandlarSoni { get; set; }

        [Field(30, false, substitutionFieldNumber: 24)]
        public string VoyagaEtganFarzandlarSoni { get; set; }

        [Field(31, false, options: ["кам таъминланган", "ўрта ҳол", "яхши"], substitutionFieldNumber: 24)]
        public string IjtimoiyXolati { get; set; }

        [Field(32, false, substitutionFieldNumber: 24)]
        public string XorijgaKetganSanasi { get; set; }

        //Хорижга кетган давлат номи
        [Field(33, true, substitutionFieldNumber: 24)]
        public string DavlatVaXudud { get; set; }

        //Ишлаш рухсат- номаси (патент) мавжуд бўлмаганлари сони
        [Field(34, false, options: ["ҳа", "йўқ"], substitutionFieldNumber: 24)]
        public string IshlashRuxsatnomasiMavjudligi { get; set; }

        [Field(35, false, substitutionFieldNumber: 24)]
        public string XorijdagiBirOylikDaromadi { get; set; }

        [Field(36, false, substitutionFieldNumber: 24)]
        public string XorijdaBirgalikdagiOilaAzolari { get; set; }

        //Хорижга кетиш мақсади
        [Field(37, true, defaultValue: "бошқа мақсад", options: ["ишлаш", "даволаниш", "ўқиш", "вақтинча яшаш саёҳат", "чет эл фуқаросига турмушга чиқиш", "доимий яшаш", "бошқа мақсад"], substitutionFieldNumber: 24)]
        public string XorijgaKetishMaqsadi { get; set; }

        //Фуқаро чет элда қайси турдаги меҳнат билан шуғулланади
        [Field(38, true, defaultValue: "Бошқа соҳа", options: ["Қурилиш", "Сотувчи", "Юк ташувчи", "Энага", 
            "Ободонлаштириш", "Ошпаз", "Ҳайдовчи", "Маиший хизмат кўрсатиш(сартарош, гўзаллик салони, этикдўз, курьер ва ҳ.к.)",
            "Давлат ташкилотлари", "банк ва бошқа ташкилотларда ишловчи", "Бошқа соҳа"], substitutionFieldNumber: 24)]
        public string ChetEldagiIshTuri { get; set; }

        //Чет элдан қайтиб келиб, Ўзбекистонда доимий қолиш истаги борлар
        [Field(39, true, options: ["ҳа", "йўқ"], substitutionFieldNumber: 24)]
        public string ChetEldanQaytishIstagiBorligi { get; set; }

        //Хорижга кетган фуқаронинг оиласидаги муаммолар
        [Field(40, false, substitutionFieldNumber: 24)]
        public string OiladagiMuammolarSoni { get; set; }

        //Хорижга кетган фуқаронинг муаммолари
        [Field(41, false, substitutionFieldNumber: 24)]
        public string XorijdagiMuammolarSoni { get; set; }

        [Field(42, false, substitutionFieldNumber: 24)]
        public string NimaYordamBerilsaQaytadi { get; set; }

        [Field(43, false, substitutionFieldNumber: 24)]
        public string XorijdagiFuqaroTelefonRaqami { get; set; }

        [Field(44, false, defaultValue: "0")]
        public string BazadaBorligi { get; set; }

        public RowStatus RowStatus { get; set; } = RowStatus.New;

        public string ErrorText { get; set; }
    }

    public enum RowStatus
    {
        New,
        Processed,
        Error
    }
}
