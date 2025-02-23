namespace DialogForms.Components.Services.ModelService;

public class ModalService : IModalService
{
    public event Func<ModalOption, Task> OnShow;
    public event Func<Task> OnHide;

    public async Task ShowAsync(ModalOption modalOption)
    {
        if (OnShow != null)
        {
            await OnShow.Invoke(modalOption);
        }
    }

    public async Task ShowAsync<T>(string title, ButtonTypes buttonType, bool isLoading = false, Dictionary<string, object> parameters = null)
    {
        var modalOption = new ModalOption
        {
            Title = title,
            ButtonType = buttonType,
            IsLoading = isLoading,
            Parameters = parameters
        };
        await ShowAsync(modalOption);
    }

    private TaskCompletionSource<bool> ConfirmationTcs;

    public async Task<bool> ShowConfirmationAsync(string title, string message)
    {
        ConfirmationTcs = new();

        var options = new ModalOption
        {
            Title = title,
            Message = message,
            ButtonType = ButtonTypes.YesNo,
            ShowFooter = true,
            ShowBody = true,
            ActionType = ActionType.Delete,
            ModalSize = ModalSize.Small
        };

        if (OnShow != null)
        {
            await OnShow.Invoke(options);
        }

        return await ConfirmationTcs.Task;
    }

    public void SetDialogResult(bool result)
    {
        ConfirmationTcs?.SetResult(result);
    }

    public void OnClose() { OnHide?.Invoke(); }
}