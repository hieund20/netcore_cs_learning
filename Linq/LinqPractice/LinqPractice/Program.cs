// See https://aka.ms/new-console-template for more information
using LinqPractice.Models;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("LINQ Practices");

        #region Data initialization
        var products = new List<Product>()
        {
            new Product(1, "Iphone 11", "accumsan tortor quis turpis sed ante vivamus tortor duis mattis egestas metus aenean fermentum donec ut mauris eget", 89, new string[] {"Grey", "Green"}, 1),
            new Product(2, "Iphone 12", "congue vivamus metus arcu adipiscing molestie hendrerit at vulputate vitae nisl aenean lectus", 85, new string[] { "Grey", "Red"}, 1),
            new Product(3, "Iphone X", "nulla sed accumsan felis ut at dolor quis odio consequat varius integer ac leo pellentesque", 2, new string[] { "Green", "Gray"}, 1),
            new Product(4, "Ipad Gen 9", "at turpis a pede posuere nonummy integer non velit donec diam neque", 46, new string[] {"White", "Red"}, 2),
            new Product(5, "Ipad Air", "in imperdiet et commodo vulputate justo in blandit ultrices enim lorem ipsum dolor sit amet consectetuer", 78, new string[] { "Green", "Red"}, 2),
        };

        var categories = new List<Category>()
        {
            new Category (1, "Điện thoại"),
            new Category (2, "Máy tính bảng"),
        };
        #endregion

        #region Selecting elements
        Console.WriteLine("SELECT");
        var selectedProducts = from p in products select p;
        // Maybe: var selectedProducts = products.Select(x => x);
        foreach (var item in selectedProducts)
        {
            Console.WriteLine(item.Name);
        }

        Console.WriteLine("SELECT MANY");
        var productColors = products.SelectMany(x => x.Colors);
        foreach (var color in productColors)
        {
            Console.WriteLine(color);
        }
        #endregion

        #region Ordering elements
        Console.WriteLine("ORDER BY");
        var productOrderedByPrice = products.OrderBy(x => x.Price);
        foreach (var product in productOrderedByPrice)
        {
            Console.WriteLine($"{product.Name} - {product.Price}");
        }

        Console.WriteLine("ORDER BY DESCENDING");
        var productOrderedByDescendingPrice = products.OrderByDescending(x => x.Price);
        foreach (var product in productOrderedByDescendingPrice)
        {
            Console.WriteLine($"{product.Name} - {product.Price}");
        }

        Console.WriteLine("THEN BY");
        var productThenByPrice = products.OrderBy(x => x.Name).ThenBy(x => x.Price);
        foreach (var product in productThenByPrice)
        {
            Console.WriteLine($"{product.Name} - {product.Price}");
        }

        Console.WriteLine("THEN BY DESCENDING");
        var productThenByDescendingPrice = products.OrderBy(x => x.Name).ThenByDescending(x => x.Price);
        foreach (var product in productThenByDescendingPrice)
        {
            Console.WriteLine($"{product.Name} - {product.Price}");
        }
        #endregion

        #region Filtering elements
        Console.WriteLine("WHERE");
        var productHasRedColors = products.Where(x => x.Colors.Contains("Red"));
        foreach (var product in productHasRedColors)
        {
            string result = product.Name;
            foreach (var color in product.Colors)
            {
                result += " " + color;
            }
            Console.WriteLine(result);
        }
        #endregion

        #region Selecting a single element
        Console.WriteLine("FIRST");

        Console.WriteLine("LAST"); 

        Console.WriteLine("SINGLE");
        #endregion
    }
}