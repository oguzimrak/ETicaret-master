using ETicaret.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.BLL
{
    public class MarkaManager
    {
        /***********************************************************/
        Repository<Markalar> rep = new Repository<Markalar>();
        ETicaretDBEntities db = new ETicaretDBEntities();
        /***********************************************************/

        public MarkaManager()
        {
            rep.Liste();
        }
        public void InsertMarka(string adi, int personelId)
        {
            int Ekle = rep.Insert(new Markalar()
            {
                MarkaAdi = adi,
                PersonelID = personelId
            });
        }
        public List<Markalar> MarkaGetir()
        {
            return rep.Liste();
        }
        public Markalar MarkaBul(int MarkaId)
        {
            return rep.VeriBul(m => m.MarkalarID == MarkaId);
        }
        public int Guncelle(int markaID, string markaAdi,int PersonelID)
        {
            Markalar guncelle = rep.VeriBul(k => k.MarkalarID == markaID);

            if (guncelle != null)
            {
                guncelle.MarkaAdi = markaAdi;
                guncelle.PersonelID = PersonelID;
                int gncSonuc = rep.Update(guncelle);
                if (gncSonuc > 0)
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}
