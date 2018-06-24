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
            const int expectedAmountAfterRefresh = 100;

            var accountServiceMock = Substitute.For<IAccountService>();
            accountServiceMock.GetAccountAmountAsync(accountId).Returns(expectedAmountAfterRefresh);

            var accountInfo = new AccountInfo(accountId, accountServiceMock);
            Assert.Equal(0, accountInfo.Amount);

            await accountInfo.RefreshAmountAsync();
            Assert.Equal(expectedAmountAfterRefresh, accountInfo.Amount);
        }
    }
}
