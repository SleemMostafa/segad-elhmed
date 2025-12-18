#nullable enable

namespace Application.Resources;

/// <summary>
/// Strongly-typed resource class for validation messages
/// Auto-generated from ValidationMessages.resx
/// </summary>
public class ValidationMessages
{
    private static System.Resources.ResourceManager? resourceMan;
    private static System.Globalization.CultureInfo? resourceCulture;

    public static System.Resources.ResourceManager ResourceManager
    {
        get
        {
            if (resourceMan == null)
            {
                var temp = new System.Resources.ResourceManager("Application.Resources.ValidationMessages", typeof(ValidationMessages).Assembly);
                resourceMan = temp;
            }
            return resourceMan;
        }
    }

    public static System.Globalization.CultureInfo? Culture
    {
        get => resourceCulture;
        set => resourceCulture = value;
    }

    // Carpet Validations
    public static string CarpetNameRequired => ResourceManager.GetString("CarpetNameRequired", resourceCulture) ?? "Name is required";
    public static string CarpetNameMaxLength => ResourceManager.GetString("CarpetNameMaxLength", resourceCulture) ?? "Name cannot exceed {0} characters";
    public static string CarpetDescriptionMaxLength => ResourceManager.GetString("CarpetDescriptionMaxLength", resourceCulture) ?? "Description cannot exceed {0} characters";
    public static string CarpetLengthRequired => ResourceManager.GetString("CarpetLengthRequired", resourceCulture) ?? "Length is required";
    public static string CarpetLengthRange => ResourceManager.GetString("CarpetLengthRange", resourceCulture) ?? "Length must be between {0} and {1} meters";
    public static string CarpetWidthRequired => ResourceManager.GetString("CarpetWidthRequired", resourceCulture) ?? "Width is required";
    public static string CarpetWidthRange => ResourceManager.GetString("CarpetWidthRange", resourceCulture) ?? "Width must be between {0} and {1} meters";
    public static string CarpetColorRequired => ResourceManager.GetString("CarpetColorRequired", resourceCulture) ?? "Color is required";
    public static string CarpetColorMaxLength => ResourceManager.GetString("CarpetColorMaxLength", resourceCulture) ?? "Color cannot exceed {0} characters";
    public static string CarpetMaterialRequired => ResourceManager.GetString("CarpetMaterialRequired", resourceCulture) ?? "Material is required";
    public static string CarpetMaterialMaxLength => ResourceManager.GetString("CarpetMaterialMaxLength", resourceCulture) ?? "Material cannot exceed {0} characters";
    public static string CarpetPriceRequired => ResourceManager.GetString("CarpetPriceRequired", resourceCulture) ?? "Price per square meter is required";
    public static string CarpetPriceRange => ResourceManager.GetString("CarpetPriceRange", resourceCulture) ?? "Price per square meter must be between {0} and {1}";
    public static string CarpetStockRequired => ResourceManager.GetString("CarpetStockRequired", resourceCulture) ?? "Stock quantity is required";
    public static string CarpetStockRange => ResourceManager.GetString("CarpetStockRange", resourceCulture) ?? "Stock quantity must be between {0} and {1}";
    public static string CarpetCategoryRequired => ResourceManager.GetString("CarpetCategoryRequired", resourceCulture) ?? "Category is required";

    // Category Validations
    public static string CategoryNameRequired => ResourceManager.GetString("CategoryNameRequired", resourceCulture) ?? "Category name is required";
    public static string CategoryNameMaxLength => ResourceManager.GetString("CategoryNameMaxLength", resourceCulture) ?? "Category name cannot exceed {0} characters";
    public static string CategoryDescriptionMaxLength => ResourceManager.GetString("CategoryDescriptionMaxLength", resourceCulture) ?? "Description cannot exceed {0} characters";
}
