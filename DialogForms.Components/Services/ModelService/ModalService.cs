namespace DialogForms.Components.Services.ModelService;

public class ModalService : IModalService
{
    public event Func<ModalOption, Task> OnShow;
    public event Func<Task> OnHide;

    public async Task ShowAsync(ModalOption modalOption)
    {
        if (OnShow != null)
        {
            await OnShow.Invoke(modalOption);
        }
    }

    public async Task ShowAsync<T>(string title, ButtonTypes buttonType, bool isLoading = false, Dictionary<string, object> parameters = null)
    {
        var modalOption = new ModalOption
        {
            Title = title,
            ButtonType = buttonType,
            IsLoading = isLoading,
            Parameters = parameters
        };
        await ShowAsync(modalOption);
    }

    public void OnClose() { OnHide?.Invoke(); }
}