using LibraryRazorManager.LibraryModule;
using LibraryRazorManager.LibraryModule.BookModels;
using LibraryRazorManager.LibraryModule.BookServices;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddRazorPages().AddViewLocalization().AddDataAnnotationsLocalization();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { new CultureInfo("en"), new CultureInfo("ru") };
    options.DefaultRequestCulture = new RequestCulture("en");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

builder.Services.AddSingleton<IBookAggregator, BookAggregatorService>();
builder.Services.AddSingleton<AbstractBookService<HistoricalBook>, HistoricalBookService>();
builder.Services.AddSingleton<AbstractBookService<GuideBook>, GuideBookService>();
builder.Services.AddSingleton<AbstractBookService<ModernBook>, ModernBookService>();
builder.Services.AddAntiforgery(options =>
{
    options.HeaderName = "RequestVerificationToken";
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Use(async (context, next) =>
{
    var path = context.Request.Path;

    if (path.StartsWithSegments("/"))
    {
        context.Response.Redirect("/Main");
        return;
    }
    await next.Invoke();
});

var localizationOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(localizationOptions.Value);

app.Run();
