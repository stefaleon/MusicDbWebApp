using MusicDbMVCWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        // GET: Bands/SelectBand/42
        public ActionResult SelectBand(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var selectedBand = db.Bands.Find(id);

            if (selectedBand == null)
            {
                return HttpNotFound();
            }

            var members = selectedBand.People.ToList();

            var viewModel = new BandViewModel
            {
                mBand = selectedBand,
                mMembers = members                
            };

            return View("Band", viewModel);
        }



    }
}