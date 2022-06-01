--Retrieving all Dvds (Done)
--Retrieving a DVD by id (Done)
--Retrieving Dvds by Title (Done)
--Retrieving Dvds by Release Year (Done)
--Retrieving Dvds by Director Name (Done)
--Retrieving Dvds by Rating (Done)
--Creating a new DVD (Done)
--Updating an Existing DVD (Done)
--Deleting a DVD (Done)

USE DVDLibrary
GO

--SELECT ALL DVDS
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES

WHERE ROUTINE_NAME = 'DVDSelectAll')
DROP PROCEDURE DVDSelectAll

GO

CREATE PROCEDURE DVDSelectAll AS
	SELECT id, title, releaseYear, director, rating, notes
	FROM DVD
GO

--SELECT SINGLE DVD/DVD BY id
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   
WHERE ROUTINE_NAME = 'DVDSelectID')
DROP PROCEDURE DVDSelectID

GO

CREATE PROCEDURE DVDSelectID (
	@id int
)
AS
	SELECT id, title, releaseYear, director, rating, notes
	FROM DVD
	WHERE id = @id
GO

--SELECT BY TITLE
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   
WHERE ROUTINE_NAME = 'DVDSelectTitle')
DROP PROCEDURE DVDSelectTitle

GO

CREATE PROCEDURE DVDSelectTitle (
	@title varchar(50)
)
AS
	SELECT id, title, releaseYear, director, rating, notes
	FROM DVD
	WHERE title LIKE '%' + @title + '%'
GO

--SELECT BY RELEASE YEAR
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   
WHERE ROUTINE_NAME = 'DVDSelectYear')
DROP PROCEDURE DVDSelectYear

GO

CREATE PROCEDURE DVDSelectYear (
	@releaseYear smallint
)
AS
	SELECT id, title, releaseYear, director, rating, notes
	FROM DVD
	WHERE releaseYear = @releaseYear
GO

--SELECT BY DIRECTOR
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES

WHERE ROUTINE_NAME = 'DVDSelectDirector')
DROP PROCEDURE DVDSelectDirector

GO

CREATE PROCEDURE DVDSelectDirector (
	@director varchar(50)
)AS
	SELECT *
	FROM DVD
	WHERE director LIKE '%' + @director + '%'
GO

--SELECT BY RATING
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   
WHERE ROUTINE_NAME = 'DVDSelectRating')
DROP PROCEDURE DVDSelectRating

GO

CREATE PROCEDURE DVDSelectRating (
	@rating varchar(5)
)
AS
	SELECT id, title, releaseYear, director, rating, notes
	FROM DVD
	WHERE rating = @rating
GO

--CREATE/ADD/INSERT DVD
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DVDInsert')
      DROP PROCEDURE DVDInsert
GO

CREATE PROCEDURE DVDInsert (
	@id int output,
	@title varchar(50),
	@releaseYear smallint,
	@director varchar(50),
	@rating varchar(5),
	@notes varchar(100)
)AS
	INSERT INTO DVD (title, releaseYear, director, rating, notes)
	VALUES (@title, @releaseYear, @director, @rating, @notes)

	SET @id = SCOPE_IDENTITY();
GO

--EDIT/UPDATE DVD
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DVDUpdate')
      DROP PROCEDURE DVDUpdate
GO

CREATE PROCEDURE DVDUpdate (
	@id int,
	@title varchar(50),
	@releaseYear smallint,
	@director varchar(50),
	@rating varchar(5),
	@notes varchar(100)
)
AS
	UPDATE DVD SET
		title = @title,
		releaseYear = @releaseYear,
		director = @director,
		rating = @rating,
		notes = @notes
	WHERE id = @id
GO

--DELETE DVD
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DVDDelete')
      DROP PROCEDURE DVDDelete
GO

CREATE PROCEDURE DVDDelete (
	@id int
)
AS
	DELETE FROM DVD
	WHERE id = @id
GO