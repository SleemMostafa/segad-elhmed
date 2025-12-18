using Application.DTOs;
using Application.Resources;
using Domain.Constants;
using FluentValidation;

namespace Application.Validators;

public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(ValidationMessages.CategoryNameRequired)
            .MaximumLength(CategoryConstants.NameMaxLength)
            .WithMessage(string.Format(ValidationMessages.CategoryNameMaxLength, CategoryConstants.NameMaxLength));

        RuleFor(x => x.Description)
            .MaximumLength(CategoryConstants.DescriptionMaxLength)
            .WithMessage(string.Format(ValidationMessages.CategoryDescriptionMaxLength, CategoryConstants.DescriptionMaxLength));
    }
}
