using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public  interface IRepository<T>
    {
        List<T> List();
        void Insert(T p);

        //Sadece ID ye gore buldurma yapıyoruz
        T Get(Expression<Func<T, bool>> filter);
        
        void Delete(T p);
        void Update(T p);
        //Burada tüm bilgileri listeletip aratıyoruz
        List<T> List(Expression<Func<T, bool>> filter);
       
    }
}
