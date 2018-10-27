namespace IntegradorFiscal.MFE.tags
{
    public class dest
    {
        public string CNPJ { get; set; } // 1-1
        public string CPF { get; set; } // 1-1
        public string idEstrangeiro { get; set; }  // 1-1 No caso de operação com o exterior, ou para comprador estrangeiro informar a tag "idEstrangeiro", com o número do passaporte ou outro documento legal para identificar pessoa estrangeira (campo aceita valor nulo).
        public string xNome { get; set; } // 0-1 Tag obrigatória para a NF-e (modelo 55) e opcional para a NFC-e.
        public ender enderDest { get; set; }
        public string indIEDest { get; set; } // 1-1 No caso de NFC-e informar indIEDest=9 e não informar a tag IE do destinatário;
        public string IM { get; set; }
        public string email { get; set; } // 0-1
    }

}
