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
    public enum LocalMessageStatus
    {
        Start,
        AskedAdress,
        Question,
        Answer,
        Wrong
    }
    public class PlainTextMessageReceiver : MessageReceiverBase
    {
        private Dictionary<Node, LocalMessageStatus> _session;
        private ConsumerMapsApi _consumerMapsApi;

        public PlainTextMessageReceiver()
        {
            _session = new Dictionary<Node, LocalMessageStatus>();
            _consumerMapsApi=new ConsumerMapsApi();
        }

        public override async Task ReceiveAsync(Message message)
        {
            if (!_session.ContainsKey(message.From))
            {
                _session.Add(message.From, LocalMessageStatus.AskedAdress);
            }
            if (_session[message.From] == LocalMessageStatus.AskedAdress)
                {
                    var locations = await _consumerMapsApi.GetAddress(message.Content.ToString());
                    if (locations != null && locations.results.Any())
                    {
                        _session.Remove(message.From);
                        var addresses = string.Empty;
                        foreach (var address in locations.results)
                        {
                            addresses += $"\n{address.formatted_address}";
                        }

                        await EnvelopeSender.SendMessageAsync($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}\n{locations.results.Count()} endereços encontrados. {addresses}", message.From);

                        
                    }
                    else
                    {
                        await EnvelopeSender.SendMessageAsync($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}\nEndereço não encontrado\n\nInforme seu endereço atual", message.From);
                    }
                }

            
            //else
            //{
            //    _session.Add(message.From, LocalMessageStatus.AskedAdress);
            //    await EnvelopeSender.SendMessageAsync($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}\nInforme seu endereço atual", message.From);
            //}
         

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
