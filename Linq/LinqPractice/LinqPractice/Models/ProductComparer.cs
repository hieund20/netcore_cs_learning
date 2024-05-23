using System.Diagnostics.CodeAnalysis;

namespace LinqPractice.Models
{
    public class ProductComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product? x, Product? y)
        {
            // Check for null values
            if (x == null || y == null)
                return false;

            // Check if the two Person objects are the same reference
            if (ReferenceEquals(x, y))
                return true;

            // Compare the SSN of the two Person objects
            // to determine if they're the same
            return x.ID == y.ID;
        }

        public int GetHashCode([DisallowNull] Product obj)
        {
            if (obj == null || obj.ID == 0)
                return 0;

            // Use the SSN of the Person object
            // as the hash code
            return obj.ID.GetHashCode();
        }
    }
}
