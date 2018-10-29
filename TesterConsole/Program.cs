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
            var emissor = new Emissor("123456789", "0.07", "12345678901234", "SGR-SAT SISTEMA DE GESTAO E RETAGUARDA DO SAT", "001", "321");
            emissor.Emitente("12345678901234", "210987654321");

            var venda = new Venda();
            venda.AdicionarProduto("151637", "7891024136454", "ENX BUCAL PLAX FRESHMINT 250ML", "33069000", "", "5405", "FR", "1.0000", "12.19", "A", "", "", "", "", "60", "3", "12.19", "", "01", "12.19", "1.6500", "1.0000", "0.2011", "01", "12.19", "7.6000", "1.0000", "0.9264", "De:     12,79 Por:   12,19");
            venda.EfetuarPagamento("04", "10.00", "123");
            venda.EfetuarPagamento("01", "2.20");
            venda.IncluirInformacaoComplementar("Volte sempre!");

            dynamic resposta = emissor.Emitir();

            Console.WriteLine(resposta.Ok);
            Console.WriteLine(resposta.Sessao);
            Console.WriteLine(resposta.Message);
            Console.WriteLine(resposta.ReturnPath);

            Console.ReadKey();
        }
    }
}
