using MediatR;
using Sazanowine.Domain.Entities;

namespace Sazanowine.Application.Features.Rooms.Queries.GetRooms;

public class GetAllRoomsQuery : IRequest<IEnumerable<Room>>
{

}
