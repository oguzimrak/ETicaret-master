using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaret.DLL;

namespace ETicaret.BLL
{
    public class IndirimTurleriManager
    {
        //*************************************************
        Repository<indirimTurleri> rep = new Repository<indirimTurleri>();
        ETicaretDBEntities db = new ETicaretDBEntities();
        //**********************************************************
        public IndirimTurleriManager()
        {
            rep.Liste();
        }
        public void InsertIndirimTuru(string adi, string aciklama)
        {
            int ekle = rep.Insert(new indirimTurleri()
            {
                indirimTuruAdi = adi,
                Aciklama = aciklama
            });
        }
        public List<indirimTurleri> IndirimTuruGetir()
        {
            return rep.Liste();
        }
        public indirimTurleri IndirimTuruBul(int IndirimTuruId)
        {
            return rep.VeriBul(m => m.indirimTurleriID == IndirimTuruId);
        }
        public int indirimTurleriGuncelle(indirimTurleri indirimTablo)
        {
            db.Entry(indirimTablo).State = System.Data.Entity.EntityState.Modified;
            if (db.SaveChanges() > 0)
            {
                return 1;
            }
            return 0;
        }
    }
}
