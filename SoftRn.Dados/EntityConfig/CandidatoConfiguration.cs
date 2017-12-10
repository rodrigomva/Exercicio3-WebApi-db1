using System.Data.Entity.ModelConfiguration;
using Exercicio3.Dominio.Entities;

namespace Exercicio3.Dados.EntityConfig
{
    public class CandidatoConfiguration : EntityTypeConfiguration<Candidato>
    {
        public CandidatoConfiguration()
        {
            //Chave Primaria
            HasKey(p => p.CandidatoId);

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100);

            //Chave estragenira para Vaga
            HasRequired(p => p.Vaga)
                .WithMany()
                .HasForeignKey(p => p.VagaId);
        }
    }
}
