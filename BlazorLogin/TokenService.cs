namespace BlazorLogin
{
    using Microsoft.JSInterop;
    using System.Threading.Tasks;

    public class TokenService
    {
        private readonly IJSRuntime jsRuntime;

        public TokenService(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public async Task<string> GetAccessToken()
        {
            return await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "access_token");
        }
    }

}

