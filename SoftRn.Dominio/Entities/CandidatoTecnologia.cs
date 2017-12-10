namespace Exercicio3.Dominio.Entities
{

    /// <summary>
    /// Tabela para fazer o vinculo do candidato as tecnologias que ele conhece
    /// </summary>
    public class CandidatoTecnologia
    {
        /// <summary>
        /// Chave Primaria
        /// </summary>
        public int CandidatoTecnologiaId { get; set; }

        /// <summary>
        /// Chave estrangeira para a tabela Tecnologia
        /// </summary>
        public int TecnologiaId { get; set; }
        public virtual Tecnologia Tecnologia { get; set; }

        /// <summary>
        /// Chave estrangeira para a tabela Candidato
        /// </summary>
        public int CanditadoId { get; set; }
        public virtual Candidato Candidato { get; set; }
    }
}
