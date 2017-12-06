namespace EFlabb2.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFlabb2.GameContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EFLabb2";
        }

        protected override void Seed(EFlabb2.GameContext context)
        {
            //Player player = new Player();
            //{
            //    Name = "JOJJO";

            //    Round = new Round()
            //    {
            //        Players = new List<Player>() { },
            //        UsedMoves = 5
            //    };
            //    };
            //player.Rounds.Players.Add(player);
            //context.Players.Add(player);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}