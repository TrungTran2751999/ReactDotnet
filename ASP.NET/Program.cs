using Microsoft.EntityFrameworkCore;
using app.Services;
using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("connectString")));

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IStudentService, StudentService>();
var _jwtSetting = builder.Configuration.GetSection("JwtSettings");
var _authkey = builder.Configuration.GetValue<string>("JwtSettings:securitykey");
builder.Services.AddAuthentication(item =>
{
    item.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    item.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(item =>
{
    item.RequireHttpsMetadata = true;
    item.SaveToken = true;
    item.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authkey)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew=TimeSpan.Zero
    };
    //ki gui token vao cookie
    item.Events = new JwtBearerEvents{
        OnMessageReceived = context =>{
            var token = context.Request.Cookies["token"];
            context.Token = token;
            return Task.CompletedTask;
        }
    };
});
builder.Services.Configure<JwtSettings>(_jwtSetting);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

// app.UseStatusCodePages(async context =>
// {
//     var response = context.HttpContext.Response;

//     if (response.StatusCode == (int)HttpStatusCode.Unauthorized ||
//         response.StatusCode == (int)HttpStatusCode.Forbidden)
//         response.Redirect("/login");
// });
app.UseAuthentication();
app.UseAuthorization();

app.UseCors();
app.MapControllers();

app.Run();
