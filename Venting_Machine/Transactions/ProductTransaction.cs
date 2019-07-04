using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venting_Machine;

namespace Venting_Machine.Transactions
{
    class ProductTransaction<T>
    {
        public static bool GetCola(Queue<Iproduct> Product, Customer customer)
        {
            VentingMachine VentMachine = VentingMachine.Instance;

            if (VentMachine.ColaQueue.Count > 0)
            {
                if (VentMachine.ColaQueue.Peek().Price <= customer.Money)
                {
                    double MoneyBefore = customer.Money;
                    customer.Money = MoneyTransaction<Iproduct>.TransferMoney(VentMachine.ColaQueue, customer.Money);
                    Console.WriteLine($"Purchased {VentMachine.ColaQueue.Peek().Title} :{VentMachine.ColaQueue.Peek().Price} Balance Before: {MoneyBefore} and After: {customer.Money}");
                }
                else
                {
                    Console.WriteLine("Not Enougth Balance!");
                }
            }
            else
            {
                Console.WriteLine("Im Out Of Coca Colas");
                return false;
            }
            return true;





        }

        public static bool GetWater(Queue<Iproduct> Product , Customer customer)
        {
            VentingMachine VentMachine = VentingMachine.Instance;

            if (VentMachine.WaterQueue.Count > 0)
            {
                if (VentMachine.WaterQueue.Peek().Price <= customer.Money)
                {
                    double MoneyBefore = customer.Money;
                    customer.Money = MoneyTransaction<Iproduct>.TransferMoney(VentMachine.WaterQueue, customer.Money);
                    Console.WriteLine($"Purchased {VentMachine.WaterQueue.Peek().Title} :{VentMachine.WaterQueue.Peek().Price} Balance Before: {MoneyBefore} and After: {customer.Money}");
                }
                else
                {
                    Console.WriteLine("Not Enougth Balance!");
                }
            }
            else
            {
                Console.WriteLine("Im Out Of Water Botles");
                return false;
            }
            return true;
        }
    }
}
