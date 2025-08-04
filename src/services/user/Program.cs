using Kaleidocode.Gists.Services.User.Properties;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(
        builder.Configuration, 
        ApplicationConstants.AuthenticationConfigurationSectionName
    );

builder.Services.AddControllers();

builder.Services.AddOpenApi();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment()) { app.MapOpenApi(); }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
