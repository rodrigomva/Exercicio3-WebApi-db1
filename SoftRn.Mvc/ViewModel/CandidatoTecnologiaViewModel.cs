namespace Exercicio3.Mvc.ViewModel
{
    /// <summary>
    /// Tabela para fazer o vinculo do candidato as tecnologias que ele conhece
    /// </summary>
    public class CandidatoTecnologiaViewModel
    {
        /// <summary>
        /// Chave Primaria
        /// </summary>
        public int CandidatoTecnologiaId { get; set; }

        /// <summary>
        /// Chave estrangeira para a tabela Tecnologia
        /// </summary>
        public int TecnologiaId { get; set; }
        public virtual TecnologiaViewModel Tecnologia { get; set; }

        /// <summary>
        /// Chave estrangeira para a tabela Candidato
        /// </summary>
        public int CanditadoId { get; set; }
        public virtual CandidatoViewModel Candidato { get; set; }
    }
}