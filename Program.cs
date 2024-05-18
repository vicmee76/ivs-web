using ivs_ui.Components;
using ivs_ui.Components.Data.Helpers;
using ivs_ui.Components.Data.Services.General;
using ivs_ui.Components.Data.Services.Organisations;
using ivs_ui.Domain.Interfaces.General;
using ivs_ui.Domain.Interfaces.Organisations;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

builder.Services.AddScoped<IWebService, WebService>();
builder.Services.AddTransient<IOrganisationService, OrganisationService>();

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
