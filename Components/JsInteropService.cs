using Microsoft.JSInterop;

namespace ivs_ui.Components;

public class JsInteropService
{
    private readonly IJSRuntime _jsRuntime;

    public JsInteropService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task ReloadPageAsync()
    {
        await _jsRuntime.InvokeVoidAsync("reloadPage");
    }
}