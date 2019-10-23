using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaret.DLL;
namespace ETicaret.BLL
{
    
    public class KategorilerManager
    {
        
        Repository<Kategoriler> rep = new Repository<Kategoriler>();

        public KategorilerManager()
        {
            rep.Liste();
        }
        public void InsertKategori(string adi,int parentID,int personelId)
        {
            int ekle = rep.Insert(new Kategoriler() {
                KategoriAdi = adi,
                ParentKategoriID=parentID,
                PersonelID=personelId
            });
        }
        public List<Kategoriler> KategoriGetir()
        {
            return rep.Liste();
        }
        public Kategoriler KategoriBul(int KatId)
        {
            return rep.VeriBul(k => k.KategorilerID == KatId);
        }
        public int ParentKategoriGetir(int Kategori_Id)
        {            
            var Parent_Id= rep.VeriBul(k=>k.KategorilerID==Kategori_Id).ParentKategoriID;
            return (int)Parent_Id;
        }
        public int KategoriGuncelle(int Kategori_Id, Kategoriler tabloKategori)
        {           
            Kategoriler guncelle = rep.VeriBul(k => k.KategorilerID == Kategori_Id);
            if (guncelle!=null)
            {
                guncelle.KategoriAdi = tabloKategori.KategoriAdi;
                guncelle.ParentKategoriID = tabloKategori.ParentKategoriID;
                guncelle.PersonelID = tabloKategori.PersonelID;
                int gncSonuc= rep.Update(tabloKategori);
                if (gncSonuc>0)
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}
