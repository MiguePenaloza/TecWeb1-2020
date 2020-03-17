using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Hilos_Asincronos
{
    abstract class Sandwich
    {
        public string sandwichId { get; set; }

        public string GetInfo()
        {
            return $"My id is {sandwichId}";
        }

        public virtual string SandwichId()
        {
            return string.Empty;
        }
    }
}
