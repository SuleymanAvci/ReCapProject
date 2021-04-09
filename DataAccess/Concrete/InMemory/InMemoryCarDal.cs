using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Car carDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carDelete);
        }

        public List<Car> GetAll()
        {
            throw new NotImplementedException();
        }

        public Car GetById(Car car)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
