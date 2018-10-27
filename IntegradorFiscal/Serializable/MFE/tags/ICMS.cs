namespace IntegradorFiscal.MFE.tags
{
    public class ICMS
    {
        public ICMS00 ICMS00 { get; set; } // 1-1
        public ICMS10 ICMS10 { get; set; } // 1-1
        public ICMS20 ICMS20 { get; set; } // 1-1
        public ICMS30 ICMS30 { get; set; } // 1-1
        public ICMS40 ICMS40 { get; set; } // 1-1
        public ICMS60 ICMS60 { get; set; } // 1-1
        public ICMS70 ICMS70 { get; set; } // 1-1
        public ICMS90 ICMS90 { get; set; } // 1-1
    }
    public class gICMS
    {
        public string Orig { get; set; } //CFe
        public string orig { get; set; } // 1-1
        public string CST { get; set; } // 1-1
    }
    public class ICMS00 : gICMS
    {
        public string modBC { get; set; } // 1-1
        public string vBC { get; set; } // 1-1
        public string pICMS { get; set; } // 1-1
        public string vICMS { get; set; } // 1-1
    }
    public class ICMS10 : gICMS
    {
        public string modBC { get; set; } // 1-1
        public string vBC { get; set; } // 1-1
        public string pICMS { get; set; } // 1-1
        public string vICMS { get; set; } // 1-1
        public string modBCST { get; set; } // 1-1
        public string pMVAST { get; set; } // 0-1
        public string pRedBCST { get; set; } // 0-1
        public string vBCST { get; set; } // 1-1
        public string pICMSST { get; set; } // 1-1
        public string vICMSST { get; set; } // 1-1
    }
    public class ICMS20 : gICMS
    {
        public string modBC { get; set; } // 1-1
        public string pRedBC { get; set; } // 1-1
        public string vBC { get; set; } // 1-1
        public string pICMS { get; set; } // 1-1
        public string vICMS { get; set; } // 1-1
        // grupo opcional -x-  0-1
        public string vICMSDeson { get; set; } // 1-1
        public string motDesICMS { get; set; } // 1-1
    }
    public class ICMS30 : gICMS
    {
        public string modBCST { get; set; }  // 1-1
        public string pMVAST { get; set; } // 0-1
        public string pRedBCST { get; set; } // 0-1
        public string vBCST { get; set; } // 1-1
        public string pICMSST { get; set; } // 1-1
        public string vICMSST { get; set; } // 1-1
        // grupo opcional -x-  0-1
        public string vICMSDeson { get; set; } // 1-1
        public string motDesICMS { get; set; } // 1-1
    }
    public class ICMS40 : gICMS  //40, 41 e 50
    {
        public string vICMSDeson { get; set; } // 1-1
        public string motDesICMS { get; set; } // 1-1
        public string vBCSTRet { get; set; } // p/ 60 CFe
        public string vICMSSTRet { get; set; }// p/ 60 CFe
    }
    public class ICMS60 : gICMS
    {
        // grupo opcional -x- 0-1 
        public string vBCSTRet { get; set; } // 1-1
        public string pST { get; set; } // 1-1
        public string vICMSSTRet { get; set; } // 1-1
        public string vBCFCPSTRet { get; set; } // 1-1
        public string pFCPSTRet { get; set; } // 1-1
        public string vFCPSTRet { get; set; } // 1-1
    }
    public class ICMS70 : gICMS
    {


        public string modBC { get; set; }// 1-1
        public string pRedBC { get; set; }// 1-1
        public string vBC { get; set; }// 1-1
        public string pICMS { get; set; }// 1-1
        public string vICMS { get; set; }// 1-1
        public string modBCST { get; set; }// 1-1
        public string pMVAST { get; set; }// 0-1
        public string pRedBCST { get; set; }// 0-1
        public string vBCST { get; set; }// 1-1
        public string pICMSST { get; set; }// 1-1
        public string vICMSST { get; set; }// 1-1
        // grupo opcional -x- 0-1
        public string vBCFCPST { get; set; }// 1-1
        public string pFCPST { get; set; }// 1-1
        public string vFCPST { get; set; }// 1-1
        // grupo opcional -x- 0-1
        public string vICMSDeson { get; set; } // 1-1
        public string motDesICMS { get; set; } // 1-1
    }
    public class ICMS90 : gICMS
    {
        // grupo opcional -x- 0-1
        public string modBC { get; set; } // 1-1
        public string vBC { get; set; } // 1-1
        public string pRedBC { get; set; } // 0-1
        public string pICMS { get; set; } // 1-1
        public string vICMS { get; set; } // 1-1
        // grupo opcional -x- 0-1
        public string vBCFCP { get; set; }// 1-1
        public string pFCP { get; set; }// 1-1
        public string vFCP { get; set; }// 1-1
        // grupo opcional -x- 0-1
        public string modBCST { get; set; } // 1-1
        public string pMVAST { get; set; } // 0-1
        public string pRedBCST { get; set; } // 0-1
        public string vBCST { get; set; } // 1-1
        public string pICMSST { get; set; } // 1-1
        public string vICMSST { get; set; } // 1-1
        // grupo opcional -x- 0-1
        public string vBCFCPST { get; set; }// 1-1
        public string pFCPST { get; set; }// 1-1
        public string vFCPST { get; set; }// 1-1
        // grupo opcional -x- 0-1
        public string vICMSDeson { get; set; } // 1-1
        public string motDesICMS { get; set; } // 1-1
    }
}