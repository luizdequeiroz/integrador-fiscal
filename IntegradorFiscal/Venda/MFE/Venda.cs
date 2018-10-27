using IntegradorFiscal.MFE.tags;
using System.Collections.Generic;

namespace IntegradorFiscal.MFE
{
    public partial class Venda : Global
    {
        public Venda()
        {
            CFe.infCFe.dest = new dest();
            CFe.infCFe.det = new List<det>();
            CFe.infCFe.total = new total();
            CFe.infCFe.pgto = new pgto
            {
                MP = new List<MP>()
            };
            CFe.infCFe.infAdic = new infAdic();
        }

        public Venda(string CNPJ, string CPF, string idEstrangeiro, string xNome, string xLgr, string nro, string xCpl, string xBairro, string cMun, string xMun, string UF,
            string CEP, string fone, string IM, string email)
        {
            CFe.infCFe.dest = new dest
            {
                CNPJ = !string.IsNullOrEmpty(CNPJ) ? CNPJ : null,
                CPF = !string.IsNullOrEmpty(CPF) ? CPF : null,
                idEstrangeiro = !string.IsNullOrEmpty(idEstrangeiro) ? idEstrangeiro : null,
                xNome = !string.IsNullOrEmpty(xNome) ? xNome : null,
                enderDest = new ender
                {
                    xLgr = !string.IsNullOrEmpty(xLgr) ? xLgr : null,
                    nro = !string.IsNullOrEmpty(nro) ? nro : null,
                    xCpl = !string.IsNullOrEmpty(xCpl) ? xCpl : null,
                    xBairro = !string.IsNullOrEmpty(xBairro) ? xBairro : null,
                    cMun = !string.IsNullOrEmpty(cMun) ? cMun : null,
                    xMun = !string.IsNullOrEmpty(xMun) ? xMun : null,
                    UF = !string.IsNullOrEmpty(UF) ? UF : null,
                    CEP = !string.IsNullOrEmpty(CEP) ? CEP.Replace(".", "").Replace("-", "") : null,
                    fone = !string.IsNullOrEmpty(fone) ? fone : null,
                },
                IM = !string.IsNullOrEmpty(IM) ? IM : null,
                email = !string.IsNullOrEmpty(email) ? email : null,
                indIEDest = "9"
            };
            CFe.infCFe.det = new List<det>();
            CFe.infCFe.total = new total();
            CFe.infCFe.pgto = new pgto
            {
                MP = new List<MP>()
            };
            CFe.infCFe.infAdic = new infAdic();
        }

        public void AdicionarProduto(string cProd, string cEAN, string xProd, string NCM, string EXTIPI, string CFOP, string uCom, string qCom, string vUnCom, string indRegra,
            string vDesc, string vOutro, string vTotTrib, string orig, string CSTCSOSNICMS, string modBCICMS, string vBCICMS, string pICMS, string CSTPIS, string vBCPIS,
            string pPIS, string qBCProdPIS, string vAliqProdPIS, string CSTCOFINS, string vBCCOFINS, string pCOFINS, string qBCProdCOFINS, string vAliqProdCOFINS, string infAdProd)
        {
            var imposto = new imposto();

            imposto.ICMS = ICMS(CSTCSOSNICMS, orig, modBCICMS, vBCICMS, pICMS);
            imposto.PIS = PIS(CSTPIS, vBCPIS, pPIS, qBCProdPIS, vAliqProdPIS);
            imposto.COFINS = COFINS(CSTCOFINS, vBCCOFINS, pCOFINS, qBCProdCOFINS, vAliqProdCOFINS);

            CFe.infCFe.det.Add(new det
            {
                nItem = (CFe.infCFe.det.Count + 1).ToString("00"),
                prod = new prod
                {
                    cProd = !string.IsNullOrEmpty(cProd) ? cProd : null,
                    cEAN = !string.IsNullOrEmpty(cEAN) ? cEAN : null,
                    xProd = !string.IsNullOrEmpty(xProd) ? xProd : null,
                    NCM = !string.IsNullOrEmpty(NCM) ? NCM : null,
                    EXTIPI = !string.IsNullOrEmpty(EXTIPI) ? EXTIPI : null,
                    CFOP = !string.IsNullOrEmpty(CFOP) ? CFOP : null,
                    uCom = !string.IsNullOrEmpty(uCom) ? uCom : null,
                    qCom = !string.IsNullOrEmpty(qCom) ? qCom : null,
                    vUnCom = !string.IsNullOrEmpty(vUnCom) ? vUnCom : null,
                    vDesc = !string.IsNullOrEmpty(vDesc) ? vDesc : null,
                    indRegra = !string.IsNullOrEmpty(indRegra) ? indRegra : null,
                    vOutro = !string.IsNullOrEmpty(vOutro) ? vOutro : null
                },
                imposto = imposto,
                infAdProd = !string.IsNullOrEmpty(infAdProd) ? infAdProd : null
            });
        }

        public void EfetuarPagamento(string codigoDoPagamento, string valorDoPagamento, string codigoDoCredito = "")
        {
            CFe.infCFe.pgto.MP.Add(new MP
            {
                cMP = codigoDoPagamento,
                vMP = valorDoPagamento,
                cAdmC = string.IsNullOrEmpty(codigoDoCredito) ? null : codigoDoCredito
            });
        }

        public void IncluirInformacaoComplementar(string infCpl)
        {
            CFe.infCFe.infAdic.infCpl = infCpl;
        }
    }
}
