using System;
using System.Xml.Serialization;

namespace IntegradorFiscal.MFE.tags
{
    [Serializable]
    public class CFeCanc
    {
        public infCFeCanc infCFe { get; set; }
    }

    public class infCFeCanc
    {   
        [XmlAttribute("chCanc")]
        public string chCanc { get; set; }
        public ideCanc ide { get; set; }
        public emit emit { get; set; }
        public dest dest { get; set; }
        public total total { get; set; }
        public infAdic infAdic { get; set; }
    }

    public class ideCanc
    {
        public string CNPJ { get; set; }
        public string signAC { get; set; }
        public string numeroCaixa { get; set; }
    }
}
