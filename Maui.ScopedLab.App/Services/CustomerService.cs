namespace Maui.ScopedLab.App.Services;

public class CustomerService : ICustomerService
{
    #region Public Methods
    public int GetIdentifier()
    {
        return this.GetHashCode();
    }

    #endregion
}
