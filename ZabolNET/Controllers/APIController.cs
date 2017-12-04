using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZabolNET.Models;

namespace ZabolNET.Controllers
{
    public class APIController : Controller
    {
        private ZabolNETContext db = new ZabolNETContext();

        // GET: Api
        public String GetFaculties()
        {
            // var x = db.Faculties.Include(f => f.);
            var x = db.Faculties.Include(s => s.Courses).ToList();

           
            var json = JsonConvert.SerializeObject(x);
            return json ;
        }

        public String GetCourses( )
        {
            var course = db.Courses.ToList().Where(x=>x.Faculty.FacultyName==faculty);
            var json = JsonConvert.SerializeObject(course);
            return json;
        }

        public String GetYears()
        {
            var years = db.Years.ToList();
            var json = JsonConvert.SerializeObject(years);
            return json;
        }

        public String GetGroups()
        {
            var groups = db.Groups.ToList();
            var json = JsonConvert.SerializeObject(groups);
            return json;
        }

  


    }
}