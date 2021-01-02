namespace E_CommerceSystemWithRestAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "OfferId", "dbo.Offers");
            DropIndex("dbo.Products", new[] { "OfferId" });
            AlterColumn("dbo.Products", "DeletedAt", c => c.DateTime());
            AlterColumn("dbo.Products", "OfferId", c => c.Int());
            CreateIndex("dbo.Products", "OfferId");
            AddForeignKey("dbo.Products", "OfferId", "dbo.Offers", "OfferId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "OfferId", "dbo.Offers");
            DropIndex("dbo.Products", new[] { "OfferId" });
            AlterColumn("dbo.Products", "OfferId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "DeletedAt", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Products", "OfferId");
            AddForeignKey("dbo.Products", "OfferId", "dbo.Offers", "OfferId", cascadeDelete: true);
        }
    }
}
