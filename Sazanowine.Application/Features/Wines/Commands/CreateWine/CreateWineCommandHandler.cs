using MediatR;
using Sazanowine.Infrastructure.Repositories;
using Sazanowine.Application.Features.Wines.Dto;
using Sazanowine.Application.Features.Users;

namespace Sazanowine.Application.Features.Wines.Commands.CreateWine;

public class CreateWineCommandHandler
    (
        IWineRepositorie wineRepositorie,
        IUserContext userContext
    ) : IRequestHandler<CreateWineCommand, int>
{
    public async Task<int> Handle(CreateWineCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser();

        var newWine = request.Map();
        int id = await wineRepositorie.Create(newWine);
        return id;
    }
}
