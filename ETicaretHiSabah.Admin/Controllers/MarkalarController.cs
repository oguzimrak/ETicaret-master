using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaret.BLL;
using ETicaret.DLL;

namespace ETicaretHiSabah.Admin.Controllers
{
    public class MarkalarController : Controller
    {
        MarkaManager markaman = new MarkaManager();
        // GET: Markalar
        public ActionResult MarkaIndex()
        {
            //Form load
            return View();
        }
        [HttpPost]
        public ActionResult MarkaIndex(string textmarkaAdi,string personelId)
        {
            string mesaj = null;
            if (!string.IsNullOrWhiteSpace(textmarkaAdi))
            {
                //Post
                personelId = "1";
                markaman.InsertMarka(textmarkaAdi, Convert.ToInt32(personelId)); 
            }
            else
            {
                mesaj = "Boş alanları doldurun";
            }
            return View();
        }
        public ActionResult MarkaGuncelle(int? Marka_Id)
        {
            ViewBag.UstKategori = new SelectList(markaman.MarkaGetir(), "MarkalarID", "MarkaAdi");
            return View(markaman.MarkaBul((int)Marka_Id));
        }
        [HttpPost]
        public ActionResult MarkaGuncelle(int markaID, string markaAdi)
        {
            int gnc=markaman.Guncelle(markaID,markaAdi,1);
            if (gnc>0)
            {
                TempData["GuncelleMesaji"] = "<h3 style='color:red'>Marka Güncellemesi Başarılı";
            }
            else
            {
                TempData["GuncelleMesaji"] = "<hr style='border:1px;color:red'>Marka Güncellemesi Olmadı Kontrol ediniz";
            }
            return View();
        }
    }
}