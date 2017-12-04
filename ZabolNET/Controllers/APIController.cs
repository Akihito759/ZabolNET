using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZabolNET.Models;

namespace ZabolNET.Controllers
{
    public class APIController : Controller
    {
        private ZabolNETContext db = new ZabolNETContext();
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
                var years = GetYears(courseName, facultyName);
                return JsonConvert.SerializeObject(years);
            }
            public List<Year> GetYears(string courseName, string facultyName)
            {
                var facCourses = db.Faculties.Include(x => x.Courses);
                var courses = facCourses.Where(f => f.FacultyName == facultyName).Select(x => x.Courses).First().ToList();
                var years = courses.Where(x => x.CourseName == courseName).Select(x => x.Years)
                    .First().ToList();

                return years;
            }

            public String GetGroupsJson(int year, string courseName, string facultyName)
            {
                var years = GetYears(courseName, facultyName);
                var groups = years.First(x => x.StartYear == year).Groups;
                return JsonConvert.SerializeObject(groups);
            }
            public List<Group> GetGroups(int year, string courseName, string facultyName)
            {
                var years = GetYears(courseName, facultyName);
                var groups = years.First(x => x.StartYear == year).Groups;
                return groups;
            }

            public String GetRecordsJs(string groupName, int year, string courseName, string facultyName)
            {
                var groups = GetGroups(year, courseName, facultyName);
                var records = groups.First(x => x.GroupName == groupName);
                return JsonConvert.SerializeObject(records);
            }
        }
    }
}