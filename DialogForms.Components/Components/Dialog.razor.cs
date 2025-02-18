namespace DialogForms.Components.Components;

public partial class Dialog : ComponentBase, IDisposable
{
    private bool IsLoading = false;

    private bool IsVisible;

    private ElementReference ModalElement;

    private string Title { get; set; } = string.Empty;

    private Type ChildComponent { get; set; }

    private Dictionary<string, object> Parameters { get; set; }

    [Parameter] public ButtonTypes ButtonType { get; set; } = ButtonTypes.SaveCancel;

    [Parameter] public EventCallback OnModalOk { get; set; }

    [Parameter] public EventCallback OnModalCancel { get; set; }

    [Parameter] public RenderFragment FooterTemplate { get; set; }

    [Parameter] public bool IsBackdropStatic { get; set; } = true;

    [Parameter] public ActionType ActionType { get; set; }

    [Parameter] public bool ShowFooter { get; set; }

    public void Dispose() { ModalService.OnShow -= ShowModalAsync; }

    protected override void OnInitialized() { ModalService.OnShow += ShowModalAsync; }

    private async Task ShowModalAsync(ModalOption options)
    {
        Title = options.Title;
        ChildComponent = options.ChildComponent;
        Parameters = options.Parameters;
        IsVisible = true;
        IsLoading = options.IsLoading;
        IsBackdropStatic = options.IsBackdropStatic;
        ButtonType = options.ButtonType;
        ActionType = options.ActionType;
        ShowFooter = options.ShowFooter;

        await InvokeAsync(StateHasChanged);
        await JsRuntime.InvokeVoidAsync("bootstrapModalShow", ModalElement);
    }

    private async Task HideAsync()
    {
        IsVisible = false;
        await InvokeAsync(StateHasChanged);
        await JsRuntime.InvokeVoidAsync("bootstrapModalHide", ModalElement);

        ModalService.OnClose();
    }

    private async Task ModalOk()
    {
        if (OnModalOk.HasDelegate)
        {
            await OnModalOk.InvokeAsync();
        }
    }

    private async Task ModalCancel()
    {
        if (OnModalCancel.HasDelegate)
        {
            await OnModalCancel.InvokeAsync();
        }
    }
}