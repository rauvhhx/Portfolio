using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Upcasting_and_Downcasting__Explicit_and_Implicit_Finalize__Destructor_.Models
{
    internal class Animals
    {
        public int AvgLifeTime { get; set; }
        public string Gender { get; set; }

        public virtual void Eat()
        {
            Console.WriteLine("Qidalanir");
        }

    }
}
