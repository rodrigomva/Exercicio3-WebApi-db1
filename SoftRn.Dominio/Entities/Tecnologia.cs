namespace Exercicio3.Dominio.Entities
{
    /// <summary>
    /// Tabela para gravar as tecnologias que a empresa tem
    /// </summary>
    public class Tecnologia
    {
        /// <summary>
        /// Chave Primaria
        /// </summary>
        public int TecnologiaId { get; set; }

        public string Nome { get; set; }
        public bool Status { get; set; }
    }
}
