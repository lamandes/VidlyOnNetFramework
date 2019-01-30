namespace VidlyOnNetFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Movies ON");
            Sql("INSERT INTO Movies (ID, Name, GenreTypeId, ReleaseDate, DateAdded, NumInStock) VALUES (1, 'Hangover', 1, '2016-04-23', '2016-12-02', 4)");
            Sql("INSERT INTO Movies (ID, Name, GenreTypeId, ReleaseDate, DateAdded, NumInStock) VALUES (2, 'Die Hard', 2, '2018-07-23', '2019-01-02', 12)");
            Sql("INSERT INTO Movies (ID, Name, GenreTypeId, ReleaseDate, DateAdded, NumInStock) VALUES (3, 'The Terminator', 2, '2017-04-23', '2017-03-15', 9)");
            Sql("INSERT INTO Movies (ID, Name, GenreTypeId, ReleaseDate, DateAdded, NumInStock) VALUES (4, 'Toy Story', 3, '1999-04-23', '2000-12-02', 1)");
            Sql("INSERT INTO Movies (ID, Name, GenreTypeId, ReleaseDate, DateAdded, NumInStock) VALUES (5, 'Titanic', 4, '2002-05-23', '2004-06-04', 13)");
            Sql("SET IDENTITY_INSERT Movies OFF");
        }

        public override void Down()
        {
        }
    }
}
