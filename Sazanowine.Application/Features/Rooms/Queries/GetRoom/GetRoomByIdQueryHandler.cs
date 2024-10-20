using MediatR;
using Sazanowine.Domain.Entities;
using Sazanowine.Domain.Exceptions;
using Sazanowine.Infrastructure.Repositories;

namespace Sazanowine.Application.Features.Rooms.Queries.GetRoom;

public class GetRoomByIdQueryHandler
    (
        IRoomRepositorie roomRepositorie
    ) : IRequestHandler<GetRoomByIdQuery, Room>
{
    public async Task<Room> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
    {
        var room = await roomRepositorie.GetByIdAsync(request.RoomId)
            ?? throw new NotFoundException(nameof(Room), request.RoomId.ToString());

        return room;
    }
}
