using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xbehave;
using Xunit;

namespace Evision.Tests.Integration
{
    public class AccountInfoFeature
    {
        [Scenario]
        public void CallToRefreshAmountAsync_ShouldInFactRunAsynchronously()
        {
            List<AccountInfo> sutList = null;
            var startTime = DateTime.MinValue;
            var endTime = DateTime.MinValue;
            const int minElapsedTime = 5;
            const int maxElapsedTime = 6;

            "Given I have ten distinct instances of AccountInfo"
                .x(() => sutList = CreateInstances());

            "When I refresh the Account Amount from all ten instances"
                .x(() =>
                {
                    startTime = DateTime.Now;
                    var tasks = new List<Task>();
                    sutList.ForEach(x => { tasks.Add(Task.Run(x.RefreshAmountAsync)); });
                    Task.WaitAll(tasks.ToArray());
                    endTime = DateTime.Now;
                });

            "Then the time elapsed time should be about 5 seconds(less than 6)"
                .x(() => Assert.InRange(CalculateTimespanInSeconds(startTime, endTime), minElapsedTime, maxElapsedTime));
        }

        private static List<AccountInfo> CreateInstances()
        {
            var accountInfoList = new List<AccountInfo>();
            for (var i = 1; i <= 10; i++)
            {
                accountInfoList.Add(new AccountInfo(i, new AccountService()));
            }

            return accountInfoList;
        }

        private static double CalculateTimespanInSeconds(DateTime startTime, DateTime endTime)
        {
            var totalSeconds = Math.Round((endTime - startTime).TotalSeconds, 2);
            return totalSeconds;
        }
    }
}
