using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZabolNET.DAL;
using ZabolNET.ViewModels;

namespace ZabolNET.Controllers
{
    public class FirstRunController : Controller
    {
        private GetDataInfo db = new GetDataInfo();
        //GET Intro/chooseFaculty
        public ActionResult Faculty()
        {
            //var _facLIst = db.Faculties.Select(x => x.FacultyName).ToList();
            

            var facultiesList = db.GetFaculties();
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
            ModelState.Clear();

            var courseList = db.GetCourses(viewModel.Faculty);

            viewModel.ToChoose = courseList;

            return PartialView("~/Views/Intro/_ChooseCourse.cshtml", viewModel);
        }

        public ActionResult ChooseYear(ChooseViewModel viewModel, string choosenFaculty)
        {
            //var _facLIst = db.Faculties.Select(x => x.FacultyName).ToList();
            viewModel.Course = choosenFaculty;
            ModelState.Clear();
            var  courseList = db.GetYears(viewModel.Course,viewModel.Faculty);

            viewModel.ToChoose = courseList.ConvertAll<string>(x => x.ToString());

            return PartialView("~/Views/Intro/_ChooseYear.cshtml", viewModel);
        }

        public ActionResult ChooseGroup(ChooseViewModel viewModel, string choosenFaculty)
        {
            //var _facLIst = db.Faculties.Select(x => x.FacultyName).ToList();
            viewModel.Year = int.Parse(choosenFaculty);
            ModelState.Clear();
            var courseList = db.GetGroups(viewModel.Year,viewModel.Course,viewModel.Faculty);
            
      

            viewModel.ToChoose = courseList;

            return PartialView("~/Views/Intro/_ChooseGroup.cshtml", viewModel);
        }

        public ActionResult Final(ChooseViewModel viewModel, string choosenFaculty)
        {
            //var _facLIst = db.Faculties.Select(x => x.FacultyName).ToList();

            viewModel.Group = choosenFaculty;
            ModelState.Clear();
            List<string> courseList = null;

            courseList = new List<string> { viewModel.Faculty,viewModel.Course,viewModel.Year.ToString(),viewModel.Group};


            viewModel.ToChoose = courseList;

            return PartialView("~/Views/Intro/_Final.cshtml",viewModel);
        }
    }
}