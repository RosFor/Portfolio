--CREATE TABLES
USE DVDLibrary
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='DVD')
	DROP TABLE DVD
GO

CREATE TABLE DVD (
	id int identity(1,1) primary key not null,
	title varchar(50) not null,
	releaseYear smallint not null,
	director varchar(50) not null,
	rating varchar(5) not null,
	notes varchar(100) not null,
)
