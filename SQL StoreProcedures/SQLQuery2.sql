create or alter proc spProjectDetails
@ProjectID int
AS
BEGIN
    SELECT ProjectID, ProjectName, StartDate, EndDate, Description
    FROM Projects
    WHERE ProjectID = @ProjectID
END
GO

Exec spProjectDetails
go

select * from Projects
go 

exec spGetResearchAreaInformation
go

CREATE or alter PROCEDURE spGetProjects
@ResearchID int = NULL
AS
BEGIN
    IF @ResearchID IS NULL
        SELECT ProjectID, ProjectName, StartDate, EndDate, Description
        FROM Projects
    ELSE
        SELECT ProjectID, ProjectName, StartDate, EndDate, Description
        FROM Projects
        WHERE ResearchID = @ResearchID
END