using MediatR;
using Sazanowine.Domain.Entities;
using Sazanowine.Domain.Exceptions;
using Sazanowine.Infrastructure.Repositories;

namespace Sazanowine.Application.Features.Wines.Queries.GetWine;

public class GetWineQueryHandler
    (
        IWineRepositorie wineRepositorie
    ) : IRequestHandler<GetWineQuery, Wine>
{
    public async Task<Wine> Handle(GetWineQuery request, CancellationToken cancellationToken)
    {
        var wine = await wineRepositorie.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Wine), request.Id.ToString());

        return wine;
    }
}
