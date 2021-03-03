CREATE TABLE Brands(
	BrandId int PRIMARY KEY NOT NULL IDENTITY(1,1),
	BrandName TEXT
)

CREATE TABLE Colors(
	ColorId int PRIMARY KEY NOT NULL IDENTITY(1,1),
	ColorName TEXT
)

CREATE TABLE Cars(
	CarId int PRIMARY KEY NOT NULL IDENTITY(1,1),
	BrandId int, 
	ColorId int,
	ModelYear TEXT,
	DailyPrice decimal,
	Description TEXT,
	FOREIGN KEY (ColorId) REFERENCES Colors(ColorId),
	FOREIGN KEY (BrandId) REFERENCES Brands(BrandId)
)

INSERT INTO Brands(BrandName)
VALUES
('BMW'),
('Audi'),
('Fiat'),
('Renault');

INSERT INTO Colors(ColorName)
VALUES
('White'),
('Black'),
('Red'),
('Blue');

INSERT INTO Cars(BrandId,ColorId,ModelYear,DailyPrice,Description)
VALUES
('1','2','2019','450','Luxury'),
('2','4','2020','500','Sport'),
('4','1','2018','250','Economic'),
('3','3','2017','320','Comfortable');

CREATE TABLE Users(
	Id int PRIMARY KEY NOT NULL IDENTITY(1,1),
	FirstName varchar(50) NOT NULL, 
	LastName varchar(50) NOT NULL,
	Email varchar(50) NOT NULL,
	Password varchar(50) NOT NULL,
)
INSERT INTO Users(FirstName,LastName,Email,Password)
VALUES
('Ali','KAHRAMAN','alikhrmn@gmail.com','1111'),
('Elif','YILMAZ','elifylmz@gmail.com','2222'),
('Veli','TOPAL','veli67@gmail.com','3333');


CREATE TABLE Customers(
	CustomerId int PRIMARY KEY NOT NULL IDENTITY(1,1),
	CompanyName varchar(50) NOT NULL,
	UserId int NOT NULL,
	FOREIGN KEY (UserId) REFERENCES Users(Id),
)


INSERT INTO Customers(CompanyName,UserId)
VALUES
('Kahramanlar Company','1'),
('Yılmaz Company','2'),
('Veli Company','3');


CREATE TABLE Rentals(
	Id int PRIMARY KEY NOT NULL IDENTITY(1,1),
	CarId int NOT NULL, 
	CustomerId int NOT NULL,
	RentDate DateTime NOT NULL,
	ReturnDate DateTime,
	FOREIGN KEY (CarId) REFERENCES Cars(CarId),
	FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId),
)


INSERT INTO Rentals(CarId,CustomerId,RentDate,ReturnDate)
VALUES
('2','1','2020.12.30','2021.01.13'),
('3','2','2021.01.10','2021.01.15');

INSERT INTO Rentals(CarId,CustomerId,RentDate)
VALUES
('1','3','2021.01.20');


CREATE TABLE CarImages(
	CarImageId int PRIMARY KEY NOT NULL IDENTITY(1,1),
	CarId int NOT NULL, 
	ImagePath nvarchar(max) NOT NULL,
	Date DateTime NOT NULL,
	FOREIGN KEY (CarId) REFERENCES Cars(CarId)
)



