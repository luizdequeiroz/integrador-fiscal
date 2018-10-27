using IntegradorFiscal.MFE.tags;
using System;
using IntegradorFiscal.Functions;
using IntegradorFiscal.MFE.SEFAZ;

namespace IntegradorFiscal.MFE
{
    public class Emissor : Global
    {
        public Emissor(string codigoDeAtivacao, string versaoDadosEnt, string CNPJ, string signAC, string numeroDoCaixa, string codigoDaFilial = "")
        {
            CodigoDeAtivacao = codigoDeAtivacao;
            CodigoDaFilial = codigoDaFilial;
            CFe = new CFe
            {
                infCFe = new infCFe
                {
                    versaoDadosEnt = versaoDadosEnt,
                    ide = new ide
                    {
                        CNPJ = string.Format("{0:00000000000000}", Convert.ToDouble(CNPJ)),
                        signAC = signAC,
                        numeroCaixa = string.Format("{0:000}", Convert.ToInt16(numeroDoCaixa)),
                    }
                }
            };
        }

        public void ConfigurarDiretorioDosCupons(string diretorioDosCupons)
        {
            DiretorioDosCupons = diretorioDosCupons;
        }

        public void ConfigurarDiretorioDoInput(string diretorioDoInput)
        {
            DiretorioDoInput = diretorioDoInput;
        }

        public void Emitente(string CNPJ, string IE, string indRatISSQN = "N")
        {
            CFe.infCFe.emit = new emit
            {
                CNPJ = CNPJ,
                IE = IE,
                indRatISSQN = indRatISSQN
            };
        }

        public bool Emitir()
        {
            if (DateTime.Now <= new DateTime(2018, 10, 31))
            {
                var xmlCFe = CFe.Serialize();

                xmlCFe = xmlCFe.Replace("nItem=\"01\"", "nItem=\"1\"").Replace("nItem=\"02\"", "nItem=\"2\"").Replace("nItem=\"03\"", "nItem=\"3\"")
                         .Replace("nItem=\"04\"", "nItem=\"4\"").Replace("nItem=\"05\"", "nItem=\"5\"").Replace("nItem=\"06\"", "nItem=\"6\"")
                         .Replace("nItem=\"07\"", "nItem=\"7\"").Replace("nItem=\"08\"", "nItem=\"8\"").Replace("nItem=\"09\"", "nItem=\"9\"");

                var id = IdSessao.Random();

                xmlCFe.Write(DiretorioDosCupons + "\\CFe_" + CodigoDaFilial + CFe.infCFe.ide.numeroCaixa + id + ".xml");

                var xmlIntegrador = xmlCFe.GerarVendaViaIntegrador(id);
                xmlIntegrador.Write(DiretorioDoInput + "\\Venda_" + CodigoDaFilial + CFe.infCFe.ide.numeroCaixa + id + ".xml");
            }
            else
            {
                throw new Exception("O uso da biblioteca de emissão expirou!");
            }

            return true;
        }
    }
}
