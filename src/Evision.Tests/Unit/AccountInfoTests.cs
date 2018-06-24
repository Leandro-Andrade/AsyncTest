using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;

namespace Evision.Tests.Unit
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

            var sut = new AccountInfo(accountId, accountServiceMock);
            Assert.Equal(0, sut.Amount);

            await sut.RefreshAmountAsync();
            Assert.Equal(expectedAmountAfterRefresh, sut.Amount);
        }
    }
}
