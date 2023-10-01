using Test.Configuration;

var builder = WebApplication.CreateBuilder(args);
ConfigurationService.ConfigureServices(builder.Services, builder.Configuration);
var app = builder.Build();
ConfigurationService.Configure(app,builder.Services.BuildServiceProvider());
app.Run();
