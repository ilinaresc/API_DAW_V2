using System;
using System.Collections.Generic;

namespace API_DAW_DOMAIN.Core.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public int? Stock { get; set; }

    public decimal? Price { get; set; }

    public int? Discount { get; set; }

    public int? CategoryId { get; set; }

    public bool? IsActive { get; set; }
}
