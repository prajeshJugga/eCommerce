using eCommerceApi;
using eCommerceApi.Repositories;
using eCommerceApi.Services;
using eCommerceApi.Services.BusinessLogic;
using eCommerceDatabase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add Repos
//builder.Services.AddScoped<IProductRepo, MockProductRepo>();
//builder.Services.AddScoped<ICustomerRepo, MockCustomerRepo>();
//builder.Services.AddScoped<IBasketRepo, MockBasketRepo>();

builder.Services.AddScoped<IProductRepo, ProductRepository>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepository>();
builder.Services.AddScoped<IBasketRepo, BasketRepository>();
builder.Services.AddScoped<IActiveSpecialRepository, ActiveSpecialsRepository>();

// Add Services
//IProductService mockProductService = new MockProductService()
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IBasketService, BasketService>();

// Add BLL Services
builder.Services.AddScoped<IBasketCalculator, BasicBasketCalculator>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration["ECommerce:ConnectionString"];

var contextOptions = new DbContextOptionsBuilder<ECommerceContext>()
    .UseSqlServer(connectionString)
    .Options;

//using var context1 = new ECommerceContext(connectionString);

//var context = new ECommerceContext(connectionString);
builder.Services
    .AddDbContext<ECommerceContext>(opt => opt.UseSqlServer(connectionString));

var app = builder.Build();

// Only ran when not in release mode
#if DEBUG
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ECommerceContext>();
    //context.Database.EnsureCreated();
    // Only perform the migration if migrations are pending
    if (context.Database.GetPendingMigrations().Count() > 0)
        context.Database.Migrate();
    if (bool.Parse(builder.Configuration["InitializeDb"]))
        try
        {
            DatabaseMockDataInitializer.Initialize(context);
        }
        catch (Exception)
        {

        }
}
#endif

app.MapDefaultEndpoints();

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
