using System;
using System.Threading.Tasks;

namespace IntegradorFiscal.Functions
{
    public class ThreadTask
    {
        public static void IniciarThread(Action action)
        {
            Task.Factory.StartNew(() =>
            {
                while (true) action.Invoke();
            });
        }
    }
}
