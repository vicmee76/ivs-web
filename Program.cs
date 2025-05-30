using Blazored.LocalStorage;
using Blazored.SessionStorage;
using ivs_ui.Components;
using ivs_ui.Components.Data.Services.Accounts;
using ivs_ui.Components.Data.Services.Events;
using ivs_ui.Components.Data.Services.General;
using ivs_ui.Components.Data.Services.Orders;
using ivs_ui.Components.Data.Services.Organisations;
using ivs_ui.Components.Data.Services.Payment;
using ivs_ui.Components.Data.Services.Tickets;
using ivs.Domain.Interfaces.Accounts;
using ivs.Domain.Interfaces.Events;
using ivs.Domain.Interfaces.General;
using ivs.Domain.Interfaces.Orders;
using ivs.Domain.Interfaces.Organisations;
using ivs.Domain.Interfaces.Payment;
using ivs.Domain.Interfaces.Tickets;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using MudBlazor.Services;
using System.Globalization;
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;
    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 7000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

// Set up custom culture settings
CultureInfo nigeriaCulture = new CultureInfo("en-NG");
nigeriaCulture.NumberFormat.CurrencySymbol = "₦";

var supportedCultures = new[] { nigeriaCulture };

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture(nigeriaCulture);
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

builder.Services.AddScoped<JsInteropService>();
builder.Services.AddSingleton<CircuitHandler, CustomCircuitHandler>();

builder.Services.AddAuthorizationCore();
builder.Services.AddAuthenticationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddBlazoredLocalStorage();


builder.Services.AddHttpClient<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddScoped<IWebService, WebService>();
builder.Services.AddTransient<IOrganizationService, OrganizationService>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IEventTypeService, EventTypeService>();
builder.Services.AddTransient<IPaymentOptionService, PaymentOptionService>();
builder.Services.AddTransient<IEventService, EventService>();
builder.Services.AddTransient<IEventTimeService, EventTimeService>();
builder.Services.AddTransient<ITicketService, TicketService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IAttendanceService, AttendanceService>();
builder.Services.AddTransient<IPaymentService, PaymentService>();
builder.Services.AddTransient<IDiscountService, DiscountService>();


var app = builder.Build();

// Use localization middleware
var localizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>()?.Value;
if (localizationOptions != null)
{
    app.UseRequestLocalization(localizationOptions);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}


app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseRouting();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();



app.Run();
