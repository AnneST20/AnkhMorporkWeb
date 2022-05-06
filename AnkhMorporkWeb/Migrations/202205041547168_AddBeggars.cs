namespace AnkhMorporkWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBeggars : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Beggars (Type, Fee, Beer) VALUES ('Twitchers', 3.0, 0)");
            Sql("INSERT INTO Beggars (Type, Fee, Beer) VALUES ('Droolers', 2.0, 0)");
            Sql("INSERT INTO Beggars (Type, Fee, Beer) VALUES ('Dribblers', 1.0, 0)");
            Sql("INSERT INTO Beggars (Type, Fee, Beer) VALUES ('Mumblers', 1.0, 0)");
            Sql("INSERT INTO Beggars (Type, Fee, Beer) VALUES ('Mutterers', 0.9, 0)");
            Sql("INSERT INTO Beggars (Type, Fee, Beer) VALUES ('Walking-Along-Shouters', 0.8, 0)");
            Sql("INSERT INTO Beggars (Type, Fee, Beer) VALUES ('Demanders of a Chip', 0.6, 0)");
            Sql("INSERT INTO Beggars (Type, Fee, Beer) VALUES ('People Who Call Other People Jimmy', 0.5, 0)");
            Sql("INSERT INTO Beggars (Type, Fee, Beer) VALUES ('People Who Need Eightpence For A Meal', 0.08, 0)");
            Sql("INSERT INTO Beggars (Type, Fee, Beer) VALUES ('People Who Need Tuppence For A Cup Of Tea', 0.02, 0)");
            Sql("INSERT INTO Beggars (Type, Fee, Beer) VALUES ('People With Placards Saying That They Need A Beer', 0.0, 1)");
        }
        
        public override void Down()
        {
        }
    }
}
