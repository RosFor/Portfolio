--RESET DATABASE & INSERT VALUES
USE DVDLibrary
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES

WHERE ROUTINE_NAME = 'DbReset')
DROP PROCEDURE DbReset

GO

CREATE PROCEDURE DbReset AS
BEGIN
	DELETE FROM DVD;

	DBCC CHECKIDENT ('DVD', RESEED, 1)

	SET IDENTITY_INSERT DVD ON
	INSERT INTO DVD (id, title, releaseYear, director, rating, notes)
	VALUES (1, 'Alice In Wonderland', 1951, 'Clyde Geronimi, Wilfred Jackson, Hamilton Luske', 'G', 'The animated film.'),
	(2, 'Donnie Darko', 2001, 'Richard Kelly', 'R', '"28 days, 6 hours, 42 minutes, 12 seconds." - Frank'),
	(3, 'Inception', 2010, 'Christopher Nolan', 'PG-13', 'The Hanz Zimmer "bwong."'),
	(4, 'Apocalypse Now', 1979, 'Francis Ford Coppola', 'R', 'Starring Martin Sheen as Captain Benjamin L. Willard.');
	SET IDENTITY_INSERT DVD OFF

END