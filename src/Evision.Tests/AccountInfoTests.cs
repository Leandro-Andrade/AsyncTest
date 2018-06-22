using System;
using NSubstitute;
using Xunit;

namespace Evision.Tests
{
    public class AccountInfoTests
    {
        [Fact]
        public void Invoking_RefreshAmount_should_update_property_Amount()
        {
            const int accountId = 1;
            var accountServiceMock = Substitute.For<IAccountService>();
            accountServiceMock.GetAccountAmount(accountId).Returns(100);

            var accountInfo = new AccountInfo(accountId, accountServiceMock);
            Assert.Equal(0, accountInfo.Amount);

            accountInfo.RefreshAmount();

            Assert.Equal(100, accountInfo.Amount);
        }
    }
}
