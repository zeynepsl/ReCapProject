using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();

        //kullanıcın sahip olduğu yetkileri getir
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetUserByEmail(string email);
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
    }
}
