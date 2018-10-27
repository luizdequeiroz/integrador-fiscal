namespace IntegradorFiscal.MFE.tags
{
    public class ide
    {
        public string cUF { get; set; } // 1-1
        public string cNF { get; set; } // 1-1
        public string natOp { get; set; } // 1-1
        public string indPag { get; set; } // 1-1
        public string mod { get; set; } // 1-1
        public string serie { get; set; } // 1-1
        public string nNF { get; set; } // 1-1
        public string dhEmi { get; set; } // 1-1 Data e hora no formato UTC (Universal Coordinated Time): AAAA-MM-DDThh:mm:ssTZD
        public string tpNF { get; set; } // 1-1 
        public string idDest { get; set; }  // 1-1 
        public string cMunFG { get; set; } // 1-1 
        public string tpImp { get; set; }  // 1-1 
        public string tpEmis { get; set; } // 1-1 
        public string nserieSAT { get; set; }
        public string nCFe { get; set; }
        public string dEmi { get; set; }
        public string hEmi { get; set; }
        public string cDV { get; set; }  // 1-1 
        public string tpAmb { get; set; } // 1-1 
        public string finNFe { get; set; }  // 1-1 
        public string indFinal { get; set; }  // 1-1 
        public string indPres { get; set; } // 1-1 
        public string procEmi { get; set; } // 1-1 
        public string verProc { get; set; }  // 1-1 
        public string dhCont { get; set; }  // 1-1 se contingência
        public string xJust { get; set; } // 1-1 se contingência
        public string CNPJ { get; set; }
        public string signAC { get; set; }
        public string assinaturaQRCODE { get; set; }
        public string numeroCaixa { get; set; }
    }

}