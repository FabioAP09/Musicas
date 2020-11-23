namespace Radio.Musicas.Dados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracaoEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Musica", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Musica", "Email");
        }
    }
}
