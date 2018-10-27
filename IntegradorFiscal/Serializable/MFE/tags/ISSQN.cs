namespace IntegradorFiscal.MFE.tags
{
    public class ISSQN
    {
        public string vBC { get; set; } // 1-1
        public string vAliq { get; set; } // 1-1
        public string vISSQN { get; set; } // 1-1
        public string cMunFG { get; set; } // 1-1
        public string cListServ { get; set; } // 1-1
        public string vDeducao { get; set; } // 0-1
        public string vOutro { get; set; } // 0-1
        public string vDescIncond { get; set; } // 0-1
        public string vDescCond { get; set; } // 0-1
        public string vISSRet { get; set; } // 0-1
        public string indISS { get; set; } // 1-1
        public string cServico { get; set; } // 0-1
        public string cMun { get; set; } // 0-1
        public string cPais { get; set; } // 0-1
        public string nProcesso { get; set; } // 0-1
        public string indIncentivo { get; set; } // 1-1
    }
}
