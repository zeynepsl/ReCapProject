using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, EfCarRentalContext>, IRentalDal
    {
        public List<RentalDetailsDto> GetRentalDetails()
        {
            using (EfCarRentalContext context = new EfCarRentalContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.CarId
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join col in context.Colors on c.ColorId equals col.ColorId
                             join user in context.Users on r.CustomerId equals user.Id

                             select new RentalDetailsDto
                             {
                                 RentalId=r.Id,
                                 CarRentDate = r.RentDate,
                                 CarReturnDate = r.ReturnDate,

                                 CarId = c.CarId,
                                 CarName = c.CarName,
                                 CarModelYear = c.ModelYear,
                                 CarDescription = c.Description,
                                 CarDailyPrice = c.DailyPrice,

                                 BrandName = b.BrandName,
                                 
                                 ColorName = col.ColorName,

                                 CustomerId = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName
                             };
                return result.ToList();

            }
        }
    }
}
