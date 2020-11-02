using System;

namespace Разработка_софта
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime d = new DateTime();
            d = d.AddHours(6);
            Console.WriteLine(d);
        }
    }
}
