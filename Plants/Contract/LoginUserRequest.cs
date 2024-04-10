using System.ComponentModel.DataAnnotations;

namespace Plants.Contract
{
    public record LoginUserRequest(
        [Required] string Login,
        [Required] string Password);
}
