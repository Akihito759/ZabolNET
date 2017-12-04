namespace ZabolNET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        FacultyID = c.Int(nullable: false, identity: true),
                        FacultyName = c.String(),
                    })
                .PrimaryKey(t => t.FacultyID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        Faculty_FacultyID = c.Int(),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Faculties", t => t.Faculty_FacultyID)
                .Index(t => t.Faculty_FacultyID);
            
            CreateTable(
                "dbo.Years",
                c => new
                    {
                        YearID = c.Int(nullable: false, identity: true),
                        StartYear = c.Int(nullable: false),
                        Course_CourseID = c.Int(),
                    })
                .PrimaryKey(t => t.YearID)
                .ForeignKey("dbo.Courses", t => t.Course_CourseID)
                .Index(t => t.Course_CourseID);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                        Year_YearID = c.Int(),
                    })
                .PrimaryKey(t => t.GroupID)
                .ForeignKey("dbo.Years", t => t.Year_YearID)
                .Index(t => t.Year_YearID);
            
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        RecordID = c.Int(nullable: false, identity: true),
                        RecordDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        ShortDescription = c.String(),
                        RecordType = c.String(),
                        Difficulty = c.Int(nullable: false),
                        Group_GroupID = c.Int(),
                        Subject_SubjectID = c.Int(),
                    })
                .PrimaryKey(t => t.RecordID)
                .ForeignKey("dbo.Groups", t => t.Group_GroupID)
                .ForeignKey("dbo.Subjects", t => t.Subject_SubjectID)
                .Index(t => t.Group_GroupID)
                .Index(t => t.Subject_SubjectID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                        Year_YearID = c.Int(),
                    })
                .PrimaryKey(t => t.SubjectID)
                .ForeignKey("dbo.Years", t => t.Year_YearID)
                .Index(t => t.Year_YearID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groups", "Year_YearID", "dbo.Years");
            DropForeignKey("dbo.Records", "Subject_SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "Year_YearID", "dbo.Years");
            DropForeignKey("dbo.Records", "Group_GroupID", "dbo.Groups");
            DropForeignKey("dbo.Years", "Course_CourseID", "dbo.Courses");
            DropForeignKey("dbo.Courses", "Faculty_FacultyID", "dbo.Faculties");
            DropIndex("dbo.Subjects", new[] { "Year_YearID" });
            DropIndex("dbo.Records", new[] { "Subject_SubjectID" });
            DropIndex("dbo.Records", new[] { "Group_GroupID" });
            DropIndex("dbo.Groups", new[] { "Year_YearID" });
            DropIndex("dbo.Years", new[] { "Course_CourseID" });
            DropIndex("dbo.Courses", new[] { "Faculty_FacultyID" });
            DropTable("dbo.Subjects");
            DropTable("dbo.Records");
            DropTable("dbo.Groups");
            DropTable("dbo.Years");
            DropTable("dbo.Courses");
            DropTable("dbo.Faculties");
        }
    }
}
