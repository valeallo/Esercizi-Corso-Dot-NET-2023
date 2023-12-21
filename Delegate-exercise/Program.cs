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

            //secondo esercizio : 
            int x = 10;

            Func<int, int, int> multiplicateNumbers = (a, b) => a * b;
            Predicate<int> isGreaterThanX = product => product > x;

            Action<string> printMessage = message => Console.WriteLine(message);

            int resultMult = multiplicateNumbers(5, 5);

            if (isGreaterThanX(resultMult))
            {
                printMessage("The product is greater than X.");
            }
            else
            {
                printMessage("The product is not greater than X.");
            }

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

