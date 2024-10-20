using MediatR;
using Sazanowine.Domain.Entities;

namespace Sazanowine.Application.Features.Wines.Queries.GetWines;

public class GetWinesQuery :IRequest<IEnumerable<Wine>>
{

}
