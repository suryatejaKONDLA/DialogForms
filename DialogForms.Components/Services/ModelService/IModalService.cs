namespace DialogForms.Components.Services.ModelService;

public interface IModalService
{
    public event Func<ModalOption, Task> OnShow;
    public event Func<Task> OnHide;
    public Task ShowAsync(ModalOption modalOption);
    public Task ShowAsync<T>(string title, ButtonTypes buttonType, bool isLoading = false, Dictionary<string, object> parameters = null);
    public void OnClose();
    Task<bool> ShowConfirmationAsync(string title, string message);
    public void SetDialogResult(bool result);
}