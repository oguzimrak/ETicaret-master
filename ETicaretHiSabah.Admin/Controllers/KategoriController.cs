using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaret.BLL;
using ETicaret.DLL;

namespace ETicaretHiSabah.Admin.Controllers
{
    public class KategoriController : Controller
    {
        //*************************************************//
        KategorilerManager katman = new KategorilerManager();
        //**************************************************//
        // GET: Kategori
        public ActionResult KategoriIndex()
        {
            //Ustkategori değişkeni bir liste yapısı çağırdık ve bu liste yapısını view sayfasında select tsgi içinde foreach ile listeleyeceğiz
            ViewBag.UstKategori = katman.KategoriGetir();
            return View();
        }
        [HttpPost]
        public ActionResult KategoriIndex(string kadi, int? PKatID, int? personelID)
        {
            string ustKatVarmi = "var";
            if (ustKatVarmi=="var")
            {
                personelID = 1;
                katman.InsertKategori(kadi, (int)PKatID, (int)personelID);
            }
            else
            {
                katman.InsertKategori(kadi, 0, (int)personelID);
            }
            
            ViewBag.UstKategori = katman.KategoriGetir();
            return View();
        }
        public ActionResult KategoriGuncelle(int? Kategori_Id)
        {
            ViewBag.UstKategori = new SelectList(katman.KategoriGetir(), "KategorilerID", "KategoriAdi",katman.ParentKategoriGetir((int)Kategori_Id));
            ViewBag.UstKategori = katman.KategoriGetir();
            return View(katman.KategoriBul((int)Kategori_Id));
        }
        [HttpPost]
        public ActionResult KategoriGuncelle(int Kategori_Id, Kategoriler tabloKategori)
        {
            int sonuc = katman.KategoriGuncelle(Kategori_Id,tabloKategori);
            if (sonuc>0)
            {
                TempData["KategoriGuncelle"] = "<h2 style='color:green'> Güncelleme Başarılı</h2>";
            }
            else
            {
                TempData["KategoriGuncelle"] = "<h2 style='color:red'> Başarısız, Kontrol ediniz.</h2>";
            }
            ViewBag.UstKategori = katman.KategoriGetir();
            return View(katman.KategoriBul((int)Kategori_Id));
        }
    }
}