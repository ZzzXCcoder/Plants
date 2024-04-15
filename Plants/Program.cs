using Microsoft.EntityFrameworkCore;
using Plants.Endpoints;
using Plants.Interfaces.auth;
using Plants.Jwt;
using Plants.Repositories;
using Plants.Services;
using WebApplication1.Context;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddApiAuthentication(builder.Configuration);
builder.Services.AddControllers();
services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<UsersService>();
services.AddScoped<IJwtProvider, JwtProvider>();
services.AddScoped<IPasswordHasher, PasswordHasher>();
services.AddScoped<IPlantsRepository, PlantRepository>();
services.AddScoped<PlantsService>();
services.AddScoped<IUser_and_PlantsRepository, User_and_PlantsRepository>();
services.AddScoped<Users_and_PlantsService>();


services.AddAutoMapper(typeof(Program));
services.AddEndpointsApiExplorer();
services.AddControllersWithViews();

services.AddSwaggerGen(config =>
{
    // путь до файла xml file
    var xmlFile = "Plants.xml"; 
    
    config.IncludeXmlComments(xmlFile);
    config.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();
app.UseStaticFiles();
// Apply migrations
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;

});

app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
    endpoints.MapUsersEndpoints();
    endpoints.MapPlantsEndpoints();
    endpoints.MapPlant_and_UserEndpoints();
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Accounts}/{action=Index}/{id?}");

app.Run();