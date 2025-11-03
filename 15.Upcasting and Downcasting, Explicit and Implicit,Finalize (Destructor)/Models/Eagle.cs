using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Upcasting_and_Downcasting__Explicit_and_Implicit_Finalize__Destructor_.Models
{
    internal class Eagle : Animals
    {
        public int FlySpeed { get; set; }
        public void Fly()
        {
            Console.WriteLine("Flied away");
        }
    }
}
