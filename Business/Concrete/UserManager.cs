using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if(user.FirstName.Length > 2)//iş kodlarından geçerse,
            {
                _userDal.Add(user); //DataAccess katmanına bağlanacağız
                return new SuccessResult(Messages.Added);
            }
            return new ErrorResult(Messages.NameInValid);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IResult Update(User user)
        {
            if (user.FirstName.Length > 2)//iş kodlarından geçerse,
            {
                _userDal.Update(user); //DataAccess katmanına bağlanacağız
                return new SuccessResult(Messages.Updated);
            }
            return new ErrorResult();
        }
    }
}
