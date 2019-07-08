using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrontEnd;

namespace FrontEnd.Transactions
{
    class ProductTransaction<T>
    {
        public static bool GetProduct(Customer customer)
        {
            VentingMachine VentMachine = VentingMachine.Instance;

            if (VentMachine.ProductQueue.Where(x => x.GetType() == typeof(T)).Count() > 0)
            {
                if (VentMachine.ProductQueue.Where(x => x.GetType() == typeof(T)).Any(x => x.Price <= customer.Money))
                {
                    double MoneyBefore = customer.Money;
                    customer.Money = MoneyTransaction<Iproduct>.TransferMoney(VentMachine.ProductQueue, customer.Money);
                    Console.WriteLine($"Purchased {VentMachine.ProductQueue.Peek().Title} :{VentMachine.ProductQueue.Peek().Price} Balance Before: {MoneyBefore} and After: {customer.Money}");
                }
                else
                {
                    Console.WriteLine("Not Enougth Balance!");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Im Out Of Selected Product");
                return false;
            }
            return true;
        }
    }
}
