using System.Collections.Generic;
using System.Xml.Serialization;

namespace IntegradorFiscal.MFE.tags
{
    public class pgto
    {
        [XmlArray(ElementName = "MPs")]
        public List<MP> MP { get; set; }
        public string vTroco { get; set; }
    }
    public class MP
    {
        public string cMP { get; set; }
        public string vMP { get; set; }
        public string cAdmC { get; set; }
    }
}
