namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TblCliente",
                c => new
                    {
                        nr_id = c.Int(nullable: false, identity: true),
                        nm_nome = c.String(nullable: false, maxLength: 50),
                        nr_cpf = c.String(nullable: false, maxLength: 11),
                        str_agencia = c.String(nullable: false, maxLength: 20),
                        str_conta = c.String(nullable: false, maxLength: 20),
                        str_estado = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.nr_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TblCliente");
        }
    }
}
