using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string[] Colors { get; set; }
        public int CategoryId { get; set; }

        public Product(int id, string name, string description, double price, string[] colors, int categoryId)
        {
            ID = id;
            Name = name;
            Description = description;
            Price = price;
            Colors = colors;
            CategoryId = categoryId;
        }

        public Product(int id)
        {
            ID = id;
        }
    }
}
