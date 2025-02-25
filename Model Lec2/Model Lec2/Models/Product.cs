using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model_Lec2.Models;

public partial class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The Product name is required.")]
    public string? Name { get; set; }

    public decimal? Price { get; set; }

    [Required(ErrorMessage = "The Description is required.")]
    [StringLength(100, MinimumLength = 5, ErrorMessage = "The Description must be between 5 and 100 characters long.")]
    public string? Description { get; set; }

    public string? Image { get; set; }
}
