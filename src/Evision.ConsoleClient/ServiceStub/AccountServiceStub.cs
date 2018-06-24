using System.Threading.Tasks;

namespace Evision.IntegrationTestClient.ServiceStub
{
    public class AccountServiceStub : IAccountService
    {
        public async Task<double> GetAccountAmountAsync(int accountId)
        {
            var account = FakeAccountData.GetAccount(accountId);
            await Task.Delay(5000);

            return account.Amount;
        }
    }
}
