-- Create the database
CREATE DATABASE CarRentalSystem;
GO

-- Use the newly created database
USE CarRentalSystem;
GO

-- Create the Cars table
CREATE TABLE Cars (
    Id INT PRIMARY KEY IDENTITY,
    Make NVARCHAR(50) NOT NULL,
    Model NVARCHAR(50) NOT NULL,
    Type INT NOT NULL
);
GO

-- Create the Customers table
CREATE TABLE Customers (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50) NOT NULL,
    LoyaltyPoints INT NOT NULL DEFAULT 0
);
GO

-- Create the Rentals table
CREATE TABLE Rentals (
    Id INT PRIMARY KEY IDENTITY,
    CarId INT NOT NULL,
    CustomerId INT NOT NULL,
    RentalDate DATETIME NOT NULL,
    RentalDays INT NOT NULL,
    ExtraDays INT NOT NULL DEFAULT 0,
    Price DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (CarId) REFERENCES Cars(Id),
    FOREIGN KEY (CustomerId) REFERENCES Customers(Id)
);
GO
