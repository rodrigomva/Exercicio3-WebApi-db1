using System.Collections.Generic;

namespace Exercicio3.Dominio.Entities
{
    /// <summary>
    /// Tabela para gravar as vagas da empresa
    /// </summary>
    public class Vaga
    {
        /// <summary>
        /// Chave Primaria
        /// </summary>
        public int VagaId { get; set; }

        public string Nome { get; set; }
        public string Descricao { get; set; }

        /// <summary>
        /// Campo informa se a vaga está encerrada
        /// </summary>
        public bool Encerrado { get; set; }

        /// <summary>
        /// Lista de Todos os candidatos para essa vaga
        /// </summary>
        public virtual IEnumerable<Candidato> Candidatos { get; set; }

        /// <summary>
        /// Lista dos pesos de cada tecnologia para essa vaga
        /// </summary>
        public virtual IEnumerable<VagaPeso> Pesos { get; set; }
    }
}
