﻿using System.Web.Mvc;

namespace Web.Controllers
{
    public class GameController : Controller
    {        
        public ActionResult Index()
        {
            return View();
        }
    }
}