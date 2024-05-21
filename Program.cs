using Blazored.SessionStorage;
using ivs_ui.Components;
using ivs_ui.Components.Data.Services.Accounts;
using ivs_ui.Components.Data.Services.General;
using ivs_ui.Components.Data.Services.Organisations;
using ivs_ui.Domain.Interfaces.Accounts;
using ivs_ui.Domain.Interfaces.General;
using ivs_ui.Domain.Interfaces.Organisations;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using MudBlazor.Services;

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



builder.Services.AddScoped<IWebService, WebService>();
builder.Services.AddTransient<IOrganisationService, OrganisationService>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddHttpClient<AuthenticationStateProvider, AuthStateProvider>();

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddBlazoredSessionStorage();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

//app.UseMiddleware<GlobalExceptionHandler>();
app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthorization();



app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
