using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Program
    {
        static void Main(string[] args)
        {
            int somme;
            string input;

            Console.Write("Enter n: ");
            input = Console.ReadLine();

            if (Int32.TryParse(input, out int n))
            {
                somme = calculSomme(n);
                Console.WriteLine(somme);
                _ = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("String could not be parsed.");
            }
        }

        public static int calculSomme(int n)
        {
            return n > 0 ? n * (n + 1) / 2 : 0;
        }

        /*public static int calculSomme(int n)
        {
            int sum = 0;
            for (int i = 0; i <= n; i++)
            {
                sum += i;
            }
            return sum;
        }*/
    }
}
