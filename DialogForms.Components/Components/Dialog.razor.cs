namespace DialogForms.Components.Components;

public partial class Dialog : ComponentBase, IDisposable
{
    private Type ChildComponent = null!;

    private bool IsLoading = false;

    private bool IsVisible;

    private ElementReference ModalElement;

    private Dictionary<string, object> Parameters = null!;

    private string Title { get; set; } = string.Empty;

    private string ModalSize => Size.ToModalSizeClass();

    [Parameter] public string Message { get; set; } = null!;

    [Parameter] public RenderFragment BodyTemplate { get; set; } = null!;

    [Parameter] public RenderFragment HeaderTemplate { get; set; } = null!;

    [Parameter] public ButtonTypes ButtonType { get; set; } = ButtonTypes.SaveCancel;

    [Parameter] public RenderFragment FooterTemplate { get; set; }

    [Parameter] public bool IsBackdropStatic { get; set; } = true;

    [Parameter] public ActionType ActionType { get; set; }

    [Parameter] public bool ShowFooter { get; set; }

    [Parameter] public bool ShowBody { get; set; } = true;

    [Parameter] public ModalSize Size { get; set; } = Enums.ModalSize.Regular;

    public void Dispose()
    {
        ModalService.OnShow -= ShowModalAsync;
        ModalService.OnHide -= HideAsync;
        ChildComponent = null!;
        Parameters = null;
    }

    protected override void OnInitialized()
    {
        ModalService.OnShow += ShowModalAsync;
        ModalService.OnHide += HideAsync;
    }

    private async Task ShowModalAsync(ModalOption options)
    {
        Title = options.Title;
        ChildComponent = options.ChildComponent;
        Parameters = options.Parameters;
        IsVisible = true;
        IsLoading = options.IsLoading;
        Size = options.ModalSize;
        ButtonType = options.ButtonType;
        ActionType = options.ActionType;
        ShowFooter = options.ShowFooter;
        ShowBody = options.ShowBody;

        await InvokeAsync(StateHasChanged);
        await JsRuntime.InvokeVoidAsync("bootstrapModalShow", ModalElement);

        if (options.IsDraggable)
        {
            await JsRuntime.InvokeVoidAsync("makeModalDraggable", "modal-content");
        }
    }

    public async Task HideAsync()
    {
        IsVisible = false;

        Title = string.Empty;
        ChildComponent = null!;
        Parameters = null;
        IsLoading = false;
        ButtonType = ButtonTypes.SaveCancel;
        ActionType = default;
        ShowFooter = false;

        await InvokeAsync(StateHasChanged);
        await JsRuntime.InvokeVoidAsync("bootstrapModalHide", ModalElement);

        //ModalService.OnClose();
    }
}