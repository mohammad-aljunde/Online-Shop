﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Image { get; set; }
        [Display(Name ="Product Color")]
        public string ProductColor { get; set; }

        [Required]
        [Display(Name ="Available")]
        public bool IsAvailable { get; set; }

        public ProductTypes ProductTypes { get; set; }
        [Required]
        [Display(Name ="Product Type")]
        public int ProductTypesId { get; set; }

        public SpecialTags SpecialTags { get; set; }
        [Required]
        [Display(Name = "Special Tag")]
        public int SpecialTagsId { get; set; }
    }
}
