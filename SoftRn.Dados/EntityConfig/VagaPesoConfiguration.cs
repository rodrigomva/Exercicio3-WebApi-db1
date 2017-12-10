using System.Data.Entity.ModelConfiguration;
using Exercicio3.Dominio.Entities;

namespace Exercicio3.Dados.EntityConfig
{
    public class VagaPesoConfiguration : EntityTypeConfiguration<VagaPeso>
    {
        public VagaPesoConfiguration()
        {
            //Chave Primaria
            HasKey(c => c.VagaPesoId);

            //Chave estragenira para Tecnologia
            HasRequired(p => p.Tecnologia)
                .WithMany()
                .HasForeignKey(p => p.TecnologiaId);

            //Chave estragenira para Vaga
            HasRequired(p => p.Vaga)
                .WithMany()
                .HasForeignKey(p => p.VagaId);
        }
    }
}
