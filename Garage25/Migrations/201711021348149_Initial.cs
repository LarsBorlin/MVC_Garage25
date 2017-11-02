namespace Garage25.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Color",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ParkedVehicle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegistrationNumber = c.String(nullable: false),
                        VehicleBrand = c.String(),
                        InDate = c.DateTime(nullable: false),
                        ParkingSpot = c.Int(nullable: false),
                        VehicleTypeId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        ColorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Color", t => t.ColorId, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleType", t => t.VehicleTypeId, cascadeDelete: true)
                .Index(t => t.VehicleTypeId)
                .Index(t => t.PersonId)
                .Index(t => t.ColorId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MailAddress = c.String(nullable: false, maxLength: 100),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 12),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(nullable: false),
                        ParkingSpace = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParkedVehicle", "VehicleTypeId", "dbo.VehicleType");
            DropForeignKey("dbo.ParkedVehicle", "PersonId", "dbo.Person");
            DropForeignKey("dbo.ParkedVehicle", "ColorId", "dbo.Color");
            DropIndex("dbo.ParkedVehicle", new[] { "ColorId" });
            DropIndex("dbo.ParkedVehicle", new[] { "PersonId" });
            DropIndex("dbo.ParkedVehicle", new[] { "VehicleTypeId" });
            DropTable("dbo.VehicleType");
            DropTable("dbo.Person");
            DropTable("dbo.ParkedVehicle");
            DropTable("dbo.Color");
        }
    }
}
