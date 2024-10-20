using MediatR;
using Sazanowine.Application.Features.Users;
using Sazanowine.Domain.Entities;
using Sazanowine.Domain.Exceptions;
using Sazanowine.Infrastructure.Repositories;

namespace Sazanowine.Application.Features.Wines.Commands.DeleteWine;

public class DeleteWineCommandHandler
    (
        IWineRepositorie wineRepositorie,
        IUserContext userContext
    ) : IRequestHandler<DeleteWineCommand>
{
    public async Task Handle(DeleteWineCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser();

        var wine = await wineRepositorie.GetByIdAsync( request.Id )
            ?? throw new NotFoundException(nameof(Wine), request.Id.ToString() );

        await wineRepositorie.Delete(wine);
    }
}
