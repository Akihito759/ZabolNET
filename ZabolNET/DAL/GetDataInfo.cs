using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ZabolNET.Models;
using ZabolNET.ViewModels;

namespace ZabolNET.DAL
{
    public class GetDataInfo
    {
        private ZabolNETContext db;

        public GetDataInfo()
        {
            db = new ZabolNETContext();
        }


        public List<String> GetFaculties()
        {
            return db.Faculties.Select(x => x.FacultyName).ToList();
        }

        public List<String> GetCourses(string fac)
        {
            var id = db.Faculties.Where(f => f.FacultyName == fac).Select(f => f.FacultyID).First();
            return db.Courses.Where(f => f.FacultyID == id).Select(f => f.CourseName).ToList();
        }

        public List<int> GetYears(string fac, string course)
        {
            return GetYear(course, fac).Select(x => x.StartYear).ToList();


        }

        public List<Record> GetRecords(string groupName, int year, string courseName, string facultyName)
        {
            var groups = GetGroup(year, courseName, facultyName);
            return groups.First(x => x.GroupName == groupName).Records;
        }

        public List<Group> GetGroup(int year, string courseName, string facultyName)
        {
            var years = GetYear(courseName, facultyName);
            var groups = years.First(x => x.StartYear == year).Groups;
            return groups;
        }

        public List<string> GetGroups(int year, string courseName, string facultyName)
        {
            var years = GetYear(courseName, facultyName);
            var groups = years.First(x => x.StartYear == year).Groups.Select(x=>x.GroupName).ToList();
            return groups;
        }

        public List<Year> GetYear(string courseName, string facultyName)
        {
            var facCourses = db.Faculties.Include(x => x.Courses);
            var courses = facCourses.Where(f => f.FacultyName == facultyName).Select(x => x.Courses).First().ToList();
            var years = courses.Where(x => x.CourseName == courseName).Select(x => x.Years)
                .First().ToList();

            return years;
        }

        public int GetSubjectID(Year Year, string SubjectName)
        {
            return Year.Subject.First(x => x.SubjectName == SubjectName).SubjectID;
        }

        public void AddRecord(ChooseViewModel viewModel, Record record, string SubjectName)
        {
            var groups = GetGroup(viewModel.Year, viewModel.Course, viewModel.Faculty);
            var group = groups.First(x => x.GroupName == viewModel.Group);
            var years = GetYear(viewModel.Course, viewModel.Faculty);
            var year = years.First(x => x.StartYear == viewModel.Year);
            record.GroupID = group.GroupID;
            record.SubjectID = GetSubjectID(year, SubjectName);
            db.Records.Add(record);
            db.SaveChanges();
        }
    }
}

   
