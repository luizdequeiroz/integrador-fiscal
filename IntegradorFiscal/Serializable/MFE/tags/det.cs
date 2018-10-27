using System.Xml.Serialization;

namespace IntegradorFiscal.MFE.tags
{
    public class det
    {
        [XmlAttribute(AttributeName = "nItem")]
        public string nItem { get; set; } // 1-1
        public prod prod { get; set; } // 1-1
        public imposto imposto { get; set; } // 1-1
        public string infAdProd { get; set; }  // 0-1
    }
}
