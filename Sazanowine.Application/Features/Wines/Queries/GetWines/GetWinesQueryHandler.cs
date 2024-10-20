using MediatR;
using Sazanowine.Application.Features.Users;
using Sazanowine.Domain.Entities;
using Sazanowine.Infrastructure.Repositories;

namespace Sazanowine.Application.Features.Wines.Queries.GetWines;

public class GetWinesQueryHandler
    (
        IWineRepositorie wineRepositorie
    ) : IRequestHandler<GetWinesQuery, IEnumerable<Wine>>
{
    public async Task<IEnumerable<Wine>> Handle(GetWinesQuery request, CancellationToken cancellationToken)
    {
        var wines = await wineRepositorie.GetAllAsync();
        return wines;
    }
}
