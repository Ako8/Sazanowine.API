using MediatR;
using Sazanowine.Application.Features.Users.Dto;

namespace Sazanowine.Application.Features.Users.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<IEnumerable<GetAllUserDto>>
{
}
