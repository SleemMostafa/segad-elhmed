#nullable enable

namespace Application.Resources;

/// <summary>
/// Strongly-typed resource class for shared UI resources
/// Auto-generated from SharedResources.resx
/// </summary>
public class SharedResources
{
    private static System.Resources.ResourceManager? resourceMan;
    private static System.Globalization.CultureInfo? resourceCulture;

    public static System.Resources.ResourceManager ResourceManager
    {
        get
        {
            if (resourceMan == null)
            {
                var temp = new System.Resources.ResourceManager("Application.Resources.SharedResources", typeof(SharedResources).Assembly);
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

    // Navigation
    public static string Home => ResourceManager.GetString("Home", resourceCulture) ?? "Home";
    public static string Categories => ResourceManager.GetString("Categories", resourceCulture) ?? "Categories";
    public static string Carpets => ResourceManager.GetString("Carpets", resourceCulture) ?? "Carpets";

    // Common Actions
    public static string Add => ResourceManager.GetString("Add", resourceCulture) ?? "Add";
    public static string Edit => ResourceManager.GetString("Edit", resourceCulture) ?? "Edit";
    public static string Delete => ResourceManager.GetString("Delete", resourceCulture) ?? "Delete";
    public static string Save => ResourceManager.GetString("Save", resourceCulture) ?? "Save";
    public static string Cancel => ResourceManager.GetString("Cancel", resourceCulture) ?? "Cancel";
    public static string Create => ResourceManager.GetString("Create", resourceCulture) ?? "Create";
    public static string Update => ResourceManager.GetString("Update", resourceCulture) ?? "Update";
    public static string Details => ResourceManager.GetString("Details", resourceCulture) ?? "Details";
    public static string Back => ResourceManager.GetString("Back", resourceCulture) ?? "Back";
    public static string Search => ResourceManager.GetString("Search", resourceCulture) ?? "Search";
    public static string Loading => ResourceManager.GetString("Loading", resourceCulture) ?? "Loading...";
    public static string Saving => ResourceManager.GetString("Saving", resourceCulture) ?? "Saving...";

    // Home Page
    public static string WelcomeMessage => ResourceManager.GetString("WelcomeMessage", resourceCulture) ?? "Welcome to your carpet inventory dashboard";
    public static string TotalProducts => ResourceManager.GetString("TotalProducts", resourceCulture) ?? "Total Products";
    public static string TotalUnits => ResourceManager.GetString("TotalUnits", resourceCulture) ?? "Total Units";
    public static string TotalValue => ResourceManager.GetString("TotalValue", resourceCulture) ?? "Total Value";
    public static string NoCarpets => ResourceManager.GetString("NoCarpets", resourceCulture) ?? "No Carpets Yet";
    public static string AddFirstCarpet => ResourceManager.GetString("AddFirstCarpet", resourceCulture) ?? "Get started by adding your first carpet to the inventory";
    public static string AddYourFirstCarpet => ResourceManager.GetString("AddYourFirstCarpet", resourceCulture) ?? "Add Your First Carpet";

    // Carpet Page
    public static string CarpetInventory => ResourceManager.GetString("CarpetInventory", resourceCulture) ?? "Carpet Inventory";
    public static string ManageCarpetStock => ResourceManager.GetString("ManageCarpetStock", resourceCulture) ?? "Manage your carpet stock and inventory";
    public static string AddNewCarpet => ResourceManager.GetString("AddNewCarpet", resourceCulture) ?? "Add New Carpet";
    public static string LoadingCarpets => ResourceManager.GetString("LoadingCarpets", resourceCulture) ?? "Loading carpets...";

    // Category Page
    public static string CategoriesManagement => ResourceManager.GetString("CategoriesManagement", resourceCulture) ?? "Categories Management";
    public static string OrganizeCategories => ResourceManager.GetString("OrganizeCategories", resourceCulture) ?? "Organize your carpet categories";
    public static string AddNewCategory => ResourceManager.GetString("AddNewCategory", resourceCulture) ?? "Add New Category";
    public static string NoCategories => ResourceManager.GetString("NoCategories", resourceCulture) ?? "No Categories Yet";
    public static string AddFirstCategory => ResourceManager.GetString("AddFirstCategory", resourceCulture) ?? "Start organizing by creating your first category";
    public static string Items => ResourceManager.GetString("Items", resourceCulture) ?? "items";
    public static string Created => ResourceManager.GetString("Created", resourceCulture) ?? "Created";
    public static string CannotDeleteCategory => ResourceManager.GetString("CannotDeleteCategory", resourceCulture) ?? "This category contains carpets and cannot be deleted";

    // Form Labels
    public static string Name => ResourceManager.GetString("Name", resourceCulture) ?? "Name";
    public static string Description => ResourceManager.GetString("Description", resourceCulture) ?? "Description";
    public static string Length => ResourceManager.GetString("Length", resourceCulture) ?? "Length";
    public static string Width => ResourceManager.GetString("Width", resourceCulture) ?? "Width";
    public static string Color => ResourceManager.GetString("Color", resourceCulture) ?? "Color";
    public static string Material => ResourceManager.GetString("Material", resourceCulture) ?? "Material";
    public static string PricePerSquareMeter => ResourceManager.GetString("PricePerSquareMeter", resourceCulture) ?? "Price per Square Meter";
    public static string StockQuantity => ResourceManager.GetString("StockQuantity", resourceCulture) ?? "Stock Quantity";
    public static string Category => ResourceManager.GetString("Category", resourceCulture) ?? "Category";
    public static string SelectCategory => ResourceManager.GetString("SelectCategory", resourceCulture) ?? "Select a category";

    // Form Pages
    public static string CreateNewCarpet => ResourceManager.GetString("CreateNewCarpet", resourceCulture) ?? "Create New Carpet";
    public static string CreateNewCategory => ResourceManager.GetString("CreateNewCategory", resourceCulture) ?? "Create New Category";
    public static string EditCarpet => ResourceManager.GetString("EditCarpet", resourceCulture) ?? "Edit Carpet";
    public static string EditCategory => ResourceManager.GetString("EditCategory", resourceCulture) ?? "Edit Category";
    public static string BasicInformation => ResourceManager.GetString("BasicInformation", resourceCulture) ?? "Basic Information";
    public static string Dimensions => ResourceManager.GetString("Dimensions", resourceCulture) ?? "Dimensions";
    public static string PricingStock => ResourceManager.GetString("PricingStock", resourceCulture) ?? "Pricing & Stock";
    public static string CategoryInfo => ResourceManager.GetString("CategoryInfo", resourceCulture) ?? "Category Information";

    // Messages
    public static string CarpetCreatedSuccess => ResourceManager.GetString("CarpetCreatedSuccess", resourceCulture) ?? "Carpet created successfully";
    public static string CarpetUpdatedSuccess => ResourceManager.GetString("CarpetUpdatedSuccess", resourceCulture) ?? "Carpet updated successfully";
    public static string CarpetDeletedSuccess => ResourceManager.GetString("CarpetDeletedSuccess", resourceCulture) ?? "Carpet deleted successfully";
    public static string CategoryCreatedSuccess => ResourceManager.GetString("CategoryCreatedSuccess", resourceCulture) ?? "Category created successfully";
    public static string CategoryUpdatedSuccess => ResourceManager.GetString("CategoryUpdatedSuccess", resourceCulture) ?? "Category updated successfully";
    public static string CategoryDeletedSuccess => ResourceManager.GetString("CategoryDeletedSuccess", resourceCulture) ?? "Category deleted successfully";
    public static string ConfirmDelete => ResourceManager.GetString("ConfirmDelete", resourceCulture) ?? "Are you sure you want to delete this item?";
    public static string ErrorOccurred => ResourceManager.GetString("ErrorOccurred", resourceCulture) ?? "An error occurred. Please try again.";

    // Units
    public static string Meters => ResourceManager.GetString("Meters", resourceCulture) ?? "meters";
    public static string SquareMeters => ResourceManager.GetString("SquareMeters", resourceCulture) ?? "m²";
    public static string Units => ResourceManager.GetString("Units", resourceCulture) ?? "units";
    public static string EGP => ResourceManager.GetString("EGP", resourceCulture) ?? "EGP";
    public static string TotalPrice => ResourceManager.GetString("TotalPrice", resourceCulture) ?? "Total Price";
    public static string Area => ResourceManager.GetString("Area", resourceCulture) ?? "Area";
}
