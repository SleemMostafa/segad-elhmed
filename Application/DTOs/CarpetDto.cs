namespace Application.DTOs;

public class CarpetDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Length { get; set; }
    public decimal Width { get; set; }
    public string Color { get; set; } = string.Empty;
    public string Material { get; set; } = string.Empty;
    public decimal PricePerSquareMeter { get; set; }
    public int StockQuantity { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public decimal Area { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
