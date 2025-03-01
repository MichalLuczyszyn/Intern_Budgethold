using System.Reflection;
using System.Text;
using Intern_Budgethold.Features.UserAuth;
using Intern_Budgethold.Features.WalletManagement;
using Intern_Budgethold.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Scalar.AspNetCore;
using Microsoft.IdentityModel.Tokens;
using Intern_Budgethold.Features.Behaviors;
using MediatR;
using Intern_Budgethold.Api.Middleware;
using Intern_Budgethold.Features.CategoryManagement;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
{
  cfg.RegisterServicesFromAssemblies(
    Assembly.GetExecutingAssembly(),
    typeof(RegisterUserHandler).Assembly);
  cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
});



builder.Services.AddUserManagement();
builder.Services.AddCategoryManagement();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddOpenApi();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(options =>
    {
      options.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
          Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
        )
      };
      options.Events = new JwtBearerEvents
      {
        OnMessageReceived = context =>
        {
          context.Token = context.Request.Cookies["jwt"];
          return Task.CompletedTask;
        }
      };
    });
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandling();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
  app.MapOpenApi();
  app.MapScalarApiReference();
}

UserModule.MapEndpoints(app);
WalletModule.MapEndpoints(app);
CategoryModule.MapEndpoints(app);

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
