using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venting_Machine.Repository;
using Venting_Machine.Transactions;



namespace Venting_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer Customer = new Customer("John", 13);

            int UserSelection;
            do
            {
                PrintMenu();
                UserSelection = Convert.ToInt32(Console.ReadLine());
                switch (UserSelection)
                {
                    case 1:
                        //Input Cola 
                        Repository<Iproduct>.AddToVentingMachine(VentingMachine.Menu(UserSelection));
                        Repository<Iproduct>.RemainingProducts();
                        break;
                    case 2:
                        //Input Water
                        Repository<Iproduct>.AddToVentingMachine(VentingMachine.Menu(UserSelection));
                        Repository<Iproduct>.RemainingProducts();
                        break;
                    case 3:
                        //Get a Cola                      
                        if (ProductTransaction<Cola>.GetProduct(Customer))
                        {
                            Repository<Cola>.RemoveFromVentingMachine();
                            Repository<Iproduct>.RemainingProducts();
                        }
                        break;
                    case 4:
                        //Get Water
                        if (ProductTransaction<Water>.GetProduct(Customer))
                        {
                            Repository<Water>.RemoveFromVentingMachine();
                            Repository<Iproduct>.RemainingProducts();
                        }
                        break;
                    case 5:
                        //CustomerBalance
                        Console.WriteLine(Customer.Money);
                        break;
                    case 6:
                        //Show Cola Count
                        Repository<Iproduct>.RemainingProducts();
                        break;
                    case 7:
                        //Show Water Count
                        Repository<Iproduct>.RemainingProducts();
                        break;
                    default:
                        break;
                }

            } while (UserSelection != 8);
        }

        public static void PrintMenu()
        {
            Console.WriteLine("                 ///////////////////////////////");
            Console.WriteLine("                 //  1.Add Coca Cola.         //");
            Console.WriteLine("                 //  2.Add Water.             //");
            Console.WriteLine("                 //  3.Get Coca Cola.         //");
            Console.WriteLine("                 //  4.Get Water.             //");
            Console.WriteLine("                 //  5.Show Balance.          //");
            Console.WriteLine("                 //  6.Show Remaining Colas.  //");
            Console.WriteLine("                 //  7.Show Remaining Water.  //");
            Console.WriteLine("                 //  8.Exit.                  //");
            Console.WriteLine("                 ///////////////////////////////");
            Console.WriteLine("              Select an answer by the displayed number \n\n");
        }





    }

    interface Iproduct
    {
        double Price { get; set; }
        string Title { get; set; }
    }

    class Customer
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public double Money { get; set; }

        public Customer(string name, int money)
        {
            Name = name;
            Money = money;
            ID = Guid.NewGuid().ToString();
        }
    }

    class Cola : Iproduct
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        public Cola(string title, double price)
        {
            Title = title;
            Price = price;
            ID = Guid.NewGuid().ToString();
        }
    }
    class Water : Iproduct
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public Water(string title, double price)
        {
            Title = title;
            Price = price;
            ID = Guid.NewGuid().ToString();
        }
    }


    //Singleton Patern
    sealed class VentingMachine
    {
        public static readonly VentingMachine Instance = new VentingMachine();
        public Queue<Iproduct> ProductQueue { get; set; } = new Queue<Iproduct>();
        //Private Default Constructor
        private VentingMachine() { }

        public static Iproduct Menu(int a)
        {
            if (a == 1)
            {
                return new Cola("Zero", 1.25);
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
