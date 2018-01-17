using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using MusicDbMVCWebApp.ViewModels;

namespace MusicDbMVCWebApp.Controllers
{    
    public class PeopleController : Controller
    {
        private MusicDbEntities db = new MusicDbEntities();

        // GET: People
        public ActionResult Index()
        {
            var people = db.People.ToList();

            return View("People", people);
        }

        // GET: People/SelectPerson/69
        public ActionResult SelectPerson(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var selectedPerson = db.People.Find(id);

            if (selectedPerson == null)
            {
                return HttpNotFound();
            }

            var bands = selectedPerson.Bands.ToList();

            var viewModel = new PersonViewModel
            {
                mPerson = selectedPerson,
                mBands = bands
            };

            return View("Person", viewModel);
        }

    }
}