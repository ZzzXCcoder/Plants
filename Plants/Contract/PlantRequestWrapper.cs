namespace Plants.Contract
{
    public class PlantRequestWrapper
    {
        public Guid Id { get; set; }
        public string Plant_name { get; set; }
        public string Plant_description { get; set; }
        public string Plant_type { get; set; }
        public string ImagePath { get; set; } = null;
    }
}
