using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venting_Machine;


namespace Venting_Machine.Repository
{
    class Repository<T>
    {
        public static T AddToVentingMachine(T Product)
        {
            VentingMachine.Instance.ProductQueue.Enqueue((Iproduct)Product);
            return Product;
        }

        public static void RemoveFromVentingMachine()
        {          
            if (VentingMachine.Instance.ProductQueue.Where(x => x.GetType() == typeof(T)).Any())
            {
                VentingMachine.Instance.ProductQueue.Dequeue();
            }
        }

        public static void RemainingProduct()
        {
            Console.WriteLine("  " + VentingMachine.Instance.ProductQueue.Where(x => x.GetType() == typeof(T)).Count() + " Remaining Products");
        }
    }
}
