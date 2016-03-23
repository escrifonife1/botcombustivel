using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Takenet.MessagingHub.Client;

namespace BotCombustivel
{
    public class BotConnection
    {
        public async Task Connect()
        {
            const string login = "BOTCOMBUSTIVEL"; //Identificador da aplicação
            const string accessKey = "OVJ1MGRs"; //Chave de acesso da aplicação
            var client = new MessagingHubClientBuilder()
                .UsingAccessKey(login, accessKey)
                .WithSendTimeout(TimeSpan.FromSeconds(20))
                .Build();
            var messageText = "It is working bitch!";
            try
            {
                await client.StartAsync();

                await client.SendMessageAsync(messageText, to: login);

                using (var cancellationToken = new CancellationTokenSource(TimeSpan.FromSeconds(30)))
                {
                    var message = await client.ReceiveMessageAsync(cancellationToken.Token);

                    if (!message.Content.ToString().Equals(messageText))
                    {
                        throw new Exception("Não funcionou");
                    }
                }

                await client.StopAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
