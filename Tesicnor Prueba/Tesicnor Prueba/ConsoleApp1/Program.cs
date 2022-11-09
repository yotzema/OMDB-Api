using System;
using Tesicnor_Prueba;
using Model;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        static async Task Main(string[] args)
        {

            FixerRequest fixer = new FixerRequest();

            fixer.Execute();

            Console.WriteLine("Hello World!");
        }
    }
}
