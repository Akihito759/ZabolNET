namespace ZabolNET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yearID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subjects", "Year_YearID", "dbo.Years");
            DropIndex("dbo.Subjects", new[] { "Year_YearID" });
            RenameColumn(table: "dbo.Subjects", name: "Year_YearID", newName: "YearID");
            AlterColumn("dbo.Subjects", "YearID", c => c.Int(nullable: false));
            CreateIndex("dbo.Subjects", "YearID");
            AddForeignKey("dbo.Subjects", "YearID", "dbo.Years", "YearID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subjects", "YearID", "dbo.Years");
            DropIndex("dbo.Subjects", new[] { "YearID" });
            AlterColumn("dbo.Subjects", "YearID", c => c.Int());
            RenameColumn(table: "dbo.Subjects", name: "YearID", newName: "Year_YearID");
            CreateIndex("dbo.Subjects", "Year_YearID");
            AddForeignKey("dbo.Subjects", "Year_YearID", "dbo.Years", "YearID");
        }
    }
}
