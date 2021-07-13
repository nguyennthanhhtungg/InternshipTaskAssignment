using System;
using System.Collections.Generic;

#nullable disable

namespace ShopOnlineAPI.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public string OrderNo { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime LastUpdated { get; set; }
        public double TotalMoney { get; set; }
        public int TotalProduct { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
