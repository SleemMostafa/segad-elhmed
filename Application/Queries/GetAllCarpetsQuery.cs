using MediatR;
using Application.DTOs;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries;

public record GetAllCarpetsQuery : IRequest<IEnumerable<CarpetDto>>;

public class GetAllCarpetsQueryHandler(AppDbContext context) : IRequestHandler<GetAllCarpetsQuery, IEnumerable<CarpetDto>>
{
    public async Task<IEnumerable<CarpetDto>> Handle(GetAllCarpetsQuery request, CancellationToken cancellationToken)
    {
        var carpets = await context.Carpets.ToListAsync(cancellationToken);
        
        return carpets.Select(c => new CarpetDto
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            Length = c.Length,
            Width = c.Width,
            Color = c.Color,
            Material = c.Material,
            PricePerSquareMeter = c.PricePerSquareMeter,
            StockQuantity = c.StockQuantity,
            Area = c.Area,
            TotalPrice = c.TotalPrice,
            CreatedAt = c.CreatedAt,
            UpdatedAt = c.UpdatedAt
        });
    }
}
