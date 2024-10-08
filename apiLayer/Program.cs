using dataLayer;
using Microsoft.EntityFrameworkCore;
using serviceLayer.Roles;
using serviceLayer.Users;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
IConfiguration conf = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddCommandLine(args)
    .AddEnvironmentVariables()
    .Build();

String sconf = conf.GetConnectionString("Mycon1");
builder.Services.AddDbContext<UserContext>(opt => opt.UseSqlServer(sconf));
builder.Services.AddTransient(typeof(IUser), typeof(UserService));
builder.Services.AddTransient(typeof(IRole), typeof(RolesService));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
