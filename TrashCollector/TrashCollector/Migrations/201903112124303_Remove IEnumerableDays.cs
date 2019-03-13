namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveIEnumerableDays : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "DayOfWeek");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "DayOfWeek", c => c.String());
        }
    }
}
