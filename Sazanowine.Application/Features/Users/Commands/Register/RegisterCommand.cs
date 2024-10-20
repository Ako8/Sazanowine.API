using MediatR;
using Sazanowine.Application.Features.Users.Dto;
using System.ComponentModel.DataAnnotations;

namespace Sazanowine.Application.Features.Users.Commands.Register;

public class RegisterCommand : IRequest<RegisterDto>
{
    [Required(ErrorMessage = "First name is required.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    public string SurName { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Phone number is required.")]
    public string PhoneNumber { get; set; }
    
    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; }
}

