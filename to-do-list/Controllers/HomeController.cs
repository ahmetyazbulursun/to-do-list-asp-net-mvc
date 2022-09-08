using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using to_do_list.Models.Entity;

namespace to_do_list.Controllers
{
    public class HomeController : Controller
    {

        Entities db = new Entities();

        // ----------- TASK VIEWS ---------->
        [HttpGet]
        public ActionResult Index()
        {
            var todaysDate = DateTime.Now.ToString("dd MMMM yyyy");

            var value = db.Tbl_Tasks.Where(x => x.STATUS == true && x.DATEOFTASK == todaysDate).ToList();
            return View(value);
        }

        [HttpPost]
        public ActionResult Index(Tbl_Tasks p)
        {
            p.STATUS = true;

            db.Tbl_Tasks.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Completed()
        {
            var todaysDate = DateTime.Now.ToString("dd MMMM yyyy");

            var value = db.Tbl_Tasks.Where(x => x.STATUS == false && x.DATEOFTASK == todaysDate).ToList();
            return View(value);
        }

        [HttpPost]
        public ActionResult Completed(Tbl_Tasks p)
        {
            p.STATUS = true;

            db.Tbl_Tasks.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // <--------------------------------------

        // ----------- TASK OPERATIONS ---------->
        public ActionResult CompleteTask(Tbl_Tasks p)
        {
            var value = db.Tbl_Tasks.Find(p.ID);

            value.STATUS = false;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTask(int id)
        {
            var value = db.Tbl_Tasks.Find(id);
            db.Tbl_Tasks.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RestoreTask(Tbl_Tasks p)
        {
            var value = db.Tbl_Tasks.Find(p.ID);

            value.STATUS = true;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // <--------------------------------------

    }
}