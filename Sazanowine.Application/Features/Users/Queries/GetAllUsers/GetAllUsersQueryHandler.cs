using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sazanowine.Application.Features.Users.Dto;
using Sazanowine.Domain.Entities;

namespace Sazanowine.Application.Features.Users.Queries.GetAllUsers;

public class GetAllUsersQueryHandler
    (
        UserManager<User> userManager
    ) : IRequestHandler<GetAllUsersQuery, IEnumerable<GetAllUserDto>>
{
    public async Task<IEnumerable<GetAllUserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await userManager.Users.ToListAsync(cancellationToken);
        var userDtos = users.ToGetUsersMap();

        foreach (var userDto in userDtos)
        {
            var user = users.First(u => u.Email == userDto.Email);
            userDto.Roles = await userManager.GetRolesAsync(user);
        }

        return userDtos;
    }
}
