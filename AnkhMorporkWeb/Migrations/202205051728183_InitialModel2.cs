﻿namespace AnkhMorporkWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Players", "LastMeeting", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Players", "LastMeeting", c => c.String(nullable: false));
        }
    }
}
