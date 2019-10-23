using ETicaret.BLL;
using ETicaret.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaretHiSabah.Admin.Controllers
{


    public class UrunlerController : Controller
    {
        KategorilerManager katman = new KategorilerManager();
        MarkaManager markman = new MarkaManager();
        OlcuBirimleriManager olcman = new OlcuBirimleriManager();
        UrunlerManager urunman = new UrunlerManager();
        // GET: Urunler
        public ActionResult UrunIndex()
        {
            DropDownListeler();

            return View();
        }
        public ActionResult UrunListesiIndex()
        {
            DropDownListeler();
            return View();
        }
        [HttpPost]
        public ActionResult UrunIndex(int? kategoriID, int? markaId, string urunAdi, decimal urunFiyati, string urunOlcuTanimi, decimal urunStok, string urunAciklama, int? personelID)
        {

            personelID = 1;
            urunman.InsertUrun((int)kategoriID, (int)markaId, urunAdi, urunFiyati, urunOlcuTanimi, urunStok, urunAciklama, (int)personelID);

            DropDownListeler();
            return View();
        }
        private void DropDownListeler()
        {
            ViewBag.Kategori = katman.KategoriGetir();
            ViewBag.MarkaCombobox = markman.MarkaGetir();
            ViewBag.OlcuBirimCombobox = olcman.OlcuBirimiGetir();
        }
        //********************************************
        //Ürün listesini farklı bir sayfada yapacağız
        public ActionResult UrunListesiView()
        {
            return View(urunman.UrunGetir());
        }

        public ActionResult UrunGuncelleIndex(int? UrunlerID)
        {
            //ViewBag.UrunGetir = new SelectList(urunman.UrunGetir(), "KategoriID",));
            ViewBag.KategoriGetir = katman.KategoriGetir();
            ViewBag.MarkaGetir = markman.MarkaGetir();
            ViewBag.OlcuBirimiGetir = olcman.OlcuBirimiGetir();
            return View(urunman.UrunBul((int)UrunlerID));
        }
        [HttpPost]
        public ActionResult UrunGuncelleIndex(Urunler tabloUrun)
        {
            int sonuc = urunman.UrunGuncelle(tabloUrun);
            if (sonuc > 0)
            {
                TempData["UrunGuncelle"] = "<h2 style='color:green'> Güncelleme Başarılı</h2>";
            }
            else
            {
                TempData["UrunGuncelle"] = "<h2 style='color:red'> Başarısız, Kontrol ediniz.</h2>";
            }
            ViewBag.KategoriGetir = katman.KategoriGetir();
            ViewBag.MarkaGetir = markman.MarkaGetir();
            ViewBag.OlcuBirimiGetir = olcman.OlcuBirimiGetir();
            return View(urunman.UrunBul(tabloUrun.UrunlerID));
        }

        public ActionResult UrunDetayIndex(int? UrunDetay_ID)
        {
            return View(urunman.UrunBul((int)UrunDetay_ID));
        }
     
        public ActionResult UrunResimEkleIndex(int? Urun_ID)
        {

            return View();
        }
    }
}