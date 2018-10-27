namespace IntegradorFiscal.MFE.tags
{
    public class imposto
    {
        public string vTotTrib { get; set; } // 0-1
        public ICMS ICMS { get; set; } // 0-1
        public PIS PIS { get; set; } // 0-1
        public COFINS COFINS { get; set; } // 0-1
        public ISSQN ISSQN { get; set; } // 0-1
    }

}
