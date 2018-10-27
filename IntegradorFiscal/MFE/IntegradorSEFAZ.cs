using IntegradorFiscal.Functions;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace IntegradorFiscal.MFE.SEFAZ
{
    public static class GeradorDoIntegrador
    {
        public static string GerarVendaViaIntegrador(this string xmlCFe, int id)
        {
            var Integrador = new Integrador
            {
                Identificador = new Identificador
                {
                    Valor = id.ToString()
                },
                Componente = new Componente
                {
                    Nome = "MF-e",
                    Metodo = new Metodo
                    {
                        Nome = "EnviarDadosVenda",
                        Parametros = new List<Parametro>()
                        {
                            new Parametro()
                            {
                                Nome = "numeroSessao",
                                Valor = id.ToString()
                            },
                            new Parametro()
                            {
                                Nome = "codigoDeAtivacao",
                                Valor = Global.CodigoDeAtivacao
                            },
                            new Parametro()
                            {
                                Nome = "dadosVenda",
                                Valor = xmlCFe
                            }
                        }
                    }
                }
            };

            return Integrador.Serialize();
        }
    }

    public class Integrador
    {
        public Identificador Identificador { get; set; }
        public Componente Componente { get; set; }
    }
    public class Identificador
    {
        public string Valor { get; set; }
    }
    public class Componente
    {
        [XmlAttribute("Nome")]
        public string Nome { get; set; }
        public Metodo Metodo { get; set; }
    }
    public class Metodo
    {
        [XmlAttribute("Nome")]
        public string Nome { get; set; }
        [XmlArray("Parametros")]
        public List<Parametro> Parametros { get; set; }
    }
    public class Parametro
    {
        public string Nome { get; set; }
        [XmlIgnore]
        public string Valor { get; set; }
        [XmlElement("Valor")]
        public XmlNode CDataValue
        {
            get
            {
                if (Valor.Contains("<CFe"))
                    return new XmlDocument().CreateCDataSection(Valor);
                else
                    return new XmlDocument().CreateTextNode(Valor);
            }
            set
            {
                Valor = value.Value;
            }
        }
    }
}
