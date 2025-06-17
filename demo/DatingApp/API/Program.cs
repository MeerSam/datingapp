using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
//this part iscalled the middleware So if we wanted to check 
// if a user is authorized to access an API endpoint, then we've got middleware
//such as use authorization.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
//removed for this demo
app.UseHttpsRedirection();
//removed  for this demo
app.UseAuthorization();


// Add as middleware : CORS service
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod()
    .WithOrigins("http://localhost:4200", "https://localhost:4200"));

app.MapControllers();

app.Run();
