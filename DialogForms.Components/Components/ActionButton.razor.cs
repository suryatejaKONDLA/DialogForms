namespace DialogForms.Components.Components;

public partial class ActionButton : ComponentBase
{
    [Parameter] public ButtonTypes ButtonType { get; set; }


    [Parameter] public EventCallback<MouseEventArgs> OkButtonClick { get; set; }


    [Parameter] public EventCallback<MouseEventArgs> CancelButtonClick { get; set; }
}