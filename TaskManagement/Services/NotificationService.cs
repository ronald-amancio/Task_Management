namespace TaskManagement.Services
{
    public class NotificationService
    {
        public event Action<string, string>? OnNotify;

        public void ShowSuccess(string message) => OnNotify?.Invoke(message, "success");
        public void ShowError(string message) => OnNotify?.Invoke(message, "danger");
    }
}