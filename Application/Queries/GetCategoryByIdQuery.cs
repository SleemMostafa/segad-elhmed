using MediatR;
using Application.DTOs;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries;

public record GetCategoryByIdQuery(Guid Id) : IRequest<CategoryDto?>;

public class GetCategoryByIdQueryHandler(AppDbContext context) : IRequestHandler<GetCategoryByIdQuery, CategoryDto?>
{
    public async Task<CategoryDto?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await context.Categories
            .Include(c => c.Carpets)
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
        
        if (category == null)
            return null;

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            CreatedAt = category.CreatedAt,
            UpdatedAt = category.UpdatedAt,
            CarpetsCount = category.Carpets.Count
        };
    }
}
