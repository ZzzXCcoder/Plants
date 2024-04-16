using Plants.Models;
using System.Text.Json.Serialization;

public class Plant
{
    public Guid Id { get; set; }
    public string Plant_name { get; set; }
    public string Plant_description { get; set; }
    public string Plant_type { get; set; }
    public string ImagePath { get; set; } = null;
    [JsonIgnore]
    public List<Account_and_plant> plant_in_table { get; set; }

    public Plant(Guid id, string plant_name, string plant_description, string plant_type, string image_path)
    {
        Id = id;
        Plant_name = plant_name;
        Plant_description = plant_description;
        Plant_type = plant_type;
        ImagePath = image_path;
    }
    public Plant()
    {

    }
}