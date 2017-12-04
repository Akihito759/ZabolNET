namespace ZabolNET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class objektyUsuniete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Records", "Subject_SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "Group_GroupID", "dbo.Groups");
            DropForeignKey("dbo.Years", "Course_CourseID", "dbo.Courses");
            DropForeignKey("dbo.Courses", "Faculty_FacultyID", "dbo.Faculties");
            DropForeignKey("dbo.Groups", "Year_YearID", "dbo.Years");
            DropForeignKey("dbo.Records", "Group_GroupID", "dbo.Groups");
            DropIndex("dbo.Courses", new[] { "Faculty_FacultyID" });
            DropIndex("dbo.Years", new[] { "Course_CourseID" });
            DropIndex("dbo.Groups", new[] { "Year_YearID" });
            DropIndex("dbo.Records", new[] { "Group_GroupID" });
            DropIndex("dbo.Records", new[] { "Subject_SubjectID" });
            DropIndex("dbo.Subjects", new[] { "Group_GroupID" });
            RenameColumn(table: "dbo.Years", name: "Course_CourseID", newName: "CourseID");
            RenameColumn(table: "dbo.Courses", name: "Faculty_FacultyID", newName: "FacultyID");
            RenameColumn(table: "dbo.Groups", name: "Year_YearID", newName: "YearID");
            RenameColumn(table: "dbo.Records", name: "Group_GroupID", newName: "GroupID");
            AddColumn("dbo.Records", "SubjectID", c => c.Int(nullable: false));
            AlterColumn("dbo.Courses", "FacultyID", c => c.Int(nullable: false));
            AlterColumn("dbo.Years", "CourseID", c => c.Int(nullable: false));
            AlterColumn("dbo.Groups", "YearID", c => c.Int(nullable: false));
            AlterColumn("dbo.Records", "GroupID", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "FacultyID");
            CreateIndex("dbo.Years", "CourseID");
            CreateIndex("dbo.Groups", "YearID");
            CreateIndex("dbo.Records", "GroupID");
            AddForeignKey("dbo.Years", "CourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
            AddForeignKey("dbo.Courses", "FacultyID", "dbo.Faculties", "FacultyID", cascadeDelete: true);
            AddForeignKey("dbo.Groups", "YearID", "dbo.Years", "YearID", cascadeDelete: true);
            AddForeignKey("dbo.Records", "GroupID", "dbo.Groups", "GroupID", cascadeDelete: true);
            DropColumn("dbo.Records", "Subject_SubjectID");
            DropColumn("dbo.Subjects", "Group_GroupID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subjects", "Group_GroupID", c => c.Int());
            AddColumn("dbo.Records", "Subject_SubjectID", c => c.Int());
            DropForeignKey("dbo.Records", "GroupID", "dbo.Groups");
            DropForeignKey("dbo.Groups", "YearID", "dbo.Years");
            DropForeignKey("dbo.Courses", "FacultyID", "dbo.Faculties");
            DropForeignKey("dbo.Years", "CourseID", "dbo.Courses");
            DropIndex("dbo.Records", new[] { "GroupID" });
            DropIndex("dbo.Groups", new[] { "YearID" });
            DropIndex("dbo.Years", new[] { "CourseID" });
            DropIndex("dbo.Courses", new[] { "FacultyID" });
            AlterColumn("dbo.Records", "GroupID", c => c.Int());
            AlterColumn("dbo.Groups", "YearID", c => c.Int());
            AlterColumn("dbo.Years", "CourseID", c => c.Int());
            AlterColumn("dbo.Courses", "FacultyID", c => c.Int());
            DropColumn("dbo.Records", "SubjectID");
            RenameColumn(table: "dbo.Records", name: "GroupID", newName: "Group_GroupID");
            RenameColumn(table: "dbo.Groups", name: "YearID", newName: "Year_YearID");
            RenameColumn(table: "dbo.Courses", name: "FacultyID", newName: "Faculty_FacultyID");
            RenameColumn(table: "dbo.Years", name: "CourseID", newName: "Course_CourseID");
            CreateIndex("dbo.Subjects", "Group_GroupID");
            CreateIndex("dbo.Records", "Subject_SubjectID");
            CreateIndex("dbo.Records", "Group_GroupID");
            CreateIndex("dbo.Groups", "Year_YearID");
            CreateIndex("dbo.Years", "Course_CourseID");
            CreateIndex("dbo.Courses", "Faculty_FacultyID");
            AddForeignKey("dbo.Records", "Group_GroupID", "dbo.Groups", "GroupID");
            AddForeignKey("dbo.Groups", "Year_YearID", "dbo.Years", "YearID");
            AddForeignKey("dbo.Courses", "Faculty_FacultyID", "dbo.Faculties", "FacultyID");
            AddForeignKey("dbo.Years", "Course_CourseID", "dbo.Courses", "CourseID");
            AddForeignKey("dbo.Subjects", "Group_GroupID", "dbo.Groups", "GroupID");
            AddForeignKey("dbo.Records", "Subject_SubjectID", "dbo.Subjects", "SubjectID");
        }
    }
}
