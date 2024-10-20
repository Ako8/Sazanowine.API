using MediatR;

namespace Sazanowine.Application.Features.Rooms.Commands.DeleteRoom;

public class DeleteRoomCommand(int RoomId) : IRequest
{
    public int Id { get; set; } = RoomId;
}
