using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Recorre los números del 1 al 100. Muestra los números pares y los divisibles entre 3. Usar el tipo de bucle que quieras.
            //Los 2 resultados se imprimen al final del bucle.

            List<int> Divisible3 = new List<int>();
            List<int> Par = new List<int>();

            for (int i = 1; i < 100; i++)
            {
                if (i % 2 == 0)
                {
                    Par.Add(i);
                }

                if (i % 3 == 0)
                {
                    Divisible3.Add(i);
                }

            }

            Console.Write("Los números pares son: ");
            foreach (var item in Par)
            {
                Console.Write(item + ",");
            }
            Console.WriteLine();

            Console.Write("Los números divisibles entre 3 son: ");
            foreach (var item in Divisible3)
            {
                Console.Write(item + ",");
            }

            Console.ReadKey();
        }
    }
}
