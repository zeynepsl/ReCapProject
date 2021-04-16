using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal: IEntityRepository<User>
    {
        //miras aldığım tüm metotlara ek olarak
        //parametre olarak verdiğim kullanıcının sahip olduğu Operasyon claimlerini de(yetkiler vs...) çekmek istiyorum
        //kullanıcının rollerini çekeceğim
        List<OperationClaim> GetClaims(User user);
    }
}
