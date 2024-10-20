using MediatR;

namespace Sazanowine.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommand() : IRequest
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}
