using Microsoft.EntityFrameworkCore;
using Plants.Endpoints;
using Plants.Interfaces.auth;
using Plants.Jwt;
using Plants.Repositories;
using Plants.Services;
using WebApplication1.Context;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddApiAuthentication(builder.Configuration);
builder.Services.AddControllersWithViews();

services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<UsersService>();
services.AddScoped<IJwtProvider, JwtProvider>();
services.AddScoped<IPasswordHasher, PasswordHasher>();

services.AddAutoMapper(typeof(Program));
services.AddEndpointsApiExplorer();
services.AddControllersWithViews();

services.AddSwaggerGen(config =>
{
    // путь до файла xml
    var xmlFile = "D:/Plants-master/Plants.xml"; 
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    config.IncludeXmlComments(xmlPath);
    config.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

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
});

app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Accounts}/{action=Index}/{id?}");

app.Run();