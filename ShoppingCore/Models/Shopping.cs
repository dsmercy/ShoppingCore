using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingCore.Models
{
    public class Shippingdetail
    {
        public int ShippingDetailId { get; set; }
        public int ?ProductId { get; set; }
        [Required]
        public int Mobile { get; set; }
        [Required]
        public string RecieverName { get; set; }
        [Required]
        public Nullable<int> MemberId { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string ZipCode { get; set; }
        public string OrderId { get; set; }
        public Nullable<decimal> AmountPaid { get; set; }
        [Required]
        public string PaymentType { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public string OrderDate { get; set; } = DateTime.Now.ToShortDateString(); 
    }
}