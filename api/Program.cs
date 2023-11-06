// Import Services
using Api.Services.CatProductoService;
using Api.Services.CatTipoClienteService;
using Api.Services.TblClienteService;
using Api.Services.TblDetalleFacturaService;
using Api.Services.TblFacturaService;

// Import Repository



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inject Services
builder.Services.AddScoped<ICatProductoService, CatProductoServiceImpl>();
builder.Services.AddScoped<ICatTipoClienteService, CatTipoClienteServiceImpl>();
builder.Services.AddScoped<ITblClienteService, TblClienteServiceImpl>();
builder.Services.AddScoped<ITblDetalleFacturaService, TblDetalleFacturaServiceImpl>();
builder.Services.AddScoped<ITblFacturaService, TblFacturaServiceImpl>();
// End Inject Services

// Inject Repository
builder.Services.AddScoped<ICatProductoRepository, CatProductoRepositoryImpl>();
// TODO: Add more repository
// End Inject Repository

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
