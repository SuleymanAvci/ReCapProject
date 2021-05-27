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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length < 2)
            {
                return new ErrorResult(Messages.UnitNameInvalid);
            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.UnitAdded);
        }


        public IResult Update(Brand brand)
        {
            if (brand.BrandName.Length < 1)
            {
                return new ErrorResult(Messages.UnitNameInvalid);
            }
            _brandDal.Update(brand);
            return new SuccessResult("Model güncellendi");
        }


        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.UnitDeleted);
        }

        public IDataResult<Brand> GetBrandById(int id)
        {
            if (_brandDal.Get(c => c.Id == id) != null)
            {
                return new SuccessDataResult<Brand>(_brandDal.Get(c => c.Id == id));
            }
            return new ErrorDataResult<Brand>(Messages.UnitNotFound);
        }


        public IDataResult<List<Brand>> GetAll()
        {
            if (_brandDal.GetAll() == null)
            {
                return new ErrorDataResult<List<Brand>>(Messages.UnitNotFound);
            }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }





    }
}
