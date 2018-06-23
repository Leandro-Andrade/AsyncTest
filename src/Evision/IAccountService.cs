using System.Threading.Tasks;

namespace Evision
{
    public interface IAccountService
    {
        Task<double> GetAccountAmountAsync(int accountId);
    }
}