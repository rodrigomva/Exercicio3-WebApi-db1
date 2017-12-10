using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Exercicio3.Dados.EntityConfig;
using Exercicio3.Dominio.Entities;

namespace Exercicio3.Dados.Context
{
    public class Exercicio3Context : DbContext
    {
        public Exercicio3Context()
            : base("ConexaoRh")
        {
            
        }

        //Tabelas do banco de dados
        public DbSet<Tecnologia> Tecnologias { get; set; }
        public DbSet<Vaga> Vagas { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<CandidatoTecnologia> CandidatoTecnologia { get; set; }
        public DbSet<VagaPeso> VagaPesos { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));


            //Configuração das Tabelas
            modelBuilder.Configurations.Add(new TecnologiaConfiguration());
            modelBuilder.Configurations.Add(new VagaConfiguration());
            modelBuilder.Configurations.Add(new VagaPesoConfiguration());
            modelBuilder.Configurations.Add(new CandidatoConfiguration());
            modelBuilder.Configurations.Add(new CandidatoTecnologiaConfiguration());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                //Salvar a data de cadastro
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
