using Dominio.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Teste.Application.Interface;

namespace Teste.Application.Service
{
    public class CidadeService : ICidadeService
    {
        private const string urlGetCidades = "http://wsteste.devedp.com.br/Master/CidadeServico.svc/rest/BuscaTodasCidades";
        private const string urlPostBuscaPontos = "http://wsteste.devedp.com.br/Master/CidadeServico.svc/rest/BuscaPontos";

        public CidadeService()
        {

        }

        public List<Cidade> ListarCidadesPorNomeEstado(Cidade cidade)
        {
            string jsonRetornoCidades = string.Empty;

            using (WebClient client = new WebClient())
            {
                client.Encoding = System.Text.Encoding.UTF8;
                client.Headers["Content-Type"] = "application/json";

                jsonRetornoCidades = client.DownloadString(urlGetCidades);
            }

            var lista = JsonConvert.DeserializeObject<List<Cidade>>(jsonRetornoCidades)
                        .Where(x => x.Nome.Contains(string.IsNullOrWhiteSpace(cidade.Nome) ? "" : cidade.Nome) 
                                    && x.Estado.Contains(string.IsNullOrWhiteSpace(cidade.Estado) ? "" : "")).ToList();

            return lista;
        }

        public IEnumerable<Cidade> ListarCidades()
        {
            string jsonRetornoCidades = string.Empty;

            using (WebClient client = new WebClient())
            {
                client.Encoding = System.Text.Encoding.UTF8;
                client.Headers["Content-Type"] = "application/json";

                jsonRetornoCidades = client.DownloadString(urlGetCidades);
            }

            var lista = JsonConvert.DeserializeObject<List<Cidade>>(jsonRetornoCidades);

            return lista;
        }

        public string PontuacaoCidadePorNomeEEstado(Cidade cidade)
        {
            string pontuacaoRetorno = string.Empty;
            string jsonData = JsonConvert.SerializeObject(cidade);

            using (WebClient client = new WebClient())
            {
                //client.Encoding = System.Text.Encoding.UTF8;
                //client.Headers["Content-Type"] = "application/json";

                pontuacaoRetorno = client.UploadString(urlPostBuscaPontos, jsonData);
            }

            return pontuacaoRetorno;
        }

    }
}
