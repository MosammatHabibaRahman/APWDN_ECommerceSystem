namespace E_CommerceSystemWithRestAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderedIdFKMadeOptionalInOrderedItemTableRe : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderedItems", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderedItems", new[] { "OrderId" });
            AlterColumn("dbo.OrderedItems", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderedItems", "OrderId");
            AddForeignKey("dbo.OrderedItems", "OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderedItems", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderedItems", new[] { "OrderId" });
            AlterColumn("dbo.OrderedItems", "OrderId", c => c.Int());
            CreateIndex("dbo.OrderedItems", "OrderId");
            AddForeignKey("dbo.OrderedItems", "OrderId", "dbo.Orders", "OrderId");
        }
    }
}
