namespace AnkhMorporkWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFools : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Fools (Type, Fee) VALUES ('Muggins', 0.5)");
            Sql("INSERT INTO Fools (Type, Fee) VALUES ('Gull', 1.0)");
            Sql("INSERT INTO Fools (Type, Fee) VALUES ('Dupe', 2.0)");
            Sql("INSERT INTO Fools (Type, Fee) VALUES ('Butt', 3.0)");
            Sql("INSERT INTO Fools (Type, Fee) VALUES ('Fool', 5.0)");
            Sql("INSERT INTO Fools (Type, Fee) VALUES ('Tomfool', 6.0)");
            Sql("INSERT INTO Fools (Type, Fee) VALUES ('Stupid Fool', 7.0)");
            Sql("INSERT INTO Fools (Type, Fee) VALUES ('Arch Fool', 8.0)");
            Sql("INSERT INTO Fools (Type, Fee) VALUES ('Complete Fool', 10.0)");
        }
        
        public override void Down()
        {
        }
    }
}
