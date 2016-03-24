using Lime.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Takenet.MessagingHub.Client;
using Takenet.MessagingHub.Client.Receivers;

namespace BotCombustivel
{
    public class PlainTextMessageReceiver : MessageReceiverBase
    {
        /*public override async Task ReceiveAsync(Message message)
        {
            var webClient = new WebClient();
            webClient.Headers.Add("Content-Type", "application/json");
            webClient.Headers.Add("OSLC-Core-Version", "2.0");
            var buscaJson = webClient.DownloadString($"http://api.meuspostos.com.br/busca.json?chave=" + message.Content.ToString());
            var busca = Newtonsoft.Json.JsonConvert.DeserializeObject<Buscar.RootObject>(buscaJson);
            */
            /*
             //Regiões
            var regioesStr = webClient.DownloadString($"http://api.meuspostos.com.br/regioes.json");
            var regioes = Newtonsoft.Json.JsonConvert.DeserializeObject<Regioes.RootObject>(regioesStr);
            */
            /*await EnvelopeSender.SendMessageAsync($"Recebido {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}", message.From);
            
            Console.WriteLine($"From: {message.From} \tContent: {message.Content}");
            
            //await EnvelopeSender.SendMessageAsync("Pong!", message.From);
            await EnvelopeSender.SendNotificationAsync(message.ToConsumedNotification());
        }*/

        public override async Task ReceiveAsync(Message message)
        {
             var searchCity = new SearchCity();

             await EnvelopeSender.SendMessageAsync($"Recebido {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}", message.From);

            Console.WriteLine($"From: {message.From} \tContent: {message.Content}");

            //await EnvelopeSender.SendMessageAsync("Pong!", message.From);
            await EnvelopeSender.SendNotificationAsync(message.ToConsumedNotification());
        }
    }

    public class SearchCity : SearchBase
    {
        public void Search(Message message)
        {
            
            var buscaJson = Client.DownloadString($"http://api.meuspostos.com.br/busca.json?chave=" + message.Content.ToString());
            var busca = Newtonsoft.Json.JsonConvert.DeserializeObject<Buscar.RootObject>(buscaJson);

            if (busca.data.busca.Any())
            {
                foreach (var b in busca.data.busca)
                {
                    var postosJson =
                        Client.DownloadString($"http://api.meuspostos.com.br/posto.json?posto=" + b.posto);
                    var posto = Newtonsoft.Json.JsonConvert.DeserializeObject<Postos.RootObject>(buscaJson);
                }
            }
        }
    }

    public abstract class SearchBase
    {
        public WebClient Client { get; private set; }

        protected SearchBase()
        {
            Client = new WebClient();
            Client.Headers.Add("Content-Type", "application/json");
            Client.Headers.Add("OSLC-Core-Version", "2.0");
        }

        
    }
}
