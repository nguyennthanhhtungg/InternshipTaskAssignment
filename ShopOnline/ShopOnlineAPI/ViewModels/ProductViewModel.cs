using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ShortDiscription { get; set; }

        [Required]
        public string DetailDiscription { get; set; }

        [Required]
        public string ProductCode { get; set; }

        public DateTime? ExpiryDate { get; set; }

        [Required]
        public DateTime ManufacturingDate { get; set; }


        [Required]
        public double Price { get; set; }


        public float? Discount { get; set; }

        public double? Weight { get; set; }

        [Required]
        public int Number { get; set; }

        public string AttachedGift { get; set; }

        [Required]
        public string Origin { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int SupplierId { get; set; }

        [Required]
        public double Tax { get; set; }
    }
}
