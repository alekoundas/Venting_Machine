using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venting_Machine.Repository;
using Venting_Machine.Transactions;
using System.Data;
using System.Data.SqlClient;



namespace Venting_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection Con = DataBase.dbConnectionAndInitData();



            int UserSelection;
            do
            {
                PrintMenu();
                UserSelection = Convert.ToInt32(Console.ReadLine());
                switch (UserSelection)
                {
                    case 1:
                        //Input Cigar 
                        Repository<Iproduct>.AddToVentingMachine(VentingMachine.Menu(UserSelection));
                        Repository<Iproduct>.RemainingProducts();
                        break;
                    case 2:
                        //Input Water
                        Repository<Iproduct>.AddToVentingMachine(VentingMachine.Menu(UserSelection));
                        Repository<Iproduct>.RemainingProducts();
                        break;
                    case 3:
                        //Get a Cigar                      
                        if (ProductTransaction<Cigar>.GetProduct(Customer.Instance))
                        {
                            Repository<Cigar>.RemoveFromVentingMachine();
                            Repository<Iproduct>.RemainingProducts();
                        }
                        break;
                    case 4:
                        //Get Water
                        if (ProductTransaction<Water>.GetProduct(Customer.Instance))
                        {
                            Repository<Water>.RemoveFromVentingMachine();
                            Repository<Iproduct>.RemainingProducts();
                        }
                        break;
                    case 5:
                        //CustomerBalance
                        Console.WriteLine(Customer.Instance.Money);
                        break;
                    case 6:
                        //Show Products Count
                        Repository<Iproduct>.RemainingProducts();
                        break;                   
                    default:
                        break;
                }

            } while (UserSelection != 7);
        }

        public static void PrintMenu()
        {
            Console.WriteLine("                 ///////////////////////////////");
            Console.WriteLine("                 //  1.Add Cigar.             //");
            Console.WriteLine("                 //  2.Add Water.             //");
            Console.WriteLine("                 //  3.Get Cigar.             //");
            Console.WriteLine("                 //  4.Get Water.             //");
            Console.WriteLine("                 //  5.Show Balance.          //");
            Console.WriteLine("                 //  6.Show Remaining Product.//");
            Console.WriteLine("                 //  7.Exit.                  //");
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
        public static readonly Customer Instance = new Customer();
        private Customer() { }
    }

    class Cigar : Iproduct
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        public Cigar(string title, double price)
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
