using System.Threading.Tasks;

namespace Evision
{
    public interface IAccountService
    {
        Task<double> GetAccountAmountAsync(int accountId);
    }

    public class AccountService : IAccountService
    {
        public async Task<double> GetAccountAmountAsync(int accountId)
        {
            await Task.Delay(5000);
            return 0;
        }
    }
}