using Plants.Services;
using System.Globalization;

namespace Plants.Endpoints
{
    public static class Users_and_PlantsEndpoints
    {
        public static IEndpointRouteBuilder MapPlant_and_UserEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("/api/AddPlantToUser/Plant_and_User", AddPlantToUser);
            endpoints.MapPost("/api/EditWateringTime/Plant_and_User", SetWateringTime);
            endpoints.MapPost("/api/Watering/Plant_and_User", Watering);

            return endpoints;
        }
        private static async Task<IResult> AddPlantToUser(Users_and_PlantsService users_And_PlantsService,HttpContext context, Guid plant)
        {
            var user = context.User;

            // Получение claims пользователя
            var claims = user.Claims;
            var idClaim = claims.FirstOrDefault(c => c.Type == "userId");

            if (idClaim == null)
            {
                return null;
            }

            var id = Guid.Parse(idClaim.Value);
            users_And_PlantsService.Add(plant, id, context);

            return Results.Ok();
        }

        private static async Task<DateTime> SetWateringTime(Users_and_PlantsService users_And_PlantsService, HttpContext context, Guid plant, string dateTime, double wateringIntervalInHours)
        {
            var user = context.User;

            // Получение claims пользователя
            var claims = user.Claims;
            var idClaim = claims.FirstOrDefault(c => c.Type == "userId");

            if (idClaim == null)
            {
                throw new Exception("Нет такого пользователя");
            }

            var id = Guid.Parse(idClaim.Value);
            await users_And_PlantsService.SetWateringInterval(plant, id, context, wateringIntervalInHours);
            string timeString = dateTime;
            string format = "yyyy-MM-dd HH:mm";
            DateTime wateringTime = DateTime.ParseExact(timeString, format, CultureInfo.InvariantCulture, DateTimeStyles.None);
            wateringTime = wateringTime.ToUniversalTime();
            return await (users_And_PlantsService.SetWateringTime(plant, id, context, wateringTime));


        }
        private static async Task<string[]> Watering(Users_and_PlantsService users_And_PlantsService, HttpContext context, Guid plant)
        {
            var user = context.User;
            // Получение claims пользователя
            var claims = user.Claims;
            var idClaim = claims.FirstOrDefault(c => c.Type == "userId");

            if (idClaim == null)
            {
                throw new Exception("Нет такого пользователя");
            }

            var id = Guid.Parse(idClaim.Value);
            var nextTime = await users_And_PlantsService.CalculateTimeToNextWatering(plant, id, context);
            var progress = await users_And_PlantsService.AddToProgress(plant, id, context);
            var result = new string[2];
            result[0] = Convert.ToString(nextTime);
            result[1] = Convert.ToString(progress);
            return result;
        }


    }
}
