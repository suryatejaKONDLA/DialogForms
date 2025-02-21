namespace DialogForms.Components.Models;

public class ModalOption
{
    public string Title { get; set; }
    public string Message { get; set; }
    public Type ChildComponent { get; set; }
    public Dictionary<string, object> Parameters { get; set; }
    public ButtonTypes ButtonType { get; set; }
    public bool IsLoading { get; set; }
    public bool ShowFooter { get; set; }
    public bool ShowBody { get; set; } = true;
    public bool IsDraggable { get; set; } = true;
    public ActionType ActionType { get; set; }
    public ModalSize ModalSize { get; set; } = ModalSize.Regular;
}