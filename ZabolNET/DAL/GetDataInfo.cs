using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ZabolNET.Models;

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
    }
}

   
