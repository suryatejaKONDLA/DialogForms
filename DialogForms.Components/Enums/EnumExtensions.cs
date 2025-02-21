namespace DialogForms.Components.Enums;

public static class EnumExtensions
{
    public static string ToModalSizeClass(this ModalSize modalSize) =>
        modalSize switch
        {
            ModalSize.Regular => "",
            ModalSize.Small => "modal-sm",
            ModalSize.Large => "modal-lg",
            ModalSize.ExtraLarge => "modal-xl",
            _ => ""
        };
}