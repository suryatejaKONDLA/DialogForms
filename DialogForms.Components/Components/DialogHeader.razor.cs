namespace DialogForms.Components.Components;

public partial class DialogHeader : ComponentBase
{
    [Parameter] public ActionType ActionType { get; set; }

    [Parameter] public string Title { get; set; }

    [Parameter] public string Subtitle { get; set; }

    [Parameter] public EventCallback<MouseEventArgs> OnCloseClick { get; set; }

    [Parameter] public RenderFragment HeaderTemplate { get; set; }

    [Parameter] public bool ShowIcon { get; set; } = true;

    [Parameter] public bool ShowCloseButton { get; set; } = true;

    [Parameter] public string CloseButtonText { get; set; }

    [Parameter] public string CloseButtonAriaLabel { get; set; } = "Close";

    private string GetActionTitle() => ActionType switch
    {
        ActionType.Add => $"Add {Title}",
        ActionType.Update => $"Update {Title}",
        ActionType.Delete => $"Delete {Title}",
        ActionType.View => $"View {Title}",
        _ => throw new ArgumentOutOfRangeException()
    };

    private string GetIconClass() => ActionType switch
    {
        ActionType.Add => "bi bi-plus-circle text-success",
        ActionType.Update => "bi bi-pencil-square text-warning",
        ActionType.Delete => "bi bi-trash text-danger",
        ActionType.View => "bi bi-eye text-primary",
        _ => "bi bi-question-circle text-secondary"
    };
}