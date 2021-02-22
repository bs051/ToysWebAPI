namespace ToysWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class toy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Toys",
                c => new
                    {
                        ToyId = c.Int(nullable: false, identity: true),
                        ToyName = c.String(),
                        ToyManufacturer = c.String(),
                        ToyColor = c.String(),
                        ToyPrice = c.Double(nullable: false),
                        AgeGroup = c.String(),
                    })
                .PrimaryKey(t => t.ToyId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Toys");
        }
    }
}
