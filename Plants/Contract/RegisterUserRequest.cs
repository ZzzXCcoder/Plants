using System.ComponentModel.DataAnnotations;

namespace Plants.Contract
{
    public record RegisterUserRequest(
    
        [Required] string Name,
        [Required] string Login,
        [Required] string Password);
}
