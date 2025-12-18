# Localization Implementation Examples

## Example 1: Using Localization in Home.razor

### Before (Hardcoded English):
```razor
<div class="page-header mb-4">
    <div class="d-flex justify-content-between align-items-center">
        <div>
            <h1 class="mb-2">
                <i class="bi bi-house-door-fill text-primary"></i>
                Home
            </h1>
            <p class="text-muted">Welcome to your carpet inventory dashboard</p>
        </div>
        <a href="/carpets/create" class="btn btn-primary btn-lg">
            <i class="bi bi-plus-circle me-2"></i>Add New Carpet
        </a>
    </div>
</div>
```

### After (Localized):
```razor
@using Application.Resources

<div class="page-header mb-4">
    <div class="d-flex justify-content-between align-items-center">
        <div>
            <h1 class="mb-2">
                <i class="bi bi-house-door-fill text-primary"></i>
                @SharedResources.Home
            </h1>
            <p class="text-muted">@SharedResources.WelcomeMessage</p>
        </div>
        <a href="/carpets/create" class="btn btn-primary btn-lg">
            <i class="bi bi-plus-circle me-2"></i>@SharedResources.AddNewCarpet
        </a>
    </div>
</div>
```

## Example 2: Using Localization in NavMenu.razor

### Before:
```razor
<div class="nav-item px-3">
    <NavLink class="nav-link" href="" Match="NavLinkMatch.All">
        <i class="bi bi-house-door-fill"></i>
        <span class="nav-text">Home</span>
    </NavLink>
</div>

<div class="nav-item px-3">
    <NavLink class="nav-link" href="categories">
        <i class="bi bi-folder-fill"></i>
        <span class="nav-text">Categories</span>
    </NavLink>
</div>

<div class="nav-item px-3">
    <NavLink class="nav-link" href="carpets">
        <i class="bi bi-grid-3x3-gap-fill"></i>
        <span class="nav-text">Carpets</span>
    </NavLink>
</div>
```

### After:
```razor
@using Application.Resources

<div class="nav-item px-3">
    <NavLink class="nav-link" href="" Match="NavLinkMatch.All">
        <i class="bi bi-house-door-fill"></i>
        <span class="nav-text">@SharedResources.Home</span>
    </NavLink>
</div>

<div class="nav-item px-3">
    <NavLink class="nav-link" href="categories">
        <i class="bi bi-folder-fill"></i>
        <span class="nav-text">@SharedResources.Categories</span>
    </NavLink>
</div>

<div class="nav-item px-3">
    <NavLink class="nav-link" href="carpets">
        <i class="bi bi-grid-3x3-gap-fill"></i>
        <span class="nav-text">@SharedResources.Carpets</span>
    </NavLink>
</div>
```

## Example 3: Using Localization in Forms (CreateCategory.razor)

### Before:
```razor
<div class="form-section">
    <h6><i class="bi bi-info-circle"></i> Category Information</h6>
    <div class="mb-3">
        <label class="form-label">Name</label>
        <InputText @bind-Value="createDto.Name" class="form-control form-control-lg" placeholder="Enter category name"/>
    </div>
    <div class="mb-3">
        <label class="form-label">Description</label>
        <InputTextArea @bind-Value="createDto.Description" class="form-control form-control-lg" placeholder="Enter description (optional)" rows="4"/>
    </div>
</div>

<div class="form-actions">
    <button type="submit" class="btn btn-primary btn-lg" disabled="@isSubmitting">
        @if (isSubmitting)
        {
            <span class="spinner-border spinner-border-sm me-2"></span>
            <span>Saving...</span>
        }
        else
        {
            <i class="bi bi-check-circle me-2"></i>
            <span>Create Category</span>
        }
    </button>
    <a href="/categories" class="btn btn-outline-secondary btn-lg">Cancel</a>
</div>
```

### After:
```razor
@using Application.Resources

<div class="form-section">
    <h6><i class="bi bi-info-circle"></i> @SharedResources.CategoryInfo</h6>
    <div class="mb-3">
        <label class="form-label">@SharedResources.Name</label>
        <InputText @bind-Value="createDto.Name" class="form-control form-control-lg" placeholder="@SharedResources.Name"/>
    </div>
    <div class="mb-3">
        <label class="form-label">@SharedResources.Description</label>
        <InputTextArea @bind-Value="createDto.Description" class="form-control form-control-lg" placeholder="@SharedResources.Description" rows="4"/>
    </div>
</div>

<div class="form-actions">
    <button type="submit" class="btn btn-primary btn-lg" disabled="@isSubmitting">
        @if (isSubmitting)
        {
            <span class="spinner-border spinner-border-sm me-2"></span>
            <span>@SharedResources.Saving</span>
        }
        else
        {
            <i class="bi bi-check-circle me-2"></i>
            <span>@SharedResources.Create @SharedResources.Category</span>
        }
    </button>
    <a href="/categories" class="btn btn-outline-secondary btn-lg">@SharedResources.Cancel</a>
</div>
```

## Example 4: Using Localization in Validators

### Before:
```csharp
public class CreateCarpetDtoValidator : AbstractValidator<CreateCarpetDto>
{
    public CreateCarpetDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(200)
            .WithMessage("Name cannot exceed 200 characters");

        RuleFor(x => x.Length)
            .NotEmpty().WithMessage("Length is required")
            .InclusiveBetween(0.1m, 100m)
            .WithMessage("Length must be between 0.1 and 100 meters");
    }
}
```

### After:
```csharp
using Application.Resources;

public class CreateCarpetDtoValidator : AbstractValidator<CreateCarpetDto>
{
    public CreateCarpetDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(ValidationMessages.CarpetNameRequired)
            .MaximumLength(200)
            .WithMessage(string.Format(ValidationMessages.CarpetNameMaxLength, 200));

        RuleFor(x => x.Length)
            .NotEmpty().WithMessage(ValidationMessages.CarpetLengthRequired)
            .InclusiveBetween(0.1m, 100m)
            .WithMessage(string.Format(ValidationMessages.CarpetLengthRange, 0.1, 100));
    }
}
```

## Example 5: Displaying Localized Messages in Code-Behind

```csharp
@using Application.Resources
@inject IJSRuntime JSRuntime

@code {
    private async Task SaveCarpet()
    {
        try
        {
            await Mediator.Send(new CreateCarpetCommand(createDto));
            
            // Show success message in current language
            await JSRuntime.InvokeVoidAsync("alert", SharedResources.CarpetCreatedSuccess);
            
            Navigation.NavigateTo("/carpets");
        }
        catch (Exception)
        {
            // Show error message in current language
            await JSRuntime.InvokeVoidAsync("alert", SharedResources.ErrorOccurred);
        }
    }
}
```

## Example 6: Conditional Text Based on Culture

```csharp
@using System.Globalization
@using Application.Resources

@code {
    private bool IsArabic => CultureInfo.CurrentUICulture.Name == "ar";
    
    private string GetDirectionClass() => IsArabic ? "rtl" : "ltr";
    
    private string GetAlignmentClass() => IsArabic ? "text-end" : "text-start";
}

<div class="@GetDirectionClass()">
    <h1 class="@GetAlignmentClass()">@SharedResources.Home</h1>
</div>
```

## Quick Reference: Available Resource Keys

### Navigation
- `SharedResources.Home`
- `SharedResources.Categories`
- `SharedResources.Carpets`

### Actions
- `SharedResources.Add`
- `SharedResources.Edit`
- `SharedResources.Delete`
- `SharedResources.Save`
- `SharedResources.Cancel`
- `SharedResources.Create`
- `SharedResources.Update`

### Form Labels
- `SharedResources.Name`
- `SharedResources.Description`
- `SharedResources.Length`
- `SharedResources.Width`
- `SharedResources.Color`
- `SharedResources.Material`
- `SharedResources.PricePerSquareMeter`
- `SharedResources.StockQuantity`
- `SharedResources.Category`

### Messages
- `SharedResources.CarpetCreatedSuccess`
- `SharedResources.CategoryCreatedSuccess`
- `SharedResources.ErrorOccurred`
- `SharedResources.Loading`
- `SharedResources.Saving`

### Validation Messages
- `ValidationMessages.CarpetNameRequired`
- `ValidationMessages.CarpetLengthRange`
- `ValidationMessages.CategoryNameRequired`
- etc.

## Testing Your Localized Pages

1. Start your application
2. Navigate to the page you localized
3. Click the language switcher (🌐) in the header
4. Switch to Arabic (العربية)
5. Verify:
   - All text displays in Arabic
   - Layout adjusts for RTL if needed
   - Forms still work correctly
   - Validation messages appear in Arabic
6. Switch back to English (EN)
7. Verify everything still works in English
