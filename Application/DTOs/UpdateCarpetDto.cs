namespace Application.DTOs;

public class UpdateCarpetDto
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
}
