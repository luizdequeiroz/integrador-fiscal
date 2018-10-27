using System.Xml.Serialization;

namespace IntegradorFiscal.MFE.tags
{
    public class infAdic
    {
        public string infAdFisco { get; set; } // 0-1
        public string infCpl { get; set; } // 0-1
        public obsCont obsCont { get; set; } // 0-10
        public obsFisco obsFisco { get; set; } // 0-10
        public procRef procRef { get; set; } // 0-100
    }

    public class obsCont
    {
        [XmlAttribute(AttributeName = "xCampo")]
        public string xCampo { get; set; } // 1-1
        public string xTexto { get; set; } // 1-1
    }

    public class obsFisco
    {
        [XmlAttribute(AttributeName = "xCampo")]
        public string xCampo { get; set; } // 1-1
        public string xTexto { get; set; } // 1-1
    }

    public class procRef
    {
        public string nProc { get; set; } // 1-1
        public string indProc { get; set; } // 1-1
    }
}
