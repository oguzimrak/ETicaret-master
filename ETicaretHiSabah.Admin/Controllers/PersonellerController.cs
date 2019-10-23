using ETicaret.BLL;
using ETicaret.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaretHiSabah.Admin.Controllers
{
    public class PersonellerController : Controller
    {
        PersonelManager persman = new PersonelManager();
        RolManager rolman = new RolManager();
        // GET: Personeller
        public ActionResult PersonelListeIndex()
        {
            return View();
        }
        
        public ActionResult PersonelEkle()
        {
            ViewBag.Roller=rolman.PersonelRolGetir();
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personeller tabloPersonel)
        {
            ViewBag.Roller = rolman.PersonelRolGetir();
            persman.InsertPersonel(tabloPersonel);
            
            return View();
        }
        [HttpPost]
        public void PersonelSil(int personelID)
        {
            persman.PersonelSil(personelID);
        }
    }
}