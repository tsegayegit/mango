﻿using System.ComponentModel.DataAnnotations;

namespace Mango.Services.CouponAPI.Models
{
    public class Coupon
    {
        [Key]
        public string CouponId { get; set; }
        [Required]
        public double DiscountAmount { get; set; }
        [Required]
        public string CouponCode { get; set; }
        public int  MinAmount { get; set; }
        

    }
}
