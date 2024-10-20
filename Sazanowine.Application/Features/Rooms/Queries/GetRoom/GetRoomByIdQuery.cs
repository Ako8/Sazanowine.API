using MediatR;
using Sazanowine.Domain.Entities;

namespace Sazanowine.Application.Features.Rooms.Queries.GetRoom;

public class GetRoomByIdQuery(int RoomId) : IRequest<Room>
{
    public int RoomId { get; set; } = RoomId;
}
