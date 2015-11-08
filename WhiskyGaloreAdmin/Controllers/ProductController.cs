using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhiskyGaloreAdmin.Models;

namespace WhiskyGaloreAdmin.Controllers
{
    public class ProductController : Controller
    {

        public ActionResult Index()
        {
            Product p = new Product();
            return View(p);
        }
        public ActionResult Tables()
        {
            Product p = new Product();
            return View(p);
        }

    }
}