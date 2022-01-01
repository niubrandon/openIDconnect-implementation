using Microsoft.AspNetCore.Authentication.JwtBearer;


string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => 
{
  options.AddPolicy(name: MyAllowSpecificOrigins,
  builder =>
  {
    builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
  });
});
//code below auth0 section

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
     .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, c =>
     {
         c.Authority = $"https://{builder.Configuration["Auth0:Domain"]}";
         c.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
         {
             ValidAudience = builder.Configuration["Auth0:Audience"],
             ValidIssuer = $"{builder.Configuration["Auth0:Domain"]}"
         };
     });

     builder.Services.AddAuthorization(o =>
    {
        o.AddPolicy("read:actions", p => p.
            RequireAuthenticatedUser().
            RequireClaim("scope", "read:actions"));
    });
// code above auth0 section


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//auth0 section below
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

//auth0 section above        

    

app.Run();

