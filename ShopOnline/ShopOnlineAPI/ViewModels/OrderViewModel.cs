using ShopOnlineAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }

        [Required]
        public string OrderNo { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }

        [Required]
        public double TotalMoney { get; set; }

        [Required]
        public int TotalProduct { get; set; }

        public List<OrderDetailViewModel> OrderDetails { get; set; }
    }
}
