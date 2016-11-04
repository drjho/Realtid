using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarSimulation
{
    class Program
    {
        static object lock1 = new object();
        static object lock2 = new object();
        static object lock3 = new object();

        static EventWaitHandle mainHandle = new AutoResetEvent(false);

        static string tempStr = "";
        static string lightStr = "<==";
        static string wiperStr = "";

        static Random rand = new Random();

        static void Main(string[] args)
        {
            var tempThread = new Thread(Temperature);
            tempThread.IsBackground = true;
            tempThread.Start();

            var lightThread = new Thread(Light);
            lightThread.IsBackground = true;
            lightThread.Start();

            var wiperThread = new Thread(Wiper);
            wiperThread.IsBackground = true;
            wiperThread.Start();

            while (true)
            {
                mainHandle.WaitOne();
                Console.Clear();
                lock (lock1)
                {
                    Console.WriteLine(tempStr);
                }
                lock (lock2)
                {
                    Console.WriteLine(lightStr);
                }
                lock (lock3)
                {
                    Console.WriteLine(wiperStr);
                }
                mainHandle.Reset();
            }
        }

        static void Temperature()
        {
            float temp = 20;
            while (true)
            {

                temp += rand.Next(-1, 2) * 0.1f;
                lock (lock1)
                {
                    tempStr = $"Temperature: {temp}";
                }
                mainHandle.Set();
                Thread.Sleep(1000);

            }

        }

        static void Light()
        {
            bool highlight = true;
            while (true)
            {
                if (Console.ReadKey(false).Key == ConsoleKey.H)
                    highlight = !highlight;

                lock (lock2)
                {
                    if (highlight)
                        lightStr = "<==";
                    else
                        lightStr = "<\\\\";
                }
                mainHandle.Set();

            }
        }

        static void Wiper()
        {
            int pos = 0;
            int shift = 1;
            var sb = new StringBuilder();
            while (true)
            {
                sb.Clear();
                sb.Append('=', pos - 0);
                sb.Append('|');
                sb.Append('=', 10 - pos);
                lock (lock3)
                {
                    wiperStr = sb.ToString();

                }
                pos += shift;
                if (pos == 10)
                    shift = -1;
                if (pos == 0)
                    shift = 1;
                mainHandle.Set();
                Thread.Sleep(100);
            }

        }
    }
}
