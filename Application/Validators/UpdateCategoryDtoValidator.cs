using Application.DTOs;
using Application.Resources;
using Domain.Constants;
using FluentValidation;

namespace Application.Validators;

public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ValidationMessages.CategoryNameRequired);

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(ValidationMessages.CategoryNameRequired)
            .MaximumLength(CategoryConstants.NameMaxLength)
            .WithMessage(string.Format(ValidationMessages.CategoryNameMaxLength, CategoryConstants.NameMaxLength));

        RuleFor(x => x.Description)
            .MaximumLength(CategoryConstants.DescriptionMaxLength)
            .WithMessage(string.Format(ValidationMessages.CategoryDescriptionMaxLength, CategoryConstants.DescriptionMaxLength));
    }
}
