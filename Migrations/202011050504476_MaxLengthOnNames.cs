namespace MvcWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxLengthOnNames : DbMigration
    {
        public override void Up()
        {
           // AlterColumn("dbo.Car", "OwnerLastName", c => c.String(maxLength: 50));            
        }
        
        public override void Down()
        {
           // AlterColumn("dbo.Car", "OwnerLastName", c => c.String(maxLength: 50));
        }
    }
}
