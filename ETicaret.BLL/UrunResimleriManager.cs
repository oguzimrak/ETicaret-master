using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaret.DLL;

namespace ETicaret.BLL
{
    public class UrunResimleriManager
    {
        Repository<UrunResimleri> repResimler = new Repository<UrunResimleri>();

        public int ResimBul(int Urun_Id)
        {
            var bulResim = repResimler.VeriBul(k => k.UrunID == Urun_Id).UrunID;
            return (int)bulResim;
        }
    }
}
