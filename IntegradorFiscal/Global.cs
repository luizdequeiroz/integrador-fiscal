using IntegradorFiscal.MFE;
using IntegradorFiscal.MFE.tags;

namespace IntegradorFiscal.MFE
{
    public class Global
    {
        public static CFe CFe { protected get; set; }
        public static CFeCanc CFeCanc { protected get; set; }
        public static string CodigoDaFilial { protected get; set; }
        public static string DiretorioDosCupons { protected get; set; } = "C:\\CFe";
        public static string DiretorioDoInput { protected get; set; } = "C:\\Integrador\\Input";

        public static string CodigoDeAtivacao { get; set; }
    }
}
