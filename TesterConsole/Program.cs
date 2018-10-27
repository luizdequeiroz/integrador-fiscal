using IntegradorFiscal.MFE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesterConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var emissor = new Emissor("123456789", "0.07", "14200166000140", "SGR-SAT SISTEMA DE GESTAO E RETAGUARDA DO SAT", "001", "321");
            emissor.Emitente("22295347000141", "310509210119");
            emissor.ConfigurarDiretorioDosCupons("C:\\CFe");
            emissor.ConfigurarDiretorioDoInput("C:\\Integrador\\Input");

            var venda = new Venda();
            venda.AdicionarProduto("151637", "7891024136454", "ENX BUCAL PLAX FRESHMINT 250ML", "33069000", "", "5405", "FR", "1.0000", "12.19", "A", "", "", "", "", "60", "3", "12.19", "", "01", "12.19", "1.6500", "1.0000", "0.2011", "01", "12.19", "7.6000", "1.0000", "0.9264", "De:     12,79 Por:   12,19");
            venda.EfetuarPagamento("01", "15.00");
            venda.IncluirInformacaoComplementar("VOCE ECONOMIZOU:R$ 0,60|Operador: 62489    Vendedor: |Trib aprox R$:0,51 Fed e R$:2,19 Est e R$:0,00 Muni|Fonte: IBPT  ca7gi3|Procon/Brasilia - DF|End: SCS Qd 8|Ed:Venancio 2000 BL B-60 Sl:240|CEP: 70.333-900 TEL: 151|Obrigado e Volte Sempre|Loja : 0639 - PDV : 0090");

            emissor.Emitir();

            Console.ReadKey();
        }
    }
}
