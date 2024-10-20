using MediatR;
using Sazanowine.Domain.Entities;
using Sazanowine.Infrastructure.Repositories;

namespace Sazanowine.Application.Features.Rooms.Queries.GetRooms;

public class GetAllRoomsQueryHandler
    (
        IRoomRepositorie roomRepositorie
    ) : IRequestHandler<GetAllRoomsQuery, IEnumerable<Room>>
{
    public async Task<IEnumerable<Room>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
    {
        var rooms = await roomRepositorie.GetAllAsync();
        return rooms;
    }
}
