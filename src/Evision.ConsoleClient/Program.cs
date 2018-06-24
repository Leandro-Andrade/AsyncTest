using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evision.IntegrationTestClient.ServiceStub;

namespace Evision.IntegrationTestClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var userCmd = "";
            StartTextAndAskForCommand();
            while (true)
            {
                if (userCmd != null && userCmd.ToLower() == Commands.Out)
                    break;

                PrintStandby();
                userCmd = Console.ReadLine();
                CommandHandler(userCmd);
            }
        }

        private static void StartTextAndAskForCommand()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\n--- Wellcome to the Evision Test ---\n");
            Console.ResetColor();

            Console.WriteLine("Command List:");
            Console.WriteLine("[run]: Execute the test");
            Console.WriteLine("[out]: Quit this application");
        }

        private static void PrintStandby()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n\nType a command>: ");
            Console.ResetColor();
        }

        private static void CommandHandler(string userCmd)
        {
            if(userCmd.ToLower() == Commands.Run)
                RunTest();
            else
                Console.Write("Unknown command: {0}", userCmd);
        }

        private static void RunTest()
        {
            Console.WriteLine("\nDescription:");
            Console.WriteLine("This integration test call multiple instances of AccountInfo each of them invoking RefreshAmountAsync()");
            Console.WriteLine("Inside RefreshAmountAsync() there is a delay of 5 seconds.");
            Console.WriteLine("This test consists of 10 calls to RefreshAmountAsync().");
            Console.WriteLine("If it was done sincronously, it should take about 50 seconds");
            Console.WriteLine("By runing this you should expect the test to be completed in about 5 seconds instead, since it handles concurrent calls and do it assyncronously");

            var startTime = DateTime.Now;
            Console.WriteLine("\nStarting at: {0}", startTime);

            var accountInfoList = new List<AccountInfo>();
            for (var i = 1; i <= 10; i++)
            {
                accountInfoList.Add(new AccountInfo(i, new AccountServiceStub()));
            }

            var tasks = new List<Task>();
            accountInfoList.ForEach(x =>
            {
                tasks.Add(Task.Run(x.RefreshAmountAsync));
            });

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine();
            accountInfoList.ForEach(x =>
            {
                Console.WriteLine("User Id: {0}, Amount: {1}", 1, x.Amount);
            });

            var endTime = DateTime.Now;
            Console.Write("\nFinished at: {0}", endTime);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nThe test took around: {0} seconds to complete", CalculateTimespanInSeconds(endTime, startTime));
            Console.ResetColor();
        }

        private static double CalculateTimespanInSeconds(DateTime endTime, DateTime startTime)
        {
            return Math.Round((endTime - startTime).TotalSeconds, 2);
        }
    }
}