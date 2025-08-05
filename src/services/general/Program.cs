using Kaleidocode.Gists.Modules.Persistence.Contexts;
using Kaleidocode.Gists.Modules.Persistence.Contracts.Base;
using Kaleidocode.Gists.Modules.Persistence.Extensions;
using Kaleidocode.Gists.Modules.Persistence.Models.Commands;
using Kaleidocode.Gists.Modules.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<MainContext>();

builder.Services.AddLookupPersistence();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
