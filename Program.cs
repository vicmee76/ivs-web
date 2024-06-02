using Blazored.SessionStorage;
using ivs_ui.Components;
using ivs_ui.Components.Data.Helpers;
using ivs_ui.Components.Data.Services.Accounts;
using ivs_ui.Components.Data.Services.Events;
using ivs_ui.Components.Data.Services.General;
using ivs_ui.Components.Data.Services.Organisations;
using ivs_ui.Domain.Interfaces.Accounts;
using ivs_ui.Domain.Interfaces.Events;
using ivs_ui.Domain.Interfaces.General;
using ivs_ui.Domain.Interfaces.Organisations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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



builder.Services.AddAuthorizationCore();
builder.Services.AddAuthenticationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddBlazoredSessionStorage();


builder.Services.AddHttpClient<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddScoped<IWebService, WebService>();
builder.Services.AddTransient<IOrganisationService, OrganisationService>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IEventTypeService, EventTypeService>();










var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}


app.UseStaticFiles();
app.UseAntiforgery();


app.UseAuthentication();
app.UseAuthorization();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();



app.Run();
