using Microsoft.EntityFrameworkCore;
using MyPawPal.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Configuration
builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.
builder.Services.AddDbContext<MyDbContext>(options => options.UseNpgsql(builder.Configuration["ConnectionStrings:DefaultConnection"]));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddAuthorization();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDogService, DogService>();

builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                });
builder.Services.AddMvc().AddXmlSerializerFormatters(); // Content Negotiation, ça permet de renvoyer des données au format XML si le client le demande (par défaut, JSON)

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("CorsPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
