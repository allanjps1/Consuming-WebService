using Dominio.Models;
using System.Collections.Generic;

namespace Teste.Application.Interface
{
    public interface ICidadeService
    {
        IEnumerable<Cidade> ListarCidades();
        List<Cidade> ListarCidadesPorNomeEstado(Cidade cidade);
        string PontuacaoCidadePorNomeEEstado(Cidade cidade);
    }
}
