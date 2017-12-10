namespace Exercicio3.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addinicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidato",
                c => new
                    {
                        CandidatoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        VagaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CandidatoId)
                .ForeignKey("dbo.Vaga", t => t.VagaId)
                .Index(t => t.VagaId);
            
            CreateTable(
                "dbo.Vaga",
                c => new
                    {
                        VagaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 250, unicode: false),
                        Encerrado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VagaId);
            
            CreateTable(
                "dbo.CandidatoTecnologia",
                c => new
                    {
                        CandidatoTecnologiaId = c.Int(nullable: false, identity: true),
                        TecnologiaId = c.Int(nullable: false),
                        CanditadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CandidatoTecnologiaId)
                .ForeignKey("dbo.Candidato", t => t.CanditadoId)
                .ForeignKey("dbo.Tecnologia", t => t.TecnologiaId)
                .Index(t => t.TecnologiaId)
                .Index(t => t.CanditadoId);
            
            CreateTable(
                "dbo.Tecnologia",
                c => new
                    {
                        TecnologiaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TecnologiaId);
            
            CreateTable(
                "dbo.VagaPeso",
                c => new
                    {
                        VagaPesoId = c.Int(nullable: false, identity: true),
                        VagaId = c.Int(nullable: false),
                        TecnologiaId = c.Int(nullable: false),
                        Peso = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.VagaPesoId)
                .ForeignKey("dbo.Tecnologia", t => t.TecnologiaId)
                .ForeignKey("dbo.Vaga", t => t.VagaId)
                .Index(t => t.VagaId)
                .Index(t => t.TecnologiaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VagaPeso", "VagaId", "dbo.Vaga");
            DropForeignKey("dbo.VagaPeso", "TecnologiaId", "dbo.Tecnologia");
            DropForeignKey("dbo.CandidatoTecnologia", "TecnologiaId", "dbo.Tecnologia");
            DropForeignKey("dbo.CandidatoTecnologia", "CanditadoId", "dbo.Candidato");
            DropForeignKey("dbo.Candidato", "VagaId", "dbo.Vaga");
            DropIndex("dbo.VagaPeso", new[] { "TecnologiaId" });
            DropIndex("dbo.VagaPeso", new[] { "VagaId" });
            DropIndex("dbo.CandidatoTecnologia", new[] { "CanditadoId" });
            DropIndex("dbo.CandidatoTecnologia", new[] { "TecnologiaId" });
            DropIndex("dbo.Candidato", new[] { "VagaId" });
            DropTable("dbo.VagaPeso");
            DropTable("dbo.Tecnologia");
            DropTable("dbo.CandidatoTecnologia");
            DropTable("dbo.Vaga");
            DropTable("dbo.Candidato");
        }
    }
}
