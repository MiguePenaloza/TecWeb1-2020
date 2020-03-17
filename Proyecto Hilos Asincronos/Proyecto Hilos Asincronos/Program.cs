using System;

namespace Proyecto_Hilos_Asincronos
{
    class Program
    {
        static void Main(string[] args)
        {
            var ex = new Drink();
            ex.drinkTime = 1;
            Console.WriteLine($"id: {ex.drinkId} time: {ex.drinkTime}");
        }
    }
}
