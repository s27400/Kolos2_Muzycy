using Kolos2_Muzycy.Enitities;
using Kolos2_Muzycy.Repositories;
using Kolos2_Muzycy.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IMusicRepository, MusicReposiotry>();
builder.Services.AddScoped<IMusicService, MusicService>();


builder.Services.AddDbContext<MusicDbContext>(opt =>
{
    string con = builder.Configuration.GetConnectionString("Default");
    opt.UseSqlServer(con);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();


app.Run();
