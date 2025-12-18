using MediatR;
using Application.DTOs;
using Domain.Entities;
using Infrastructure.Data;
using FluentValidation;

namespace Application.Commands;

public record CreateCarpetCommand(CreateCarpetDto CarpetDto) : IRequest<CarpetDto>;

public class CreateCarpetCommandHandler(AppDbContext context) : IRequestHandler<CreateCarpetCommand, CarpetDto>
{
    public async Task<CarpetDto> Handle(CreateCarpetCommand request, CancellationToken cancellationToken)
    {
        var carpet = new Carpet
        {
            Id = Guid.NewGuid(),
            Name = request.CarpetDto.Name,
            Description = request.CarpetDto.Description,
            Length = request.CarpetDto.Length,
            Width = request.CarpetDto.Width,
            Color = request.CarpetDto.Color,
            Material = request.CarpetDto.Material,
            PricePerSquareMeter = request.CarpetDto.PricePerSquareMeter,
            StockQuantity = request.CarpetDto.StockQuantity,
            CategoryId = request.CarpetDto.CategoryId,
            CreatedAt = DateTime.UtcNow
        };

        context.Carpets.Add(carpet);
        await context.SaveChangesAsync(cancellationToken);
        
        // Load category for response
        await context.Entry(carpet).Reference(c => c.Category).LoadAsync(cancellationToken);
        var created = carpet;

        return new CarpetDto
        {
            Id = created.Id,
            Name = created.Name,
            Description = created.Description,
            Length = created.Length,
            Width = created.Width,
            Color = created.Color,
            Material = created.Material,
            PricePerSquareMeter = created.PricePerSquareMeter,
            StockQuantity = created.StockQuantity,
            CategoryId = created.CategoryId,
            CategoryName = created.Category.Name,
            Area = created.Area,
            TotalPrice = created.TotalPrice,
            CreatedAt = created.CreatedAt,
            UpdatedAt = created.UpdatedAt
        };
    }
}

public class CreateCarpetCommandValidator : AbstractValidator<CreateCarpetCommand>
{
    public CreateCarpetCommandValidator()
    {
        RuleFor(x => x.CarpetDto.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters.");

        RuleFor(x => x.CarpetDto.Length)
            .GreaterThan(0).WithMessage("Length must be greater than 0.");

        RuleFor(x => x.CarpetDto.Width)
            .GreaterThan(0).WithMessage("Width must be greater than 0.");

        RuleFor(x => x.CarpetDto.Color)
            .NotEmpty().WithMessage("Color is required.");

        RuleFor(x => x.CarpetDto.Material)
            .NotEmpty().WithMessage("Material is required.");

        RuleFor(x => x.CarpetDto.PricePerSquareMeter)
            .GreaterThan(0).WithMessage("Price must be greater than 0.");

        RuleFor(x => x.CarpetDto.StockQuantity)
            .GreaterThanOrEqualTo(0).WithMessage("Stock quantity cannot be negative.");
    }
}
