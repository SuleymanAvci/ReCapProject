using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (user.FirstName.Length < 2)
            {
                return new ErrorResult(Messages.UnitNameInvalid);
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.UnitAdded);
        }

        public IResult Update(User user)
        {
            if (user.FirstName.Length < 1)
            {
                return new ErrorResult(Messages.UnitNameInvalid);
            }
            _userDal.Update(user);
            return new SuccessResult("Ürün güncellendi");
        }


        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UnitDeleted);
        }

        public IDataResult<User> GetUserById(int id)
        {
            if (_userDal.Get(c => c.Id == id) != null)
            {
                return new SuccessDataResult<User>(_userDal.Get(c => c.Id == id));
            }
            return new ErrorDataResult<User>(Messages.UnitNotFound);
        }


        public IDataResult<List<User>> GetAll()
        {
            if (_userDal.GetAll() == null)
            {
                return new ErrorDataResult<List<User>>(Messages.UnitNotFound);
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }




    }
}
