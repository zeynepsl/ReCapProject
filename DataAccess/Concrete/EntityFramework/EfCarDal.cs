using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            //bu using farklı == IDisposable pattern implementation 0f c#
            //c# a özel 
            //using içine yazılan nesneler, using bitince garbage collector tarafından hemen atılır. çünkü:
            //context nesnesi biraz pahalı
            //bu şekilde de belleği hızlı temizlemiş oluyoruz.
            using (EfCarRentalContext context = new EfCarRentalContext())
            {
                var addedEntity = context.Entry(entity); //REFERANSI YAKALA, EfCarRentalContext LE BAĞLA BU ENTİTY Yİ
                //yani veri kaynağıyla ilişkilendir
                addedEntity.State = EntityState.Added;
                context.SaveChanges(); //ekle
            }
        }

        public void Delete(Car entity)
        {
            using(EfCarRentalContext context = new EfCarRentalContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using(EfCarRentalContext context = new EfCarRentalContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using(EfCarRentalContext context = new EfCarRentalContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
