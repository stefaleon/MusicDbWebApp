using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicDbMVCWebApp.Controllers
{
    public class BandsController : Controller
    {
        private MusicDbEntities db = new MusicDbEntities();

        // GET: Bands
        public ActionResult Index()
        {
            var bands = db.Bands.ToList();

            return View("Bands", bands);
        }
    }
}