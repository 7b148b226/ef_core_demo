namespace ef_6_with_.net_4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Infos",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Field1 = c.String(maxLength: 4),
                        Field2 = c.String(maxLength: 64),
                        Field3 = c.String(maxLength: 1024),
                        Field4 = c.String(maxLength: 4000),
                        Field5 = c.String(),
                        Field6 = c.Boolean(nullable: false),
                        Field7 = c.Byte(nullable: false),
                        Field8 = c.Short(nullable: false),
                        Field9 = c.Int(nullable: false),
                        Field10 = c.Long(nullable: false),
                        Field11 = c.Decimal(nullable: false, precision: 4, scale: 2),
                        Field12 = c.Decimal(nullable: false, precision: 9, scale: 5),
                        Field13 = c.Decimal(nullable: false, precision: 19, scale: 10),
                        Field14 = c.Decimal(nullable: false, precision: 38, scale: 19),
                        Field15 = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Infos");
        }
    }
}
