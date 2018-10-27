using System;

namespace IntegradorFiscal.Functions
{
    public class IdSessao
    {
        public static int Random()
        {
            Random generator = new Random();
            var r = int.Parse(generator.Next(0, 1000000).ToString("D6"));

            //var CFe = new CFe().SelecionarPorId(r);
            //var CFeCanc = new CFeCanc().SelecionarPorId(r);

            //if (CFe.id != 0 && CFeCanc.id != 0)
            //{
            //    random();
            //}

            return r;
        }
    }
}
