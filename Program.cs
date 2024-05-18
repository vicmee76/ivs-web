using ivs_ui.Components;
using ivs_ui.Components.Data.Helpers;
using ivs_ui.Components.Data.Services.Accounts;
using ivs_ui.Components.Data.Services.General;
using ivs_ui.Components.Data.Services.Organisations;
using ivs_ui.Domain.Interfaces.Accounts;
using ivs_ui.Domain.Interfaces.General;
using ivs_ui.Domain.Interfaces.Organisations;
using MudBlazor;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;
    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 4000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

builder.Services.AddScoped<IWebService, WebService>();
builder.Services.AddTransient<IOrganisationService, OrganisationService>();
builder.Services.AddTransient<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseMiddleware<GlobalExceptionHandler>();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
