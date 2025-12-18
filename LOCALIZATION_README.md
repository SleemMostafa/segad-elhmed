# Localization System Documentation

## Overview
This project implements a comprehensive localization system supporting both **English (en)** and **Arabic (ar)** languages.

## Structure

### Resources Location
All resource files are located in: `Application/Resources/`

### Resource Files

#### 1. ValidationMessages
- **ValidationMessages.resx** - English validation messages
- **ValidationMessages.ar.resx** - Arabic validation messages
- **ValidationMessages.Designer.cs** - Strongly-typed accessor class

**Usage in Validators:**
```csharp
using Application.Resources;

RuleFor(x => x.Name)
    .NotEmpty().WithMessage(ValidationMessages.CarpetNameRequired)
    .MaximumLength(100)
    .WithMessage(string.Format(ValidationMessages.CarpetNameMaxLength, 100));
```

#### 2. SharedResources
- **SharedResources.resx** - English UI labels, messages, and text
- **SharedResources.ar.resx** - Arabic UI labels, messages, and text
- **SharedResources.Designer.cs** - Strongly-typed accessor class

**Usage in Blazor Components:**
```razor
@using Application.Resources

<h1>@SharedResources.Home</h1>
<button>@SharedResources.Save</button>
```

## Supported Languages

### English (en) - Default
- Culture Code: `en`
- Direction: LTR (Left-to-Right)
- Default language when no preference is set

### Arabic (ar)
- Culture Code: `ar`
- Direction: RTL (Right-to-Left)
- Automatically applied when user selects Arabic

## Language Switching

### LanguageSwitcher Component
Located at: `Components/Layout/LanguageSwitcher.razor`

**Features:**
- Toggle between English and Arabic
- Persists selection in browser cookie
- Automatically reloads page to apply new language
- Visual icon and language indicator

**Integration:**
The LanguageSwitcher is included in the MainLayout header for global access.

## Configuration

### Program.cs Setup
```csharp
// Configure supported cultures
var supportedCultures = new[]
{
    new CultureInfo("en"),
    new CultureInfo("ar")
};

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("en");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

// Add localization services
builder.Services.AddLocalization();
builder.Services.AddSingleton<IStringLocalizer<SharedResources>, StringLocalizer<SharedResources>>();
builder.Services.AddSingleton<IStringLocalizer<ValidationMessages>, StringLocalizer<ValidationMessages>>();
```

### Middleware
```csharp
app.UseRequestLocalization(); // Must be before UseStaticFiles
```

## Adding New Resources

### Step 1: Add to .resx files
Add the key-value pair to both:
- `ValidationMessages.resx` (English)
- `ValidationMessages.ar.resx` (Arabic)

OR

- `SharedResources.resx` (English)
- `SharedResources.ar.resx` (Arabic)

### Step 2: Update Designer.cs
Add the property to the corresponding Designer.cs file:

```csharp
public static string YourNewKey => 
    ResourceManager.GetString("YourNewKey", resourceCulture) ?? "Default Value";
```

### Step 3: Use in Code
```csharp
// In Validators
.WithMessage(ValidationMessages.YourNewKey)

// In Blazor Components
@SharedResources.YourNewKey
```

## Resource Categories

### ValidationMessages.resx
- **Carpet Validations:** CarpetNameRequired, CarpetLengthRange, etc.
- **Category Validations:** CategoryNameRequired, CategoryDescriptionMaxLength, etc.

### SharedResources.resx
- **Navigation:** Home, Categories, Carpets
- **Actions:** Add, Edit, Delete, Save, Cancel, Create, Update
- **Page Labels:** WelcomeMessage, TotalProducts, CarpetInventory
- **Form Labels:** Name, Description, Length, Width, Color, Material
- **Messages:** Success/Error messages
- **Units:** Meters, SquareMeters, Units, EGP

## Best Practices

1. **Always use resource keys** instead of hardcoded strings
2. **Provide fallback values** in Designer.cs properties
3. **Use string.Format** for messages with parameters:
   ```csharp
   string.Format(ValidationMessages.CarpetNameMaxLength, maxLength)
   ```
4. **Keep resource keys consistent** across languages
5. **Test both languages** after adding new resources
6. **Use meaningful key names** that describe the content

## Testing Localization

1. Start the application
2. Click the language switcher in the header (🌐 icon)
3. Toggle between EN and العربية
4. Verify all text changes appropriately
5. Test validation messages by submitting forms with invalid data

## RTL Support

### Arabic Layout
When Arabic is selected:
- Text direction automatically changes to RTL
- FlexBox layouts reverse
- Icons and UI elements mirror appropriately

### CSS Considerations
Use logical properties where possible:
```css
/* Instead of margin-left */
margin-inline-start: 1rem;

/* Instead of padding-right */
padding-inline-end: 0.5rem;
```

## Troubleshooting

### Resources not loading
1. Ensure .resx files have **Build Action: Embedded Resource**
2. Check Application.csproj has EmbeddedResource configuration
3. Verify namespace matches: `Application.Resources`

### Language not switching
1. Check browser cookies for `.AspNetCore.Culture`
2. Verify `app.UseRequestLocalization()` is called
3. Ensure supported cultures are configured

### Missing translations
1. Check both .resx files have the same keys
2. Verify Designer.cs is updated
3. Rebuild the Application project

## Future Enhancements

- Add more languages (e.g., French, Spanish)
- Implement user preference persistence in database
- Add date/time formatting per culture
- Localize validation error messages from FluentValidation
- Add number formatting based on culture

## Maintainability

The localization system is designed to be:
- **Centralized:** All resources in one location
- **Type-safe:** Strongly-typed accessor classes
- **Extensible:** Easy to add new languages
- **Consistent:** Same structure across all resources
- **Maintainable:** Clear separation between validation and UI resources
