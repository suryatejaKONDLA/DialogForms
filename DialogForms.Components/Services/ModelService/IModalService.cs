﻿namespace DialogForms.Components.Services.ModelService;

public interface IModalService
{
    public event Func<ModalOption, Task> OnShow;
    public event Action OnHide;
    public Task ShowAsync(ModalOption modalOption);
    public Task ShowAsync<T>(string title, ButtonTypes buttonType, bool isLoading = false, Dictionary<string, object> parameters = null);
    public void OnClose();
}