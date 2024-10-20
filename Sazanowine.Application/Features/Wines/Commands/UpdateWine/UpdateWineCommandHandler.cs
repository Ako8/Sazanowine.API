using MediatR;
using Sazanowine.Application.Features.Users;
using Sazanowine.Application.Features.Wines.Dto;
using Sazanowine.Domain.Entities;
using Sazanowine.Domain.Exceptions;
using Sazanowine.Infrastructure.Repositories;

namespace Sazanowine.Application.Features.Wines.Commands.UpdateWine;

public class UpdateWineCommandHandler
    (
        IWineRepositorie wineRepositorie ,
        IUserContext userContext
    ): IRequestHandler<UpdateWineCommand>
{
    public async Task Handle(UpdateWineCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser();

        var wine = await wineRepositorie.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Wine), request.Id.ToString());

        request.Map(wine);
        await wineRepositorie.SaveChanges();
    }
}
