namespace VidlyOnNetFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBirthDateCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET BirthDate ='1995-06-08' WHERE Name = 'Andes'");
        }
        
        public override void Down()
        {
        }
    }
}
