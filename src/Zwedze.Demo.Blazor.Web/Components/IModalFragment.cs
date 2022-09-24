using Microsoft.AspNetCore.Components;

namespace Zwedze.Demo.Blazor.Web.Components;

public interface IModalFragment<T>
{
    /// <summary>
    ///     A callback fired once the user validate the Modal content state.
    /// </summary>
    EventCallback<T> OnOk();

    /// <summary>
    ///     A callback fired once the user dismiss/close the Modal frame.
    /// </summary>
    EventCallback OnDismiss();
}