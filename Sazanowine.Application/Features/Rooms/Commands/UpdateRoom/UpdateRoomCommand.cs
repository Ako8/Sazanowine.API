using MediatR;
using Sazanowine.Domain.Entities;

namespace Sazanowine.Application.Features.Rooms.Commands.UpdateRoom;

public class UpdateRoomCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Languages Description { get; set; }
    public decimal Price { get; set; }
    public string CardImage { get; set; } = string.Empty;
    public List<string> ModalImages { get; set; } = [];
}
