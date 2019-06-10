using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cap1
{
    class Program
    {
        private const string _THREAD = "Thread: {0}";
        private const string _MAIN_THREAD = "Main thread: {0}";

        static void Main(string[] args)
        {
            //Thread t = new Thread(new ThreadStart(ThreadMethod));
            Thread t = new Thread(new ParameterizedThreadStart(ParametrizedThread));

            //t.Start();
            t.Start(5);

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(_MAIN_THREAD, i);
                Thread.Sleep(0);
            }

            t.Join();

            Console.ReadKey();
        }

        static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(_THREAD, i);
                Thread.Sleep(0);
            }
        }

        static void ParametrizedThread(object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine(_THREAD, i);
            }
        }
    }
}
