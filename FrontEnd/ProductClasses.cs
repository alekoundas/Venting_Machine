using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd
{
    interface Iproduct
    {
        double Price { get; set; }
        string Title { get; set; }
        string OutputAvailable { get; }
        string OutputCart { get; }
    }


    class Cigar : Iproduct
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string OutputAvailable { get { return String.Format($" {Title,10} {Price,3} x" + (VentingMachine.Instance.ProductQueue.Where(x => x.Title == Title).Count())); } }
        public string OutputCart { get { return String.Format($" {Title,10} {Price,3} x" + (VentingMachine.Instance.CartQueue.Where(x => x.Title == Title).Count())); } }

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
        public string OutputAvailable { get { return String.Format($" {Title,10} {Price,3} x" + (VentingMachine.Instance.ProductQueue.Where(x => x.Title == Title).Count())); } }
        public string OutputCart { get { return String.Format($" {Title,10} {Price,3} x" + (VentingMachine.Instance.CartQueue.Where(x => x.Title == Title).Count())); } }

        public Water(string title, double price)
        {
            Title = title;
            Price = price;
            ID = Guid.NewGuid().ToString();
        }       
    }
}
