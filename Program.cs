using BestPracticeDirectory.Models.Configurations;
using BestPracticeDirectory.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configura la Distributed Cache (es. in memoria, ma puoi usare Redis o SQL Server) ( DistribuitedCacheController )
builder.Services.AddDistributedMemoryCache(); // Cambia con AddStackExchangeRedisCache() per Redis

// Aggiungi il servizio Memory Cache ( MemoryCacheController )
builder.Services.AddMemoryCache();

// Configura il logging per includere console e debug ( LoggerController )
builder.Logging.ClearProviders(); // Pulisce i provider predefiniti
builder.Logging.AddConsole();    // Aggiunge i log sulla console
builder.Logging.AddDebug();      // Aggiunge i log sul debugger

// Registra la configurazione tipizzata della classe MyCustonSetting
builder.Services.Configure<MyCustomSettings>(builder.Configuration.GetSection("MyCustomSettings"));

// Registra il servizio HttpClient ( controller HttpClientController )
builder.Services.AddHttpClient();

// Registra il servizio HttpClient con una configurazione personalizzata ( HttpClientFactoryController )
builder.Services.AddHttpClient("ConfiguredClient", client =>
{
    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
    client.DefaultRequestHeaders.Add("User-Agent", "BestPracticeDirectory");
    client.Timeout = TimeSpan.FromSeconds(30);
});

// Registra MyBackgroundService come servizio in background ( MyBackgroundService )
builder.Services.AddSingleton<MyBackgroundService>();
builder.Services.AddHostedService(provider => provider.GetService<MyBackgroundService>());

// Registra MyBackgroundTask come servizio in background ( MyBackGroundTask ) / ( BackgroundTaskController )
builder.Services.AddHostedService<MyBackgroundTask>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
