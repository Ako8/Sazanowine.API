using MediatR;
using Sazanowine.Application.Features.Users.Commands.Register;
using Sazanowine.Domain.Entities;

namespace Sazanowine.Application.Features.Users.Dto;

public static class UserMapper
{
    public static User RegisterMap(this RegisterCommand request)
    {
        var user = new User
        {
            UserName = request.Email,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            FirstName = request.Name,
            LastName = request.SurName,
            MailTokenExpireTime = DateTime.UtcNow
        };
        return user;
    }

    public static List<GetAllUserDto> ToGetUsersMap(this List<User> users)
    {
        return users.Select(u => new GetAllUserDto
        {
            Name = u.FirstName,
            SurName = u.LastName,
            PhoneNumber = u.PhoneNumber,
            Email = u.Email,
            Roles = new List<string>() 
        }).ToList();
    }

    public static UserDto ToDto(this User user)
    {
        return new UserDto
        {
            Name = user.FirstName,
            SurName = user.LastName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
        };
    }
}
