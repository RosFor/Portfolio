Use CarDealership
Go

--Home: Select Featured Vehicles
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleSelectFeatured')
      DROP PROCEDURE VehicleSelectFeatured
GO

CREATE PROCEDURE VehicleSelectFeatured AS
BEGIN
	SELECT 
	V.VehicleID,
	VM.VehicleModelID, VM.ModelName, VM.MakeID, M.MakeName,
	V.ConditionID, CT.ConditionType,
	V.BodyID, B.BodyStyle,
	V.TransmissionID, T.TransmissionType,
	V.ColorID, CR.ColorName,
	V.InteriorColorID, IC.InteriorColorName,
	V.VehicleYear,
	V.Mileage,
	V.VinNumber,
	V.VehicleDescription,
	V.VehicleImageFile,
	V.MSRP,
	V.SalePrice
	--VehicleID, VehicleYear, VM.MakeID, V.VehicleModelID, SalePrice, VehicleImageFile
	FROM Vehicle V
	Inner Join Condition CT on V.ConditionID = CT.ConditionID
	Inner Join Body B on V.BodyID = B.BodyID
	Inner Join Transmission T on V.TransmissionID = T.TransmissionID
	Inner Join Color CR on V.ColorID = CR.ColorID
	Inner Join InteriorColor IC on V.InteriorColorID = IC.InteriorColorID
	Inner Join VehicleModel VM on V.VehicleModelID = VM.VehicleModelID
	Inner Join Make M on VM.MakeID = M.MakeID
	WHERE ((V.IsFeatured = 1) AND (V.IsSold = 0))
	ORDER BY V.DateAdded DESC
END
GO

--Inventory: Search New Vehicles
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SearchNewVehicles')
      DROP PROCEDURE SearchNewVehicles
GO
CREATE PROCEDURE SearchNewVehicles (
	@SearchTerm varchar(20) = '',
	@MinYear smallint,
	@MaxYear smallint,
	@MinPrice decimal(8,2),
	@MaxPrice decimal(8,2)
)
AS
	SELECT TOP 20 V.VehicleID, 
	VM.VehicleModelID, VM.ModelName, M.MakeID, M.MakeName,
	V.ConditionID, CT.ConditionType,
	V.BodyID, B.BodyStyle,
	V.TransmissionID, T.TransmissionType,
	V.ColorID, CR.ColorName,
	V.InteriorColorID, IC.InteriorColorName,
	V.VehicleYear,
	V.Mileage,
	V.VinNumber,
	V.VehicleDescription,
	V.VehicleImageFile,
	V.MSRP,
	V.SalePrice
	FROM Vehicle V
	Inner Join Condition CT on V.ConditionID = CT.ConditionID
	Inner Join Body B on V.BodyID = B.BodyID
	Inner Join Transmission T on V.TransmissionID = T.TransmissionID
	Inner Join Color CR on V.ColorID = CR.ColorID
	Inner Join InteriorColor IC on V.InteriorColorID = IC.InteriorColorID
	Inner Join VehicleModel VM on V.VehicleModelID = VM.VehicleModelID
	Inner Join Make M on VM.MakeID = M.MakeID
	WHERE 1 = 1
	AND ((VM.ModelName LIKE '%' + @SearchTerm + '%')
	OR (M.MakeName LIKE '%' + @SearchTerm + '%')
	OR (V.VehicleYear LIKE '%' + @SearchTerm + '%'))
	AND (V.ConditionID = 1)
	AND (V.SalePrice >= @MinPrice)
	AND (V.SalePrice <= @MaxPrice)
	AND (V.VehicleYear >= @MinYear)
	AND (V.VehicleYear <= @MaxYear)
	AND (V.IsSold = 0)
	ORDER BY V.MSRP DESC
GO

--Inventory: Search Used Vehicles
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SearchUsedVehicles')
      DROP PROCEDURE SearchUsedVehicles
GO
CREATE PROCEDURE SearchUsedVehicles (
	@SearchTerm varchar(20) = '',
	@MinYear smallint,
	@MaxYear smallint,
	@MinPrice decimal(8,2),
	@MaxPrice decimal(8,2)
)
AS
	SELECT TOP 20 V.VehicleID, 
	VM.VehicleModelID, VM.ModelName, M.MakeID, M.MakeName,
	V.ConditionID, CT.ConditionType,
	V.BodyID, B.BodyStyle,
	V.TransmissionID, T.TransmissionType,
	V.ColorID, CR.ColorName,
	V.InteriorColorID, IC.InteriorColorName,
	V.VehicleYear,
	V.Mileage,
	V.VinNumber,
	V.VehicleDescription,
	V.VehicleImageFile,
	V.MSRP,
	V.SalePrice
	FROM Vehicle V
	Inner Join Condition CT on V.ConditionID = CT.ConditionID
	Inner Join Body B on V.BodyID = B.BodyID
	Inner Join Transmission T on V.TransmissionID = T.TransmissionID
	Inner Join Color CR on V.ColorID = CR.ColorID
	Inner Join InteriorColor IC on V.InteriorColorID = IC.InteriorColorID
	Inner Join VehicleModel VM on V.VehicleModelID = VM.VehicleModelID
	Inner Join Make M on VM.MakeID = M.MakeID
	WHERE 1 = 1
	AND ((VM.ModelName LIKE '%' + @SearchTerm + '%')
	OR (M.MakeName LIKE '%' + @SearchTerm + '%')
	OR (V.VehicleYear LIKE '%' + @SearchTerm + '%'))
	AND (V.ConditionID = 2)
	AND (V.SalePrice >= @MinPrice)
	AND (V.SalePrice <= @MaxPrice)
	AND (V.VehicleYear >= @MinYear)
	AND (V.VehicleYear <= @MaxYear)
	AND (V.IsSold = 0)
	ORDER BY V.MSRP DESC
GO

--Inventory: New & Used Vehicles
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SearchNewAndUsedVehicles')
      DROP PROCEDURE SearchNewAndUsedVehicles
GO
CREATE PROCEDURE SearchNewAndUsedVehicles (
	@SearchTerm varchar(20) = '',
	@MinYear smallint,
	@MaxYear smallint,
	@MinPrice decimal(8,2),
	@MaxPrice decimal(8,2)
)
AS
	SELECT TOP 20 V.VehicleID, 
	VM.VehicleModelID, VM.ModelName, M.MakeID, M.MakeName,
	V.ConditionID, CT.ConditionType,
	V.BodyID, B.BodyStyle,
	V.TransmissionID, T.TransmissionType,
	V.ColorID, CR.ColorName,
	V.InteriorColorID, IC.InteriorColorName,
	V.VehicleYear,
	V.Mileage,
	V.VinNumber,
	V.VehicleDescription,
	V.VehicleImageFile,
	V.MSRP,
	V.SalePrice
	FROM Vehicle V
	Inner Join Condition CT on V.ConditionID = CT.ConditionID
	Inner Join Body B on V.BodyID = B.BodyID
	Inner Join Transmission T on V.TransmissionID = T.TransmissionID
	Inner Join Color CR on V.ColorID = CR.ColorID
	Inner Join InteriorColor IC on V.InteriorColorID = IC.InteriorColorID
	Inner Join VehicleModel VM on V.VehicleModelID = VM.VehicleModelID
	Inner Join Make M on VM.MakeID = M.MakeID
	WHERE 1 = 1
	AND ((VM.ModelName LIKE '%' + @SearchTerm + '%')
	OR (M.MakeName LIKE '%' + @SearchTerm + '%')
	OR (V.VehicleYear LIKE '%' + @SearchTerm + '%'))
	AND ((V.ConditionID = 1)
	OR (V.ConditionID = 2))
	AND (V.SalePrice >= @MinPrice)
	AND (V.SalePrice <= @MaxPrice)
	AND (V.VehicleYear >= @MinYear)
	AND (V.VehicleYear <= @MaxYear)
	AND (V.IsSold = 0)
	ORDER BY V.VehicleID ASC
GO

--Home: Select All Vehicles
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleSelectAll')
      DROP PROCEDURE VehicleSelectAll
GO

CREATE PROCEDURE VehicleSelectAll AS
BEGIN
	SELECT *
	FROM Vehicle V
	Inner Join Condition CT on V.ConditionID = CT.ConditionID
	Inner Join Body B on V.BodyID = B.BodyID
	Inner Join Transmission T on V.TransmissionID = T.TransmissionID
	Inner Join Color CR on V.ColorID = CR.ColorID
	Inner Join InteriorColor IC on V.InteriorColorID = IC.InteriorColorID
	Inner Join VehicleModel VM on V.VehicleModelID = VM.VehicleModelID
	Inner Join Make M on VM.MakeID = M.MakeID
	WHERE V.IsSold = 0
	ORDER BY 
	M.MakeName ASC,
	VM.ModelName ASC
END
GO

--Select All Makes
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MakeSelectAll')
      DROP PROCEDURE MakeSelectAll
GO

CREATE PROCEDURE MakeSelectAll AS
BEGIN
	SELECT MakeID, MakeName
	FROM Make
END
GO

--Select All VehicleModels
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleModelSelectAll')
      DROP PROCEDURE VehicleModelSelectAll
GO

CREATE PROCEDURE VehicleModelSelectAll AS
BEGIN
	SELECT 
	VM.VehicleModelID, VM.ModelName, M.MakeID, M.MakeName,
	VM.DateAdded, 
	VM.UserEmail
	FROM VehicleModel VM
	Inner Join Make M on VM.MakeID = M.MakeID
END
GO

--Select All Conditions
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ConditionSelectAll')
      DROP PROCEDURE ConditionSelectAll
GO

CREATE PROCEDURE ConditionSelectAll AS
BEGIN
	SELECT ConditionID, ConditionType
	FROM Condition
END
GO

--Select All Body Styles
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'BodySelectAll')
      DROP PROCEDURE BodySelectAll
GO

CREATE PROCEDURE BodySelectAll AS
BEGIN
	SELECT BodyID, BodyStyle
	FROM Body
END
GO

--Select All Transmission Types
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'TransmissionSelectAll')
      DROP PROCEDURE TransmissionSelectAll
GO

CREATE PROCEDURE TransmissionSelectAll AS
BEGIN
	SELECT TransmissionID, TransmissionType
	FROM Transmission
END
GO

--Select All Colors
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ColorSelectAll')
      DROP PROCEDURE ColorSelectAll
GO

CREATE PROCEDURE ColorSelectAll AS
BEGIN
	SELECT ColorID, ColorName
	FROM Color
END
GO

--Select All Interior Colors
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'InteriorColorSelectAll')
      DROP PROCEDURE InteriorColorSelectAll
GO

CREATE PROCEDURE InteriorColorSelectAll AS
BEGIN
	SELECT InteriorColorID, InteriorColorName
	FROM InteriorColor
END
GO

--Home: Select All Specials
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SpecialSelectAll')
      DROP PROCEDURE SpecialSelectAll
GO

CREATE PROCEDURE SpecialSelectAll AS
BEGIN
	SELECT SpecialsID, SpecialsTitle, SpecialsDescription, SpecialsImageFile
	FROM Specials
END
GO

--Select All Contacts
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ContactSelectAll')
      DROP PROCEDURE ContactSelectAll
GO

CREATE PROCEDURE ContactSelectAll AS
BEGIN
	SELECT ContactID, ContactName, ContactEmail, ContactPhone, ContactMessage
	FROM Contact
END
GO

--Select All Purchase Types
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'PurchaseTypeSelectAll')
      DROP PROCEDURE PurchaseTypeSelectAll
GO

CREATE PROCEDURE PurchaseTypeSelectAll AS
BEGIN
	SELECT PurchaseTypeID, PurchaseType
	FROM PurchaseTypes
END
GO

--Select All States
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'StatesSelectAll')
      DROP PROCEDURE StatesSelectAll
GO

CREATE PROCEDURE StatesSelectAll AS
BEGIN
	SELECT StateID, StateName, StateAbbreviation
	FROM States
END
GO

--Select All Sales
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SaleSelectAll')
      DROP PROCEDURE SaleSelectAll
GO

CREATE PROCEDURE SaleSelectAll AS
BEGIN
	SELECT *
	FROM Sale Sale
	Inner Join States S on Sale.SaleID = S.StateID
	Inner Join PurchaseTypes PT on Sale.PurchaseTypeID = PT.PurchaseTypeID
	Inner Join Vehicle V on Sale.VehicleID = V.VehicleID
END
GO

--Select Vehicle Details
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleSelectID')
      DROP PROCEDURE VehicleSelectID
GO

CREATE PROCEDURE VehicleSelectID (
	@VehicleID int
) AS 
BEGIN
	SELECT 
	V.VehicleID,
	VM.VehicleModelID, VM.ModelName, VM.MakeID, M.MakeName,
	V.ConditionID, CT.ConditionType,
	V.BodyID, B.BodyStyle,
	V.TransmissionID, T.TransmissionType,
	V.ColorID, CR.ColorName,
	V.InteriorColorID, IC.InteriorColorName,
	V.VehicleYear,
	V.Mileage,
	V.VinNumber,
	V.VehicleDescription,
	V.VehicleImageFile,
	V.MSRP,
	V.SalePrice,
	V.IsSold,
	V.IsFeatured
	--VM.MakeID, V.VehicleModelID, V.BodyID, V.TransmissionID, V.ColorID, V.InteriorColorID, 
	--	VehicleYear, Mileage, VinNumber, MSRP, SalePrice, VehicleDescription, VehicleImageFile
	FROM Vehicle V
	Inner Join Condition CT on V.ConditionID = CT.ConditionID
	Inner Join Body B on V.BodyID = B.BodyID
	Inner Join Transmission T on V.TransmissionID = T.TransmissionID
	Inner Join Color CR on V.ColorID = CR.ColorID
	Inner Join InteriorColor IC on V.InteriorColorID = IC.InteriorColorID
	Inner Join VehicleModel VM on V.VehicleModelID = VM.VehicleModelID
	Inner Join Make M on VM.MakeID = M.MakeID
	WHERE VehicleID = @VehicleID
END
GO

--Update
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SaleVehicleUpdate')
      DROP PROCEDURE SaleVehicleUpdate
GO

CREATE PROCEDURE SaleVehicleUpdate (
	@VehicleID int,
	@IsFeatured bit = false,
	@IsSold bit = true
) AS
BEGIN
	UPDATE Vehicle SET
		IsFeatured = @IsFeatured,
		IsSold = @IsSold
	WHERE VehicleID = @VehicleID
	
END
GO

--Select Make By ID
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MakeSelectID')
      DROP PROCEDURE MakeSelectID
GO

CREATE PROCEDURE MakeSelectID (
	@MakeID int
) AS
BEGIN
	SELECT MakeID, MakeName
	FROM Make
	WHERE MakeID = @MakeID
END
GO

--Select VehicleModel By ID
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleModelSelectID')
      DROP PROCEDURE VehicleModelSelectID
GO

CREATE PROCEDURE VehicleModelSelectID (
	@VehicleModelID int
) AS
BEGIN
	SELECT VehicleModelID, MakeID, ModelName, DateAdded, UserEmail
	FROM VehicleModel
	WHERE VehicleModelID = @VehicleModelID
END
GO

--Select Condition By ID
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ConditionSelectID')
      DROP PROCEDURE ConditionSelectID
GO

CREATE PROCEDURE ConditionSelectID (
	@ConditionID int
) AS
BEGIN
	SELECT ConditionID, ConditionType
	FROM Condition
	WHERE ConditionID = @ConditionID
END
GO

--Select Body Styles By ID
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'BodySelectID')
      DROP PROCEDURE BodySelectID
GO

CREATE PROCEDURE BodySelectID (
	@BodyID int
) AS
BEGIN
	SELECT BodyID, BodyStyle
	FROM Body
	WHERE BodyID = @BodyID
END
GO

--Select Transmission By ID
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'TransmissionSelectID')
      DROP PROCEDURE TransmissionSelectID
GO

CREATE PROCEDURE TransmissionSelectID (
	@TransmissionID int
) AS
BEGIN
	SELECT TransmissionID, TransmissionType
	FROM Transmission
	WHERE TransmissionID = @TransmissionID
END
GO

--Select Color By ID
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ColorSelectID')
      DROP PROCEDURE ColorSelectID
GO

CREATE PROCEDURE ColorSelectID (
	@ColorID int
) AS
BEGIN
	SELECT ColorID, ColorName
	FROM Color
	WHERE ColorID = @ColorID
END
GO

--Select Interior Color By ID
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'InteriorColorSelectID')
      DROP PROCEDURE InteriorColorSelectID
GO

CREATE PROCEDURE InteriorColorSelectID (
	@InteriorColorID int
) AS
BEGIN
	SELECT InteriorColorID, InteriorColorName
	FROM InteriorColor
	WHERE InteriorColorID = @InteriorColorID
END
GO

--Select Contact By ID
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ContactSelectID')
      DROP PROCEDURE ContactSelectID
GO

CREATE PROCEDURE ContactSelectID (
	@ContactID int
) AS
BEGIN
	SELECT ContactID, ContactName, ContactEmail, ContactPhone, ContactMessage
	FROM Contact
	WHERE ContactID = @ContactID
END
GO

--Select Purchase Type By ID
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'PurchaseTypeSelectID')
      DROP PROCEDURE PurchaseTypeSelectID
GO

CREATE PROCEDURE PurchaseTypeSelectID (
	@PurchaseTypeID int
) AS
BEGIN
	SELECT PurchaseTypeID, PurchaseType
	FROM PurchaseTypes
	WHERE PurchaseTypeID = @PurchaseTypeID
END
GO

--Select State By ID
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'StateSelectID')
      DROP PROCEDURE StateSelectID
GO

CREATE PROCEDURE StateSelectID (
	@StateID int
) AS
BEGIN
	SELECT StateID, StateName, StateAbbreviation
	FROM States
	WHERE StateID = @StateID
END
GO

--Add Contact
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ContactInsert')
      DROP PROCEDURE ContactInsert
GO

CREATE PROCEDURE ContactInsert (
	@ContactID int output,
	@ContactName varchar(50),
	@ContactEmail varchar(50) = '',
	@ContactPhone varchar(12) = '',
	@ContactMessage varchar(100)
) AS
BEGIN
	INSERT INTO Contact (ContactName, ContactEmail, ContactPhone, ContactMessage)
	VALUES (@ContactName, @ContactEmail, @ContactPhone, @ContactMessage);

	SET @ContactID = SCOPE_IDENTITY();
END
GO

----Purchase Vehicle
--IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
--   WHERE ROUTINE_NAME = 'SaleInsert')
--      DROP PROCEDURE SaleInsert
--GO

--CREATE PROCEDURE SaleInsert (
--	@SaleID int output,
--	@StatesID int,
--	@PurchaseTypeID int,
--	@VehicleID int,
--	@CustomerName varchar(50),
--	@CustomerPhone char(10) = null,
--	@CustomerEmail varchar(50) = null,
--	@CustomerStreet1 varchar(50),
--	@CustomerStreet2 varchar(50) = null,
--	@CustomerCity varchar(30),
--	@CustomerZip char(5),
--	@SalePurchasePrice decimal(8,2),
--	@SalePurchaseDate date,
--	@UserEmail varchar(50)
--) AS
--BEGIN
--	INSERT INTO Sale (StatesID, PurchaseTypeID, VehicleID, CustomerName, CustomerPhone, CustomerEmail, CustomerStreet1, CustomerStreet2, CustomerCity, CustomerZip, SalePurchasePrice, SalePurchaseDate)
--	VALUES (@StatesID, @PurchaseTypeID, @VehicleID, @CustomerName, @CustomerPhone, @CustomerEmail, @CustomerStreet1, @CustomerStreet2, @CustomerCity, @CustomerZip, @SalePurchasePrice, @SalePurchaseDate);

--	SET @SaleID = SCOPE_IDENTITY();
--END
--GO

--Add Sale
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SaleInsert')
      DROP PROCEDURE SaleInsert
GO

CREATE PROCEDURE SaleInsert (
 	@SaleID int output,
	@StatesID int,
	@PurchaseTypeID int,
	@VehicleID int,
	@CustomerName varchar(50),
	@CustomerPhone varchar(12) = '',
	@CustomerEmail varchar(50) = '',
	@CustomerStreet1 varchar(50),
	@CustomerStreet2 varchar(50) = '',
	@CustomerCity varchar(30),
	@CustomerZip char(5),
	@SalePurchasePrice decimal(8,2),
	@SalePurchaseDate date,
	@UserEmail varchar(50)
) AS
BEGIN
	INSERT INTO Sale (StatesID, PurchaseTypeID, VehicleID,
	CustomerName, CustomerPhone, CustomerEmail, 
	CustomerStreet1, CustomerStreet2, CustomerCity, CustomerZip,
	SalePurchasePrice, SalePurchaseDate, UserEmail)
	VALUES (@StatesID, @PurchaseTypeID, @VehicleID,
	@CustomerName, @CustomerPhone, @CustomerEmail, 
	@CustomerStreet1, @CustomerStreet2, @CustomerCity, @CustomerZip,
	@SalePurchasePrice, CONVERT(Date,@SalePurchaseDate,103), @UserEmail);

	SET @SaleID = SCOPE_IDENTITY();
END
GO

--Add Vehicle
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleInsert')
      DROP PROCEDURE VehicleInsert
GO

CREATE PROCEDURE VehicleInsert (
 	@VehicleID int output,
	@VehicleModelID int,
	@ConditionID int,
	@BodyID int,
	@TransmissionID int,
	@ColorID int,
	@InteriorColorID int,
	@VehicleYear smallint,
	@Mileage int,
	@VinNumber varchar(17),
	@MSRP decimal(8,2),
	@SalePrice decimal(8,2),
	@VehicleDescription varchar(500),
	@VehicleImageFile varchar(50),
	@DateAdded date,
	@IsFeatured bit = false,
	@IsSold bit = false
) AS
BEGIN
	INSERT INTO Vehicle (VehicleModelID, ConditionID, BodyID, TransmissionID, ColorID, InteriorColorID,
	VehicleYear, Mileage, VinNumber, MSRP, SalePrice, VehicleDescription, VehicleImageFile, DateAdded, IsFeatured, IsSold)
	VALUES (@VehicleModelID, @ConditionID, @BodyID, @TransmissionID, @ColorID, @InteriorColorID,
	@VehicleYear, @Mileage, @VinNumber, @MSRP, @SalePrice, @VehicleDescription, @VehicleImageFile, CONVERT(Date,@DateAdded,103), @IsFeatured, @IsSold);

	SET @VehicleID = SCOPE_IDENTITY();
END
GO

--Add Make
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MakeInsert')
      DROP PROCEDURE MakeInsert
GO

CREATE PROCEDURE MakeInsert (
	@MakeID int output,
	@MakeName varchar(20)
	
) AS
BEGIN
	INSERT INTO Make (MakeName)
	VALUES (@MakeName)

	SET @MakeID = SCOPE_IDENTITY();
END
GO

--Add Model
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleModelInsert')
      DROP PROCEDURE VehicleModelInsert
GO

CREATE PROCEDURE VehicleModelInsert (
	@VehicleModelID int output,
	@MakeID int,
	@ModelName varchar(30),
	@UserEmail varchar(50),
	@DateAdded date
	
) AS
BEGIN
	INSERT INTO VehicleModel (MakeID, ModelName, UserEmail, DateAdded)
	VALUES (@MakeID, @ModelName, @UserEmail, CONVERT(Date,@DateAdded,103))

	SET @VehicleModelID = SCOPE_IDENTITY();
END
GO

--Admin: Insert/Add Special
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SpecialsInsert')
      DROP PROCEDURE SpecialsInsert
GO

CREATE PROCEDURE SpecialsInsert (
	@SpecialsID int output,
	@SpecialsTitle varchar(50),
	@SpecialsDescription varchar(300),
	@SpecialsImageFile varchar(50) = 'SpecialsIMG.png'
) AS
BEGIN
	INSERT INTO Specials (SpecialsTitle, SpecialsDescription, SpecialsImageFile)
	VALUES (@SpecialsTitle, @SpecialsDescription, @SpecialsImageFile)

	SET @SpecialsID = SCOPE_IDENTITY();
END
GO

--Edit Vehicle
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleUpdate')
      DROP PROCEDURE VehicleUpdate
GO

CREATE PROCEDURE VehicleUpdate (
	@VehicleID int,
	@VehicleModelID int,
	@ConditionID int,
	@BodyID int,
	@TransmissionID int,
	@ColorID int,
	@InteriorColorID int,
	@VehicleYear varchar(50),
	@Mileage varchar(30),
	@VinNumber varchar(17),
	@MSRP decimal(8,2),
	@SalePrice decimal(8,2),
	@VehicleDescription varchar(500),
	@VehicleImageFile varchar(50),
	@IsFeatured bit,
	@IsSold bit
) AS
BEGIN
	UPDATE Vehicle SET
		VehicleModelID = @VehicleModelID,
		ConditionID = @ConditionID,
		BodyID = @BodyID,
		TransmissionID = @TransmissionID,
		InteriorColorID = @InteriorColorID,
		ColorID= @ColorID,
		VehicleYear = @VehicleYear, 
		Mileage = @Mileage,
		VinNumber = @VinNumber, 
		MSRP = @MSRP, 
		SalePrice = @SalePrice, 
		VehicleDescription = @VehicleDescription,
		VehicleImageFile = @VehicleImageFile,
		IsFeatured = @IsFeatured,
		IsSold = @IsSold
	WHERE VehicleID = @VehicleID
	
END
GO

--VehicleModel and Make Connection
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleModelMake')
      DROP PROCEDURE VehicleModelMake
GO

CREATE PROCEDURE VehicleModelMake AS
BEGIN
	SELECT VehicleModelID, MakeID, ModelName, DateAdded, UserEmail
	FROM VehicleModel
END
GO

--Admin: Delete Special
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SpecialsDelete')
      DROP PROCEDURE SpecialsDelete
GO

CREATE PROCEDURE SpecialsDelete (
	@SpecialsID int
)
AS
	DELETE FROM Specials
	WHERE SpecialsID = @SpecialsID
GO

--Delete Vehicle
--IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
--   WHERE ROUTINE_NAME = 'VehicleDelete')
--      DROP PROCEDURE VehicleDelete
--GO

--CREATE PROCEDURE VehicleDelete (
--	@VehicleID int
--) AS
--BEGIN
--	DELETE FROM Vehicle
--	WHERE VehicleID = @VehicleID;
--END
--GO

--Delete Vehicle
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleDelete')
      DROP PROCEDURE VehicleDelete
GO

CREATE PROCEDURE VehicleDelete (
	@VehicleID int
) AS
BEGIN
	BEGIN TRANSACTION

	DELETE FROM Sale WHERE VehicleID = @VehicleID;
	DELETE FROM Vehicle WHERE VehicleID = @VehicleID;

	COMMIT TRANSACTION
END
GO

--Inventory Report, New
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ReportNew')
      DROP PROCEDURE ReportNew
GO

CREATE PROCEDURE ReportNew AS
BEGIN
	SELECT
	V.VehicleYear [Year],
	M.MakeName [Make],
	VM.ModelName [Model],
	COUNT(VM.ModelName) [Count],
	SUM(V.MSRP) [Stock Value]
	FROM Vehicle V
	Inner Join Condition C on V.ConditionID = C.ConditionID
	Inner Join VehicleModel VM on V.VehicleModelID = VM.VehicleModelID
	Inner Join Make M on VM.MakeID = M.MakeID
	WHERE (C.ConditionType='New' AND V.IsSold=0)
	Group By M.MakeName, VM.ModelName, V.VehicleYear
END
GO

--Inventory Report, New
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ReportUsed')
      DROP PROCEDURE ReportUsed
GO

CREATE PROCEDURE ReportUsed AS
BEGIN
	SELECT
	V.VehicleYear [Year],
	M.MakeName [Make],
	VM.ModelName [Model],
	COUNT(VM.ModelName) [Count],
	SUM(V.MSRP) [Stock Value]
	FROM Vehicle V
	Inner Join Condition C on V.ConditionID = C.ConditionID
	Inner Join VehicleModel VM on V.VehicleModelID = VM.VehicleModelID
	Inner Join Make M on VM.MakeID = M.MakeID
	WHERE (C.ConditionType='Used' AND V.IsSold=0)
	Group By M.MakeName, VM.ModelName, V.VehicleYear
END
GO

----Inventory Report, New
--IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
--   WHERE ROUTINE_NAME = 'ReportSale')
--      DROP PROCEDURE ReportSale
--GO

--CREATE PROCEDURE ReportSale AS
--BEGIN
--	SELECT
--	S.UserEmail [User],
--	SUM(S.SalePurchasePrice) [Total Sales],
--	COUNT(S.VehicleID) [Total Vehicles]
--	FROM Sale S
--	Group By S.UserEmail
--END
--GO

--Reports: Search Reports
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ReportSearch')
      DROP PROCEDURE ReportSearch
GO
CREATE PROCEDURE ReportSearch (
	@UserSearch varchar(50) = '',
	@FromDate date,
	@ToDate date
)
AS
	SELECT 
	S.UserEmail [User],
	SUM(S.SalePurchasePrice) [Total Sales],
	COUNT(S.VehicleID) [Total Vehicles]
	FROM Sale S
	WHERE 1 = 1
	--PARSE('12/16/2010' AS datetime2)
	AND (S.UserEmail LIKE '%' + @UserSearch + '%')
	AND (CAST(S.SalePurchaseDate AS DATE) >= CAST(@FromDate AS DATE))
	AND (CAST(S.SalePurchaseDate AS DATE) <= CAST(@ToDate AS DATE))
	Group By S.UserEmail
GO