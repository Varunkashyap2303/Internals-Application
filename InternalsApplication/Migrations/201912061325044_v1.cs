namespace InternalsApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassRoom",
                c => new
                    {
                        Room_No = c.Int(nullable: false),
                        Duration = c.Time(precision: 7),
                        Dept_No = c.Int(),
                        Teacher_ID = c.String(maxLength: 255),
                        USN = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Room_No)
                .ForeignKey("dbo.Department", t => t.Dept_No)
                .ForeignKey("dbo.Teacher", t => t.Teacher_ID)
                .ForeignKey("dbo.Student", t => t.USN)
                .Index(t => t.Dept_No)
                .Index(t => t.Teacher_ID)
                .Index(t => t.USN);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Dept_No = c.Int(nullable: false),
                        Dept_Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Dept_No);
            
            CreateTable(
                "dbo.Report",
                c => new
                    {
                        Report_ID = c.Long(nullable: false, identity: true),
                        Total = c.Int(),
                        Percentage = c.Decimal(precision: 5, scale: 3, storeType: "numeric"),
                        USN = c.String(maxLength: 255),
                        Teacher_ID = c.String(maxLength: 255),
                        Dept_No = c.Int(),
                        Subject_Code = c.String(maxLength: 255),
                        Script_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Report_ID)
                .ForeignKey("dbo.Department", t => t.Dept_No)
                .ForeignKey("dbo.Script", t => t.Script_ID)
                .ForeignKey("dbo.Student", t => t.USN)
                .ForeignKey("dbo.Subject", t => t.Subject_Code)
                .ForeignKey("dbo.Teacher", t => t.Teacher_ID)
                .Index(t => t.USN)
                .Index(t => t.Teacher_ID)
                .Index(t => t.Dept_No)
                .Index(t => t.Subject_Code)
                .Index(t => t.Script_ID);
            
            CreateTable(
                "dbo.Script",
                c => new
                    {
                        Script_ID = c.Int(nullable: false, identity: true),
                        IA1 = c.Int(),
                        IA2 = c.Int(),
                        IA3 = c.Int(),
                        Teacher_ID = c.String(maxLength: 255),
                        Subject_Code = c.String(maxLength: 255),
                        USN = c.String(maxLength: 255),
                        Dept_No = c.Int(),
                    })
                .PrimaryKey(t => t.Script_ID)
                .ForeignKey("dbo.Department", t => t.Dept_No)
                .ForeignKey("dbo.Student", t => t.USN)
                .ForeignKey("dbo.Subject", t => t.Subject_Code)
                .ForeignKey("dbo.Teacher", t => t.Teacher_ID)
                .Index(t => t.Teacher_ID)
                .Index(t => t.Subject_Code)
                .Index(t => t.USN)
                .Index(t => t.Dept_No);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        USN = c.String(nullable: false, maxLength: 255),
                        Name = c.String(maxLength: 255),
                        Semester = c.Int(),
                        Dept_ID = c.Int(),
                    })
                .PrimaryKey(t => t.USN);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        Subject_Code = c.String(nullable: false, maxLength: 255),
                        Subject_Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Subject_Code);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        Teacher_ID = c.String(nullable: false, maxLength: 255),
                        Teacher_Name = c.String(maxLength: 255),
                        Dept_No = c.Int(),
                    })
                .PrimaryKey(t => t.Teacher_ID)
                .ForeignKey("dbo.Department", t => t.Dept_No)
                .Index(t => t.Dept_No);
            
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
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ClassRoom", "USN", "dbo.Student");
            DropForeignKey("dbo.Script", "Teacher_ID", "dbo.Teacher");
            DropForeignKey("dbo.Report", "Teacher_ID", "dbo.Teacher");
            DropForeignKey("dbo.Teacher", "Dept_No", "dbo.Department");
            DropForeignKey("dbo.ClassRoom", "Teacher_ID", "dbo.Teacher");
            DropForeignKey("dbo.Script", "Subject_Code", "dbo.Subject");
            DropForeignKey("dbo.Report", "Subject_Code", "dbo.Subject");
            DropForeignKey("dbo.Script", "USN", "dbo.Student");
            DropForeignKey("dbo.Report", "USN", "dbo.Student");
            DropForeignKey("dbo.Report", "Script_ID", "dbo.Script");
            DropForeignKey("dbo.Script", "Dept_No", "dbo.Department");
            DropForeignKey("dbo.Report", "Dept_No", "dbo.Department");
            DropForeignKey("dbo.ClassRoom", "Dept_No", "dbo.Department");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Teacher", new[] { "Dept_No" });
            DropIndex("dbo.Script", new[] { "Dept_No" });
            DropIndex("dbo.Script", new[] { "USN" });
            DropIndex("dbo.Script", new[] { "Subject_Code" });
            DropIndex("dbo.Script", new[] { "Teacher_ID" });
            DropIndex("dbo.Report", new[] { "Script_ID" });
            DropIndex("dbo.Report", new[] { "Subject_Code" });
            DropIndex("dbo.Report", new[] { "Dept_No" });
            DropIndex("dbo.Report", new[] { "Teacher_ID" });
            DropIndex("dbo.Report", new[] { "USN" });
            DropIndex("dbo.ClassRoom", new[] { "USN" });
            DropIndex("dbo.ClassRoom", new[] { "Teacher_ID" });
            DropIndex("dbo.ClassRoom", new[] { "Dept_No" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Teacher");
            DropTable("dbo.Subject");
            DropTable("dbo.Student");
            DropTable("dbo.Script");
            DropTable("dbo.Report");
            DropTable("dbo.Department");
            DropTable("dbo.ClassRoom");
        }
    }
}
