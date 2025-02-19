namespace DialogForms.Components.Components;

public partial class DialogFooter : ComponentBase
{
    [Parameter] public RenderFragment FooterTemplate { get; set; }

    [Parameter] public bool ShowFooter { get; set; } = true;

    [Parameter] public ButtonTypes ButtonType { get; set; }
}