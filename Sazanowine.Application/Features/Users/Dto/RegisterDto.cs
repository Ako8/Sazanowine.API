using System.ComponentModel.DataAnnotations;

namespace Sazanowine.Application.Features.Users.Dto;

public class RegisterDto
{
    public bool Succeeded { get; set; }
    public IEnumerable<string> Errors { get; set; }
}
