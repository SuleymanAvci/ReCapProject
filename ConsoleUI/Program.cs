using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarAddTest();
            //CarUpdateTest();
            //CarDeleteTest();            
            //GetCarByIdTest();
            //CarGetAllTest();

            //GetCarDetailsTest();
            //GetCarsByBrandIdTest();
            GetCarsByColorIdTest();

            //CetCarsByColorId();
            //CetCarDetails();
            //ColorGetAll();

            //CarListTest();




        }



        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.Add(new Car {CarName="eeee", ColorId=3, BrandId=4, DailyPrice=444, Description="uuuu", ModelYear="2001" });    
            
            Console.WriteLine(result.Message);
        }


        private static void CarUpdateTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.Update(new Car { CarId = 25, CarName = "Mercedes ccc" });

            Console.WriteLine(result.Message);
        }


        private static void CarDeleteTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.Delete(new Car { CarId = 1024 });
            
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
        }


        private static void GetCarByIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarById(3);
            if (result.Data == null)
            {
                Console.WriteLine(result.Success + " - " + result.Message);
            }
            else
            {
                Console.WriteLine(result.Data.CarName + " - " + result.Data.DailyPrice + " - " + result.Data.Description);
            }
        }


        private static void CarGetAllTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + " - " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }


        private static void GetCarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + " - " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetCarsByBrandIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarsByBrandId(4);

            foreach (var car in result.Data)
            {
                Console.WriteLine(car.BrandId + " - " + car.CarName);
            }
        }


        private static void GetCarsByColorIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarsByColorId(3);

            foreach (var car in result.Data)
            {
                Console.WriteLine(car.ColorId + " - " + car.CarName);
            }
        }


    }
}
