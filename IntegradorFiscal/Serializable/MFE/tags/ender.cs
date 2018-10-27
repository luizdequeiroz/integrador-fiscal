namespace IntegradorFiscal.MFE.tags
{
    public class ender
    {
        public string xLgr { get; set; } // 1-1
        public string nro { get; set; }  // 1-1
        public string xCpl { get; set; }  // 0-1
        public string xBairro { get; set; } // 1-1
        public string cMun { get; set; } // 1-1
        public string xMun { get; set; } // 1-1
        public string UF { get; set; } // 1-1
        public string CEP { get; set; } // 1-1
        public string cPais { get; set; } // 0-1
        public string xPais { get; set; } // 0-1
        public string fone { get; set; } // 0-1
    }
}
