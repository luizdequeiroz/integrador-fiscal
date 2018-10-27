namespace IntegradorFiscal.MFE.tags
{
    public class total
    {
        public ICMSTot ICMSTot { get; set; } // 1-1
        public ISSQNtot ISSQNtot { get; set; } // 0-1
        public retTrib retTrib { get; set; } // 0-1
        public string vCFe { get; set; }
        public DescAcrEntr DescAcrEntr { get; set; }

    }
    public class ICMSTot
    {
        public string vBC { get; set; } // 1-1
        public string vICMS { get; set; } // 1-1
        public string vICMSDeson { get; set; } // 1-1
        public string vFCP { get; set; } // 1-1
        public string vFCPUFDest { get; set; }
        public string vICMSUFDest { get; set; }
        public string vICMSUFRemet { get; set; }
        public string vBCST { get; set; } // 1-1
        public string vST { get; set; } // 1-1
        public string vFCPST { get; set; } // 1-1
        public string vFCPSTRet { get; set; } // 1-1
        public string vProd { get; set; } // 1-1
        public string vFrete { get; set; } // 1-1
        public string vSeg { get; set; } // 1-1
        public string vDesc { get; set; } // 1-1
        public string vII { get; set; } // 1-1
        public string vIPI { get; set; } // 1-1
        public string vIPIDevol { get; set; } // 1-1
        public string vPIS { get; set; } // 1-1
        public string vCOFINS { get; set; } // 1-1
        public string vOutro { get; set; } // 1-1
        public string vNF { get; set; } // 1-1
        public string vTotTrib { get; set; } // 0-1
    }

    public class ISSQNtot
    {
        public string vServ { get; set; } // 0-1
        public string vBC { get; set; } // 0-1
        public string vISS { get; set; } // 0-1
        public string vPIS { get; set; } // 0-1
        public string vCOFINS { get; set; } // 0-1
        public string dCompet { get; set; } // 1-1
        public string vDeducao { get; set; } // 0-1
        public string vOutro { get; set; } // 0-1
        public string vDescIncond { get; set; } // 0-1
        public string vDescCond { get; set; } // 0-1
        public string vISSRet { get; set; } // 0-1
        public string cRegTrib { get; set; } // 0-1
    }

    public class retTrib
    {
        public string vRetPIS { get; set; } // 0-1
        public string vRetCOFINS { get; set; } // 0-1
        public string vRetCSLL { get; set; } // 0-1
        public string vBCIRRF { get; set; } // 0-1
        public string vIRRF { get; set; } // 0-1
        public string vBCRetPrev { get; set; } // 0-1
        public string vRetPrev { get; set; } // 0-1
    }

    public class DescAcrEntr
    {
        public string vDescSubtot { get; set; }
        public string vAcresSubtot { get; set; }
        public string vCFeLei12741 { get; set; }
    }
}
