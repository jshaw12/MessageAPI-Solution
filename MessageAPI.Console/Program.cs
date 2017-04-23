using MessageAPI.Facade;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MessageAPIConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's wait for the API to load.");
            Console.ReadLine();

            var message = (new WebRequestFacade()).GetMessage();
            Console.WriteLine(message);

            Console.ReadLine();
        }
    }
}
