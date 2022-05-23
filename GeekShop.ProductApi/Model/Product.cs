﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GeekShop.ProductApi.Model.Base;

namespace GeekShop.ProductApi.Model;

[Table("product")]
public class Product : BaseEntity
{
    [Column("name")]
    [Required]
    [StringLength(150)]
    public string Name { get; set; }
    
    [Column("price")]
    [Required]
    [Range(1, 10000)]
    public decimal Price { get; set; }
    
    [Column("description")]
    [StringLength(1000)]
    public string Description { get; set; }
    
    [Column("category_name")]
    [StringLength(50)]
    public string Category { get; set; }
    
    [Column("image_url")]
    [StringLength(2048)]
    public string ImageUrl { get; set; }
}