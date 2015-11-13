using System.Web.Mvc;
using WhiskyGaloreAdmin.Models;

namespace WhiskyGaloreAdmin.Controllers
{
    public class ManagerController : Controller
    {

        public ActionResult Orders()
        {
            return View(new Manager("getOrders"));
        }
        public ActionResult Whisky()
        {
            return View(new Manager("getProductInfo"));
        }
        public ActionResult DailyHours()
        {
            DailyHours d = new DailyHours();
            d.getNames();
            return View(d);
        }
        [HttpPost]
        public ActionResult DailyHours(DailyHours h)
        {
            //if (ModelState.IsValid)
           /// {
                h.InsertDailyhours(h);
                ModelState.Clear();
                DailyHours d = new DailyHours();
                d.getNames();
                return View(d);
           // }
           // else
           //     return View(h);
        }

        public ActionResult DailyHoursUpdate()
        {
            DailyHours d = new DailyHours();
            d.getNames();
            return View(d);
        }
        [HttpPost]
        public ActionResult DailyHoursUpdate(DailyHours h)
        {
            //if (ModelState.IsValid)
            /// {
           // h.updateDailyhours(h);
            ModelState.Clear();
            DailyHours d = new DailyHours();
            d.getData();
            return View(d);
            // }
            // else
            //     return View(h);
        }


    }

}
