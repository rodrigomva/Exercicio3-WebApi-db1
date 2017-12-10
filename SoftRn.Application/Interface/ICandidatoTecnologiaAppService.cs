using System.Collections.Generic;
using Exercicio3.Dominio.Entities;

namespace Exercicio3.Application.Interface
{
    public interface ICandidatoTecnologiaAppService : IAppServiceBase<CandidatoTecnologia>
    {
        /// <summary>
        /// Buscar as tecnologia por candidado
        /// <param name="id">ID do Candidato</param>
        /// </summary>
        IEnumerable<CandidatoTecnologia> BuscarPorCandidato(int id);
    }
}
