using System.Data.Entity.ModelConfiguration;
using Exercicio3.Dominio.Entities;

namespace Exercicio3.Dados.EntityConfig
{
    public class VagaConfiguration : EntityTypeConfiguration<Vaga>
    {
        public VagaConfiguration()
        {
            //Chave Primaria
            HasKey(c => c.VagaId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}
