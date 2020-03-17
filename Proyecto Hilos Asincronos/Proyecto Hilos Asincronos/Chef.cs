using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proyecto_Hilos_Asincronos
{
    class Chef
    {
        public async Task<string> PrepareSandwichAsync()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("mixing teh ingredients");
                Thread.Sleep(20000);
                Console.WriteLine("getting the chicken from the oven");
            });

            return "fried chicken";
        }

        public string PrepareDrink()
        {
            Console.WriteLine("starting slicing salad");
            Thread.Sleep(5000);
            Console.WriteLine("finished salad");
            return "a healty salad";
        }
    }
}
