using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Threading.Comps
{
    public class Foo
    {
        private static object locker = new object();

        int[] numbers;

        public Foo(int size = 50)
        {
            numbers = new int[size];
        }

        public void FillInt(int num)
        {
            lock (locker)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = num;
                }
                Print();
            }
        }

        public void Fill(object mObj)
        {
            if (mObj is int)
                FillInt((int)mObj);


            //lock (locker)
            //{
            //    if (mObj is int)
            //    {
            //        for (int i = 0; i < numbers.Length; i++)
            //        {
            //            numbers[i] = (int)mObj;
            //        }
            //        Print();
            //    }
            //}

        }

        public void Print()
        {
            foreach (int i in numbers)
            {
                Console.Write(numbers[i]);
            }
            Console.WriteLine();

        }
    }
}
