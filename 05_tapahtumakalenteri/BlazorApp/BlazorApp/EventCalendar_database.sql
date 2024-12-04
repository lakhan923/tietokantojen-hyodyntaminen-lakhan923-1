USE EventCalendar;
-- Drop the Events table
DROP TABLE IF EXISTS Events;

-- Drop the Users table
DROP TABLE IF EXISTS Users;

-- Drop the Categories table
DROP TABLE IF EXISTS Categories;

-- Recreate Categories table
CREATE TABLE Categories (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX) NULL
);

-- Insert sample categories
INSERT INTO Categories (Name, Description)
VALUES ('Meeting', 'Meetings with colleagues, clients, or partners'),
       ('Conference', 'Conferences or large gatherings'),
       ('Workshop', 'Training workshops and educational sessions'),
       ('Social', 'Social events and gatherings'),
       ('Webinar', 'Online presentations and seminars');

-- Recreate Users table
CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(128) NOT NULL,
    Role NVARCHAR(50) NOT NULL
);

-- Insert sample users
DECLARE @i INT = 1;
WHILE @i <= 20
BEGIN
    INSERT INTO Users (FirstName, LastName, Email, PasswordHash, Role)
    VALUES ('User' + CAST(@i AS NVARCHAR), 'Lastname', 'user' + CAST(@i AS NVARCHAR) + '@example.com', 'hashedpassword' + CAST(@i AS NVARCHAR), 'User');
    SET @i = @i + 1;
END

-- Recreate Events table
CREATE TABLE Events (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX) NULL,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    Location NVARCHAR(200) NULL,
    CategoryId INT NULL,
    CreatedBy INT NOT NULL,
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
    FOREIGN KEY (CreatedBy) REFERENCES Users(Id)
);

-- Insert sample events
DECLARE @j INT = 1;
WHILE @j <= 20
BEGIN
    INSERT INTO Events (Title, Description, StartDate, EndDate, Location, CategoryId, CreatedBy)
    VALUES ('Event ' + CAST(@j AS NVARCHAR), 'Description for Event ' + CAST(@j AS NVARCHAR), DATEADD(DAY, @j * 3, GETDATE()), DATEADD(DAY, @j * 3, DATEADD(HOUR, 2, GETDATE())), 'Location ' + CAST(@j AS NVARCHAR), 1 + (@j % 5), 1 + (@j % 20));
    SET @j = @j + 1;
END