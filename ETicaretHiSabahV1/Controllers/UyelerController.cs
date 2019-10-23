using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaret.BLL;
using ETicaret.DLL;


namespace ETicaretHiSabahV1.Controllers
{
    public class UyelerController : Controller
    {
        UyelerManager uyeman = new UyelerManager();

        // GET: Uyeler
        public ActionResult UyelerIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyelerIndex(string UyeAdi,string Email,string Sifre,string Sifre_Tekrar)
        {
            if (Sifre!=Sifre_Tekrar)
            {
                ViewBag.SifreAynimi = "Şifreler Uyuşmuyor";
                return View();
            }
            else
            {
                DateTime tarih = DateTime.Now;
                uyeman.UyeKaydet(UyeAdi, null, Convert.ToDateTime(tarih), Email, null, null, null, null, "", Email, Sifre);
                return RedirectToAction("DefaultIndex", "Default");
                //RedirecToAction ile Index adı ve klasör adı vererek, klasör altındaki Index i çalıştırmasını sağlıyoruz.
                // Bu RedirecToAction aldığı parametre ile Controller altındaki ActionName parametre alır, ikinci parametresi ise Controller adını alarak aynı klasör mantığında olduğu gibi Index sayfası çalıştırır.
            }

        }
    }
}