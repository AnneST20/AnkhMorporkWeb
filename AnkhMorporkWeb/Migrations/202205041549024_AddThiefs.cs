namespace AnkhMorporkWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddThiefs : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Thiefs (Fee) VALUES (10.0)");
        }
        
        public override void Down()
        {
        }
    }
}
