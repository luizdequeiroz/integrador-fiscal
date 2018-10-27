using IntegradorFiscal.MFE.tags;

namespace IntegradorFiscal.MFE
{
    public partial class Venda
    {
        private ICMS ICMS(string CSTCSOSNICMS, string orig, string modBCICMS, string vBCICMS, string pICMS)
        {
            var ICMS = new ICMS();

            if (CSTCSOSNICMS == "00")
            {
                ICMS = new ICMS
                {
                    ICMS00 = new ICMS00
                    {
                        CST = !string.IsNullOrEmpty(CSTCSOSNICMS) ? CSTCSOSNICMS : null,
                        Orig = !string.IsNullOrEmpty(orig) ? orig : null,
                        modBC = !string.IsNullOrEmpty(modBCICMS) ? modBCICMS : null,
                        vBC = !string.IsNullOrEmpty(vBCICMS) ? vBCICMS : null,
                        pICMS = !string.IsNullOrEmpty(pICMS) ? pICMS : null,
                        vICMS = null
                    }
                };

            }
            else if (CSTCSOSNICMS == "40")
            {
                ICMS = new ICMS
                {
                    ICMS40 = new ICMS40
                    {
                        CST = !string.IsNullOrEmpty(CSTCSOSNICMS) ? CSTCSOSNICMS : null,
                        Orig = !string.IsNullOrEmpty(orig) ? orig : null,
                        vICMSDeson = null, //sem parametros recebidos da função
                        motDesICMS = null //sem parametros recebidos da função
                    }
                };

            }
            else if (CSTCSOSNICMS == "60")
            {
                ICMS = new ICMS
                {
                    ICMS40 = new ICMS40
                    {
                        CST = !string.IsNullOrEmpty(CSTCSOSNICMS) ? CSTCSOSNICMS : null,
                        Orig = !string.IsNullOrEmpty(orig) ? orig : "0",
                        vBCSTRet = null, //sem parametros recebidos da função
                        vICMSSTRet = null //sem parametros recebidos da função
                    }
                };
            }

            return ICMS;
        }

        private PIS PIS(string CSTPIS, string vBCPIS, string pPIS, string qBCProdPIS, string vAliqProdPIS)
        {
            var PIS = new PIS();

            if (CSTPIS == "01" || CSTPIS == "02")
            {
                PIS = new PIS
                {
                    PISAliq = new PISAliq
                    {
                        CST = CSTPIS,
                        vBC = vBCPIS,
                        pPIS = double.Parse(pPIS.Replace(".", ",")).ToString("0.0000").Replace(",", ".")
                    }
                };
            }
            else if (CSTPIS == "03")
            {
                PIS = new PIS
                {
                    PISQtde = new PISQtde
                    {
                        CST = CSTPIS,
                        qBCProd = qBCProdPIS,
                        vAliqProd = double.Parse(vAliqProdPIS.Replace(".", ",")).ToString("0.00").Replace(",", ".")
                    }
                };
            }
            else if (CSTPIS == "04" || CSTPIS == "06" || CSTPIS == "07" || CSTPIS == "08" || CSTPIS == "09")
            {
                PIS = new PIS
                {
                    PISNT = new PISNT
                    {
                        CST = CSTPIS
                    }
                };
            }
            else if (CSTPIS == "99")
            {
                PIS = new PIS
                {
                    PISOutr = new PISOutr
                    {
                        CST = CSTPIS,
                        vBC = vBCPIS,
                        pPIS = double.Parse(pPIS.Replace(".", ",")).ToString("0.0000").Replace(",", "."),
                        qBCProd = qBCProdPIS,
                        vAliqProd = double.Parse(vAliqProdPIS.Replace(".", ",")).ToString("0.00").Replace(",", ".")
                    }
                };
            }

            return PIS;
        }

        private COFINS COFINS(string CSTCOFINS, string vBCCOFINS, string pCOFINS, string qBCProdCOFINS, string vAliqProdCOFINS)
        {
            var COFINS = new COFINS();

            if (CSTCOFINS == "01" || CSTCOFINS == "02")
            {
                COFINS = new COFINS
                {
                    COFINSAliq = new COFINSAliq
                    {
                        CST = CSTCOFINS,
                        vBC = vBCCOFINS,
                        pCOFINS = double.Parse(pCOFINS.Replace(".", ",")).ToString("0.0000").Replace(",", ".")
                    }
                };
            }
            else if (CSTCOFINS == "03")
            {
                COFINS = new COFINS
                {
                    COFINSQtde = new COFINSQtde
                    {
                        CST = CSTCOFINS,
                        qBCProd = qBCProdCOFINS,
                        vAliqProd = double.Parse(vAliqProdCOFINS.Replace(".", ",")).ToString("0.00").Replace(",", ".")
                    }
                };
            }
            else if (CSTCOFINS == "04" || CSTCOFINS == "06" || CSTCOFINS == "07" || CSTCOFINS == "08" || CSTCOFINS == "09")
            {
                COFINS = new COFINS
                {
                    COFINSNT = new COFINSNT
                    {
                        CST = CSTCOFINS
                    }
                };
            }
            else if (CSTCOFINS == "99")
            {
                COFINS = new COFINS
                {
                    COFINSOutr = new COFINSOutr
                    {
                        CST = CSTCOFINS,
                        vBC = vBCCOFINS,
                        pCOFINS = double.Parse(pCOFINS.Replace(".", ",")).ToString("0.0000").Replace(",", "."),
                        qBCProd = qBCProdCOFINS,
                        vAliqProd = double.Parse(vAliqProdCOFINS.Replace(".", ",")).ToString("0.00").Replace(",", ".")
                    }
                };
            }

            return COFINS;
        }
    }
}
