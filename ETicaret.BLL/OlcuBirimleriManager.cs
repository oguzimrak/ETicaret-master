using ETicaret.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.BLL
{
    public class OlcuBirimleriManager
    {
        Repository<OlcuBirimleri> rep = new Repository<OlcuBirimleri>();
        ETicaretDBEntities db = new ETicaretDBEntities();

        public OlcuBirimleriManager()
        {
            rep.Liste();
        }
        public void InsertOlcuBirimi(string adi, string aciklama)
        {
            int ekle = rep.Insert(new OlcuBirimleri()
            {
                OlcuBirimiAdi =adi,
                Aciklama = aciklama
            });
        }
        public List<OlcuBirimleri> OlcuBirimiGetir()
        {
            return rep.Liste();
        }
        public OlcuBirimleri OlcuBirimiBul(int OlcuBirimiId)
        {
            return rep.VeriBul(m => m.OlcuBirimleriID == OlcuBirimiId);
        }
        public OlcuBirimleri OlcuBirimiBul(string OlcuBirimiId)
        {
            return rep.VeriBul(m => m.OlcuBirimiAdi == OlcuBirimiId);
        }
        public int Guncelle(OlcuBirimleri tabloGuncelle)
        {
            db.Entry(tabloGuncelle).State = System.Data.Entity.EntityState.Modified;
            if (db.SaveChanges() > 0)
            {
                return 1;
            }
            return 0;
        }
    }
}
