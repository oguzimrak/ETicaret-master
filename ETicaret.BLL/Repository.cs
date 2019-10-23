﻿using ETicaret.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.BLL
{
    public class Repository<T> where T:class//Class a eklenen kod yapısıyla bu class ın instance alacağını belirtiyoruz
    {
        ETicaretDBEntities db = new ETicaretDBEntities();
        
        public List<T> Liste()
        {
            return db.Set<T>().ToList();
            //clss adı olan repository eğer kısıtlama yoksa hata verecektir.Biz Repository class ını where ile onun bir class olduğunu belirteceğiz.
        }
        public int Save()
        {
            return db.SaveChanges();
        }
        public int Insert(T nesne)
        {
            db.Set<T>().Add(nesne);
            return Save();
        }
        public int Update(T nesne)
        {
            return Save();
        }
        public int Delete(T nesne)
        {
            db.Set<T>().Remove(nesne);
            return Save();
        }
        public List<T> Liste(Expression<Func<T,bool>> sorguWhere)
        {
            //<=>x.ID==12
            //Expression<Func<T,bool>>==> Bİr parametre olarak tanımladık.
            return db.Set<T>().Where(sorguWhere).ToList();
        }

        //Orderby,Top,Group BY
        public IQueryable<T> ListeFiltre(Expression<Func<T,bool>> sorguWhere)
        {
            return db.Set<T>().Where(sorguWhere);
        }

        public T VeriBul(Expression<Func<T,bool>> SorguKodu)
        {
            //return db.Set<T>().FirstOrDefault(SorguKodu);
            return db.Set<T>().Where(SorguKodu).FirstOrDefault();

        }
    }

}
