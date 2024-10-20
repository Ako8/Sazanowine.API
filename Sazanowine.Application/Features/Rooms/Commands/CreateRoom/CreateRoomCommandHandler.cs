using MediatR;
using Sazanowine.Infrastructure.Repositories;
using Sazanowine.Application.Features.Rooms.Dto;
using Sazanowine.Application.Features.Users;

namespace Sazanowine.Application.Features.Rooms.Commands.CreateRoom;

public class CreateRoomCommandHandler
    (
       IRoomRepositorie roomRepositorie,
       IUserContext userContext
    ): IRequestHandler<CreateRoomCommand, int>
{
    public async Task<int> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();

        var newRoom = request.Map();
        int id = await roomRepositorie.Create(newRoom);
        return id;
    }
}
