namespace DialogForms.Components.Components;

public partial class ActionButton : ComponentBase
{
    [Parameter] public ButtonTypes ButtonType { get; set; }

    [Parameter] public EventCallback<MouseEventArgs> OkButtonClick { get; set; }

        private void OnYesClicked()
        {
            ModalService.SetDialogResult(true);
            ModalService.OnClose();
        }

        private void OnNoClicked()
        {
            ModalService.SetDialogResult(false);
            ModalService.OnClose();
        }
    
        private void OnClosedClicked()
        {
            ModalService.OnClose();
        }
}