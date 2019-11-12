namespace Devoir.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class premiere : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Intervenants",
                c => new
                    {
                        Matricule = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 50),
                        Prenom = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Matricule);
            
            CreateTable(
                "dbo.Interventions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOuverture = c.DateTime(nullable: false),
                        DateFermeture = c.DateTime(),
                        Intervenant_Matricule = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Intervenants", t => t.Intervenant_Matricule)
                .Index(t => t.Intervenant_Matricule);
            
            CreateTable(
                "dbo.Materiels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        designation = c.String(nullable: false, maxLength: 50),
                        Disponible = c.Boolean(nullable: false),
                        description = c.String(),
                        DateAchat = c.DateTime(nullable: false),
                        reference = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Immatriculation = c.String(nullable: false, maxLength: 50),
                        Marque = c.String(nullable: false, maxLength: 50),
                        VolumeUtile = c.Single(nullable: false),
                        Model = c.String(nullable: false, maxLength: 50),
                        Disponible = c.Boolean(nullable: false),
                        Intervention_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Interventions", t => t.Intervention_Id)
                .Index(t => t.Intervention_Id);
            
            CreateTable(
                "dbo.MaterielInterventions",
                c => new
                    {
                        Materiel_Id = c.Int(nullable: false),
                        Intervention_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Materiel_Id, t.Intervention_Id })
                .ForeignKey("dbo.Materiels", t => t.Materiel_Id, cascadeDelete: true)
                .ForeignKey("dbo.Interventions", t => t.Intervention_Id, cascadeDelete: true)
                .Index(t => t.Materiel_Id)
                .Index(t => t.Intervention_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicules", "Intervention_Id", "dbo.Interventions");
            DropForeignKey("dbo.Interventions", "Intervenant_Matricule", "dbo.Intervenants");
            DropForeignKey("dbo.MaterielInterventions", "Intervention_Id", "dbo.Interventions");
            DropForeignKey("dbo.MaterielInterventions", "Materiel_Id", "dbo.Materiels");
            DropIndex("dbo.MaterielInterventions", new[] { "Intervention_Id" });
            DropIndex("dbo.MaterielInterventions", new[] { "Materiel_Id" });
            DropIndex("dbo.Vehicules", new[] { "Intervention_Id" });
            DropIndex("dbo.Interventions", new[] { "Intervenant_Matricule" });
            DropTable("dbo.MaterielInterventions");
            DropTable("dbo.Vehicules");
            DropTable("dbo.Materiels");
            DropTable("dbo.Interventions");
            DropTable("dbo.Intervenants");
        }
    }
}
