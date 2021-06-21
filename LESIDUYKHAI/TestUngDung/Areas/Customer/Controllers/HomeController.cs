using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Customer.Controllers
{
    public class HomeController : Controller
    {
        // GET: Customer/Home
        public ActionResult Index(string searchString = "", int page = 1, int pageSize = 5)
        {
            var dao = new ProductDao();
            var categoryDao = new CategoryDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            if (DateTime.Now.Month.ToString().Length == 1)
            {
                ViewBag.monthURLImage = "0" + DateTime.Now.Month.ToString();
            }
            else
            {
                ViewBag.monthURLImage = DateTime.Now.Month.ToString();
            }
            ViewBag.yearURLImage = DateTime.Now.Year.ToString();

            ViewBag.ListCategory = categoryDao.ListAll();
            return View(model);
        }
    }
}