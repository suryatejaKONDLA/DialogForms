namespace DialogForms.Components.Services.ModelService;

public class ModalService : IModalService
{
    public event Func<ModalOption, Task> OnShow;
    public event Action OnHide;

    public Task ShowAsync(ModalOption modalOption) => OnShow?.Invoke(modalOption) ?? Task.CompletedTask;

    public Task ShowAsync<T>(string title, ButtonTypes buttonType, bool isLoading = false, Dictionary<string, object> parameters = null)
    {
        var options = new ModalOption
        {
            Title = title,
            ChildComponent = typeof(T),
            Parameters = parameters,
            ButtonType = buttonType,
            IsLoading = isLoading
        };

        return ShowAsync(options);
    }

    public void OnClose()
    {
        OnHide?.Invoke();
        OnHide = null;
    }
}