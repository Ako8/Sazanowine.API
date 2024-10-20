using MediatR;

namespace Sazanowine.Application.Features.Wines.Commands.DeleteWine;

public class DeleteWineCommand(int WineId) : IRequest 
{
    public int Id { get; set; } = WineId;
}
