namespace NavoiKasabaUyushmasi.Model
{
    public class MigrantImportModel
    {
        public string TartibRaqami { get; set; }

        public string XududNomi { get; set; }

        public string KiritayotganMFY { get; set; }

        public string SorIshtirFio { get; set; }

        public string SorIshtirQarindoshligi { get; set; }

        public string SorIshtirPassportSeria { get; set; }

        public string SorIshtirPassportRaqam { get; set; }

        public string SorIshtirTelefonRaqam { get; set; }

        public string Jinsi { get; set; }

        public string Fio { get; set; }

        public string SeriaPassport { get; set; }

        public string RaqamPassport { get; set; }

        public string TugilganKun { get; set; }

        public string TugilganOy { get; set; }

        public string TugilganYil { get; set; }

        public string Yiloyat { get; set; }

        public string Tuman { get; set; }

        public string Mahalla { get; set; }

        public string Kocha { get; set; }

        public string Uy { get; set; }

        public string Xonadon { get; set; }

        public string FuqorolikXolati { get; set; }

        public string Malumoti { get; set; }

        public string Mutaxasisligi { get; set; }

        public string XozirgiXolati { get; set; }

        public string UzbgaQaytganSanasi { get; set; }

        public string Sogligi { get; set; }

        public string OilaviyXolati { get; set; }

        public string OilaviyMuxiti { get; set; }

        public string JamiFarzandlarSoni { get; set; }

        public string VoyagaEtmaganFarzandlarSoni { get; set; }

        public string VoyagaEtganFarzandlarSoni { get; set; }

        public string IjtimoiyXolati { get; set; }

        public string XorijgaKetganSanasi { get; set; }

        public string DavlatVaXudud { get; set; }

        public string IshlashRuxsatnomasiMavjudligi { get; set; }

        public string XorijdagiBirOylikDaromadi { get; set; }

        public string XorijdaBirgalikdagiOilaAzolari { get; set; }

        public string XorijgaKetishMaqsadi { get; set; }

        public string ChetEldagiIshTuri { get; set; }

        public string ChetEldanQaytishIstagiBorligi { get; set; }

        public string OiladagiMuammolarSoni { get; set; }

        public string XorijdagiMuammolarSoni { get; set; }

        public string NimaYordamBerilsaQaytadi { get; set; }

        public string XorijdagiFuqaroTelefonRaqami { get; set; }

        public string BazadaBorligi { get; set; }

        public RowStatus RowStatus { get; set; } = RowStatus.New;

        public string ErrorText { get; set; }

        public string Age18BelowOrUpper { get; set; }
    }

    public enum RowStatus
    {
        New,
        Processed,
        Error
    }
}
