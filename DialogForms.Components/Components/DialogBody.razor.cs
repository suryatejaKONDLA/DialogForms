namespace DialogForms.Components.Components;

public partial class DialogBody : ComponentBase
{
    [Parameter] public Type ChildComponent { get; set; }

    [Parameter] public Dictionary<string, object> Parameters { get; set; } = new();

    [Parameter] public RenderFragment BodyTemplate { get; set; }

    [Parameter] public bool IsLoading { get; set; }

    [Parameter] public bool ShowBody { get; set; } = true;
   
    [Parameter] public string Message { get; set; }
}