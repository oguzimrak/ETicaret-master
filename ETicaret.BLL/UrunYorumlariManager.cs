using ETicaret.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.BLL
{
    public class UrunYorumlariManager
    {
        Repository<Yorumlar> repYorum = new Repository<Yorumlar>();


        public UrunYorumlariManager()
        {
            repYorum.Liste();
        }
        public void InsertYorum(int uyeId,int urunId, string yorumbaslik,string yorummetni,int star, DateTime tarih, int begenmesayisi,int begenmemesayisi)
        {
            int ekle = repYorum.Insert(new Yorumlar()
            {
                UyeID = uyeId,
                UrunID=urunId,
                YorumBasligi=yorumbaslik,
                YorumMetni=yorummetni,
                Star=star,
                Tarihi=tarih,
                BegenmeSayisi=begenmesayisi,
                BegenmemeSayisi=begenmemesayisi,
                OnayDurumu=false
            });
        }
        public void UpdateYorum(int yorumId,int uyeId, int urunId, string yorumbaslik, string yorummetni, int star, DateTime tarih, int begenmesayisi, int begenmemesayisi)
        {
            int ekle = repYorum.Update(new Yorumlar()
            {
                YorumlarID=yorumId,
                UyeID = uyeId,
                UrunID = urunId,
                YorumBasligi = yorumbaslik,
                YorumMetni = yorummetni,
                Star = star,
                Tarihi = tarih,
                BegenmeSayisi = begenmesayisi,
                BegenmemeSayisi = begenmemesayisi
            });
        }
        public void DeleteYorum(int yorumId)
        {
            int ekle = repYorum.Delete(new Yorumlar()
            {
                YorumlarID=yorumId
            });
        }
        public List<Yorumlar> Liste(int urunlerID)
        {
            return repYorum.ListeFiltre(k => k.UrunID == urunlerID).ToList();
            //return repYorum.ListeFiltre(k => k.UrunID == urunlerID && k.OnayDurumu == true).ToList();
        }
    }
}
