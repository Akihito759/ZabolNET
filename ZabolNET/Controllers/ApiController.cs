using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using ZabolNET.Models;

namespace ZabolNET.Controllers
{
    public class ApiController : Controller
    {
        // GET: Api
        private ZabolNETContext db = new ZabolNETContext();

        //Course _course = new Course();
        // GET: Faculties
        public String GetFacultyJs()
        {
            var faculties = db.Faculties.Select(x => x.FacultyName).ToList();
            return JsonConvert.SerializeObject(faculties);
        }
        public String GetCoursesJs(string facultyName)
        {
            var id = db.Faculties.Where(f => f.FacultyName == facultyName).Select(f => f.FacultyID).First();
            var courses = db.Courses.Where(f => f.FacultyID == id).Select(f => f.CourseName).ToList();
            return JsonConvert.SerializeObject(courses);
        }

        public String GetYearsJson(string courseName, string facultyName)
        {
            var years = GetYear(courseName, facultyName);
            return JsonConvert.SerializeObject(years);
        }


        public String GetGroupsJson(int year, string courseName, string facultyName)
        {
            var years = GetYear(courseName, facultyName);
            var groups = years.First(x => x.StartYear == year).Groups;
            return JsonConvert.SerializeObject(groups);
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
        public List<Year> GetYear(string courseName, string facultyName)
        {
            var facCourses = db.Faculties.Include(x => x.Courses);
            var courses = facCourses.Where(f => f.FacultyName == facultyName).Select(x => x.Courses).First().ToList();
            var years = courses.Where(x => x.CourseName == courseName).Select(x => x.Years)
                .First().ToList();

            return years;
        }
        public String GetRecordsJs(string groupName, int year, string courseName, string facultyName)
        {
            var groups = GetGroup(year, courseName, facultyName);
            var records = groups.First(x => x.GroupName == groupName);
            return JsonConvert.SerializeObject(records);
        }
    }
}