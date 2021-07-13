using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnlineAPI.ViewModels
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }

        [Required]
        public string CustomerName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public string AvatarUrl { get; set; }

        [Required]
        public bool IsLocked { get; set; }

        public string Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [Required]
        public string CustomerNo { get; set; }
    }
}
