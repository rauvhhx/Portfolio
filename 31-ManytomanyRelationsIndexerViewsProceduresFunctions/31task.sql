CREATE DATABASE CompanyMM;
GO

USE CompanyMM;
GO

CREATE TABLE Employees
(
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    BirthDate DATE NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    CONSTRAINT CK_Employees_BirthDate CHECK (BirthDate <= DATEADD(YEAR, -18, CAST(GETDATE() AS DATE)))
);

CREATE TABLE Projects
(
    ProjectID INT IDENTITY(1,1) PRIMARY KEY,
    ProjectName NVARCHAR(100) NOT NULL UNIQUE,
    StartDate DATE NOT NULL,
    EndDate DATE NULL,
    CONSTRAINT CK_Projects_Dates CHECK (EndDate IS NULL OR EndDate >= StartDate)
);

CREATE TABLE EmployeeProjects
(
    EmployeeID INT NOT NULL,
    ProjectID INT NOT NULL,
    AssignedDate DATE NOT NULL,
    CONSTRAINT PK_EmployeeProjects PRIMARY KEY (EmployeeID, ProjectID),
    CONSTRAINT FK_EmployeeProjects_Employees FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID),
    CONSTRAINT FK_EmployeeProjects_Projects FOREIGN KEY (ProjectID) REFERENCES Projects(ProjectID),
    CONSTRAINT CK_EmployeeProjects_AssignedDate CHECK (AssignedDate >= '2000-01-01')
);

INSERT INTO Employees (FirstName, LastName, BirthDate, Email) VALUES
(N'Ali', N'Mammadov', '1990-05-10', N'ali.mammadov@example.com'),
(N'Aysel', N'Huseynova', '1988-02-15', N'aysel.huseynova@example.com'),
(N'Kamran', N'Aliyev', '1992-09-01', N'kamran.aliyev@example.com'),
(N'Leyla', N'Rahimova', '1985-11-20', N'leyla.rahimova@example.com'),
(N'Rashad', N'Ahmedov', '1993-03-30', N'rashad.ahmedov@example.com');

INSERT INTO Projects (ProjectName, StartDate, EndDate) VALUES
(N'HR System Upgrade', '2024-01-10', '2024-06-30'),
(N'E-Commerce Platform', '2024-02-01', NULL),
(N'Mobile App Revamp', '2024-03-15', NULL);

INSERT INTO EmployeeProjects (EmployeeID, ProjectID, AssignedDate) VALUES
(1, 1, '2024-01-15'),
(1, 2, '2024-02-10'),
(1, 3, '2024-03-20'),
(2, 1, '2024-01-20'),
(2, 2, '2024-02-20'),
(3, 2, '2024-02-25'),
(3, 3, '2024-03-25'),
(4, 3, '2024-04-01');

SELECT * FROM Employees;

SELECT * FROM Projects;

SELECT e.EmployeeID,
       e.FirstName,
       e.LastName,
       p.ProjectID,
       p.ProjectName,
       ep.AssignedDate
FROM Employees e
JOIN EmployeeProjects ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects p ON p.ProjectID = ep.ProjectID
ORDER BY e.EmployeeID, p.ProjectID;

SELECT p.ProjectID,
       p.ProjectName,
       COUNT(ep.EmployeeID) AS EmployeeCount
FROM Projects p
LEFT JOIN EmployeeProjects ep ON p.ProjectID = ep.ProjectID
GROUP BY p.ProjectID, p.ProjectName;

SELECT e.EmployeeID,
       e.FirstName,
       e.LastName,
       COUNT(ep.ProjectID) AS ProjectCount
FROM Employees e
JOIN EmployeeProjects ep ON e.EmployeeID = ep.EmployeeID
GROUP BY e.EmployeeID, e.FirstName, e.LastName
HAVING COUNT(ep.ProjectID) > 2;
GO

CREATE VIEW EmployeeProjectView AS
SELECT e.EmployeeID,
       e.FirstName + N' ' + e.LastName AS FullName,
       p.ProjectID,
       p.ProjectName,
       ep.AssignedDate
FROM Employees e
JOIN EmployeeProjects ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects p ON p.ProjectID = ep.ProjectID;
GO

SELECT * FROM EmployeeProjectView
WHERE EmployeeID = 1;
GO

CREATE PROCEDURE sp_AssignEmployeeToProject
    @empId INT,
    @projId INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO EmployeeProjects (EmployeeID, ProjectID, AssignedDate)
    SELECT @empId, @projId, CAST(GETDATE() AS DATE)
    WHERE NOT EXISTS
    (
        SELECT 1
        FROM EmployeeProjects
        WHERE EmployeeID = @empId
          AND ProjectID = @projId
    );
END;
GO

CREATE FUNCTION fn_GetProjectCount
(
    @empId INT
)
RETURNS INT
AS
BEGIN
    DECLARE @cnt INT;

    SELECT @cnt = COUNT(*)
    FROM EmployeeProjects
    WHERE EmployeeID = @empId;

    RETURN @cnt;
END;
GO

SELECT dbo.fn_GetProjectCount(1) AS ProjectCountForEmp1;

EXEC sp_AssignEmployeeToProject @empId = 5, @projId = 1;

SELECT *
FROM EmployeeProjects
WHERE EmployeeID = 5;

SELECT dbo.fn_GetProjectCount(5) AS ProjectCountForEmp5;

DELETE FROM EmployeeProjects
WHERE EmployeeID = 5;

SELECT *
FROM EmployeeProjects
WHERE EmployeeID = 5;
