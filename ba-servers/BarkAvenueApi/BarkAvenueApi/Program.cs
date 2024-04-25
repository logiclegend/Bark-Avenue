using BarkAvenueApi.Email;
using BarkAvenueApi.Models;
using BarkAvenueApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddTransient<IEmailService, EmailService>();

builder.Services.AddDbContext<ApplicationDbContext>();


builder.Services.AddTransient<IUserRegistrationService>(provider =>
    new UserRegistrationService(provider.GetRequiredService<ApplicationDbContext>(),
                                     provider.GetRequiredService<IEmailService>()));

builder.Services.AddTransient<IUserAuthenticationService, UserAuthenticationService>();
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.AddTransient<JwtSettings>();


var app = builder.Build();

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
