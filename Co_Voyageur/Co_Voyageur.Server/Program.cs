using Co_Voyageur.Server.Data;
using Co_Voyageur.Server.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Co_Voyageur.Server.Helpers;
using Co_Voyageur.Server.Models;
using Co_Voyageur.Server.Services;
using Co_Voyageur.Server.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Co_Voyageur.Server",
        Version = "3.0.0", // Cela d�finit explicitement la version OpenAPI 3.0.0
    });
});


builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepository<Car,int>,CarRepository>();
builder.Services.AddScoped<IRepository<Review,int>, ReviewRepository>();
builder.Services.AddScoped<IRepository<User,int>,UserRepository>();
builder.Services.AddScoped<IRepository<Step,int>,StepRepository>();
builder.Services.AddScoped<IRepository<Trip,int>,TripRepository>();

builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<CarService>();
builder.Services.AddScoped<ReviewService>();
builder.Services.AddScoped<StepService>();
builder.Services.AddScoped<TripService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        options.JsonSerializerOptions.MaxDepth = 32;  // Optionnel : augmenter la profondeur maximale
    });

var app = builder.Build();


app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mon API v1");
        c.RoutePrefix = "swagger"; // Swagger dispo sur /swagger
    });
}

app.UseHttpsRedirection();

app.UseCors(options =>
{
    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
