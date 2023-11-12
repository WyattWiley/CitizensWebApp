create or alter proc spInstitutionInformation
AS
BEGIN
	select * 
	from Institutions
END
GO

EXEC spInstitutionInformation
GO

create or alter proc spGetResearchAreaInformation
AS
BEGIN
	select * 
	from ResearchAreas
END
GO

EXEC spGetResearchAreaInformation where InstitutionID = @InstitutionID
GO

create or alter proc spProjectDetails
AS
BEGIN
	select * 
	from Projects
END
GO

EXEC spProjectDetails
GO

create or alter proc spProjects
AS
BEGIN
	select ProjectID, ProjectName
	from Projects
END
GO

EXEC spProjects
GO

exec spGetResearchAreaInformation
Go

CREATE OR ALTER PROCEDURE spGetResearchAreaInformation
    @InstitutionID int = NULL
AS
BEGIN
    IF @InstitutionID IS NULL
        SELECT * FROM ResearchAreas
    ELSE
        SELECT * FROM ResearchAreas WHERE InstitutionID = @InstitutionID
END

EXEC spGetResearchAreaInformation
GO

CREATE OR ALTER PROCEDURE spProjectDetails
    @ProjectID int = NULL
AS
BEGIN
    IF @ProjectID IS NULL
        SELECT * FROM Projects
    ELSE
        SELECT * FROM Projects WHERE ProjectID = @ProjectID
END
GO

Exec spProjectDetails
GO

CREATE or alter PROCEDURE spProjectDetails
    @ResearchID int = NULL
AS
BEGIN
    IF @ResearchID IS NULL
        SELECT * FROM Projects
    ELSE
        SELECT * FROM Projects WHERE ResearchID = @ResearchID
END
GO
