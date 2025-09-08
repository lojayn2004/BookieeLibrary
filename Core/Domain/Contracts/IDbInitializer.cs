
namespace Domain.Contracts
{
    public interface IDbInitializer
    {
        Task InitializeAppAsync();

        Task InitializeIdentityAsync();

    }
}
