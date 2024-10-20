using MediatR;
using Sazanowine.Domain.Entities;

namespace Sazanowine.Application.Features.Rooms.Commands.CreateRoom;

public class CreateRoomCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;
    public Languages Description { get; set; }
    public string CardImage { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public List<string> ModalImages { get; set; } = [];
}
