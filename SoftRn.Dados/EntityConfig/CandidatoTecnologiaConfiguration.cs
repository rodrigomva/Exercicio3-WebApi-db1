using System.Data.Entity.ModelConfiguration;
using Exercicio3.Dominio.Entities;

namespace Exercicio3.Dados.EntityConfig
{
    public class CandidatoTecnologiaConfiguration : EntityTypeConfiguration<CandidatoTecnologia>
    {
        public CandidatoTecnologiaConfiguration()
        {
            //Chave Primaria
            HasKey(p => p.CandidatoTecnologiaId);

            HasRequired(p => p.Candidato)
                .WithMany()
                .HasForeignKey(p => p.CanditadoId);

            //Chave estragenira para Tecnologia
            HasRequired(p => p.Tecnologia)
                .WithMany()
                .HasForeignKey(p => p.TecnologiaId);
        }
    }
}
