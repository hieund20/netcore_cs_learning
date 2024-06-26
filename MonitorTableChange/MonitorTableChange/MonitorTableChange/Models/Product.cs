﻿namespace MonitorTableChange.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }

        //Navigation propertiesz    
        public Category Category { get; set; }
    }
}
