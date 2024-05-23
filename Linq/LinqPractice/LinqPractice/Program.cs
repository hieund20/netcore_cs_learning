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
            new Product(5, "Ipad Air", "in imperdiet et commodo vulputate justo in blandit ultrices enim lorem ipsum dolor sit amet consectetuer", 46, new string[] { "Green", "Red"}, 2),
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
        var firstProductHasOddPrice = products.First(x => x.Price % 2 == 0);
        Console.WriteLine($"{firstProductHasOddPrice.Name} - {firstProductHasOddPrice.Price}");

        Console.WriteLine("FIRST OR DEFAULT");
        var productHasOverPrice100 = products.FirstOrDefault(x => x.Price > 100);
        if (productHasOverPrice100 != null)
        {
            Console.WriteLine($"{productHasOverPrice100.Name} - {productHasOverPrice100.Price}");
        }
        else
        {
            Console.WriteLine("Can not find product has price is over than 100");
        }
        
        Console.WriteLine("LAST");
        var lastProductHasOddPrice = products.Last(x => x.Price % 2 == 0);
        Console.WriteLine($"{lastProductHasOddPrice.Name} - {lastProductHasOddPrice.Price}");

        Console.WriteLine("LAST OR DEFAULT");
        var lastProductHasOverPrice100 = products.LastOrDefault(x => x.Price > 100);
        if (lastProductHasOverPrice100 != null)
        {
            Console.WriteLine($"{lastProductHasOverPrice100.Name} - {lastProductHasOverPrice100.Price}");
        }
        else
        {
            Console.WriteLine("Can not find product has price is over than 100");
        }


        Console.WriteLine("SINGLE");
        var singleProduct = products.Single(x => x.Name == "Iphone 11");
        Console.WriteLine(singleProduct.Name);

        Console.WriteLine("SINGLE OR DEFAULT");
        var singleProductDefault = products.SingleOrDefault(x => x.Name == "Samsung");
        if (singleProductDefault != null)
        {
            Console.WriteLine(singleProductDefault.Name);
        }
        else
        {
            Console.WriteLine("Can not find product has name is Samsung");
        }
        #endregion

        #region Selecting specific elements
        Console.WriteLine("DISTINCT");
        int[] scores = { 1, 2, 2, 3, 4 };
        var uniqueScores = scores.Distinct();
        foreach ( var score in uniqueScores )
        {
            Console.WriteLine(score);
        }

        Console.WriteLine("DISTINCT BY");
        var productDistinctByPrice = products.DistinctBy(x => x.Price);
        foreach (var product in productDistinctByPrice)
        {
            Console.WriteLine($"{product.Name} - {product.Price}$");
        }    


        Console.WriteLine("TAKE");
        foreach (var product in products.Take(3))
        {
            Console.WriteLine(product.Name);
        }

        Console.WriteLine("TAKE WHILE");
        foreach (var product in products.TakeWhile(x => x.Price > 50))
        {
            Console.WriteLine($"{product.Name} - {product.Price}$");
        }

        Console.WriteLine("TAKE LAST");
        foreach (var product in products.TakeLast(3))
        {
            Console.WriteLine($"{product.Name} - {product.Price}$");
        }

        Console.WriteLine("SKIP");
        foreach (var product in products.Skip(3))
        {
            Console.WriteLine(product.Name);
        }

        Console.WriteLine("SKIP WHILE");
        foreach (var product in products.SkipWhile(x => x.Price > 50))
        {
            Console.WriteLine($"{product.Name} - {product.Price}$");
        }    

        Console.WriteLine("SKIP LAST");
        foreach (var product in products.SkipLast(3))
        {
            Console.WriteLine($"{product.Name} - {product.Price}$");
        }

        Console.WriteLine("CHUNK");
        foreach (var item in products.Chunk(2))
        {
            Console.WriteLine($"");
        }
        #endregion

        #region Checking if an element contained in a sequence
        Console.WriteLine("ANY");
        if (products.Any(x => x.Price > 100))
        {
            Console.WriteLine("There are a few products that cost more than 100");
        }
        else
        {
            Console.WriteLine("All product's price is less than 100");
        }

        Console.WriteLine("ALL");
        if (products.All(x => x.Price > 100))
        {
            Console.WriteLine("All product's price is over than 100");
        }
        else
        {
            Console.WriteLine("There are a few products that cost more than 100");
        }

        Console.WriteLine("CONTAINS");
        Product productFind = new Product(1); //Only need ID
        if (products.Contains(productFind, new ProductComparer()))
        {
            Console.WriteLine(products.Where(x => x.ID == productFind.ID).Select(x => x.Name).First());
        }
        else
        {
            Console.WriteLine("Not found");
        }
        #endregion

        #region Grouping data
        Console.WriteLine("GROUP BY");
        foreach (var group in products.GroupBy(x => x.CategoryId))
        {
            Console.WriteLine(group.Key + ":");
            foreach (var product in products)
            {
                Console.WriteLine("- " + product.Name + " (" + product.Price + ")");
            }
            Console.WriteLine();
        }
        #endregion

        #region Aggregating data
        Console.WriteLine("COUNT");
        Console.WriteLine($"{products.Count(x => x.Price > 50)}");

        Console.WriteLine("AVERAGE");
        Console.WriteLine($"{products.Average(x => x.Price)}");

        Console.WriteLine("SUM");
        Console.WriteLine($"{products.Sum(x => x.Price)}");

        Console.WriteLine("MIN");
        Console.WriteLine($"{products.Min(x => x.Price)}");

        Console.WriteLine("MIN BY");
        Console.WriteLine($"{products.MinBy(x => x.Price).Name}");

        Console.WriteLine("MAX");
        Console.WriteLine($"{products.Max(x => x.Price)}");

        Console.WriteLine("MAX BY");
        Console.WriteLine($"{products.MaxBy(x => x.Price).Name}");

        //Console.WriteLine("AGGREGATE");
        //Console.WriteLine($"{products.MaxBy(x => x.Price).Name}");
        #endregion

        #region Iterating elements
        Console.WriteLine("FOREACH");
        products.ForEach(x => Console.WriteLine(x.Name));
        #endregion

        #region Joining sequences
        Console.WriteLine("JOIN");
        var categoryProducts = products.Join(
            categories,
            product => product.CategoryId,
            category => category.ID,
            (product, category) => new
                {
                    productName = product.Name,
                    product.Price,
                    categoryName = category.Name
                }
            );

        foreach (var item in categoryProducts)
        {
            Console.WriteLine($"{item.productName} - {item.Price} - {item.categoryName}");
        }
        #endregion

        #region Set operations

        #endregion

        #region Range, Repeat, and Reverse

        #endregion

        #region Parallel LINQ & IAsyncEnumerable<T>
        #endregion
    }
}