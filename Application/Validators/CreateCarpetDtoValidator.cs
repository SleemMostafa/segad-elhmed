using Application.DTOs;
using Domain.Constants;
using FluentValidation;

namespace Application.Validators;

public class CreateCarpetDtoValidator : AbstractValidator<CreateCarpetDto>
{
    public CreateCarpetDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(CarpetConstants.NameMaxLength)
            .WithMessage($"Name cannot exceed {CarpetConstants.NameMaxLength} characters");

        RuleFor(x => x.Description)
            .MaximumLength(CarpetConstants.DescriptionMaxLength)
            .WithMessage($"Description cannot exceed {CarpetConstants.DescriptionMaxLength} characters");

        RuleFor(x => x.Length)
            .NotEmpty().WithMessage("Length is required")
            .InclusiveBetween(CarpetConstants.MinDimension, CarpetConstants.MaxDimension)
            .WithMessage($"Length must be between {CarpetConstants.MinDimension} and {CarpetConstants.MaxDimension} meters");

        RuleFor(x => x.Width)
            .NotEmpty().WithMessage("Width is required")
            .InclusiveBetween(CarpetConstants.MinDimension, CarpetConstants.MaxDimension)
            .WithMessage($"Width must be between {CarpetConstants.MinDimension} and {CarpetConstants.MaxDimension} meters");

        RuleFor(x => x.Color)
            .NotEmpty().WithMessage("Color is required")
            .MaximumLength(CarpetConstants.ColorMaxLength)
            .WithMessage($"Color cannot exceed {CarpetConstants.ColorMaxLength} characters");

        RuleFor(x => x.Material)
            .NotEmpty().WithMessage("Material is required")
            .MaximumLength(CarpetConstants.MaterialMaxLength)
            .WithMessage($"Material cannot exceed {CarpetConstants.MaterialMaxLength} characters");

        RuleFor(x => x.PricePerSquareMeter)
            .NotEmpty().WithMessage("Price per square meter is required")
            .InclusiveBetween(CarpetConstants.MinPrice, CarpetConstants.MaxPrice)
            .WithMessage($"Price must be between {CarpetConstants.MinPrice} and {CarpetConstants.MaxPrice}")
            .PrecisionScale(CarpetConstants.DecimalPrecision, CarpetConstants.DecimalScale, ignoreTrailingZeros: true)
            .WithMessage($"Price must have a maximum of {CarpetConstants.DecimalScale} decimal places");

        RuleFor(x => x.StockQuantity)
            .NotEmpty().WithMessage("Stock quantity is required")
            .InclusiveBetween(CarpetConstants.MinStockQuantity, CarpetConstants.MaxStockQuantity)
            .WithMessage($"Stock quantity must be between {CarpetConstants.MinStockQuantity} and {CarpetConstants.MaxStockQuantity}");
    }
}
