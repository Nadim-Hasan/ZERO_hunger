using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZERO_hunger.EF.Models;

namespace ZERO_hunger.Controllers
{
    public class DonationsController : Controller
    {
        HungerContext db = new HungerContext();



      
        public ActionResult Index()

        {
            return View(db.Donations.ToList());
        }
        [HttpGet]
        public ActionResult Details()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Details(int? id)
        {
            var db = new HungerContext();
            var result = (from don in db.Donations
                          select don).ToList();
            return View(result);
           // return View(donation);
        }

        // GET: Donations/Create
        public ActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
     
        public ActionResult Create(Donation donation)
        {
            if (ModelState.IsValid)
            {
                db.Donations.Add(donation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donation);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new HungerContext();
            var ed = (from em in db.Donations
                       where em.RId == id
                       select em).SingleOrDefault();
            return View(ed);
        }

      


        [HttpPost]
       
        public ActionResult Edit(Donation don)
        {
            var db = new HungerContext();
            var ed = (from em in db.Employees
                      where em.Id == don.Id
                      select em).SingleOrDefault();
          
            
            //db.Entry(ed).CurrentValues.SetValues(don);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

      






        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = await db.Donations.FindAsync(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

    







        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Donation donation = await db.Donations.FindAsync(id);
            db.Donations.Remove(donation);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
