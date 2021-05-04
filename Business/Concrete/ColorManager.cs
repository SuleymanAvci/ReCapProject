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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            if (color.ColorName.Length < 2)
            {
                return new ErrorResult(Messages.ColorNameInvalid);
            }
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Update(Color color)
        {
            if (color.ColorName.Length < 1)
            {
                return new ErrorResult(Messages.ColorNameInvalid);
            }
            _colorDal.Update(color);
            return new SuccessResult("Ürün güncellendi");
        }


        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

         public IDataResult<Color> GetColorById(int id)
        {
            if (_colorDal.Get(c => c.ColorId == id) != null)
            {
                return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == id));
            }
            return new ErrorDataResult<Color>(Messages.UnitNotFound);
        }


       public IDataResult<List<Color>> GetAll()
        {
            if (_colorDal.GetAll() == null)
            {
                return new ErrorDataResult<List<Color>>(Messages.UnitNotFound);
            }
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }



    }
}
