using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            //bu using c# a özel: IDisposable pattern implementation 0f c#
            //context nesnesi biraz pahalı; bu yüzden: belleği hızlı temizleme:
            //using içine yazdığın neseneler, using metodu bitince garbage collector tarfından hemen bellekten atılır
        }

        public void Delete(Color Entity)
        {
            throw new NotImplementedException();
        }

        public Color Get()
        {
            throw new NotImplementedException();
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Color entity)
        {
            throw new NotImplementedException();
        }
    }
}
