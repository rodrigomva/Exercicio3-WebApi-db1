using System.Collections.Generic;

namespace Exercicio3.Dominio.Entities
{
    /// <summary>
    /// Tabela para registrar os candidatos das vagas
    /// </summary>
    public class Candidato
    {
        /// <summary>
        /// Chave Primaria
        /// </summary>
        public int CandidatoId { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// Chave estrangeira para a tabela Vaga
        /// </summary>
        public int VagaId { get; set; }
        public virtual Vaga Vaga { get; set; }

        ///<summary>
        /// Lista das tecnologias que o candidato tem conhecimento
        /// </summary>
        public virtual IEnumerable<CandidatoTecnologia> Tecnologias { get; set; }
    }
}
