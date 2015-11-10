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
            return View(new DailyHours());
        }
        [HttpPost]
        public ActionResult DailyHours(DailyHours h)
        {
            h.InsertDailyhours(h);
            System.Diagnostics.Debug.WriteLine("returning !");
            return View(new DailyHours());
        }

    }

}
