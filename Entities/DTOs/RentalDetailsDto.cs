using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailsDto:IDto
    {
        public int RentalId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CarName { get; set; }
        public String BrandName { get; set; }
        public String ColorName { get; set; }
        public DateTime CarModelYear { get; set; }
        public double CarDailyPrice { get; set; }
        public string CarDescription { get; set; }
        public DateTime CarRentDate { get; set; }
        public DateTime CarReturnDate { get; set; }
       
    }
}
