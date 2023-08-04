using Microsoft.JSInterop;

namespace BlazorCRUD.Client.Pages
{
    public class DotnetToJavaScript
    {
        private readonly IJSRuntime iJSRuntime;
        public  DotnetToJavaScript(IJSRuntime iJSRuntime)
        {
        this.iJSRuntime = iJSRuntime;
        }

        public  async Task Print(int counter)
        {
            await iJSRuntime.InvokeVoidAsync("logUser", counter);
        }
    }
}
