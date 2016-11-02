namespace GorenjeDashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MachineModels",
                c => new
                    {
                        MachineId = c.Int(nullable: false, identity: true),
                        Machine = c.String(),
                    })
                .PrimaryKey(t => t.MachineId);
            
            CreateTable(
                "dbo.OrderModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MachineId = c.Int(nullable: false),
                        MaterialId = c.Int(nullable: false),
                        PalleteId = c.Int(nullable: false),
                        Priority = c.String(),
                        State = c.Int(nullable: false),
                        TimeAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MachineModels", t => t.MachineId, cascadeDelete: true)
                .ForeignKey("dbo.MaterialModels", t => t.MaterialId, cascadeDelete: true)
                .ForeignKey("dbo.PalleteModels", t => t.PalleteId, cascadeDelete: true)
                .Index(t => t.MachineId)
                .Index(t => t.MaterialId)
                .Index(t => t.PalleteId);
            
            CreateTable(
                "dbo.MaterialModels",
                c => new
                    {
                        MaterialId = c.Int(nullable: false, identity: true),
                        Material = c.String(),
                        MaterialCode = c.String(),
                        MaterialStructure = c.String(),
                    })
                .PrimaryKey(t => t.MaterialId);
            
            CreateTable(
                "dbo.PalleteModels",
                c => new
                    {
                        PalleteId = c.Int(nullable: false, identity: true),
                        PalleteName = c.String(),
                    })
                .PrimaryKey(t => t.PalleteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderModels", "PalleteId", "dbo.PalleteModels");
            DropForeignKey("dbo.OrderModels", "MaterialId", "dbo.MaterialModels");
            DropForeignKey("dbo.OrderModels", "MachineId", "dbo.MachineModels");
            DropIndex("dbo.OrderModels", new[] { "PalleteId" });
            DropIndex("dbo.OrderModels", new[] { "MaterialId" });
            DropIndex("dbo.OrderModels", new[] { "MachineId" });
            DropTable("dbo.PalleteModels");
            DropTable("dbo.MaterialModels");
            DropTable("dbo.OrderModels");
            DropTable("dbo.MachineModels");
        }
    }
}
