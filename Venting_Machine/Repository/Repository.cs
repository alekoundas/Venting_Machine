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
            VentingMachine VentMachine = VentingMachine.Instance;


            if (Product.GetType() == typeof(Cola))
            {
                VentMachine.ColaQueue.Enqueue((Iproduct)Product);
                RemainingProduct(Product);
                return Product;
            }
            else if (Product.GetType() == typeof(Water))
            {
                VentMachine.WaterQueue.Enqueue((Iproduct)Product);
                RemainingProduct(Product);

                return Product;
            }
            return Product;
        }

        public static void RemoveFromVentingMachine(T Product)
        {
            VentingMachine VentMachine = VentingMachine.Instance;


            if (Product.GetType() == typeof(Cola))
            {
                VentMachine.ColaQueue.Dequeue();
            }
            else if (Product.GetType() == typeof(Water))
            {
                VentMachine.WaterQueue.Dequeue();
            }
        }

        public static void RemainingProduct(T Product)
        {
            
            VentingMachine VentMachine = VentingMachine.Instance;           
            if (Product.GetType() == typeof(Cola))
            {
                if (VentMachine.ColaQueue.Count != 0)
                {
                    Console.WriteLine("  " + VentMachine.ColaQueue.Count + " Remaining Colas");
                }
                else
                {
                    Console.WriteLine("  " + 0 + " Remaining Colas");
                }
                
            }
            else if(Product.GetType() == typeof(Water))
            {
                Console.WriteLine(VentMachine.ColaQueue.Count);
                if (VentMachine.ColaQueue.Count != 0)
                {
                    Console.WriteLine("  " + VentMachine.WaterQueue.Count + " Remaining Water");
                }
                else
                {
                    Console.WriteLine("  " + 0 + " Remaining Water");
                }
               
            }


        }




    }
}
