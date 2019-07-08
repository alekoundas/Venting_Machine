using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd
{
    //Singleton Patern
    public sealed class Customer
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public double Money { get; set; }
        public static readonly Customer Instance = new Customer();
        //Private Default Constractor
        private Customer() { }
    }
}
