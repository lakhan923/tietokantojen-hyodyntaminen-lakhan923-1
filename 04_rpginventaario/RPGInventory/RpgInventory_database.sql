USE RpgInventory;

-- Drop the stored procedure if it exists
DROP PROCEDURE IF EXISTS SearchItems;
GO

-- Create the SearchItems stored procedure
CREATE PROCEDURE SearchItems @Keyword NVARCHAR(100)
AS
BEGIN
    SELECT *
    FROM Items
    WHERE ItemName LIKE '%' + @Keyword + '%';
END;
GO

-- Drop the tables if they exist
DROP TABLE IF EXISTS Items;
DROP TABLE IF EXISTS ItemTypes;
DROP TABLE IF EXISTS ItemRarities;
GO

-- Create the ItemTypes table
CREATE TABLE ItemTypes (
    Id INT PRIMARY KEY IDENTITY,
    TypeName NVARCHAR(100)
);
GO

-- Insert some values into ItemTypes
INSERT INTO ItemTypes (TypeName) VALUES ('Weapon'), ('Armor');
GO

-- Create the ItemRarities table
CREATE TABLE ItemRarities (
    Id INT PRIMARY KEY IDENTITY,
    RarityName NVARCHAR(100)
);
GO

-- Insert some values into ItemRarities
INSERT INTO ItemRarities (RarityName) VALUES ('Normal'), ('Magic'), ('Rare'), ('Unique');
GO

-- Create the Items table
CREATE TABLE Items (
    Id INT PRIMARY KEY IDENTITY,
    ItemName NVARCHAR(100),
    ItemTypeId INT FOREIGN KEY REFERENCES ItemTypes(Id),
    RarityId INT FOREIGN KEY REFERENCES ItemRarities(Id),
    BaseValue DECIMAL(10, 2),
    AttValue DECIMAL(10, 2),
    DefValue DECIMAL(10, 2)
);
GO

-- Insert some values into Items (with references to ItemTypes and ItemRarities)
INSERT INTO Items (ItemName, ItemTypeId, RarityId, BaseValue, AttValue, DefValue)
VALUES 
('Sword of Power', 1, 2, 100.00, 50.00, 20.00),  -- Weapon, Magic
('Shield of Strength', 2, 1, 50.00, 10.00, 50.00),  -- Armor, Normal
('Dagger of Stealth', 1, 3, 75.00, 40.00, 10.00);  -- Weapon, Rare
GO
