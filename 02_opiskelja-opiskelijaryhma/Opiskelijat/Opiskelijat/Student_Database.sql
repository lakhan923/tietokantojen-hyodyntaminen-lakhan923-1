USE Opiskelijat;
 -- SELECT * FROM Opiskelija;


-- Drop existing tables if they exist
DROP TABLE IF EXISTS Opiskelija;
DROP TABLE IF EXISTS Opiskelijaryhma;

-- Opiskelijaryhma table
CREATE TABLE Opiskelijaryhma (
    OpiskelijaryhmaID INT IDENTITY(1,1) PRIMARY KEY,
    ryhmanNimi VARCHAR(100)
);

-- example data into Opiskelijaryhma
INSERT INTO Opiskelijaryhma (ryhmanNimi) VALUES ('Group 1'), ('Group 2'), ('Group 3');

-- Opiskelija table with a foreign key referencing Opiskelijaryhma
CREATE TABLE Opiskelija (
    OpiskelijaID INT IDENTITY(1,1) PRIMARY KEY,
    etunimi VARCHAR(100),
    sukunimi VARCHAR(100),
    ryhma_id INT,
    FOREIGN KEY (ryhma_id) REFERENCES Opiskelijaryhma(OpiskelijaryhmaID)
);

-- example data into Opiskelija
INSERT INTO Opiskelija (etunimi, sukunimi, ryhma_id) 
VALUES 
('John', 'Doe', 1), ('Jane', 'Smith', 2), ('Alice', 'Brown', 3);