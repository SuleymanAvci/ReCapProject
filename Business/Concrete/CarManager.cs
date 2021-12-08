using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            
            _carDal.Add(car);                
            return new SuccessResult(Messages.UnitAdded);
        }


        public IResult Update(Car car)
        {
            if(car.CarName.Length<1)
            {
                return new ErrorResult(Messages.UnitNameInvalid);
            }
            _carDal.Update(car);
            return new SuccessResult("Ürün güncellendi");
        }


        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.UnitDeleted);
        }


        public IDataResult<Car> GetCarById(int id)
        {
            if (_carDal.Get(c => c.Id == id) != null)
            {
                return new SuccessDataResult<Car>(_carDal.Get(c => c.Id==id));
            }
            return new ErrorDataResult<Car>(Messages.UnitNotFound);
        }


        public IDataResult<List<Car>> GetAll()
        {
            if (_carDal.GetAll() == null)
            {
                return new ErrorDataResult<List<Car>>(Messages.UnitNotFound);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }


        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (_carDal.GetCarDetails()==null)
            {
                return new ErrorDataResult<List<CarDetailDto>>();
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }


        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {

             return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));

        }


        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }

        private IResult CheckIfCarCountOfBrandCorrect(int brandId)
        {
            var result = _carDal.GetAll(p => p.BrandId == brandId).Count();
            if (result>10)
            {
                return new ErrorResult(Messages.CarCountOfBrandError);
            }
            return new SuccessResult();
        }

    }
}
