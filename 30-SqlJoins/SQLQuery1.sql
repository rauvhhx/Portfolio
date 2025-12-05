

CREATE TABLE Countries(
    Id INT PRIMARY KEY,
    Name NVARCHAR(100)
);

CREATE TABLE Cities(
    Id INT PRIMARY KEY,
    Name NVARCHAR(100),
    CountryId INT FOREIGN KEY REFERENCES Countries(Id)
);

CREATE TABLE Employees(
    Id INT PRIMARY KEY,
    Name NVARCHAR(100),
    Surname NVARCHAR(100),
    Age INT,
    Salary DECIMAL(10,2),
    Position NVARCHAR(100),
    CityId INT FOREIGN KEY REFERENCES Cities(Id),
    IsDeleted BIT
);



INSERT INTO Countries VALUES
(1, 'Azerbaijan'),
(2, 'Turkey'),
(3, 'USA');

INSERT INTO Cities VALUES
(1, 'Baku', 1),
(2, 'Istanbul', 2),
(3, 'New York', 3);

INSERT INTO Employees VALUES
(1, 'Ali', 'Aliyev', 28, 1800, 'Developer', 1, 0),
(2, 'Aysel', 'Quliyeva', 25, 2500, 'Manager', 2, 0),
(3, 'Murad', 'Huseynov', 30, 2100, 'Reseption', 1, 0),
(4, 'Kenan', 'Mammadov', 35, 1900, 'Reseption', 3, 1),
(5, 'Lala', 'Ismayilova', 27, 3000, 'Designer', 2, 1);


SELECT e.Name, e.Surname, c.Name AS City, co.Name AS Country
FROM Employees e
JOIN Cities c ON e.CityId = c.Id
JOIN Countries co ON c.CountryId = co.Id;

SELECT e.Name, e.Surname, e.Salary, co.Name AS Country
FROM Employees e
JOIN Cities c ON e.CityId = c.Id
JOIN Countries co ON c.CountryId = co.Id
WHERE e.Salary > 2000;


SELECT c.Name AS City, co.Name AS Country
FROM Cities c
JOIN Countries co ON c.CountryId = co.Id;


SELECT e.Name, e.Surname, e.Age, e.Salary, e.Position, c.Name AS City, co.Name AS Country
FROM Employees e
JOIN Cities c ON e.CityId = c.Id
JOIN Countries co ON c.CountryId = co.Id
WHERE e.Position = 'Reseption';


SELECT e.Name, e.Surname, c.Name AS City, co.Name AS Country
FROM Employees e
JOIN Cities c ON e.CityId = c.Id
JOIN Countries co ON c.CountryId = co.Id
WHERE e.IsDeleted = 1;
