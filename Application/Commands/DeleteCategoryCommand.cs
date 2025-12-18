using MediatR;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands;

public record DeleteCategoryCommand(Guid Id) : IRequest<bool>;

public class DeleteCategoryCommandHandler(AppDbContext context) : IRequestHandler<DeleteCategoryCommand, bool>
{
    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await context.Categories
            .Include(c => c.Carpets)
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
            
        if (category == null) return false;

        // Prevent deletion if category has carpets
        if (category.Carpets.Any())
        {
            throw new InvalidOperationException("Cannot delete category that contains carpets. Please remove or reassign all carpets first.");
        }

        context.Categories.Remove(category);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
