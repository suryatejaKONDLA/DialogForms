namespace DialogForms.Components.Services.ModelService;

public interface IModalService
{
    public event Func<ModalOption, Task> OnShow;

    public event Action OnHide;

    public Task ShowAsync(ModalOption modalOption);

    public Task ShowAsync(ModalOption modalOption, Action callbackAction);

    public Task ShowAsync<T>(string title, EventTypes eventType, string message = null, Dictionary<string, object> parameters = null);

    public Task ShowAsync(string title, Type component, EventTypes eventType, string message = null, Dictionary<string, object> parameters = null);

    public void OnClose();
}