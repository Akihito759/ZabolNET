namespace ZabolNET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subjects", "Group_GroupID", c => c.Int());
            CreateIndex("dbo.Subjects", "Group_GroupID");
            AddForeignKey("dbo.Subjects", "Group_GroupID", "dbo.Groups", "GroupID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subjects", "Group_GroupID", "dbo.Groups");
            DropIndex("dbo.Subjects", new[] { "Group_GroupID" });
            DropColumn("dbo.Subjects", "Group_GroupID");
        }
    }
}
