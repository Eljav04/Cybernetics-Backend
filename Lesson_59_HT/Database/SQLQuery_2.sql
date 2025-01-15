-- CREATE TABLE Location (
--     LocationID INT PRIMARY KEY IDENTITY(1,1),
--     LocationName NVARCHAR(100) NOT NULL
-- );

-- CREATE TABLE Contact (
--     ContactID INT PRIMARY KEY IDENTITY(1,1),
--     Name NVARCHAR(100) NOT NULL,
--     Surname NVARCHAR(100) NOT NULL,
--     Email NVARCHAR(255) UNIQUE NOT NULL,
--     LocationID INT FOREIGN KEY REFERENCES Location(LocationID)
-- );

-- CREATE TABLE PhoneNumber (
--     PhoneNumberID INT PRIMARY KEY IDENTITY(1,1),
--     ContactID INT FOREIGN KEY REFERENCES Contact(ContactID),
--     PhoneNumber NVARCHAR(15) NOT NULL
-- );

-- Insert into Location
INSERT INTO Location (LocationName)
VALUES ('Local storage'), ('Google Account'), ('iClouid'), ('SIM');

INSERT INTO Contact (Name, Surname, Email, LocationID)
VALUES 
    ('Yusif', 'Beybutov', 'yusif@gmail.com', 1),
    ('Aylin', 'Hasanova', 'aylin@gmail.com', 2),
    ('Emin', 'Mammadov', 'emin@gmail.com', 3),
    ('Leyla', 'Aliyeva', 'leyla@gmail.com', 4),
    ('Nigar', 'Guliyeva', 'nigar@gmail.com', 1),
    ('Murad', 'Karimov', 'murad@gmail.com', 2),
    ('Rashad', 'Ibrahimov', 'rashad@gmail.com', 3),
    ('Sabina', 'Huseynova', 'sabina@gmail.com', 4),
    ('Kamran', 'Aliyev', 'kamran@gmail.com', 1);

INSERT INTO PhoneNumber (ContactID, PhoneNumber)
VALUES 
    (1, '+994503431290'),
    (2, '+994503221478'),
    (3, '+994502589634'),
    (4, '+994504478123'),
    (5, '+994507856341'),
    (6, '+994505432876'),
    (7, '+994508731245'),
    (8, '+994502147893'),
    (9, '+994509845312');


INSERT INTO PhoneNumber (ContactID, PhoneNumber)
VALUES 
    (1, '+994103231209'),
    (3, '+994702589634'),
    (4, '+994124478123'),
    (5, '+994707856341');
