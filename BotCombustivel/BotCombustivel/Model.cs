using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotCombustivel
{
    public class Regioes
    {
        public class Cidade
        {
            public string cd_cidade { get; set; }
            public string nome { get; set; }
            public string nome_tela { get; set; }
            public string estado { get; set; }
            public string cd_regiao { get; set; }
            public string nome_regiao { get; set; }
            public string nome_tela_regiao { get; set; }
            public string cidade_sede { get; set; }
        }

        public class Regio
        {
            public string cd_regiao { get; set; }
            public string nome { get; set; }
            public string nome_tela { get; set; }
            public string cd_cidade_sede { get; set; }
            public string nome_cidade_sede { get; set; }
            public List<Cidade> cidades { get; set; }
        }

        public class Data
        {
            public List<Regio> regioes { get; set; }
            public string status { get; set; }
            public string detail { get; set; }
            public string resquest_uri { get; set; }
            public string created_at { get; set; }
            public string elapsed_time { get; set; }
        }

        public class RootObject
        {
            public Data data { get; set; }
        }
    }

    public class Buscar
    {
        public class Busca
        {
            public string posto { get; set; }
            public string nome { get; set; }
            public string endereco { get; set; }
            public string bairro { get; set; }
            public string dt_pesquisa { get; set; }
            public string bandeira { get; set; }
            public string icone { get; set; }
            public string gasolina { get; set; }
            public string in_gasolina { get; set; }
            public string alcool { get; set; }
            public string in_alcool { get; set; }
            public string diesel { get; set; }
            public string in_diesel { get; set; }
            public string gnv { get; set; }
            public string in_gnv { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public int distancia { get; set; }
        }

        public class Data
        {
            public IList<Busca> busca { get; set; }
            public string status { get; set; }
            public string detail { get; set; }
            public string resquest_uri { get; set; }
            public DateTime created_at { get; set; }
            public string elapsed_time { get; set; }
        }

        public class RootObject
        {
            public Data data { get; set; }
        }
    }

    public class Postos
    {
        public class Posto
        {
            public string posto { get; set; }
            public string nome { get; set; }
            public string telefone { get; set; }
            public string endereco { get; set; }
            public string bairro { get; set; }
            public string dt_pesquisa { get; set; }
            public string bandeira { get; set; }
            public string icone { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string gasolina { get; set; }
            public string nota_gasolina { get; set; }
            public string alcool { get; set; }
            public string in_alcool { get; set; }
            public string diesel { get; set; }
            public string in_diesel { get; set; }
            public string gnv { get; set; }
            public string in_gnv { get; set; }
            public string qt_nota1 { get; set; }
            public string qt_nota2 { get; set; }
            public string qt_nota3 { get; set; }
            public string qt_nota4 { get; set; }
            public string qt_nota5 { get; set; }
            public object comentarios { get; set; }
        }

        public class Data
        {
            public IList<Posto> postos { get; set; }
            public string status { get; set; }
            public string detail { get; set; }
            public string resquest_uri { get; set; }
            public DateTime created_at { get; set; }
            public string elapsed_time { get; set; }
        }

        public class RootObject
        {
            public Data data { get; set; }
        }

    }
}
