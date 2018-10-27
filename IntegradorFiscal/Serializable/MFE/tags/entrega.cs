namespace IntegradorFiscal.MFE.tags
{
    public class entrega
    {
        public string CNPJ { get; set; } // 1-1
        public string CPF { get; set; } // 1-1
        public string xLgr { get; set; } // 1-1
        public string nro { get; set; } // 1-1
        public string xCpl { get; set; } // 0-1
        public string xBairro { get; set; }  // 1-1
        public string cMun { get; set; }  // 1-1
        public string xMun { get; set; }  // 1-1
        public string UF { get; set; } // 1-1
    }
}
