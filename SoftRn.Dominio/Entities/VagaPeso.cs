namespace Exercicio3.Dominio.Entities
{
    /// <summary>
    /// Tabela para informar o peso de cada tecnologia para cada vaga
    /// </summary>
    public class VagaPeso
    {
        /// <summary>
        /// Chave Primaria
        /// </summary>
        public int VagaPesoId { get; set; }

        /// <summary>
        /// Chave estrangeira da tabela vaga
        /// </summary>
        public int VagaId { get; set; }
        public virtual Vaga Vaga { get; set; }

        /// <summary>
        /// Chave estrangeira da tabela tecnologia
        /// </summary>
        public int TecnologiaId { get; set; }
        public virtual Tecnologia Tecnologia { get; set; }

        /// <summary>
        /// Campo para informar qual o peso dessa tecnologia para essa vaga
        /// </summary>
        public decimal Peso { get; set; }
    }
}
