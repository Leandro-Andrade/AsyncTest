using System;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;

namespace Evision.Tests
{
    public class AccountInfoTests
    {
        [Fact]
        public async Task Invoking_RefreshAmountAsync_should_update_property_Amount()
        {
            const int accountId = 1;
            var accountServiceMock = Substitute.For<IAccountService>();
            accountServiceMock.GetAccountAmountAsync(accountId).Returns(100);

            var accountInfo = new AccountInfo(accountId, accountServiceMock);
            Assert.Equal(0, accountInfo.Amount);

            await accountInfo.RefreshAmountAsync();

            Assert.Equal(100, accountInfo.Amount);
        }
    }
}
