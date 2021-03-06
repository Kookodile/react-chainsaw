using Microsoft.EntityFrameworkCore;
using ReactChainsaw.API.Database;
using ReactChainsaw.API.Database.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options => {

    options.AddPolicy("cors", cors =>
    {

        cors.AllowAnyOrigin();
        cors.AllowAnyHeader();
        cors.AllowAnyMethod();

    });

});
// Add services to the container.
builder.Services.AddDbContextPool<AppDbContext>(option =>
{
    var connexionString = "server=localhost; port=3306; database=react-chainsaw; user=root; Persist Security Info=False; Connect Timeout=300";
    option.UseMySql(connexionString, ServerVersion.AutoDetect(connexionString));
});

builder.Services.AddScoped<ToDoRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["action"]}"));

var app = builder.Build();
app.UseCors("cors");

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
context.Database.EnsureCreated();
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
