using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentaCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using(RentaCarContext context = new RentaCarContext())
            {
                var result = from p in context.Cars
                             join c in context.Brands
                             on p.BrandId equals c.BrandId 
                             join t in context.Colors 
                             on p.ColorId equals t.ColorId
                             select new CarDetailDto { CarId = p.CarId, CarName = p.CarName, BrandName = c.BrandName, ColorName=t.ColorName, DailyPrice = p.DailyPrice };
                return result.ToList();
            }
        }
    }
}
