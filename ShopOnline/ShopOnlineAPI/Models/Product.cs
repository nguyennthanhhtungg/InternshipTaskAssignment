using System;
using System.Collections.Generic;

#nullable disable

namespace ShopOnlineAPI.Models
{
    public partial class Product
    {
        public Product()
        {
            Comments = new HashSet<Comment>();
            OrderDetails = new HashSet<OrderDetail>();
            ProductImages = new HashSet<ProductImage>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ShortDiscription { get; set; }
        public string DetailDiscription { get; set; }
        public string ProductCode { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public double Price { get; set; }
        public float? Discount { get; set; }
        public double? Weight { get; set; }
        public int Number { get; set; }
        public string AttachedGift { get; set; }
        public string Origin { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public double Tax { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
