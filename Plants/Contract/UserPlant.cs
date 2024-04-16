using WebApplication1.Models;

namespace Plants.Contract
{
    public class UserPlant
    {
        public Plant Plant { get; set; }
        public UserRequestWrapper Account { get; set; }
    }
}

