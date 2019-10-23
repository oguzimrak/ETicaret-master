using ETicaret.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.BLL
{
    public class UrunlerManager
    {
        Repository<Urunler> rep = new Repository<Urunler>();

        public UrunlerManager()
        {
            rep.Liste();
        }
        public void InsertUrun(int kategoriID,int markaId,string urunAdi,decimal urunFiyati,string urunOlcuTanimi,decimal urunStok,string urunAciklama,int personelId)
        {
            int ekle = rep.Insert(new Urunler()
            {
                KategoriID=kategoriID,
                MarkaID=markaId,
                UrunAdi=urunAdi,
                UrunFiyat=urunFiyati,
                UrunOlcuTanimi=urunOlcuTanimi,
                UrunStok=urunStok,
                UrunAciklama=urunAciklama,
                PersonelID=1
            });
        }
        public List<Urunler> UrunGetir()
        {
            return rep.Liste();
        }
        public Urunler UrunBul(int UrunId)
        {
            return rep.ListeFiltre(k => k.UrunlerID==UrunId).FirstOrDefault();
        }
        public Urunler UrunDetay(int urunId)
        {
            return rep.ListeFiltre(k => k.UrunlerID == urunId).FirstOrDefault();
            //FirstOrDefault()==>varsa veri>0==> true
            //FirstOrDefault()==>yoksa veri 0 olacak==> false
        }
        public int UrunGuncelle(Urunler tabloUrun)
        {
            Urunler guncelle = rep.VeriBul(k => k.UrunlerID == tabloUrun.UrunlerID);
            if (guncelle != null)
            {
                guncelle.UrunlerID = tabloUrun.UrunlerID;
                guncelle.KategoriID = tabloUrun.KategoriID;
                guncelle.MarkaID = tabloUrun.MarkaID;
                guncelle.UrunAdi = tabloUrun.UrunAdi;
                guncelle.UrunFiyat = tabloUrun.UrunFiyat;
                guncelle.UrunOlcuTanimi = tabloUrun.UrunOlcuTanimi;
                guncelle.UrunStok = tabloUrun.UrunStok;
                guncelle.UrunAciklama = tabloUrun.UrunAciklama;
                guncelle.PersonelID = tabloUrun.PersonelID;
                int gncSonuc = rep.Update(tabloUrun);
                if (gncSonuc > 0)
                {
                    return 1;
                }
                return 0;
            }
            return 0;
        }
     
    }
}
