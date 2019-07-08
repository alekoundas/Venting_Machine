using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;



namespace FrontEnd
{

    interface Iqueue
    {
        Queue<Iproduct> CartQueue { get; set; }
        Queue<Iproduct> ProductQueue { get; set; }
    }

    //Singleton Patern
    sealed class VentingMachine : Iqueue
    {
        public static readonly VentingMachine Instance = new VentingMachine();
        public Queue<Iproduct> ProductQueue { get; set; } = new Queue<Iproduct>();
        public Queue<Iproduct> CartQueue { get; set; } = new Queue<Iproduct>();
        //Private Default Constructor
        private VentingMachine() { }

        public static Iproduct Menu(int a)
        {
            if (a == 1)
            {
                return new Cigar("Old Holborn - White", 1.25);
            }
            else if (a == 2)
            {
                return new Water("Zagori", 0.50d);
            }
            else
            {
                return null;
            }
        }
    }
}
