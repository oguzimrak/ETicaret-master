using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaret.BLL;
using ETicaret.DLL;
namespace ETicaretHiSabah.Admin.Controllers
{
    public class LoginController : Controller
    {
        PersonelManager persMan = new PersonelManager();
        // GET: Login
        public ActionResult LoginIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginIndex(string kullaniciAdi, string sifre)
        {
            var loginGiris = persMan.Giris(kullaniciAdi, sifre);
            if (loginGiris != null)
            {
                //Admin sayfasına yönlendirme yapılacak
                ViewBag.personelID = loginGiris.PersonellerID;
                return RedirectToAction("DefaultIndex","Default");
            }
            else
            {
                ViewBag.mesaj = "<hr/><h5 style='color:red'>Kullanıcı Adı veya Şifre Hatalı</h5>";
            }
            return View();
        }
    }
}