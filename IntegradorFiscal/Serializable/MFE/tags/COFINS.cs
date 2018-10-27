namespace IntegradorFiscal.MFE.tags
{
    public class COFINS
    {
        public COFINSAliq COFINSAliq { get; set; } // 1-1
        public COFINSQtde COFINSQtde { get; set; } // 1-1
        public COFINSNT COFINSNT { get; set; } // 1-1
        public COFINSOutr COFINSOutr { get; set; }
    }
    public class gCOFINS
    {
        public string CST { get; set; } // 1-1
    }

    public class COFINSAliq : gCOFINS
    {
        public string vBC { get; set; } // 1-1
        public string pCOFINS { get; set; } // 1-1
        public string vCOFINS { get; set; } // 1-1
    }

    public class COFINSQtde : gCOFINS
    {
        public string qBCProd { get; set; } // 1-1
        public string vAliqProd { get; set; } // 1-1
        public string vCOFINS { get; set; } // 1-1
    }

    public class COFINSNT : gCOFINS { }

    public class COFINSOutr : gCOFINS
    {
        public string vBC { get; set; } // 1-1
        public string pCOFINS { get; set; } // 1-1
        public string qBCProd { get; set; } // 1-1
        public string vAliqProd { get; set; } // 1-1
        public string vCOFINS { get; set; } // 1-1
    }
}