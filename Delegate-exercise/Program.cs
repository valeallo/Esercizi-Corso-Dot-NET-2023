using System;

namespace Delegate_exercise
{

   internal class Program
        {

        public delegate int SumDelegate(int a, int b);
        public delegate string PrintSumDelegate(SumDelegate sumFunction);

       
        public static int Sum(int a, int b)
        {
            return a + b;
        }

        public static string StringifyResult(SumDelegate sumFunction)
        {
            return sumFunction(5, 10).ToString();
        }

        static void Main(string[] args)
        {
            SumDelegate sumDel = new SumDelegate(Sum);

            PrintSumDelegate execSumDel = new PrintSumDelegate(StringifyResult);

      
            string result = execSumDel(sumDel);

       
            Console.WriteLine("The result is: " + result);

 
        }
    }

}

