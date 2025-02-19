#region

using DialogForms.Components.Enums;

#endregion

namespace DialogForms.Components.Pages.Masters;

public partial class Customer : IDisposable
{
    private CustomerModel Model;

    [Parameter] public object Context { get; set; }

    private EditContext EditContext { get; set; }

    [Parameter] public ButtonTypes ButtonType { get; set; }

    [Parameter] public ActionType ActionType { get; set; }

    public void Dispose()
    {
        // TODO release managed resources here
    }

    protected override void OnParametersSet() { ResetForm(); }

    private void OnSubmit(EditContext context)
    {
        if (!context.Validate())
        {
            return;
        }

        if (ActionType == ActionType.Add)
        {
            CustomerDataService.AddCustomer(Model);
        }
        else if (ActionType == ActionType.Update)
        {
            CustomerDataService.UpdateCustomer(Model.Id, Model);
        }

        ModalService.OnClose();
    }

    private void ResetForm()
    {
        Model = Context as CustomerModel ?? new CustomerModel();
        EditContext = new(Model);
    }
}