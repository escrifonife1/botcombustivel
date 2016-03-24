using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotCombustivel
{
    public class AllCams
    {
        public AllCams() { }

        public string GetQuerystringConcatenated()
        {
            var all = GetAll();
            var query = string.Empty;
            foreach (var camera in all)
            {
                query += camera._queryString + "|";
            }

            return query;
        }

        public List<Camera> GetAll()
        {
            var camList = new List<Camera>();

            camList.Add(new Camera(
                queryString: "Complexo+Lagoinha+Belo+Horizonte",
                urlCamera: "http://infotrafego.pbh.gov.br/rlt/images/camara01.jpg",
                name: "Complexo Lagoinha",
                address: ""
            ));

            camList.Add(new Camera(
                queryString: "Avenida+do+Contorno+Viaduto+Leste+Belo+Horizonte",
                urlCamera: "http://infotrafego.pbh.gov.br/rlt/images/camara02.jpg",
                name: "Avenida do Contorno Viaduto Leste",
                address: ""
            ));

            camList.Add(new Camera(
                queryString: "Avenida+Contorno+esquina+com+Avenida+dos+Andradas+Belo+Horizonte",
                urlCamera: "http://infotrafego.pbh.gov.br/rlt/images/camara03.jpg",
                name: "Avenida do Contorno esquina com Avenida dos Andradas",
                address: ""
            ));

            camList.Add(new Camera(
                queryString: "Avenida+Santos+Dummont+esquina+com+rua+Curitiba+Belo+Horizonte",
                urlCamera: "http://infotrafego.pbh.gov.br/rlt/images/camara04.jpg",
                name: "Avenida Santos Dummont esquina com Rua Curitiba",
                address: ""
            ));

            camList.Add(new Camera(
                queryString: "Rua+da+Bahia+esquina+com+rua+dos+Caetés+Belo+Horizonte",
                urlCamera: "http://infotrafego.pbh.gov.br/rlt/images/camara05.jpg",
                name: "Rua da Bahia esquina com Rua dos Caetés",
                address: ""
            ));

            camList.Add(new Camera(
                queryString: "Praça+Sete+Belo+Horizonte",
                urlCamera: "http://infotrafego.pbh.gov.br/rlt/images/camara06.jpg",
                name: "Praça Sete",
                address: ""
            ));

            camList.Add(new Camera(
                queryString: "Viadutp+Helena+Greco+Belo+Horizonte",
                urlCamera: "http://infotrafego.pbh.gov.br/rlt/images/camara07.jpg",
                name: "Viaduto Helena Greco",
                address: ""
            ));

            camList.Add(new Camera(
                queryString: "Avenida+do+Contorno+Barro+Preto+Belo+Horizonte",
                urlCamera: "http://infotrafego.pbh.gov.br/rlt/images/camara08.jpg",
                name: "Avenida do Contorno, Barro Preto Belo+Horizonte",
                address: ""
            ));

            camList.Add(new Camera(
                queryString: "Avenida+Amazonas+esquina+com+rua+são+paulo+Belo+Horizonte",
                urlCamera: "http://infotrafego.pbh.gov.br/rlt/images/camara10.jpg",
                name: "Avenida Amazonas esquina com rua São Paulo",
                address: ""
            ));

            camList.Add(new Camera(
               queryString: "Avenida+Amazonas+esquina+rua+Santa+Catarina+Belo+Horizonte",
               urlCamera: "http://infotrafego.pbh.gov.br/rlt/images/camara11.jpg",
               name: "Avenida+Amazonas+esquina+rua+Santa+Catarina+Belo+Horizonte",
               address: ""
           ));

            camList.Add(new Camera(
               queryString: "Praça+Afonso+Arinos+Belo+Horizonte",
               urlCamera: "http://infotrafego.pbh.gov.br/rlt/images/camara12.jpg",
               name: "Praça+Afonso+Arinos+Belo+Horizonte",
               address: ""
            ));

            camList.Add(new Camera(
                queryString: "Avenida+Amazonas+esquina+Rio+Grande+do+Sul+Belo+Horizonte",
                urlCamera: "http://infotrafego.pbh.gov.br/rlt/images/camara13.jpg",
                name: "Avenida+Amazonas+esquina+Rio+Grande+do+Sul",
                address: ""
             ));

            camList.Add(new Camera(
                queryString: "Avenida+Amazonas+esquina+com+Avenida+do+Contorno+Belo+Horizonte",
                urlCamera: "http://infotrafego.pbh.gov.br/rlt/images/camara14.jpg",
                name: "Avenida+Amazonas+esquina+com+Avenida+do+Contorno+Belo+Horizonte",
                address: ""
             ));

            camList.Add(new Camera(
                queryString: "Avenida+Bias+fortes+esquina+com+rua+da+Bahia+Belo+Horizonte",
                urlCamera: "http://infotrafego.pbh.gov.br/rlt/images/camara15.jpg",
                name: "Avenida+Bias+fortes+esquina+com+rua+da+Bahia+belo+horizonte",
                address: ""
             ));

            camList.Add(new Camera(
                queryString: "Praça+da+Liberdade+Belo+Horizonte",
                urlCamera: "http://infotrafego.pbh.gov.br/rlt/images/camara16.jpg",
                name: "Praça+da+Liberdade+Belo+Horizonte",
                address: ""
             ));

            camList.Add(new Camera(
                queryString: "Praça+da+Assembléia+Belo+Horizonte",
                urlCamera: "http://infotrafego.pbh.gov.br/rlt/images/camara17.jpg",
                name: "Praça+da+Assembléia+Belo+Horizonte",
                address: ""
             ));

            camList.Add(new Camera(
                queryString: "Avenida+do+Contorno+esquina+com+Avenida+Raja+Gabaglia+Belo+Horizonte",
                urlCamera: "http://infotrafego.pbh.gov.br/rlt/images/camara18.jpg",
                name: "Avenida+do+Contorno+esquina+com+Avenida+Raja+Gabaglia+Belo+Horizonte",
                address: ""
             ));

            camList.Add(new Camera(
                queryString: "Avenida+Nossa+Senhora+do+Carmo+esquina+com+Rua+Uruguai+Belo+Horizonte",
                urlCamera: "http://infotrafego.pbh.gov.br/rlt/images/camara19.jpg",
                name: "Avenida+Nossa+Senhora+do+Carmo+esquina+com+Rua+Uruguai+Belo+Horizonte",
                address: ""
             ));

            camList.Add(new Camera(
                queryString: "Praça+Milton+Campos+Belo+Horizonte",
                urlCamera: "http://infotrafego.pbh.gov.br/rlt/images/camara20.jpg",
                name: "Praça+Milton+Campos+Belo+Horizonte",
                address: ""
             ));

            camList.Add(new Camera(
                queryString: "Avenida+Nossa+Senhora+do+Carmo+esquina+com+Avenida+do+contorno+Belo+Horizonte",
                urlCamera: "http://infotrafego.pbh.gov.br/rlt/images/camara21.jpg",
                name: "Avenida+Nossa+Senhora+do+Carmo+esquina+com+Avenida+do+contorno+Belo+Horizonte",
                address: ""
             ));

            camList.Add(new Camera(
                queryString: "Avenida+Cristovão+colombo+esquina+com+Rua+alagoas+Belo+Horizonte",
                urlCamera: "http://infotrafego.pbh.gov.br/rlt/images/camara22.jpg",
                name: "Avenida+Cristovão+colombo+esquina+com+Rua+alagoas",
                address: ""
             ));


            camList.Add(new Camera(
               queryString: "Praça+Raul+Soares+Belo+Horizonte",
               urlCamera: "http://infotrafego.pbh.gov.br/rlt/images/camara23.jpg",
               name: "Praça+Raul+Soares",
               address: ""
            ));

            camList.Add(new Camera(
               queryString: "Avenida+Bias+Fortes+esquina+com+Avenida+Alvares+Cabral+Belo+Horizonte",
               urlCamera: "http://infotrafego.pbh.gov.br/rlt/images/camara25.jpg",
               name: "Avenida+Bias+Fortes+esquina+com+Avenida+Alvares+Cabral",
               address: ""
            ));

            return camList;
        }


    }
}
