using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            
            CarTest();
            Console.WriteLine();
            ColorTest();
            Console.WriteLine();
            BrandTest();
            Console.WriteLine();
            CarDetailsTest();
            Console.WriteLine();

            CustomerAddTest();
            RentalAddTest();

            Console.WriteLine();
            CustomerTest();
            Console.WriteLine();
            RentalTest();
       



        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
                foreach (var car in carManager.GetAll().Data)
                {
                    Console.WriteLine("CarId: {0} BrandId: {1} ColorId: {2} DailyPrice: {3} Description: {4}"
                        , car.CarId, car.BrandId, car.ColorId, car.DailyPrice, car.Description);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.Add(new Car { BrandId = 3, ColorId = 2, ModelYear = "2021", DailyPrice = 400, Description="Luxury" });
            Console.WriteLine(result.Message);
        }
            private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine("BrandId: {0} BrandName: {1}", brand.BrandId, brand.BrandName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine("ColorId: {0} ColorName: {1}", color.ColorId, color.ColorName);
            }
        }

        private static void CarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine("CarName: {0} BrandName: {1} ColorName: {2} DailyPrice: {3}"
                        , car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void CustomerAddTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(new Customer { CompanyName = "Ahmet Company", UserId = 4 });
            Console.WriteLine(result.Message);
            var result2 = customerManager.Add(new Customer { CompanyName = "Hazel Company", UserId = 5 });
            Console.WriteLine(result2.Message);
        }
        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine("CustomerId: {0} CompanyName: {1} UserId: {2}"
                    , customer.CustomerId, customer.CompanyName, customer.UserId);
            }
        }

        private static void RentalAddTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentDate = new DateTime(2021, 02, 22), ReturnDate = new DateTime(2021, 02, 25) });
            Console.WriteLine(result.Message);

        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine("RentalId: {0} CarID: {1} CustomerId: {2} RentDate: {3} ReturnDate: {4}"
                    , rental.Id, rental.CarId, rental.CustomerId, rental.RentDate, rental.ReturnDate);
            }
        }









    }
}
