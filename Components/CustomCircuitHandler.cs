using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.JSInterop;

namespace ivs_ui.Components;

public class CustomCircuitHandler :  CircuitHandler
{
    private readonly IServiceProvider _serviceProvider;

    public CustomCircuitHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }


    // Override OnCircuitDisconnected to trigger reload when the connection is lost
    public  async Task OnCircuitDisconnectedAsync(Circuit circuit, CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var jsInteropService = scope.ServiceProvider.GetRequiredService<JsInteropService>();
        await jsInteropService.ReloadPageAsync();
        await base.OnConnectionDownAsync(circuit, cancellationToken);
    }
}