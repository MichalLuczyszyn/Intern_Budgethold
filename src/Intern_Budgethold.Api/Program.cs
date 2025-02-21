using System.Reflection;
using Intern_Budgethold.Features.UserAuth;
using Intern_Budgethold.Features.WalletManagement;
using Intern_Budgethold.Infrastructure;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    Assembly.GetExecutingAssembly(),
    typeof(CreateUserHandler).Assembly)
);

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddOpenApi();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
  app.MapOpenApi();
  app.MapScalarApiReference();
}

UserModule.MapEndpoints(app);
WalletModule.MapEndpoints(app);

app.UseHttpsRedirection();


app.Run();
