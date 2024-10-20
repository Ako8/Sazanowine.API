﻿namespace Sazanowine.Domain.Entities;

public class Wine
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public bool ForSale { get; set; } = false;
    public int VintageYear { get; set; }
    public decimal DiscountedPrice { get; set; }
    public bool IsDiscounted { get; set; }
}
