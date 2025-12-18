using MediatR;
using Infrastructure.Data;

namespace Application.Commands;

public record DeleteCarpetCommand(Guid Id) : IRequest<bool>;

public class DeleteCarpetCommandHandler(AppDbContext context) : IRequestHandler<DeleteCarpetCommand, bool>
{
    public async Task<bool> Handle(DeleteCarpetCommand request, CancellationToken cancellationToken)
    {
        var carpet = await context.Carpets.FindAsync(new object[] { request.Id }, cancellationToken);
        if (carpet == null) return false;

        context.Carpets.Remove(carpet);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
