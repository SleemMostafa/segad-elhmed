using Application.DTOs;
using Application.Resources;
using Domain.Constants;
using FluentValidation;

namespace Application.Validators;

public class UpdateCarpetDtoValidator : AbstractValidator<UpdateCarpetDto>
{
    public UpdateCarpetDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ValidationMessages.CarpetCategoryRequired);

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(ValidationMessages.CarpetNameRequired)
            .MaximumLength(CarpetConstants.NameMaxLength)
            .WithMessage(string.Format(ValidationMessages.CarpetNameMaxLength, CarpetConstants.NameMaxLength));

        RuleFor(x => x.Description)
            .MaximumLength(CarpetConstants.DescriptionMaxLength)
            .WithMessage(string.Format(ValidationMessages.CarpetDescriptionMaxLength, CarpetConstants.DescriptionMaxLength));

        RuleFor(x => x.Length)
            .NotEmpty().WithMessage(ValidationMessages.CarpetLengthRequired)
            .InclusiveBetween(CarpetConstants.MinDimension, CarpetConstants.MaxDimension)
            .WithMessage(string.Format(ValidationMessages.CarpetLengthRange, CarpetConstants.MinDimension, CarpetConstants.MaxDimension));

        RuleFor(x => x.Width)
            .NotEmpty().WithMessage(ValidationMessages.CarpetWidthRequired)
            .InclusiveBetween(CarpetConstants.MinDimension, CarpetConstants.MaxDimension)
            .WithMessage(string.Format(ValidationMessages.CarpetWidthRange, CarpetConstants.MinDimension, CarpetConstants.MaxDimension));

        RuleFor(x => x.Color)
            .NotEmpty().WithMessage(ValidationMessages.CarpetColorRequired)
            .MaximumLength(CarpetConstants.ColorMaxLength)
            .WithMessage(string.Format(ValidationMessages.CarpetColorMaxLength, CarpetConstants.ColorMaxLength));

        RuleFor(x => x.Material)
            .NotEmpty().WithMessage(ValidationMessages.CarpetMaterialRequired)
            .MaximumLength(CarpetConstants.MaterialMaxLength)
            .WithMessage(string.Format(ValidationMessages.CarpetMaterialMaxLength, CarpetConstants.MaterialMaxLength));

        RuleFor(x => x.PricePerSquareMeter)
            .NotEmpty().WithMessage(ValidationMessages.CarpetPriceRequired)
            .InclusiveBetween(CarpetConstants.MinPrice, CarpetConstants.MaxPrice)
            .WithMessage(string.Format(ValidationMessages.CarpetPriceRange, CarpetConstants.MinPrice, CarpetConstants.MaxPrice))
            .PrecisionScale(CarpetConstants.DecimalPrecision, CarpetConstants.DecimalScale, ignoreTrailingZeros: true)
            .WithMessage(string.Format(ValidationMessages.CarpetPriceRange, CarpetConstants.MinPrice, CarpetConstants.MaxPrice));

        RuleFor(x => x.StockQuantity)
            .NotEmpty().WithMessage("Stock quantity is required")
            .InclusiveBetween(CarpetConstants.MinStockQuantity, CarpetConstants.MaxStockQuantity)
            .WithMessage($"Stock quantity must be between {CarpetConstants.MinStockQuantity} and {CarpetConstants.MaxStockQuantity}");
    }
}
