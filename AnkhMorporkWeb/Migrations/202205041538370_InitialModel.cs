namespace AnkhMorporkWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assassins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MinReward = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaxReward = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Beggars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Fee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Beer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Fee = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Money = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Beer = c.Int(nullable: false),
                        MeetingsWithThief = c.Int(nullable: false),
                        CurrentGuild = c.Int(nullable: false),
                        LastMeeting = c.String(nullable: false),
                        CurrentMeeting = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Thiefs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fee = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Thiefs");
            DropTable("dbo.Players");
            DropTable("dbo.Fools");
            DropTable("dbo.Beggars");
            DropTable("dbo.Assassins");
        }
    }
}
