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
    public bool IsDraggable { get; set; }
    public bool IsResizable { get; set; }
    public bool IsBackdropStatic { get; set; }
    public ActionType ActionType { get; set; }
}