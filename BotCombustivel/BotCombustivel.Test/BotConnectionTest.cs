using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BotCombustivel.Test
{
    [TestClass]
    public class BotConnectionTest
    {
        [TestMethod]
        public async Task TestConnection()
        {
            var botConnection = new BotConnection();
            await botConnection.Connect(new MessageReceiver());
        }
    }
}
