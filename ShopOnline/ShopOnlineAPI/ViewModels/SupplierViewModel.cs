using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI.ViewModels
{
    public class SupplierViewModel
    {
        public int SupplierId { get; set; }

        [Required]
        public string SupplierName { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string LogoUrl { get; set; }


        public string Discription { get; set; }
    }
}
