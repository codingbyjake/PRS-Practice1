using Microsoft.EntityFrameworkCore;
using PRS_Practice1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connStringKey = "PrsDbContextWinhost";

#if DEBUG
connStringKey = "PRSPrac1DbContext";
#endif

builder.Services.AddDbContext<PRSPrac1DbContext>(x => {
    x.UseSqlServer(builder.Configuration.GetConnectionString(connStringKey), x => x.EnableRetryOnFailure());
});
builder.Services.AddCors();


// Define app and set connection access
var app = builder.Build();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());


// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();