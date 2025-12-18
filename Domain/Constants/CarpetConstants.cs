namespace Domain.Constants;

public static class CarpetConstants
{
    // Field Max Lengths
    public const int NameMaxLength = 200;
    public const int DescriptionMaxLength = 1000;
    public const int ColorMaxLength = 50;
    public const int MaterialMaxLength = 100;

    // Decimal Precision
    public const int DecimalPrecision = 18;
    public const int DecimalScale = 2;

    // Validation Constants
    public const decimal MinDimension = 0.1m; // Minimum 10cm
    public const decimal MaxDimension = 100m; // Maximum 100 meters
    public const decimal MinPrice = 0.01m;
    public const decimal MaxPrice = 1000000m;
    public const int MinStockQuantity = 0;
    public const int MaxStockQuantity = 999999;

    // Business Rules
    public const int LowStockThreshold = 10;
    public const int MediumStockThreshold = 50;
}
