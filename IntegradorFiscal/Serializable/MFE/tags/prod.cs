using System.Xml.Serialization;

namespace IntegradorFiscal.MFE.tags
{
    public class prod
    {
        public string cProd { get; set; } // 1-1
        public string cEAN { get; set; } // 1-1
        public string xProd { get; set; } // 1-1
        public string NCM { get; set; } // 1-1
        public string CEST { get; set; } //0-1 substituição tributária
        public string indEscala { get; set; } //1-1
        public string CNPJFab { get; set; } //0-1
        public string cBenef { get; set; } //0-1
        public string NVE { get; set; }  // 0-1
        public string EXTIPI { get; set; } // 0-1
        public string CFOP { get; set; } // 1-1
        public string uCom { get; set; } // 1-1
        public string qCom { get; set; } // 1-1
        public string vUnCom { get; set; } // 1-1 Para efeitos de cálculo, o valor unitário será obtido pela divisão do valor do produto pela quantidade comercial. (v2.0)
        public string vProd { get; set; } // 1-1
        public string vItem { get; set; } // 1-1
        public string cEANTrib { get; set; } // 1-1
        public string uTrib { get; set; } // 1-1
        public string qTrib { get; set; } // 1-1
        public string vUnTrib { get; set; } // 1-1 Para efeitos de cálculo, o valor unitário será obtido pela divisão do valor do produto pela quantidade tributável (NT 2013/003).
        public string vFrete { get; set; } // 0-1
        public string vSeg { get; set; } // 0-1
        public string indRegra { get; set; }
        public string vDesc { get; set; } // 0-1
        public string vOutro { get; set; } // 0-1
        public string indTot { get; set; }  // 1-1 0=Valor do item (vProd) não compõe o valor total da NF-e, 1=Valor do item(vProd) compõe o valor total da NF-e(vProd)
        public string xPed { get; set; } // 0-1
        public string nItemPed { get; set; } // 0-1
        public string nRECOPI { get; set; } // 1-1
        public obsFiscoDet obsFiscoDet { get; set; }
    }

    public class obsFiscoDet
    {
        [XmlAttribute(AttributeName = "xCampoDet")]
        public string xCampoDet { get; set; }
        public string xTextoDet { get; set; }
    }

    public class CEST
    {
        
    }
}
