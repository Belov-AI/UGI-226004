using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Product<TPrice> : IComparable<Product<TPrice>>
        where TPrice : IComparable<TPrice>
    {
        public string Name { get; set; }
        public TPrice Price {  get; set; }

        public override string ToString()
        {
            return Name;
        }

        public Product(string name, TPrice price)
        {
            Name = name;
            Price = price;
        }

        public Product(string name) : this(name, default(TPrice)) { }

        public Product() : this("no name") { }

        public void Sell()
        {
            Console.WriteLine($"Вы продали {Name} за {Price} руб.");
        }

        public int CompareTo(Product<TPrice> other)
        {
            return Price.CompareTo( other.Price );
        }
    }
}
