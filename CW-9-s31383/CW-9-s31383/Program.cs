using CW_9_s31383.DAL;
using CW_9_s31383.DbServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddDbContext<HospitalDbContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);
builder.Services.AddScoped<IDbService,DbService>();
var app = builder.Build();
app.MapControllers();
app.Run();