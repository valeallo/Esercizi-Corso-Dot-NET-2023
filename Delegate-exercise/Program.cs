using System;

namespace Delegate_exercise
{

   internal class Program
        {

    



        static void Main(string[] args)
        {


            //primo esercizio : 
            SumDelegate sumDel =  Sum;
            PrintSumDelegate execSumDel = new PrintSumDelegate(StringifyResult);
            string result = execSumDel(sumDel);
            PrintResultInConsole(result);
 
        }

        //primo esercizio : 
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
        public static void PrintResultInConsole(string str)
        {
            Console.WriteLine("The result is: " + str);
        }
    }

}

