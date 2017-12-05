using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZabolNET.DAL;
using ZabolNET.Models;
using ZabolNET.ViewModels;

namespace ZabolNET.Controllers
{
    public class HomeController : Controller
    {
        private GetDataInfo db = new GetDataInfo();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your aki kurwa ion page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult AddEvent(ChooseViewModel model)
        {          
            return View(model);
        }

        public ActionResult PostEvent(ChooseViewModel model,Record record)
        {
            var x = model;
            var y = record;
            db.AddRecord(model, record, "POK");

            return View("~/Views/Home/MainView.cshtml", model);
        }

        public ActionResult Choose()
        {
            return View();
        }

        public ActionResult GetViewModel(ChooseViewModel model)
        {
           var x =  model;
           return View("~/Views/Home/MainView.cshtml",model);
        }

        public ActionResult GetRecords(ChooseViewModel model)
        {
            var x = db.GetRecords(model.Group, model.Year, model.Course, model.Faculty);

            return PartialView("~/Views/_Show.cshtml", x);
        }


    }
}