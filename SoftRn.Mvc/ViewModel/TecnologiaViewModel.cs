using System.ComponentModel.DataAnnotations;

namespace Exercicio3.Mvc.ViewModel
{
    /// <summary>
    /// Tabela para gravar as tecnologias que a empresa tem
    /// </summary>
    public class TecnologiaViewModel
    {
        /// <summary>
        /// Chave Primaria
        /// </summary>
        public int TecnologiaId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string Nome { get; set; }

        public bool Status { get; set; }
    }
}