using MediatR;
using Sazanowine.Domain.Entities;
using Sazanowine.Domain.Exceptions;
using Sazanowine.Infrastructure.Repositories;
using Sazanowine.Application.Features.Rooms.Dto;
using Sazanowine.Application.Features.Users;

namespace Sazanowine.Application.Features.Rooms.Commands.UpdateRoom;

public class UpdateRoomCommandHandler
    (
        IRoomRepositorie roomRepositorie,
        IUserContext userContext
    ) : IRequestHandler<UpdateRoomCommand>
{
    public async Task Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();

        var room = await roomRepositorie.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Room), request.Id.ToString());

        var updatedRoom = request.Map(room);
        await roomRepositorie.SaveChanges();
    }
}
