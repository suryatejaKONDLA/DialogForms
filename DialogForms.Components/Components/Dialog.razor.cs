using DialogForms.Components.Enums;

namespace DialogForms.Components.Components;

public partial class Dialog : ComponentBase
{
    private bool IsVisible;

    private string Title { get; set; } = "";

    private string Message { get; set; } = "";

    private Type ChildComponent { get; set; }

    private Dictionary<string, object> Parameters { get; set; }

    private ElementReference ModalElement;


    protected override void OnInitialized()
    {
        ModalService.OnShow += ShowModalAsync;
    }

    private async Task ShowModalAsync(ModalOption options)
    {
        Title = options.Title;
        Message = options.Message ?? "";
        ChildComponent = options.ChildComponent;
        Parameters = options.Parameters;
        IsVisible = true;
        EventType = options.EventType;

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

    public void Dispose()
    {
        ModalService.OnShow -= ShowModalAsync;
    }

    [Parameter]
    public EventTypes EventType { get; set; } = EventTypes.SaveCancel;

    [Parameter]
    public EventCallback OnModalOk { get; set; }

    [Parameter]
    public EventCallback OnModalCancel { get; set; }

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