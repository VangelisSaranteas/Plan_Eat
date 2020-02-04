namespace GuiltyPleasures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exercise",
                c => new
                    {
                        BurnId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Calories = c.Double(nullable: false),
                        Carbs = c.Double(nullable: false),
                        Fat = c.Double(nullable: false),
                        Protein = c.Double(nullable: false),
                        Time = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BurnId);
            
            CreateTable(
                "dbo.Food",
                c => new
                    {
                        FruitId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Calories = c.Double(nullable: false),
                        Carbs = c.Double(nullable: false),
                        Fat = c.Double(nullable: false),
                        Protein = c.Double(nullable: false),
                        Type = c.String(nullable: false, maxLength: 100),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.FruitId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.UsersBalance",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Goal = c.Double(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UsersExercise",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        BurnId = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.BurnId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Exercise", t => t.BurnId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.BurnId);
            
            CreateTable(
                "dbo.UsersFruits",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        FruitId = c.Int(nullable: false),
                        QuantityBreakfast = c.Double(nullable: false),
                        QuantityLunch = c.Double(nullable: false),
                        QuantityDinner = c.Double(nullable: false),
                        QuantitySnacks = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.FruitId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Food", t => t.FruitId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.FruitId);
            
            CreateTable(
                "dbo.UsersGoals",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Goal = c.Double(nullable: false),
                        PackageId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.Packages", t => t.PackageId)
                .Index(t => t.Id)
                .Index(t => t.PackageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersGoals", "PackageId", "dbo.Packages");
            DropForeignKey("dbo.UsersGoals", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsersFruits", "FruitId", "dbo.Food");
            DropForeignKey("dbo.UsersFruits", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsersExercise", "BurnId", "dbo.Exercise");
            DropForeignKey("dbo.UsersExercise", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.UsersBalance", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Food", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UsersGoals", new[] { "PackageId" });
            DropIndex("dbo.UsersGoals", new[] { "Id" });
            DropIndex("dbo.UsersFruits", new[] { "FruitId" });
            DropIndex("dbo.UsersFruits", new[] { "UserId" });
            DropIndex("dbo.UsersExercise", new[] { "BurnId" });
            DropIndex("dbo.UsersExercise", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.UsersBalance", new[] { "Id" });
            DropIndex("dbo.Food", new[] { "ApplicationUser_Id" });
            DropTable("dbo.UsersGoals");
            DropTable("dbo.UsersFruits");
            DropTable("dbo.UsersExercise");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Packages");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UsersBalance");
            DropTable("dbo.Food");
            DropTable("dbo.Exercise");
        }
    }
}
