using Modulo_Mensageria.Extensions;
using Modulo_Mensageria.QuartzJobs;
using Modulo_Mensageria.Repository;
using Quartz;
using Serilog;
using Microsoft.EntityFrameworkCore;
using Modulo_Mensageria.Repository.Implementation;
using Modulo_Mensageria.Repository.Interfaces;
using Modulo_Mensageria.Services.Interfaces;
using Modulo_Mensageria.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);


//insira a string connection
builder.Services.AddDbContext<DbContexto>(options =>
    options.UseNpgsql(Environment.GetEnvironmentVariable("CONNECTION_STRING_MARKETING"))
);

builder.Services.AddDbContext<UnifiedContext>(options =>
    options.UseNpgsql(Environment.GetEnvironmentVariable("CONNECTION_STRING_GERAL"))
);

builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddScoped<ICampanhaService, CampanhaService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IMensageriaService, MensageriaService>();

// Add repositorys to the container.
builder.Services.AddScoped<ICampanhaRepository, CampanhaRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddQuartz(q =>
{
    q.AddJobAndTrigger<QuartzMensageria>(builder.Configuration);
});

builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("corsapp");

app.UseAuthorization();

app.MapControllers();

app.Run();
