using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Exercicio3.Mvc.ViewModel
{
    /// <summary>
    /// Tabela para registrar os candidatos das vagas
    /// </summary>
    public class CandidatoViewModel
    {
        /// <summary>
        /// Chave Primaria
        /// </summary>
        public int CandidatoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um E-mail válido")]
        public string Email { get; set; }

        /// <summary>
        /// Chave estrangeira para a tabela Vaga
        /// </summary>
        public int VagaId { get; set; }
        public virtual VagaViewModel Vaga { get; set; }

        ///<summary>
        /// Lista das tecnologias que o candidato tem conhecimento
        /// </summary>
        public virtual IEnumerable<CandidatoTecnologiaViewModel> Tecnologias { get; set; }
    }
}