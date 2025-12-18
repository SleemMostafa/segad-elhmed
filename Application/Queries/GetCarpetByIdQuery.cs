using MediatR;
using Application.DTOs;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries;

public record GetCarpetByIdQuery(Guid Id) : IRequest<CarpetDto?>;

public class GetCarpetByIdQueryHandler(AppDbContext context) : IRequestHandler<GetCarpetByIdQuery, CarpetDto?>
{
    public async Task<CarpetDto?> Handle(GetCarpetByIdQuery request, CancellationToken cancellationToken)
    {
        var carpet = await context.Carpets
            .Include(c => c.Category)
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
        
        if (carpet == null)
            return null;

        return new CarpetDto
        {
            Id = carpet.Id,
            Name = carpet.Name,
            Description = carpet.Description,
            Length = carpet.Length,
            Width = carpet.Width,
            Color = carpet.Color,
            Material = carpet.Material,
            PricePerSquareMeter = carpet.PricePerSquareMeter,
            StockQuantity = carpet.StockQuantity,
            CategoryId = carpet.CategoryId,
            CategoryName = carpet.Category.Name,
            Area = carpet.Area,
            TotalPrice = carpet.TotalPrice,
            CreatedAt = carpet.CreatedAt,
            UpdatedAt = carpet.UpdatedAt
        };
    }
}
