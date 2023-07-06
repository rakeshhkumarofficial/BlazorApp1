using MetaMask.Blazor;
using MetaMask.Blazor.Exceptions;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string MetaMask { get; set; }
        [Inject]
        public IMetaMaskService MetaMaskService { get; set; } = default!;
        protected async Task Connect()
        {
             bool hasMetaMask = await MetaMaskService.HasMetaMask();
             bool isSiteConnected = await MetaMaskService.IsSiteConnected();
            try
            {
                await MetaMaskService.ConnectMetaMask();
                
                MetaMask = await MetaMaskService.GetSelectedAddress();
              
                NavigationManager.NavigateTo("/home");
            }
            catch (UserDeniedException)
            {
                //Handle "User Denied" case;
            }
            
        }
       
    }
}
