using dotnet_integrationtest.Infra;
using dotnet_integrationtest.Infra.Config;
using dotnet_integrationtest.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region [DI]
builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("Connections"));
builder.Services.AddSingleton<DbConnectionProvider>();
builder.Services.AddScoped<QuoteRepository>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

