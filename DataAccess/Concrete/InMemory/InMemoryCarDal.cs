using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=4,ModelYear="2010",DailyPrice=200, Description="Klima yok"},
                new Car{Id=2,BrandId=2,ColorId=2,ModelYear="2011",DailyPrice=300, Description="Klima var"},
                new Car{Id=3,BrandId=1,ColorId=3,ModelYear="2011",DailyPrice=300, Description="Klima var"},
                new Car{Id=4,BrandId=1,ColorId=4,ModelYear="2012",DailyPrice=400, Description="Klima var"},
                new Car{Id=5,BrandId=2,ColorId=2,ModelYear="2013",DailyPrice=450, Description="Klima var,Dizel"},
                new Car{Id=6,BrandId=2,ColorId=4,ModelYear="2013",DailyPrice=450, Description="Klima var,Dizel"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car deletedCar = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(deletedCar);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }



        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            return _cars.SingleOrDefault(c => c.Id == 1);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;

        }
    }
}
