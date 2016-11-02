namespace GorenjeDashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class materialmachinerename : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MaterialModels", "MachineId", c => c.Int(nullable: false));
            DropColumn("dbo.MaterialModels", "MachineName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MaterialModels", "MachineName", c => c.String());
            DropColumn("dbo.MaterialModels", "MachineId");
        }
    }
}
