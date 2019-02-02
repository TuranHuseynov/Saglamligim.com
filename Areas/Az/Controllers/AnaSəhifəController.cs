using AzmanAzWebPage.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AzmanAzWebPage.Models;
using AzmanAzWebPage.Viewmodel;

namespace AzmanAzWebPage.Areas.Az.Controllers
{
    [UserFilterController]
    public class AnaSəhifəController : Controller
    {
        DB_A3E145_SaglamligimEntities db = new DB_A3E145_SaglamligimEntities();
        MyModel vm = new MyModel();
        // GET: Az/AnaSəhifə
        public ActionResult Index()
        {
            vm._zakazim = db.Zakazims.ToList();
            vm._elaqe = db.Elaqes.ToList();
            
            return View(vm);
        }
    }
}