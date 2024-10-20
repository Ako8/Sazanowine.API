
using Microsoft.AspNetCore.Identity;

namespace Sazanowine.Domain.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Order> Orders { get; set; } = [];
    public DateTime? MailTokenExpireTime { get; set; }
}   