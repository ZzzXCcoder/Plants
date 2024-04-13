using System.ComponentModel.DataAnnotations;

namespace Plants.Models
{
    public class Plant
    {

        public Guid Id { get; set; }

        public string Plant_name { get; set; }
        public string Plant_description { get; set; }

        public string Plant_type { get; set;}

        public byte[] Image { get; set; } = null;
        public List<Account_and_plant> plant_in_table { get; set; }
    }
}
