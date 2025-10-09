using Microsoft.EntityFrameworkCore;
using PancheriaJP.Config;
using PancheriaJP.Repositories;
using PancheriaJP.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services
builder.Services.AddScoped<PanchoServices>();
builder.Services.AddScoped<IngredienteServices>();
builder.Services.AddScoped<CategoriaServices>();

//Repositories
builder.Services.AddScoped<IPanchoRepository, PanchoRepository>();
builder.Services.AddScoped<IIngredienteRepository, IngredienteRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

// Mapper
builder.Services.AddAutoMapper(opts => { }, typeof(Mapping));

// DB
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("devConnection"));
});

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
