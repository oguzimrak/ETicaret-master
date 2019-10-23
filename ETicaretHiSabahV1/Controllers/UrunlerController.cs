using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaret.BLL;

namespace ETicaretHiSabahV1.Controllers
{
    public class UrunlerController : Controller
    {
        UrunlerManager urunman = new UrunlerManager();
        //****************************************************
        // ETicaretDBEntities db=new ETicaretDBEntities();
        //****************************************************
        UrunYorumlariManager yorman = new UrunYorumlariManager();

        // GET: Urunler
        public ActionResult UrunlerIndex()
        {
            return View();
        }
        public ActionResult UrunDetay()
        {
            //ürünler sayfasında üründetay tıklandığında ürün id değerini tutacak Route data kodlaması yapacağız.
            var dataId = RouteData.Values["id"];
            //var tutulanIdsonuc=db.Urunler.Where(k=>k.UrunlerID==Convert.ToInt32(dataId));
            var detay = urunman.UrunDetay(Convert.ToInt32(dataId));
            
            return View(detay);
        }
        public ActionResult UrunYorumIndex()
        {
            return View();
        }

        [HttpPost]
        public void UrunYorumIndex(string YorumBaslik, string YorumMetni,int? urunId,int? uyeId)
        {
            yorman.InsertYorum(1, (int)urunId, YorumBaslik, YorumMetni, 0, Convert.ToDateTime(DateTime.Now.ToShortDateString()), 1, 1);
        }
    }
}