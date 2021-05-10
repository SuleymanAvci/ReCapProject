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
    class RentalManager : IRentalService
    {

        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }


        public IResult Add(Rental rental)
        {
            if (rental.Id < 0)
            {
                return new ErrorResult(Messages.UnitNameInvalid);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.UnitAdded);
        }

        public IResult Update(Rental rental)
        {
            if (rental.Id < 0)
            {
                return new ErrorResult(Messages.UnitNameInvalid);
            }
            _rentalDal.Update(rental);
            return new SuccessResult("Ürün güncellendi");
        }


        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.UnitDeleted);
        }

        public IDataResult<Rental> GetRentalById(int id)
        {
            if (_rentalDal.Get(c => c.Id == id) != null)
            {
                return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.Id == id));
            }
            return new ErrorDataResult<Rental>(Messages.UnitNotFound);
        }


        public IDataResult<List<Rental>> GetAll()
        {
            if (_rentalDal.GetAll() == null)
            {
                return new ErrorDataResult<List<Rental>>(Messages.UnitNotFound);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }


    }
}
