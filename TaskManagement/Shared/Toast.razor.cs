using Microsoft.AspNetCore.Components;
using TaskManagement.Services;

namespace TaskManagement.Shared
{
    public partial class Toast : ComponentBase
    {
        [Inject] NotificationService NotificationService { get; set; } = default!;

        private bool IsVisible = false;
        private string Message = string.Empty;
        private string ToastType = "success";

        protected override void OnInitialized()
        {
            NotificationService.OnNotify += Show;
        }

        private void Show(string message, string type)
        {
            Message = message;
            ToastType = type;
            IsVisible = true;
            StateHasChanged();

            _ = Task.Delay(3000).ContinueWith(_ =>
            {
                IsVisible = false;
                InvokeAsync(StateHasChanged);
            });
        }

        private void Hide()
        {
            IsVisible = false;
        }
    }
}