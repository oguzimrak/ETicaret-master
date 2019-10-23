using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaret.BLL;
using ETicaret.DLL;

namespace ETicaretHiSabah.Admin.Controllers
{
    public class IndirimTurleriController : Controller
    {
        IndirimTurleriManager indirimturman = new IndirimTurleriManager();
        // GET: IndirimTurleri
        public ActionResult IndirimTurleriIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IndirimTurleriIndex(string textindirimturuAdi, string textindirimturuaciklama)
        {
            string mesaj = null;
            if (!string.IsNullOrWhiteSpace(textindirimturuAdi))
            {
                //Post
                indirimturman.InsertIndirimTuru(textindirimturuAdi, textindirimturuaciklama);
            }
            else
            {
                mesaj = "Boş alanları doldurun";
            }
            return View();
        }
        public ActionResult IndirimTurleriGuncelle(int? IndirimTuru_Id)
        {
            ViewBag.IndirimTuru = new SelectList(indirimturman.IndirimTuruGetir(), "indirimTurleriID", "indirimTuruAdi");
            return View(indirimturman.IndirimTuruBul((int)IndirimTuru_Id));
        }
        [HttpPost]
        public ActionResult IndirimTurleriGuncelle(indirimTurleri indirimTablo)
        {
            int gnc = indirimturman.indirimTurleriGuncelle(indirimTablo);
            if (gnc > 0)
            {
                TempData["GuncelleMesaji"] = "<h3 style='color:red'>İndirim Türü Güncellemesi Başarılı";
            }
            else
            {
                TempData["GuncelleMesaji"] = "<hr style='border:1px;color:red'>İndirim Türü Güncellemesi Olmadı Kontrol ediniz";
            }
            return View();
        }
    }
}