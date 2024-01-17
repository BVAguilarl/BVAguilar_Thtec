using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    public interface InterfazA
    {
        string MetodoA();
        string MetodoB();
    }
    
    class ClaseB : InterfazA
    {
        public string MetodoA()
        {
            return "Hola clase: B método A";
        }
          
        public string MetodoB()
        {
            return "Hola clase: B método B";
        }
    }

    class ClaseA : ClaseB
    {
        public string Ajuste()
        {
            return MetodoA() + " \nHola clase: A método: A - Termine mi prueba";
        }
    }

   
    internal class Program
    {  

        static void Main(string[] args)
        {
            ClaseA claseA = new ClaseA();

            Console.WriteLine(claseA.Ajuste());
            Console.WriteLine(claseA.MetodoB());
            
            Console.ReadLine();
        }
    }
}
