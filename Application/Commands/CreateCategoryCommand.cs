using MediatR;
using Application.DTOs;
using Domain.Entities;
using Infrastructure.Data;

namespace Application.Commands;

public record CreateCategoryCommand(CreateCategoryDto CategoryDto) : IRequest<CategoryDto>;

public class CreateCategoryCommandHandler(AppDbContext context) : IRequestHandler<CreateCategoryCommand, CategoryDto>
{
    public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = request.CategoryDto.Name,
            Description = request.CategoryDto.Description,
            CreatedAt = DateTime.UtcNow
        };

        context.Categories.Add(category);
        await context.SaveChangesAsync(cancellationToken);

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            CreatedAt = category.CreatedAt,
            UpdatedAt = category.UpdatedAt,
            CarpetsCount = 0
        };
    }
}
