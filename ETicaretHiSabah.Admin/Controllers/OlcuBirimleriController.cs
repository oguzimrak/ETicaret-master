using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaret.BLL;
using ETicaret.DLL;

namespace ETicaretHiSabah.Admin.Controllers
{
    public class OlcuBirimleriController : Controller
    {
        OlcuBirimleriManager olcman = new OlcuBirimleriManager();
        // GET: OlcuBirimleri
        public ActionResult OlcuBirimiIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OlcuBirimiIndex(string textolcubirimiAdi,string textolcubirimiaciklama)
        {
            string mesaj = null;
            if (!string.IsNullOrWhiteSpace(textolcubirimiAdi))
            {
                //Post
                olcman.InsertOlcuBirimi(textolcubirimiAdi, textolcubirimiaciklama);
            }
            else
            {
                mesaj = "Boş alanları doldurun";
            }
            return View();
        }
        public ActionResult OlcuBirimiGuncelle(int? OlcuBirimi_ID)
        {
            ViewBag.UstKategori = new SelectList(olcman.OlcuBirimiGetir(), "OlcuBirimleriID", "OlcuBirimiAdi");
            return View(olcman.OlcuBirimiBul((int)OlcuBirimi_ID));
        }
        
        [HttpPost]
        public ActionResult OlcuBirimiGuncelle(OlcuBirimleri olcTablo)
        {
            int gnc = olcman.Guncelle(olcTablo);
            if (gnc > 0)
            {
                TempData["GuncelleMesaji"] = "<h3 style='color:red'>Ölçü Birimi Güncellemesi Başarılı";
            }
            else
            {
                TempData["GuncelleMesaji"] = "<hr style='border:1px;color:red'>Ölçü Birimi Güncellemesi Olmadı Kontrol ediniz";
            }
            return View();
        }
    }
}