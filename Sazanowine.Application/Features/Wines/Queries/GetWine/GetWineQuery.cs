using MediatR;
using Sazanowine.Domain.Entities;

namespace Sazanowine.Application.Features.Wines.Queries.GetWine;

public class GetWineQuery(int WineId) : IRequest<Wine>
{
    public int Id { get; set; } = WineId;
}
