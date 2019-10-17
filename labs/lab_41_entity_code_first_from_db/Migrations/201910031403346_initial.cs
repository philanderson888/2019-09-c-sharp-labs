namespace lab_41_entity_code_first_from_db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Batch",
                c => new
                    {
                        BatchId = c.Int(nullable: false, identity: true),
                        OrangeID = c.Int(),
                        Quantity = c.Int(),
                        DespatchDate = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.BatchId)
                .ForeignKey("dbo.Oranges", t => t.OrangeID)
                .Index(t => t.OrangeID);
            
            CreateTable(
                "dbo.Oranges",
                c => new
                    {
                        OrangeId = c.Int(nullable: false, identity: true),
                        OrangeName = c.String(maxLength: 50),
                        DateHarvested = c.DateTime(storeType: "date"),
                        IsLuxuryGrade = c.Boolean(),
                        CategoryId = c.Int(),
                        MaxOrangesPerCrate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrangeId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Oranges", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Batch", "OrangeID", "dbo.Oranges");
            DropIndex("dbo.Oranges", new[] { "CategoryId" });
            DropIndex("dbo.Batch", new[] { "OrangeID" });
            DropTable("dbo.Categories");
            DropTable("dbo.Oranges");
            DropTable("dbo.Batch");
        }
    }
}
