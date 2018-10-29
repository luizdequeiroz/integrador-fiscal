using IntegradorFiscal.Functions;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System;
using System.Threading;
using System.IO;
using System.Xml.Linq;
using System.Text;

namespace IntegradorFiscal.MFE.SEFAZ
{
    public static class IntegradorSEFAZ
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

        #region Monitorar a Output
        public static void MonitorarOutput(string diretorioDoOutput)
        {
            var _retornos = new List<dynamic>();
            dynamic _retorno = null;

            var dir = new DirectoryInfo("C:\\Integrador\\Output");
            var files = dir.GetFiles("*.xml", SearchOption.AllDirectories);

            foreach (FileInfo file in files)
            {
                Thread.Sleep(500);

                if (File.Exists(file.FullName))
                {
                    try
                    {
                        XDocument xdoc = XDocument.Load(file.FullName);

                        XElement xele = (XElement)xdoc.FirstNode;
                        string resp = (string)xele.Element("IntegradorResposta") ?? "null";

                        if (xele.Name == "Integrador" && resp != "null")
                        {
                            var Identificador = xdoc.Element("Integrador").Element("Identificador");
                            var IntegradorResposta = xdoc.Element("Integrador").Element("IntegradorResposta");

                            if (Identificador == null || IntegradorResposta.Element("Codigo").Value != "AP")
                            {
                                #region Erros Genéricos : Identificador == null || IntegradorResposta.Element("Codigo").Value != "AP"
                                var path = "C:\\Integrador\\OutputBackup\\" + file.Name;
                                file.MoveFile(path);

                                _retorno = new
                                {
                                    Ok = false,
                                    Message = "Não existe tag <Integrador> no retorno ou o código do retorno é diferente de 'AP'!",
                                    ReturnPath = path
                                };
                                #endregion Erros Genéricos : Identificador == null || IntegradorResposta.Element("Codigo").Value != "AP"
                            }
                            else
                            {
                                var resposta = xdoc.Element("Integrador").Element("Resposta").Element("retorno").Value;
                                if (resposta.Contains("Timeout") || resposta == "MFE não encontrado Verifique se está com a versão 01.04.03 ou superior do Driver MFE, e tente novamente!")
                                #region Timeout : resposta.Contains("Timeout")
                                {
                                    var path = "C:\\Integrador\\OutputBackup\\Timeout\\" + Identificador.Value + "_" + file.Name;
                                    file.MoveFile(path);

                                    _retorno = new
                                    {
                                        Ok = false,
                                        Message = "Tempo de espera de resposta excedido! " + resposta,
                                        ReturnPath = path
                                    };
                                }
                                #endregion Timeout : resposta.Contains("Timeout")
                                else
                                {
                                    var ret = resposta.Split('|');
                                    var idSessao = ret[0];
                                    var codigoRetorno = ret[1];
                                    var mensagem = ret[3];

                                    if (codigoRetorno.Substring(0, 2) == "06")
                                    #region retorno EnviarDadosVenda : codRetorno == 06XXX
                                    {
                                        #region EmitidoOK : codRetorno == 06000
                                        if (codigoRetorno.Substring(2, 3) == "000")
                                        {
                                            #region Retornos de erro de NFCe
                                            if (ret[6] == "The remote server returned an error: (500) Internal Server Error.")
                                            {
                                                var path = "C:\\Integrador\\OutputBackup\\Emitidos\\" + Identificador.Value + "_" + file.Name;
                                                file.MoveFile(path);

                                                _retorno = new
                                                {
                                                    Ok = false,
                                                    Sessao = int.Parse(idSessao),
                                                    Message = "Erro interno do servidor da SEFAZ! " + ret[6],
                                                    ReturnPath = path
                                                };
                                            }
                                            else if (ret[6].Contains("Unable to connect to the remote server"))
                                            {
                                                var path = "C:\\Integrador\\OutputBackup\\Emitidos\\" + Identificador.Value + "_" + file.Name;
                                                file.MoveFile(path);

                                                _retorno = new
                                                {
                                                    Ok = false,
                                                    Sessao = int.Parse(idSessao),
                                                    Message = "Erro de conexão com o serviço da SEFAZ! " + ret[6],
                                                    ReturnPath = path
                                                };
                                            } 
                                            #endregion
                                            else
                                            {
                                                byte[] dados = Convert.FromBase64String(ret[6]);
                                                string cupom = Encoding.UTF8.GetString(dados);

                                                #region Retorno de emissão bem sucedida de NFCe
                                                if (mensagem == "Enviado com sucesso + Retorno SEFAZ.")
                                                {
                                                    var xEnvelope = XDocument.Parse(cupom);
                                                    var strRet = xEnvelope.Element("{http://www.w3.org/2003/05/soap-envelope}Envelope").Element("{http://www.w3.org/2003/05/soap-envelope}Body").Element("{http://www.portalfiscal.inf.br/nfe/wsdl/NfeAutorizacao}nfeAutorizacaoLoteResult").Element("{http://www.portalfiscal.inf.br/nfe}retEnviNFe").ToString();

                                                    var path = "C:\\Integrador\\OutputBackup\\Emitidos\\VendaAutorizada-" + idSessao + ".xml";
                                                    file.MoveFile(path);

                                                    _retorno = new
                                                    {
                                                        Ok = true,
                                                        Sessao = int.Parse(idSessao),
                                                        Message = mensagem,
                                                        ReturnPath = path
                                                    };
                                                } 
                                                #endregion
                                                else
                                                {
                                                    XDocument cfe = XDocument.Parse(cupom);
                                                    
                                                    string dataDeAutorizacao = ret[7];
                                                    string chaveAcesso = ret[8].Substring(3, 44);
                                                    string valorCFe = ret[9];
                                                    string qrCode = ret[11];

                                                    var path = "C:\\Integrador\\OutputBackup\\Emitidos\\VendaAutorizada-" + idSessao + ".xml";
                                                    file.MoveFile(path);

                                                    _retorno = new
                                                    {
                                                        Ok = true,
                                                        Sessao = int.Parse(idSessao),
                                                        Message = mensagem,
                                                        Data = dataDeAutorizacao,
                                                        ChaveAcesso = chaveAcesso,
                                                        Valor = valorCFe,
                                                        QRCode = qrCode,
                                                        Xml = cfe.ToString(),
                                                        ReturnPath = path
                                                    };
                                                }
                                            }
                                        }
                                        #endregion EmitidoOK : codRetorno == 06000
                                        #region EmitidoRejeitado : codRetorno == 06010
                                        else if (codigoRetorno.Substring(2, 3) == "010")
                                        {
                                            var path = "C:\\Integrador\\OutputBackup\\EmitidosRejeitados\\EmitidoRejeitado-" + idSessao + ".xml";
                                            file.MoveFile(path);

                                            _retorno = new
                                            {
                                                Ok = false,
                                                Sessao = int.Parse(idSessao),
                                                Message = mensagem,
                                                ReturnPath = path
                                            };
                                        }
                                        #endregion EmitidoRejeitado : codRetorno == 06010
                                        #region EmitidoErro : codRetorno != 06000 && codRetorno != 06010
                                        else
                                        {
                                            var path = "C:\\Integrador\\OutputBackup\\EmitidosErros\\EmitidoErro-" + idSessao + ".xml";
                                            file.MoveFile(path);

                                            _retorno = new
                                            {
                                                Ok = false,
                                                Sessao = int.Parse(idSessao),
                                                Message = mensagem,
                                                ReturnPath = path
                                            };
                                        }
                                        #endregion EmitidoErro : codRetorno != 06000 && codRetorno != 06010
                                    }
                                    #endregion retorno EnviarDadosVenda : codRetorno == 06XXX
                                    else if (codigoRetorno.Substring(0, 2) == "07")
                                    #region retorno CancelarUltimaVenda : codRetorno == 07XXX
                                    {
                                        #region CanceladoOK : codRetorno == 07000
                                        if (codigoRetorno.Substring(2, 3) == "000")
                                        {
                                            byte[] dados = Convert.FromBase64String(ret[6]);
                                            string cupom = Encoding.UTF8.GetString(dados);

                                            XDocument cfecanc = XDocument.Parse(cupom);

                                            string data = ret[7];
                                            string dataAutorizado = data;
                                            string chaveAcesso = ret[8].Substring(3, 44);
                                            string valorCFe = ret[9];
                                            string qrCode = ret[11];

                                            var path = "C:\\Integrador\\OutputBackup\\Cancelados\\CancelarUltimaVendaAutorizado-" + idSessao + ".xml";
                                            file.MoveFile(path);

                                            _retorno = new
                                            {
                                                Ok = true,
                                                Sessao = int.Parse(idSessao),
                                                Message = mensagem,
                                                ReturnPath = path
                                            };
                                        }
                                        #endregion CanceladoOK : codRetorno == 07000
                                        #region CancelamentoRejeitado : codRetorno == 07007
                                        else if (codigoRetorno.Substring(2, 3) == "007")
                                        {
                                            var path = "C:\\Integrador\\OutputBackup\\CancelamentosRejeitados\\CancelamentoRejeitado-" + idSessao + ".xml";
                                            file.MoveFile(path);

                                            _retorno = new
                                            {
                                                Ok = false,
                                                Sessao = int.Parse(idSessao),
                                                Message = mensagem,
                                                ReturnPath = path
                                            };
                                        }
                                        #endregion CancelamentoRejeitado : codRetorno == 07007
                                        #region CancelamentoErro : codRetorno != 07000 && codRetorno != 07007
                                        else
                                        {
                                            var path = "C:\\Integrador\\OutputBackup\\CancelamentosErros\\CancelamentoErro-" + idSessao + ".xml";
                                            file.MoveFile(path);

                                            _retorno = new
                                            {
                                                Ok = false,
                                                Sessao = int.Parse(idSessao),
                                                Message = mensagem,
                                                ReturnPath = path
                                            };
                                        }
                                        #endregion CancelamentoErro : codRetorno != 07000 && codRetorno != 07007                                        
                                    }
                                    #endregion retorno CancelarUltimaVenda : codRetorno == 07XXX
                                    else if (codigoRetorno.Substring(0, 2) == "10")
                                    #region retorno ConsultarStatusOperacional : codRetorno == 10XXX
                                    {
                                        var path = "C:\\Integrador\\OutputBackup\\Diversos\\ConsultarStatusOperacional-" + idSessao + ".xml";
                                        file.MoveFile(path);

                                        _retorno = new
                                        {
                                            Ok = true,
                                            Sessao = int.Parse(idSessao),
                                            Message = mensagem,
                                            ReturnPath = path
                                        };
                                    }
                                    #endregion retorno ConsultarStatusOperacional : codRetorno == 10XXX
                                    else if (codigoRetorno.Substring(0, 2) == "08")
                                    #region retorno ConsultarSAT : codRetorno == 08XXX
                                    {
                                        var path = "C:\\Integrador\\OutputBackup\\Diversos\\ConsultarMFE-" + idSessao + ".xml";
                                        file.MoveFile(path);

                                        _retorno = new
                                        {
                                            Ok = true,
                                            Sessao = int.Parse(idSessao),
                                            Message = mensagem,
                                            ReturnPath = path
                                        };
                                    }
                                    #endregion
                                    else //TODO: tratar retorno de funcoes diversas : codRetorno.Substring(0, 2) != "06" && codRetorno.Substring(0, 2) != "07" && codRetorno.Substring(0, 2) != "10"
                                    #region Retorno de Funções Diversas : codRetorno != "06XXX" && codRetorno != "07XXX" && codRetorno != "10XXX"
                                    {
                                        var path = "C:\\Integrador\\OutputBackup\\" + file.Name;
                                        file.MoveFile(path);

                                        _retorno = new
                                        {
                                            Ok = true,
                                            Sessao = int.Parse(idSessao),
                                            Message = mensagem,
                                            ReturnPath = path
                                        };
                                    }
                                    #endregion Retorno de Funções Diversas : codRetorno != "06XXX" && codRetorno != "07XXX" && codRetorno != "10XXX"
                                }
                            }
                        }
                        else
                        {
                            file.Delete();

                            _retorno = new
                            {
                                Ok = false,
                                Message = "Arquivo não corresponde a um .xml de retorno do Integrador!",
                                ReturnPath = file.FullName
                            };
                        }
                    }
                    catch (Exception ex)
                    {
                        var path = "C:\\Integrador\\OutputBackup\\Exceptions\\" + file.Name;
                        file.MoveFile(path);

                        _retorno = new
                        {
                            Ok = false,
                            Message = "Exceção no monitoramento da pasta de retorno (Output): " + ex.Message + " (" + ex.StackTrace + ")",
                            ReturnPath = file.FullName
                        };
                    }
                }

                _retornos.Add(_retorno);
                Global.RetornosProcessados = _retornos;
            }
        }
        #endregion
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
