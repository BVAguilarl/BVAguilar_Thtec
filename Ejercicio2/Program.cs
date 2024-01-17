using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Registrar el precio de “n” productos e imprimir el producto de mayor precio y el de menor precio.

            decimal precioMaximo, precioMinimo;
            int productoMaximo = 0, productoMinimo = 0;

            Console.WriteLine("Número de productos");
            int NumeroProductos = int.Parse(Console.ReadLine());

            for (int i = 1; i <= NumeroProductos; i++)
            {
                Console.WriteLine($"Precio del producto {i}:");
                decimal precioActual = Convert.ToDecimal(Console.ReadLine());

                // Actualizar precio máximo y mínimo según sea necesario
                if (precioActual > decimal.MinValue)
                {
                    precioMaximo = precioActual;
                    productoMaximo = i;
                }

                if (precioActual < decimal.MaxValue)
                {
                    precioMinimo = precioActual;
                    productoMinimo = i;
                }
            }

            Console.WriteLine("El producto de mayor precio es el: " + productoMaximo + " $" + +precioMaximo);

            Console.WriteLine("El producto de menor precio es el: " + productoMinimo + " $" + precioMinimo);


            Console.ReadKey();

        }
    }
}
