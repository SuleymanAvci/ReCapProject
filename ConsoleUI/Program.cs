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
            CarAddTest();
            //CarUpdateTest();
            //CarDeleteTest();            
            //GetCarByIdTest();
            //CarGetAllTest();

            //GetCarDetailsTest();
            //GetCarsByBrandIdTest();
            //GetCarsByColorIdTest();
            //CetCarsByColorId();


            //***********************************************

            //UserAddTest();
            //CustomerAddTest();


            //RentalAddTest();

        }

        private static void RentalAddTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.Add(new Rental
            {
                RentalCarId = 1,
                CustomerId = 1,
                RentDate = new DateTime(2021-06-04),
                ReturnDate = new DateTime(2021-06-06)
            });
        }

        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.Add(new Car {CarName="ttttt", ColorId=3, BrandId=4, DailyPrice=555, Description="uuuu", ModelYear="2001" });    
            
            Console.WriteLine(result.Message);
        }


        private static void CarUpdateTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.Update(new Car { Id = 25, CarName = "Mercedes ccc" });

            Console.WriteLine(result.Message);
        }


        private static void CarDeleteTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.Delete(new Car { Id = 1024 });
            
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

        //****************************************************************************************


        private static void UserAddTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.Add(new User { FirstName = "Süleyman", LastName = "AVCI", Email = "aa@cc", Password = "12345" });

            Console.WriteLine(result.Message);
        }


        private static void CustomerAddTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(new Customer { UserId = 1, CompanyName = "Dadal" });

            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

    }
}
      