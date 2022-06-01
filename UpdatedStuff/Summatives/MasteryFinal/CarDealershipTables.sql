USE CarDealership
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Make')
	DROP TABLE Make
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='VehicleModel')
	DROP TABLE VehicleModel
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Condition')
	DROP TABLE Condition
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Body')
	DROP TABLE Body
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Transmission')
	DROP TABLE Transmission
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Color')
	DROP TABLE Color
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='InteriorColor')
	DROP TABLE InteriorColor
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='States')
	DROP TABLE States
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='PurchaseType')
	DROP TABLE PurchaseType
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Vehicle')
	DROP TABLE Vehicle
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Sale')
	DROP TABLE Sale
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Specials')
	DROP TABLE Specials
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Contact')
	DROP TABLE Contact
GO

CREATE TABLE Make (
	MakeID int primary key identity(1,1) not null,
	MakeName varchar(20) not null
)

CREATE TABLE VehicleModel (
	VehicleModelID int primary key identity(1,1) not null,
	MakeID int foreign key references Make(MakeID) not null,
	ModelName varchar(30) not null,
	DateAdded date not null,
	UserEmail varchar(50) not null,
)

CREATE TABLE Condition (
	ConditionID int primary key identity(1,1) not null,
	ConditionType varchar(5) not null
)

CREATE TABLE Body (
	BodyID int primary key identity(1,1) not null,
	BodyStyle varchar(5) not null
)

CREATE TABLE Transmission (
	TransmissionID int primary key identity(1,1) not null,
	TransmissionType varchar(10) not null
)

CREATE TABLE Color (
	ColorID int primary key identity(1,1) not null,
	ColorName varchar(10) not null
)
CREATE TABLE InteriorColor (
	InteriorColorID int primary key identity(1,1) not null,
	InteriorColorName varchar(10) not null
)

CREATE TABLE Vehicle (
	VehicleID int primary key identity(1,1) not null,
	VehicleModelID int foreign key references VehicleModel(VehicleModelID) not null,
	ConditionID int foreign key references Condition(ConditionID) not null,
	BodyID int foreign key references Body(BodyID) not null,
	TransmissionID int foreign key references Transmission(TransmissionID) not null,
	ColorID int foreign key references Color(ColorID) not null,
	InteriorColorID int foreign key references InteriorColor(InteriorColorID) not null,
	VehicleYear smallint not null,
	Mileage int not null,
	VinNumber varchar(17) unique not null,
	VehicleDescription varchar(500) not null,
	VehicleImageFile varchar(50) not null,
	MSRP decimal(8,2) not null,
	SalePrice decimal(8,2) not null,
	IsFeatured bit not null,
	IsSold bit not null,
	DateAdded date not null,
)

CREATE TABLE States (
	StateID int primary key identity(1,1) not null,
	StateName varchar(20) not null,
	StateAbbreviation char(2) not null
)

CREATE TABLE PurchaseType (
	PurchaseTypeID int primary key identity(1,1) not null,
	PurchaseType varchar(15) not null
)

CREATE TABLE Sale (
	SaleID int primary key identity(1,1) not null,
	StatesID int foreign key references States(StateID) not null,
	PurchaseID int foreign key references PurchaseType(PurchaseTypeID) not null,
	VehicleID int foreign key references Vehicle(VehicleID) not null,
	CustomerName varchar(50) not null,
	CustomerPhone char(10) not null,
	CustomerEmail varchar(50) not null,
	CustomerStreet1 varchar(50) not null,
	CustomerStreet2 varchar(50) null,
	CustomerCity varchar(30) null,
	CustomerZip char(5) null,
	SalePurchasePrice decimal(8,2) not null,
	SalePurchaseDate date not null,
	UserEmail varchar(50) not null
)

CREATE TABLE Contact (
	ContactID int primary key identity(1,1) not null,
	ContactName varchar(50) not null,
	ContactEmail varchar(50) not null,
	ContactPhone char(10) not null,
	ContactMessage varchar(100) not null
)

CREATE TABLE Specials (
	SpecialsID int primary key identity(1,1) not null,
	SpecialsTitle varchar(50) not null,
	SpecialsDescription varchar(300) not null,
	SpecialsImageFile varchar(50) not null,
)