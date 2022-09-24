namespace Zwedze.Demo.Blazor.Web.Components;

public partial class ConfirmationModal
{
    private bool _isModalVisible = false;

    private void ShowModal()
    {
        _isModalVisible = true;
    }

    private void Dismiss()
    {
        _isModalVisible = false;
    }
    
    private void Ok()
    {
        _isModalVisible = false;
    }
}