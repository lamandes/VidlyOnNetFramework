namespace VidlyOnNetFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertiesInMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(storeType: "date"));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(storeType: "date"));
            AddColumn("dbo.Movies", "NumInStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumInStock");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "ReleaseDate");
        }
    }
}
