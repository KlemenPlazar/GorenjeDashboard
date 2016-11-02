namespace GorenjeDashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MaterialModels", "MachineName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MaterialModels", "MachineName");
        }
    }
}
