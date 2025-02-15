namespace DialogForms.Components.Models;

public class ModalOption
{
    public string Title { get; init; } = string.Empty;

    public string Message { get; init; } = string.Empty;

    public Type ChildComponent { get; init; }

    public EventTypes EventType { get; init; }

    public Dictionary<string, object> Parameters { get; init; }
}