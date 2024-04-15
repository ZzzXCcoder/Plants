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

        private static async Task<TimeSpan> SetWateringTime(Users_and_PlantsService users_And_PlantsService, HttpContext context, Guid plant, string dateTime)
        {
            var user = context.User;

            // Получение claims пользователя
            var claims = user.Claims;
            var idClaim = claims.FirstOrDefault(c => c.Type == "userId");

            if (idClaim == null)
            {
                return DateTime.MinValue.TimeOfDay;
            }

            var id = Guid.Parse(idClaim.Value);
            string timeString = dateTime;
            string format = "HH:mm";
            DateTime wateringTime = DateTime.ParseExact(timeString, format, CultureInfo.InvariantCulture, DateTimeStyles.None);
            wateringTime = wateringTime.ToUniversalTime();
            return await (users_And_PlantsService.SetWateringTime(plant, id, context, wateringTime));


        }
    }
}
