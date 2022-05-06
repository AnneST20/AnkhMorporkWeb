namespace AnkhMorporkWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAssassins : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Assassins (MinReward, MaxReward, IsActive) VALUES (1, 11, 1)");
            Sql("INSERT INTO Assassins (MinReward, MaxReward, IsActive) VALUES (2, 12, 1)");
            Sql("INSERT INTO Assassins (MinReward, MaxReward, IsActive) VALUES (3, 13, 1)");
            Sql("INSERT INTO Assassins (MinReward, MaxReward, IsActive) VALUES (4, 14, 1)");
            Sql("INSERT INTO Assassins (MinReward, MaxReward, IsActive) VALUES (5, 15, 1)");
            Sql("INSERT INTO Assassins (MinReward, MaxReward, IsActive) VALUES (6, 16, 1)");
            Sql("INSERT INTO Assassins (MinReward, MaxReward, IsActive) VALUES (7, 17, 1)");
            Sql("INSERT INTO Assassins (MinReward, MaxReward, IsActive) VALUES (8, 18, 1)");
            Sql("INSERT INTO Assassins (MinReward, MaxReward, IsActive) VALUES (9, 19, 1)");
            Sql("INSERT INTO Assassins (MinReward, MaxReward, IsActive) VALUES (10, 20, 1)");
        }
        
        public override void Down()
        {
        }
    }
}
