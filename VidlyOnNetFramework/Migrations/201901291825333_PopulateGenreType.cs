namespace VidlyOnNetFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreType : DbMigration
    {
        public override void Up()
        {
            //Comedy, Action, Family, Romance
            Sql("INSERT INTO GenreTypes (Id, TypeName) VALUES (1, 'Commedy')");
            Sql("INSERT INTO GenreTypes (Id, TypeName) VALUES (2, 'Action')");
            Sql("INSERT INTO GenreTypes (Id, TypeName) VALUES (3, 'Family')");
            Sql("INSERT INTO GenreTypes (Id, TypeName) VALUES (4, 'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
