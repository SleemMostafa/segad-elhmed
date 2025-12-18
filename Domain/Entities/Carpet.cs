namespace Domain.Entities;

public class Carpet
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Length { get; set; } // in meters
    public decimal Width { get; set; } // in meters
    public string Color { get; set; } = string.Empty;
    public string Material { get; set; } = string.Empty;
    public decimal PricePerSquareMeter { get; set; }
    public int StockQuantity { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    public decimal TotalPrice => Length * Width * PricePerSquareMeter;
    public decimal Area => Length * Width;
}
