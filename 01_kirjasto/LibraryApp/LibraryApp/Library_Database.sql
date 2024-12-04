USE  Library;
-- SELECT BookId, Title, PublicationYear FROM Book;
-- SELECT * FROM Book WHERE PublicationYear >= YEAR(GETDATE()) - 5;

DROP TABLE IF EXISTS Loan;
DROP TABLE IF EXISTS Book;
CREATE TABLE Book
(
    BookId INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(255) NOT NULL,
    ISBN NVARCHAR(13) NOT NULL,
    PublicationYear INT,
    AvailableCopies INT NOT NULL
);

-- Insert sample data into the Book table
INSERT INTO Book (Title, ISBN, PublicationYear, AvailableCopies)
VALUES 
('To Kill a Mockingbird', '9780060935467', 1960, 3),
('1984', '9780451524935', 1949, 2),
('The Catcher in the Rye', '9780316769174', 1951, 4),
('The Great Gatsby', '9780743273565', 2024, 5),
('Moby Dick', '9781503280786', 2024, 1),
('Pride and Prejudice', '9781503290563', 2023, 3),
('War and Peace', '9781853260629', 2022, 2),
('Hamlet', '9780140714548', 2024, 6),
('The Odyssey', '9780140268867', 2024, 4),
('The Power of Human Nature', '9780199535675', 2021, 1);

DROP TABLE IF EXISTS Member;
-- Create the Member (User) table
CREATE TABLE Member
(
    MemberId INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(255) NOT NULL,
    LastName NVARCHAR(255) NOT NULL,
    Address NVARCHAR(255),
    PhoneNumber NVARCHAR(20),
    Email NVARCHAR(255),
    RegistrationDate DATE NOT NULL,
    DateOfBirth DATE NOT NULL
);

INSERT INTO Member (FirstName, LastName, Address, PhoneNumber, Email, RegistrationDate, DateOfBirth)
VALUES
('John', 'Doe', '123 Main St', '555-1234', 'john.doe@example.com', '2020-01-01', '1990-01-01'),
('Jane', 'Smith', '456 Elm St', '555-5678', 'jane.smith@example.com', '2021-05-15', '1992-09-10'),
('Markus', 'smith', '123 Main St', '555-1234', 'Markus.doe@example.com', '2020-01-01', '1985-03-05'),
('Jane', 'Smith', '456 Elm St', '555-5678', 'jane.smith@example.com', '2021-05-15', '1993-11-14'),
('Mark', 'Jones', '789 Oak St', '555-9012', 'mark.jones@example.com', '2022-03-10', '1980-07-22'),
('Emily', 'Clark', '101 Pine St', '555-3456', 'emily.clark@example.com', '2019-06-22', '1999-01-02'),
('Michael', 'Brown', '202 Maple St', '555-7890', 'michael.brown@example.com', '2018-11-05', '2000-12-11');


-- Create the Loan table
CREATE TABLE Loan
(
    LoanId INT PRIMARY KEY IDENTITY(1,1),
    BookId INT FOREIGN KEY REFERENCES Book(BookId),
    MemberId INT FOREIGN KEY REFERENCES Member(MemberId),
    LoanDate DATE NOT NULL,
    DueDate DATE NOT NULL,
    ReturnDate DATE
);

INSERT INTO Loan (BookId, MemberId, LoanDate, DueDate)
VALUES
(1, 1, '2022-01-05', '2022-01-19'),
(2, 2, '2022-02-10', '2022-02-24'),
(3, 1, '2022-03-01', '2022-03-15');

DROP TABLE IF EXISTS Users;
-- Users table
CREATE TABLE Users
(
    UserId INT PRIMARY KEY IDENTITY(1,1), 
    FirstName NVARCHAR(255) NOT NULL,        
    LastName NVARCHAR(255) NOT NULL,        
    Email NVARCHAR(255) NOT NULL UNIQUE,   
    PasswordHash NVARCHAR(255) NOT NULL,    
    Role NVARCHAR(50) NOT NULL               
);


-- Sample data for Users
    INSERT INTO Users (FirstName, LastName, Email, PasswordHash, Role)
   VALUES 
('Alice', 'Johnson', 'alice.johnson@example.com', 'hashedpassword1', 'User'),
('Bob', 'Brown', 'bob.brown@example.com', 'hashedpassword2', 'Admin');
