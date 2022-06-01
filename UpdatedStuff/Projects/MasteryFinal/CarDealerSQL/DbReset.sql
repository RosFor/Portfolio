Use CarDealership
Go

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DbReset')
      DROP PROCEDURE DbReset
GO

CREATE PROCEDURE DbReset AS
BEGIN
	DELETE FROM Sale;
	DELETE FROM Vehicle;
	DELETE FROM VehicleModel;
	DELETE FROM Make;
	DELETE FROM Condition;
	DELETE FROM Body;
	DELETE FROM Transmission;
	DELETE FROM Color;
	DELETE FROM InteriorColor;
	DELETE FROM States;
	DELETE FROM PurchaseTypes;
	DELETE FROM Specials;
	DELETE FROM Contact;

	DBCC CHECKIDENT ('Sale', RESEED, 1)
	DBCC CHECKIDENT ('Vehicle', RESEED, 1)
	DBCC CHECKIDENT ('VehicleModel', RESEED, 1)
	DBCC CHECKIDENT ('Make', RESEED, 1)
	DBCC CHECKIDENT ('Condition', RESEED, 1)
	DBCC CHECKIDENT ('Body', RESEED, 1)
	DBCC CHECKIDENT ('Transmission', RESEED, 1)
	DBCC CHECKIDENT ('Color', RESEED, 1)
	DBCC CHECKIDENT ('InteriorColor', RESEED, 1)
	DBCC CHECKIDENT ('States', RESEED, 1)
	DBCC CHECKIDENT ('PurchaseTypes', RESEED, 1)
	DBCC CHECKIDENT ('Specials', RESEED, 1)
	DBCC CHECKIDENT ('Contact', RESEED, 1)

--Make
	SET IDENTITY_INSERT Make ON;
	INSERT INTO Make
		(MakeID, MakeName)
	VALUES
		(1, 'Cadillac'),
		(2, 'Chevrolet'),
		(3, 'Ferrari'),
		(4, 'Ford'),
		(5, 'Lincoln'),
		(6, 'Honda')
	SET IDENTITY_INSERT Make OFF;

--Condition
	SET IDENTITY_INSERT Condition ON;
	INSERT INTO Condition
		(ConditionID, ConditionType)
	VALUES
		(1, 'New'),
		(2, 'Used')
	SET IDENTITY_INSERT Condition OFF;

--Body
	SET IDENTITY_INSERT Body ON;
	INSERT INTO Body
		(BodyID, BodyStyle)
	VALUES
		(1, 'Car'),
		(2, 'SUV'),
		(3, 'Truck'),
		(4, 'Van')
	SET IDENTITY_INSERT Body OFF;

--Transmission
	SET IDENTITY_INSERT Transmission ON;
	INSERT INTO Transmission
		(TransmissionID, TransmissionType)
	VALUES
		(1, 'Manual'),
		(2, 'Automatic')
	SET IDENTITY_INSERT Transmission OFF;

--Color
	SET IDENTITY_INSERT Color ON;
	INSERT INTO Color
		(ColorID, ColorName)
	VALUES
		(1, 'White'),
		(2, 'Silver'),
		(3, 'Black'),
		(4, 'Red'),
		(5, 'Yellow'),
		(6, 'Green'),
		(7, 'Blue')
	SET IDENTITY_INSERT Color OFF;

--Interior Color
	SET IDENTITY_INSERT InteriorColor ON;
	INSERT INTO InteriorColor
		(InteriorColorID, InteriorColorName)
	VALUES
		(1, 'White'),
		(2, 'Cream'),
		(3, 'Beige/Tan'),
		(4, 'Brown'),
		(5, 'Grey'),
		(6, 'Black')
	SET IDENTITY_INSERT InteriorColor OFF;

--States
	SET IDENTITY_INSERT States ON;
	INSERT INTO States
		(StateID, StateName, StateAbbreviation)
	VALUES
		(1, 'Minnesota', 'MN'),
		(2, 'New Jersey', 'NJ'),
		(3, 'Oregon', 'OR'),
		(4, 'Texas', 'TX'),
		(5, 'Colorado', 'CO')
	SET IDENTITY_INSERT States OFF;

--Purchase Type
	SET IDENTITY_INSERT PurchaseTypes ON;
	INSERT INTO PurchaseTypes
		(PurchaseTypeID, PurchaseType)
	VALUES
		(1, 'Cash'),
		(2, 'Dealer Finance'),
		(3, 'Bank Finance')
	SET IDENTITY_INSERT PurchaseTypes OFF;

--Specials
	SET IDENTITY_INSERT Specials ON;
	INSERT INTO Specials
		(SpecialsID, SpecialsTitle, SpecialsDescription, SpecialsImageFile)
	VALUES
		(1, 'Specials - Title 1', 'wrLIYcfiVVSXDSffgbuh UubPlDfPDlQOkCAzEgzW ZaXyZinyvVtspknkWumW SNqZYecdFxHfcsYtjayB RNMeJNnEfzvJWHcGUUWT', 'SpecialsIMG.png'),
		(2, 'Specials - Title 2', 'RUcIZfJZXOfHJdPpcYvU JKfrLLmVvvKDmyEBSRVi xtyGWfDRFTNJfaMGTwKX VzsZtycmbyFdtHBmWQDp RBsrcytSQpeWawYNColG QWSfTKrNXRDRHWgSXcOy', 'SpecialsIMG.png'),
		(3, 'Specials - Title 3', 'ydJZMdBfMoGfUquxjTVh cqoUMXgaanTyDLWCbYeP gprHByOeRXmrfdUwUhyF TeXtWtsvikAEcDxLbHGf hStkcSIgQAtSiVSXhfjf OJykjZwhoxdLMfYaRTfI HYMPGNpNgzAQBXWyFrRH', 'SpecialsIMG.png'),
		(4, 'Specials - Title 4', 'hqRQiqUWWYQKZptUWKZi HrgNGFGYpxEvRcbdPODL eXIaLWGjkpQevJrjbmpP lGSiCwMQLyKjIQfSfgSc sfWnXQdSVkGtlvlAhBSo fMIaRXDLdZMeAEUHJwJZ JLZpuOOKdMetSNJzWHMc iATGTvqAibMwppQaSEsf', 'SpecialsIMG.png')
	SET IDENTITY_INSERT Specials OFF;

--Contact
	SET IDENTITY_INSERT Contact ON;
	INSERT INTO Contact
		(ContactID, ContactName, ContactPhone, ContactEmail, ContactMessage)
	VALUES
		(1, 'Customer A', '111.111.1111', '111@aol.com', 'Interested in the Roma.'),
		(2, 'Customer B', '222.222.2222', '222@yahoo.com', 'Interested in the F150.'),
		(3, 'Customer B', '222.222.2222', '222@yahoo.com', 'N/A')
	SET IDENTITY_INSERT Contact OFF;

--VehicleModel
	SET IDENTITY_INSERT VehicleModel ON;
	INSERT INTO VehicleModel
		(VehicleModelID, MakeID, ModelName, DateAdded, UserEmail)
	VALUES
		(1, 1, 'DeVille', '2021-01-01', 'admin@guildcars.com'),
		(2, 1, 'Escalade', '2021-01-01', 'admin@guildcars.com'),
		(3, 1, 'XT4', '2021-01-01', 'admin@guildcars.com'),
		(4, 2, 'Camaro', '2022-02-02', 'admin@guildcars.com'),
		(5, 2, 'Corvette', '2022-02-02', 'admin@guildcars.com'),
		(6, 2, 'Impala', '2022-02-02', 'admin@guildcars.com'),
		(7, 3, '488 Pista', '2022-03-03', 'admin@guildcars.com'),
		(8, 3, 'F8', '2022-03-03', 'admin@guildcars.com'),
		(9, 3, 'Roma', '2022-03-03', 'admin@guildcars.com'),
		(10, 4, 'Focus', '2022-04-04', 'sales@guildcars.com'),
		(11, 4, 'Mustang', '2022-04-04', 'sales@guildcars.com'),
		(12, 4, 'Taurus X', '2022-04-04', 'sales@guildcars.com'),
		(13, 5, 'Continental', '2022-05-05', 'sales@guildcars.com'),
		(14, 5, 'Navigator', '2022-05-05', 'sales@guildcars.com'),
		(15, 5, 'Town Car', '2022-05-05', 'sales@guildcars.com'),
		(16, 6, 'Ridgeline', '2022-06-06', 'sales@guildcars.com'),
		(17, 6, 'Odyssey', '2022-06-06', 'sales@guildcars.com')
	SET IDENTITY_INSERT VehicleModel OFF;

--Vehicle
	SET IDENTITY_INSERT Vehicle ON;
	INSERT INTO Vehicle
		(VehicleID, VehicleModelID, ConditionID, BodyID, TransmissionID, ColorID, InteriorColorID,
		VehicleYear, Mileage, VinNumber, VehicleDescription, VehicleImageFile, MSRP, SalePrice, IsFeatured, IsSold, DateAdded)
	VALUES 
		(1, 1, 2, 1, 2, 7, 5, '1974', '11111', 'JKBVNKD167A013982', 'Used blue-grey automatic Cadillac DeVille , with grey interior.', 'CarIMG.png', 15000.00, 12000.00, 0, 1, '2021-01-01'),
		(2, 2, 2, 2, 2, 3, 5, '2019', '22222', '1G1JC1243T7246823', 'Used black automatic Cadillac Escalade, with grey interior.', 'SuvIMG.png', 70000.00, 67000.00, 1, 0, '2021-01-02'),
		(3, 3, 2, 2, 2, 1, 2, '2020', '33333', 'JM1FE17N340134462', 'Used white automatic Cadillac XT4, with cream interior.', 'SuvIMG.png', 43000.00, 40000.00, 1, 0, '2021-01-03'),
		(4, 4, 1, 1, 1, 5, 6, '1967', '444', '2G1AN35J4C1202219', 'New yellow manual Chevrolet Camaro, with black interior.', 'CarIMG.png', 32000.00, 31000.00, 0, 1, '2021-01-04'),
		(5, 5, 2, 1, 1, 4, 6, '1995', '55555', '4S3BK4358V7310025', 'Used red manual Chevrolet Corvette, with black interior.', 'CarIMG.png', 160000.00, 78000.00, 1, 0, '2021-01-05'),
		(6, 6, 2, 1, 1, 4, 1, '1960', '66666', 'KM8JU3AC6DU588418', 'Used red manual Chevrolet Impala, with white interior.', 'CarIMG.png', 60000.00, 34000.00, 1, 0, '2021-01-06'),
		(7, 7, 1, 1, 2, 7, 6, '2021', '777', 'KM8JN72DX7U587496', 'New blue automatic Ferrari 488 Pista, with black interior.', 'CarIMG.png', 398000.00, 395000.00, 0, 1, '2021-01-07'),
		(8, 8, 2, 1, 2, 5, 6, '2020', '8888', '3D7UT2CL2BG587350', 'Used yellow automatic Ferrari F8, with black interior.', 'CarIMG.png', 418000.00, 414000.00, 1, 0, '2021-01-08'),
		(9, 9, 1, 1, 2, 3, 5, '2020', '999', '2G1WL52M2T1187676', 'New silver automatic Ferrari Roma, with grey interior.', 'CarIMG.png', 222000.00, 222000.00, 1, 0, '2021-01-09'),
		(10, 10, 2, 1, 1, 1, 5, '2001', '10000', '1B4GP25R51B138763', 'Used white manual Ford Focus, with grey interior.', 'CarIMG.png', 5000.00, 4000.00, 0, 1, '2021-01-10'),
		(11, 10, 2, 1, 1, 4, 6, '2007', '11000', '1P3XP48K6LN273071', 'Used red manual Ford Focus, with black interior.', 'CarIMG.png', 3000.00, 2000.00, 1, 0, '2021-01-11'),
		(12, 11, 2, 1, 2, 6, 6, '2020', '12000', '4S3BD4353T7209207', 'Used green automatic Ford Mustang, with black interior.', 'CarIMG.png', 42000.00, 40000.00, 1, 0, '2021-01-12'),
		(13, 12, 2, 1, 2, 4, 2, '2008', '13000', '2G1WL54T4R9165225', 'Used red automatic Ford Taurus X, with cream interior.', 'SuvIMG.png', 5000.00, 5000.00, 0, 1, '2021-01-13'),
		(14, 13, 2, 1, 2, 7, 3, '1942', '14000', 'JH4DB7540SS801338', 'Used blue automatic Lincoln Continental, with beige interior.', 'CarIMG.png', 35000.00, 21000.00, 0, 1, '2021-01-14'),
		(15, 14, 2, 2, 2, 3, 2, '2021', '15000', 'SAJWA2GEXBMV00832', 'Used black automatic Lincoln Navigator, with cream interior.', 'SuvIMG.png', 99000.00, 95000.00, 1, 0, '2021-01-15'),
		(16, 15, 2, 1, 2, 3, 6, '2011', '16000', '1FVACYDT19HAJ2694', 'Used black automatic Lincoln Town Car, with black interior.', 'CarIMG.png', 11000.00, 9000.00, 1, 0, '2021-01-16'),
		(17, 16, 1, 3, 1, 2, 6, '2021', '170', 'WP1AB29P99LA40680', 'New silver manual Honda Ridgeline, with black interior.', 'TruckIMG.png', 37000.00, 36000.00, 1, 0, '2021-01-17'),
		(18, 17, 1, 3, 2, 7, 5, '2022', '180', '1HD1GPM15CC339172', 'New blue automatic Honda Odyssey, with black interior.', 'VanIMG.png', 48000.00, 47000.00, 1, 0, '2021-01-18')
	SET IDENTITY_INSERT Vehicle OFF;

--Sale
	SET IDENTITY_INSERT Sale ON;
	INSERT INTO Sale
		(SaleID, StatesID, PurchaseTypeID, VehicleID, 
		CustomerName,CustomerPhone,CustomerEmail,CustomerStreet1,CustomerStreet2,CustomerCity,CustomerZip,
		SalePurchasePrice,SalePurchaseDate,UserEmail)
	VALUES 
		(1, 1, 1, 1, 'Customer A', '111.111.1111', '111@customer.com', '1111 Oak Street', '', 'Minneapolis', '55406', 12000.00, '2022-11-11', 'admin@guildcars.com'),
		(2, 1, 1, 4, 'Customer A', '111.111.1111', '111@customer.com', '1111 Oak Street', '', 'Minneapolis', '55406', 31000.00, '2022-11-11', 'admin@guildcars.com'),
		(3, 2, 2, 7, 'Customer B', '222.222.2222', '222@customer.com', '2222 Elm Street', 'Apt B', 'Newark', '07102', 395000.00, '2022-02-22', 'sales@guildcars.com'),
		(4, 2, 2, 10, 'Customer B', '333.333.3333', '222@customer.com', '2222 Elm Street', 'Apt B', 'Newark', '07102', 4000.00, '2022-02-22', 'sales@guildcars.com'),
		(5, 3, 3, 13, 'Customer C', '333.333.3333', '333@customer.com', '3333 Ash Street', '', 'Portland', '97223', 5000.00, '2022-03-03', 'disabled@guildcars.com'),
		(6, 3, 3, 14, 'Customer C', '333.333.3333', '333@customer.com', '3333 Ash Street', '', 'Portland', '97223', 21000.00, '2022-03-03', 'disabled@guildcars.com')
	SET IDENTITY_INSERT Sale OFF;

END