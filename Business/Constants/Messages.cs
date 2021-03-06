﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "The Car is added.";
        public static string CarUpdated = "The Car is updated.";
        public static string CarDeleted = "The Car is deleted.";
        public static string CarNameInvalid = "The Car name is invalid. Must be longer than 2 characters.";
        public static string CarDailyPriceInvalid = "The Car daily price is invalid. Must be greater than 0.";
        public static string CarsListed = "The Cars are listed.";
        public static string MaintenanceTime = "The System in Maintenance.";

        public static string ColorAdded = "The Color is added.";
        public static string ColorUpdated = "The Color is updated.";
        public static string ColorDeleted = "The Color is deleted.";
        public static string ColorsListed = "The Colors are listed.";
        public static string ColorNameInvalid = "The Color name is invalid.";

        public static string BrandAdded = "The Brand is added.";
        public static string BrandUpdated = "The Brand is updated.";
        public static string BrandDeleted = "The Brand is deleted.";
        public static string BrandNameInvalid = "The Brand name is invalid.";
        public static string BrandsListed = "The Brands are listed.";

        public static string CustomerAdded = "The Customer is added.";
        public static string CustomerUpdated = "The Customer is updated.";
        public static string CustomerDeleted = "The Customer is deleted.";
        public static string CustomersListed = "The Customers are listed.";

        public static string RentalAdded = "The Rental is added.";
        public static string RentalUpdated = "The Rental is updated.";
        public static string RentalDeleted = "The Rental is deleted.";
        public static string RentalsListed = "The Rental are listed.";
        public static string RentalInvalid = "The Rental is invalid. Because The Car did not return the rental company.";

        public static string CarImageAdded = "The Car Image is added.";
        public static string CarImageUpdated = "The Car Image is updated.";
        public static string CarImageDeleted= "The Car Image is deleted.";
        public static string CarImageLimitExceded = "A Car must have a maximum of 5 Car Images.";
        public static string CarImageNotExists = "The Car has not any Image.";


        public static string AuthorizationDenied = "There is no authority.";
        public static string UserRegistered = "The user is registered.";
        public static string UserNotFound = "The user is not found.";
        public static string UserAlreadyExists = "The user is already exists";

        public static string PasswordError = "Incorrect password";
        public static string SuccessfullLogin = "Successful Login";
        public static string TokenCreated = "Access Token is created.";

        public static string CreditCardAdded = "The CreditCard is added.";
        public static string CreditCardUpdated = "The CreditCard is updated.";
        public static string CreditCardDeleted = "The CreditCard is deleted.";
        public static string CreditCardsListed = "The CreditCards are listed.";

        public static string CarRented = "The Car is already rented.";






    }
}
