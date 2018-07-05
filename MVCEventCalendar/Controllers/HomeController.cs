using MVCEventCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEventCalendar.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            using (MyDatabaseEntities db = new MyDatabaseEntities())
            {
                var events = db.Events.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        [HttpPost]
        public JsonResult SaveEvent(Events e)
        {
            var status = false;

            using (MyDatabaseEntities db = new MyDatabaseEntities())
            {
                if (e.EventId > 0)
                {
                    var v = db.Events.Where(a => a.EventId == e.EventId).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Description = e.Description;
                        v.IsFullDay = e.IsFullDay;
                        v.ThemeColor = e.ThemeColor;
                    }
                }
                else
                {
                    db.Events.Add(e);
                }

                db.SaveChanges();
                status = true;
            }

            return new JsonResult {Data = new { status = status } };
        }

        [HttpPost]
        public ActionResult DeleteEvent(int EventID)
        {
            var status = false;
            using (MyDatabaseEntities db = new MyDatabaseEntities())
            {
                var v = db.Events.Where(a => a.EventId == EventID).FirstOrDefault();
                if (v != null)
                {
                    db.Events.Remove(v);
                    db.SaveChanges();
                    status = true;
                }
                else
                {

                }
            }

            return new JsonResult { Data = new { status = status } };
        }
    }
}