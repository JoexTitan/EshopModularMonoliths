using Catalog;  // importing the namespace for Catalog
using Basket;   // importing the namespace for Basket
using Ordering; // importing the namespace for Ordering

var builder = WebApplication.CreateBuilder(args);

// Adding services to DI container (lifecylce & disposal criteria)
builder.Services
    .AddCatalogModule(builder.Configuration)
    .AddBasketModule(builder.Configuration)
    .AddOrderingModule(builder.Configuration);

//builder.Services.AddControllers(); // Adding MVC Controllers

// Register custom services
//builder.Services.AddTransient<IMyService, MyService>();               // Transient (NewEveryReq)
//builder.Services.AddScoped<IMyRepository, MyRepository>();            // Remembers Controller Context
//builder.Services.AddSingleton<IConfiguration>(builder.Configuration); // Singleton on the server

var app = builder.Build();

// Configure the HTTP request pipeline via middleware

app
    .UseCatalogModule()
    .UseBasketModule()
    .UseOrderingModule();

app.MapGet("/", () => "Hello World!");

app.Run();
