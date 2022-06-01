USE [master];
GO

if exists (select * from sys.databases where name = N'SamHotelDB')
begin
	EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'SamHotelDB';
	ALTER DATABASE SamHotelDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE SamHotelDB;
end

CREATE DATABASE SamHotelDB;
GO

USE SamHotelDB;
GO

CREATE TABLE Guest(
GuestID INT PRIMARY KEY IDENTITY(1,1),
FirstName VARCHAR(20) NOT NULL,
LastName VARCHAR(20) NOT NULL,
[Address] VARCHAR(50) NOT NULL,
City VARCHAR(20) NOT NULL,
[State] CHAR(2) NOT NULL,
Zip CHAR(5) NOT NULL,
Phone CHAR(12) NOT NULL
);

CREATE TABLE RoomType(
RoomTypeID INT PRIMARY KEY IDENTITY(1,1),
[Type] VARCHAR(10) NOT NULL,
StandardOccupancy TINYINT NOT NULL,
MaximumOccupancy TINYINT NOT NULL,
BasePrice DECIMAL(5,2) NOT NULL,
ExtraPersonCost DECIMAL (4,2) NOT NULL
);

CREATE TABLE Amenities(
AmenityID INT PRIMARY KEY IDENTITY(1,1),
AmenityType VARCHAR(20) NOT NULL,
AmenityCost DECIMAL(4,2) NOT NULL
);

CREATE TABLE Reservation(
ReservationID INT PRIMARY KEY IDENTITY(1,1),
GuestID INT FOREIGN KEY REFERENCES Guest(GuestID) NOT NULL,
Adults TINYINT NOT NULL,
Children TINYINT NOT NULL,
StartDate DATE NOT NULL,
EndDate DATE NOT NULL,
TotalRoomCost DECIMAL(6,2) NOT NULL
);

CREATE TABLE Room(
RoomNumber INT PRIMARY KEY IDENTITY(1,1),
RoomTypeID INT FOREIGN KEY REFERENCES RoomType(RoomTypeID) NOT NULL,
ADAAccessible BIT NOT NULL
);

CREATE TABLE RoomReservation(
RoomNumber INT NOT NULL,
ReservationID INT NOT NULL,
Constraint pk_RR PRIMARY KEY (RoomNumber,ReservationID),
Constraint fk_RR_RN FOREIGN KEY (RoomNumber) REFERENCES Room(RoomNumber),
Constraint fk_RR_RID FOREIGN KEY (ReservationID) REFERENCES Reservation(ReservationID)
);

CREATE TABLE RoomAmenities(
RoomNumber INT NOT NULL,
AmenityID INT NOT NULL,
CONSTRAINT pk_RA PRIMARY KEY (RoomNumber,AmenityID),
CONSTRAINT fk_RA_RN FOREIGN KEY (RoomNumber) REFERENCES Room(RoomNumber),
CONSTRAINT fk_RA_AID FOREIGN KEY (AmenityID) REFERENCES Amenities(AmenityID)
);