USE master
GO

CREATE LOGIN DvdLibraryApp WITH PASSWORD='testing123'
GO

USE DVDLibrary
GO

CREATE USER DvdLibraryApp FOR LOGIN DvdLibraryApp
GO

GRANT EXECUTE ON DVDSelectAll TO DvdLibraryApp
GRANT EXECUTE ON DVDSelectID TO DvdLibraryApp
GRANT EXECUTE ON DVDSelectTitle TO DvdLibraryApp
GRANT EXECUTE ON DVDSelectYear TO DvdLibraryApp
GRANT EXECUTE ON DVDSelectDirector TO DvdLibraryApp
GRANT EXECUTE ON DVDSelectRating TO DvdLibraryApp
GRANT EXECUTE ON DVDInsert TO DvdLibraryApp
GRANT EXECUTE ON DVDUpdate TO DvdLibraryApp
GRANT EXECUTE ON DVDDelete TO DvdLibraryApp
GO