using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Exercicio3.Mvc.ViewModel
{
    /// <summary>
    /// Tabela para gravar as vagas da empresa
    /// </summary>
    public class VagaViewModel
    {
        /// <summary>
        /// Chave Primaria
        /// </summary>
        public int VagaId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [MaxLength(250, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string Descricao { get; set; }

        /// <summary>
        /// Campo informa se a vaga está encerrada
        /// </summary>
        public bool Encerrado { get; set; }

        /// <summary>
        /// Lista de Todos os candidatos para essa vaga
        /// </summary>
        public virtual IEnumerable<CandidatoViewModel> Candidatos { get; set; }

        /// <summary>
        /// Lista dos pesos de cada tecnologia para essa vaga
        /// </summary>
        public virtual IEnumerable<VagaPesoViewModel> Pesos { get; set; }

        /// <summary>
        /// Campo informa o total de candidatos para esta vaga
        /// </summary>
        public int TotalCandidatos { get; set; }
    }
}