using MediatR;
using Sazanowine.Application.Features.Users;
using Sazanowine.Domain.Entities;
using Sazanowine.Domain.Exceptions;
using Sazanowine.Infrastructure.Repositories;

namespace Sazanowine.Application.Features.Rooms.Commands.DeleteRoom;

public class DeleteRoomCommandHandler
    (
       IRoomRepositorie roomRepositorie,
       IUserContext userContext
    ): IRequestHandler<DeleteRoomCommand>
{
    public async Task Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();

        var room = await roomRepositorie.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Room), request.Id.ToString());

        await roomRepositorie.Delete(room);
    }
}
