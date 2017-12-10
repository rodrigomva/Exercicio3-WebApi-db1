using System.Collections.Generic;
using Exercicio3.Dominio.Entities;

namespace Exercicio3.Application.Interface
{
    public interface ICandidatoAppService : IAppServiceBase<Candidato>
    {
        /// <summary>
        /// Buscar candidatos por vaga
        /// <param name="id">ID da Vaga</param>
        /// </summary>
        IEnumerable<Candidato> BuscarPorVaga(int id);

        /// <summary>
        /// Retorna a quantidade de Candidato para a vaga
        /// <param name="id">ID da Vaga</param>
        /// </summary>
        int QuantCandidatoPorVaga(int idVaga);
    }
}
