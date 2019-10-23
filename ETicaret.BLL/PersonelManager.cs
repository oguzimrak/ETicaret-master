using ETicaret.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ETicaret.BLL
{
    public class PersonelManager
    {
        Repository<Personeller> repPers = new Repository<Personeller>();

        ETicaretDBEntities db = new ETicaretDBEntities();

        public Personeller Giris(string kullanici_Adi,string sifre)
        {
            //var giris1 = repPers.ListeFiltre(k => (k.KAdi == kullanici_Adi || k.EMail == kullanici_Adi) && k.KSifre == sifre);
            //int p_ID=giris1.FirstOrDefault().PersonellerID;

            var giris2 = repPers.VeriBul(k => (k.KAdi == kullanici_Adi || k.EMail == kullanici_Adi) && k.KSifre == sifre);
            //Aşağıdaki ID yapısıyla Veribul metodunun içinde FirstOrDefault() olmasından dolayı alabildi.Aynı işlemi ListeFiltre() metodu ile almak için giris1.FirstOrDefault dedikten sonra almamız lazım.
            //int PersId = giris2.PersonellerID;

            return giris2;
        }

        public List<Personeller> PersonelGetir()
        {
            return repPers.Liste();
        }
        public int InsertPersonel(Personeller tabloPersonel)
        {
            int ekleSonuc = repPers.Insert(tabloPersonel);
            if (ekleSonuc>0)
            {
                return 1;
            }
            return 0;
        }
        public int PersonelSil(int personelID)
        {
            Personeller silSorgu = repPers.VeriBul(k => k.PersonellerID == personelID);
            if (silSorgu != null)
            {
                int silSonuc = repPers.Delete(silSorgu);
                if (silSonuc > 0)
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}
