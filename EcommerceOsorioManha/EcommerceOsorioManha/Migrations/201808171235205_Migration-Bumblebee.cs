namespace EcommerceOsorioManha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationBumblebee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemVendas",
                c => new
                    {
                        ItemVendaId = c.Int(nullable: false, identity: true),
                        Qtd = c.Int(nullable: false),
                        Preco = c.Int(nullable: false),
                        DataEntrega = c.DateTime(nullable: false),
                        Produto_ProdutoId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemVendaId)
                .ForeignKey("dbo.Produtos", t => t.Produto_ProdutoId)
                .Index(t => t.Produto_ProdutoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemVendas", "Produto_ProdutoId", "dbo.Produtos");
            DropIndex("dbo.ItemVendas", new[] { "Produto_ProdutoId" });
            DropTable("dbo.ItemVendas");
        }
    }
}
