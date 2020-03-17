using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Hilos_Asincronos
{
    abstract class Drink
    {
        public string drinkId { get; set; }

        public string GetInfo()
        {
            return $"My id is {drinkId}";
        }

        public virtual string DrinkId()
        {
            return string.Empty;
        }       
    }
}
