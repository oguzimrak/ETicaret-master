using ETicaret.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.BLL
{
    public class RolManager
    {
        Repository<PersonelRolleri> repRol = new Repository<PersonelRolleri>();
        

        public List<PersonelRolleri> PersonelRolGetir()
        {
            return repRol.Liste();
        }
    }
}
