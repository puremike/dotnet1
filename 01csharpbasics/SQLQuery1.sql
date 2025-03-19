CREATE SCHEMA TutorialAppSchema
GO

CREATE TABLE TutorialAppSchema.Computer 
( 
    -- TableID INT IDENTITY(starting, increment by)
    ComputerId INT IDENTITY(1,1) PRIMARY KEY,
    -- NVARCHAR can take unicode and non-characters. You can use VARCHAR and CHAR for characters
    Motherboard NVARCHAR(50),
    CPUCores INT,
    HasWifi BIT,
    HasLTE BIT,
    ReleaseDate DATETIME,
    -- DECIMAL(18 whole number values, 4 decimals) 
    Price DECIMAL(18, 4),
    VideoCard NVARCHAR(50),
);
GO

INSERT INTO TutorialAppSchema.Computer 
    (Motherboard, CPUCores, HasWifi, HasLTE, ReleaseDate, Price, VideoCard)
VALUES 
    ('ASUS ROG Strix X570-E', 8, 1, 0, '2023-05-15', 1299.99, 'NVIDIA RTX 3060'),
    ('MSI B550-A PRO', 4, 1, 1, '2022-11-01', 899.50, 'AMD Radeon RX 6600'),
    ('Gigabyte Z490 AORUS', 6, 0, 0, '2021-08-20', 749.99, 'NVIDIA GTX 1660 Ti'),
    ('ASRock B450M', 12, 1, 0, '2024-01-10', 1999.75, 'NVIDIA RTX 4080'),
    ('Intel NUC M15', 4, 1, 1, '2023-09-30', 1099.00, 'Intel Iris Xe');

SELECT * FROM TutorialAppSchema.Computer;

-- Select a row from a table using a ComputerId, Price, etc.
SELECT * FROM TutorialAppSchema.Computer WHERE ComputerId = 3;

-- Delete a row from a table
DELETE FROM TutorialAppSchema.Computer WHERE ComputerId = 3;

-- Insert a row into the table
INSERT INTO TutorialAppSchema.Computer
    (Motherboard, CPUCores, HasWifi, HasLTE, ReleaseDate, Price, VideoCard)
VALUES
    ('Gigabyte Z490 AORUS', 6, 0, 0, '2021-08-20', 749.99, 'NVIDIA GTX 1660 Ti');

-- Update a row
UPDATE TutorialAppSchema.Computer SET Price = 1000.99 WHERE ComputerId = 5;


SELECT [Motherboard], [CPUCores], [HasWifi], [HasLTE], [ReleaseDate], [Price], [VideoCard] 
FROM TutorialAppSchema.Computer
ORDER BY Price DESC --DESC- decending order