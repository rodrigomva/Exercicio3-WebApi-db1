using System.Collections.Generic;
using Exercicio3.Dominio.Entities;

namespace Exercicio3.Dominio.Interfaces.Services
{
    public interface ICandidatoTecnologiaService : IServiceBase<CandidatoTecnologia>
    {
        /// <summary>
        /// Buscar as tecnologia por candidado
        /// <param name="id">ID do Candidato</param>
        /// </summary>
        IEnumerable<CandidatoTecnologia> BuscarPorCandidato(int id);
    }
}
