namespace DialogForms.Components.Services.ModelService;

public class ModalService : IModalService
{
    public event Func<ModalOption, Task> OnShow;

    public event Action OnHide;

    public Task ShowAsync(ModalOption modalOption)
    {
        return OnShow?.Invoke(modalOption) ?? Task.CompletedTask;
    }

    public Task ShowAsync(ModalOption modalOption, Action callbackAction)
    {
        OnHide = callbackAction;
        return OnShow?.Invoke(modalOption) ?? Task.CompletedTask;
    }

    public Task ShowAsync<T>(string title, EventTypes eventType, string message = null, Dictionary<string, object> parameters = null)
    {
        var options = new ModalOption
        {
            Title = title,
            Message = message,
            ChildComponent = typeof(T),
            Parameters = parameters,
            EventType = eventType
        };

        return ShowAsync(options);
    }

    public Task ShowAsync(string title, Type component, EventTypes eventType, string message = null, Dictionary<string, object> parameters = null)
    {
        var options = new ModalOption
        {
            Title = title,
            Message = message,
            ChildComponent = component,
            Parameters = parameters,
            EventType = eventType
        };

        return ShowAsync(options);
    }

    public void OnClose()
    {
        OnHide?.Invoke();
        OnHide = null;
    }
}