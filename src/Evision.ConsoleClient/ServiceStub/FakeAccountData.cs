using System.Collections.Generic;
using System.Linq;

namespace Evision.IntegrationTestClient.ServiceStub
{
    public static class FakeAccountData
    {
        private static List<Account> _accounts => new List<Account>
        {
            new Account {Id = 1, Amount = 10},
            new Account {Id = 2, Amount = 20},
            new Account {Id = 3, Amount = 30},
            new Account {Id = 4, Amount = 40},
            new Account {Id = 5, Amount = 50},
            new Account {Id = 6, Amount = 60},
            new Account {Id = 7, Amount = 70},
            new Account {Id = 8, Amount = 80},
            new Account {Id = 9, Amount = 90},
            new Account {Id = 10, Amount = 100}
        };

        public static Account GetAccount(int id)
        {
            var account = _accounts.FirstOrDefault(x => x.Id == id);
            return account;
        }
    }
}
