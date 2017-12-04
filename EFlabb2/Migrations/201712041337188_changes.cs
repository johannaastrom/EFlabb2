namespace EFlabb2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        LevelId = c.Int(nullable: false, identity: true),
                        AvailableMoves = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LevelId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rounds",
                c => new
                    {
                        RoundId = c.Int(nullable: false, identity: true),
                        UsedMoves = c.Int(nullable: false),
                        PlayerId = c.Int(nullable: false),
                        LevelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoundId)
                .ForeignKey("dbo.Levels", t => t.LevelId, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId)
                .Index(t => t.LevelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rounds", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Rounds", "LevelId", "dbo.Levels");
            DropIndex("dbo.Rounds", new[] { "LevelId" });
            DropIndex("dbo.Rounds", new[] { "PlayerId" });
            DropTable("dbo.Rounds");
            DropTable("dbo.Players");
            DropTable("dbo.Levels");
        }
    }
}
