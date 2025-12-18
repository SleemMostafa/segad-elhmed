using MediatR;
using Application.DTOs;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands;

public record UpdateCategoryCommand(UpdateCategoryDto CategoryDto) : IRequest<CategoryDto>;

public class UpdateCategoryCommandHandler(AppDbContext context) : IRequestHandler<UpdateCategoryCommand, CategoryDto>
{
    public async Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var existing = await context.Categories
            .Include(c => c.Carpets)
            .FirstOrDefaultAsync(c => c.Id == request.CategoryDto.Id, cancellationToken);
        
        if (existing == null)
        {
            throw new KeyNotFoundException($"Category with ID {request.CategoryDto.Id} not found");
        }

        existing.Name = request.CategoryDto.Name;
        existing.Description = request.CategoryDto.Description;
        existing.UpdatedAt = DateTime.UtcNow;

        await context.SaveChangesAsync(cancellationToken);

        return new CategoryDto
        {
            Id = existing.Id,
            Name = existing.Name,
            Description = existing.Description,
            CreatedAt = existing.CreatedAt,
            UpdatedAt = existing.UpdatedAt,
            CarpetsCount = existing.Carpets.Count
        };
    }
}
