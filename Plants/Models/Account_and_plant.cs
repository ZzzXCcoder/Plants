using WebApplication1.Models;

namespace Plants.Models
{
    public class Account_and_plant
    {
        public Guid Id { get; set; }
        public Guid PlantId { get; set; }
        public Guid AccountId { get; set; }
        public DateTime watering_time { get; set; }
        public double watering_rate { get; set; }
        public double wateringIntervalInHours {  get; set; }
        public Plant? Plant { get; set; }
        public Account? Account { get; set; }
    }
}
