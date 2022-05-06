namespace AnkhMorporkWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlayer : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Players (Money, Beer, MeetingsWithThief, CurrentGuild, LastMeeting, CurrentMeeting)" +
                " VALUES (100.00, 0, 0, 0, '', '')");
        }
        
        public override void Down()
        {
        }
    }
}
