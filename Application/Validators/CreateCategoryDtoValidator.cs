using Application.DTOs;
using Domain.Constants;
using FluentValidation;

namespace Application.Validators;

public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Category name is required")
            .MaximumLength(CategoryConstants.NameMaxLength)
            .WithMessage($"Category name cannot exceed {CategoryConstants.NameMaxLength} characters");

        RuleFor(x => x.Description)
            .MaximumLength(CategoryConstants.DescriptionMaxLength)
            .WithMessage($"Description cannot exceed {CategoryConstants.DescriptionMaxLength} characters");
    }
}
