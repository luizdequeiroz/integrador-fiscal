using System.Xml.Serialization;

namespace IntegradorFiscal.MFE.tags
{
    public class emit
    {
        public string CNPJ { get; set; } // 1-1
        public string CPF { get; set; } // 1-1
        public string cUF { get; set; }
        public string xNome { get; set; } // 1-1
        public string xFant { get; set; } // 0-1
        public ender enderEmit { get; set; } // 1-1
        public string IE { get; set; } // 1-1
        public string IM { get; set; } // 1-1 Informado na emissão de NF-e conjugada, com itens de produtos sujeitos ao ICMS e itens de serviços sujeitos ao ISSQN.
        public string cRegTrib { get; set; }
        [XmlIgnore]
        public string CSC { get; set; }
        public string indRatISSQN { get; set; }
        public string CNAE { get; set; } // 0-1 Informado na emissão de NF-e conjugada, com itens de produtos sujeitos ao ICMS e itens de serviços sujeitos ao ISSQN.
        public string CRT { get; set; } // 1-1 Informado na emissão de NF-e conjugada, com itens de produtos sujeitos ao ICMS e itens de serviços sujeitos ao ISSQN.
        [XmlIgnore]
        public string nVersao { get; set; }
    }
}
