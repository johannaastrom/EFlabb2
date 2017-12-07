namespace EFlabb2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAvatar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "Avatar", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "Avatar");
        }
    }
}
