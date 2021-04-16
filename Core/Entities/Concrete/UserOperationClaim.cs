using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    //kullanıcının operasyon claimleri
    public class UserOperationClaim:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
