var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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
//removed
app.UseHttpsRedirection();
//removed
app.UseAuthorization();

app.MapControllers();

app.Run();
