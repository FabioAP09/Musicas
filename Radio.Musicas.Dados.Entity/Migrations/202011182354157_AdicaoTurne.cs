namespace Radio.Musicas.Dados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicaoTurne : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Turne",
                c => new
                    {
                        IdTurne = c.Long(nullable: false, identity: true),
                        NomeTurne = c.String(name: "Nome Turne", nullable: false, maxLength: 100),
                        IdMusica = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdTurne)
                .ForeignKey("dbo.Musica", t => t.IdMusica, cascadeDelete: true)
                .Index(t => t.IdMusica);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Turne", "IdMusica", "dbo.Musica");
            DropIndex("dbo.Turne", new[] { "IdMusica" });
            DropTable("dbo.Turne");
        }
    }
}
