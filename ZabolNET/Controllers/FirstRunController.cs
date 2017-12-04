using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZabolNET.ViewModels;

namespace ZabolNET.Controllers
{
    public class FirstRunController : Controller
    {
        //GET Intro/chooseFaculty
        public ActionResult Faculty()
        {
            //var _facLIst = db.Faculties.Select(x => x.FacultyName).ToList();
            var facultiesList = new List<string> { "AEI", "IB" };
            var viewModel = new ChooseViewModel
            {
                ToChoose = facultiesList
            };
            return PartialView("~/Views/Intro/_ChooseFaculty.cshtml", viewModel);
        }

        public ActionResult ChooseCourse(ChooseViewModel viewModel, string choosenFaculty)
        {
            //var _facLIst = db.Faculties.Select(x => x.FacultyName).ToList();
            viewModel.Faculty = choosenFaculty;
            List<string> courseList = null;
            if (choosenFaculty == "AEI")
            {
                courseList = new List<string> { "AiR", "Infa" };
            }
            if (choosenFaculty == "IB")
            {
                courseList = new List<string> { "dupa", "Damian" };
            }

            viewModel.ToChoose = courseList;

            return PartialView("~/Views/Intro/_ChooseCourse.cshtml", viewModel);
        }
    }
}