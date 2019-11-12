namespace Devoir.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deuxieme : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vehicules", "Intervention_Id", "dbo.Interventions");
            DropIndex("dbo.Vehicules", new[] { "Intervention_Id" });
            AddColumn("dbo.Interventions", "Vehicule_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Interventions", "Vehicule_Id");
            AddForeignKey("dbo.Interventions", "Vehicule_Id", "dbo.Vehicules", "Id", cascadeDelete: true);
            DropColumn("dbo.Vehicules", "Intervention_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicules", "Intervention_Id", c => c.Int());
            DropForeignKey("dbo.Interventions", "Vehicule_Id", "dbo.Vehicules");
            DropIndex("dbo.Interventions", new[] { "Vehicule_Id" });
            DropColumn("dbo.Interventions", "Vehicule_Id");
            CreateIndex("dbo.Vehicules", "Intervention_Id");
            AddForeignKey("dbo.Vehicules", "Intervention_Id", "dbo.Interventions", "Id");
        }
    }
}
