using System.Data.Entity.ModelConfiguration;
using Exercicio3.Dominio.Entities;

namespace Exercicio3.Dados.EntityConfig
{
    public class TecnologiaConfiguration : EntityTypeConfiguration<Tecnologia>
    {
        public TecnologiaConfiguration()
        {
            //Chave Primaria
            HasKey(c => c.TecnologiaId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
