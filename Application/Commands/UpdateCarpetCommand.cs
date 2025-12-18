using MediatR;
using Application.DTOs;
using Infrastructure.Data;
using FluentValidation;

namespace Application.Commands;

public record UpdateCarpetCommand(UpdateCarpetDto CarpetDto) : IRequest<CarpetDto>;

public class UpdateCarpetCommandHandler(AppDbContext context) : IRequestHandler<UpdateCarpetCommand, CarpetDto>
{
    public async Task<CarpetDto> Handle(UpdateCarpetCommand request, CancellationToken cancellationToken)
    {
        var existing = await context.Carpets.FindAsync(new object[] { request.CarpetDto.Id }, cancellationToken);
        
        if (existing == null)
        {
            throw new KeyNotFoundException($"Carpet with ID {request.CarpetDto.Id} not found");
        }

        existing.Name = request.CarpetDto.Name;
        existing.Description = request.CarpetDto.Description;
        existing.Length = request.CarpetDto.Length;
        existing.Width = request.CarpetDto.Width;
        existing.Color = request.CarpetDto.Color;
        existing.Material = request.CarpetDto.Material;
        existing.PricePerSquareMeter = request.CarpetDto.PricePerSquareMeter;
        existing.StockQuantity = request.CarpetDto.StockQuantity;
        existing.CategoryId = request.CarpetDto.CategoryId;
        existing.UpdatedAt = DateTime.UtcNow;

        await context.SaveChangesAsync(cancellationToken);
        
        // Load category for response
        await context.Entry(existing).Reference(c => c.Category).LoadAsync(cancellationToken);
        var updated = existing;

        return new CarpetDto
        {
            Id = updated.Id,
            Name = updated.Name,
            Description = updated.Description,
            Length = updated.Length,
            Width = updated.Width,
            Color = updated.Color,
            Material = updated.Material,
            PricePerSquareMeter = updated.PricePerSquareMeter,
            StockQuantity = updated.StockQuantity,
            CategoryId = updated.CategoryId,
            CategoryName = updated.Category.Name,
            Area = updated.Area,
            TotalPrice = updated.TotalPrice,
            CreatedAt = updated.CreatedAt,
            UpdatedAt = updated.UpdatedAt
        };
    }
}

public class UpdateCarpetCommandValidator : AbstractValidator<UpdateCarpetCommand>
{
    public UpdateCarpetCommandValidator()
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
