using Microsoft.AspNetCore.Identity;

namespace Sazanowine.Application.Features.Users.Dto;

public class GetAllUserDto
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public IList<string> Roles { get; set; }
}
