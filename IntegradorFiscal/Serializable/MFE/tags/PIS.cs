namespace IntegradorFiscal.MFE.tags
{
    public class PIS
    {
        public PISAliq PISAliq { get; set; } // 1-1
        public PISQtde PISQtde { get; set; } // 1-1
        public PISNT PISNT { get; set; } // 1-1
        public PISOutr PISOutr { get; set; } // 1-1
    }
    public class gPIS
    {
        public string CST { get; set; } // 1-1 
    }

    public class PISAliq : gPIS
    {
        public string vBC { get; set; } // 1-1
        public string pPIS { get; set; } // 1-1
        public string vPIS { get; set; } // 1-1

    }
    public class PISQtde : gPIS
    {
        public string qBCProd { get; set; } // 1-1
        public string vAliqProd { get; set; } // 1-1
        public string vPIS { get; set; } // 1-1
    }

    public class PISNT : gPIS { }

    public class PISOutr :gPIS
    {
        public string vBC { get; set; } // 1-1
        public string pPIS { get; set; } // 1-1
        public string qBCProd { get; set; } // 1-1
        public string vAliqProd { get; set; } // 1-1
        public string vPIS { get; set; } // 1-1
    }
}