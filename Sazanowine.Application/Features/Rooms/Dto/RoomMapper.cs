using MediatR;
using Sazanowine.Application.Features.Rooms.Commands.CreateRoom;
using Sazanowine.Application.Features.Rooms.Commands.UpdateRoom;
using Sazanowine.Domain.Entities;

namespace Sazanowine.Application.Features.Rooms.Dto;

public static class RoomMapper
{
    public static Room Map(this CreateRoomCommand command)
    {
        var room = new Room()
        {
            Name = command.Name,
            Description = command.Description,
            Price = command.Price,
            CardImage = command.CardImage,
            ModalImages = command.ModalImages,
        };

        return room;
    }

    public static Room Map(this UpdateRoomCommand command, Room room)
    {
        room.Name = command.Name;
        room.Description = command.Description;
        room.Price = command.Price; 
        room.CardImage = command.CardImage;
        room.ModalImages = command.ModalImages;

        return room;
    }

}
