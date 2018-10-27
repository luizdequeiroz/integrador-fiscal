using System.Collections.Generic;
using System.Xml.Serialization;

namespace IntegradorFiscal.MFE.tags
{
    public class CFe
    {
        public infCFe infCFe { get; set; }
    }

    public class infCFe
    {
        [XmlAttribute(AttributeName = "versaoSB")]
        public string versaoSB { get; set; }
        [XmlAttribute(AttributeName = "versaoDadosEnt")]
        public string versaoDadosEnt { get; set; }
        [XmlAttribute(AttributeName = "versao")]
        public string versao { get; set; }
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }
        public ide ide { get; set; }
        public emit emit { get; set; }
        [XmlElement(IsNullable = true, Namespace = "")]
        public dest dest { get; set; }
        public entrega entrega { get; set; }
        [XmlArray(ElementName = "dets")]
        public List<det> det { get; set; }
        public total total { get; set; }
        public pgto pgto { get; set; }
        public infAdic infAdic { get; set; }
    }
}
