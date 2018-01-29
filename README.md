# HumaneSociety
CREATE DATABASE humaneSociety;
CREATE SCHEMA HumaneSociety;

CREATE TABLE HumaneSociety.Animals(
ID int IDENTITY(1,1) PRIMARY KEY,
PetName varchar(50) NOT NULL,
AnimalType varchar(50), 
BirthDate datetime2,
Size varchar(10) NOT NULL,
Gender varchar(10) NOT NULL,
VaccineStatus varchar(25), 
FoodType varchar(50),
FoodAmount int,

AdoptionStatus varchar(12));
ID int IDENTITY(1,1) PRIMARY KEY,
PetName varchar(50) NOT NULL,
AnimalType varchar(50), 
BirthDate datetime2,
Size varchar(10) NOT NULL,
Gender varchar(10) NOT NULL,
VaccineStatus varchar(25), 
FoodType varchar(50),
FoodAmount int,
RoomID int FOREIGN KEY REFERENCES Rooms(RoomNumber),
AdoptionStatus varchar(12),

CREATE TABLE HumaneSociety.Room(
RoomNumber int IDENTITY(1,1) PRIMARY KEY,
Vacancy varchar(20),
CONSTRAINT AnimalID FOREIGN KEY REFERENCES Animals(ID),
);

ALTER TABLE humaneSociety.Animals
ADD RoomID int;

CREATE TABLE HumaneSociety.Room(
RoomNumber int IDENTITY(1,1) PRIMARY KEY,
Vacancy varchar(20),
AnimalID int,
);

ALTER TABLE humaneSociety.Animals
ADD CONSTRAINT FK_RoomID 
FOREIGN KEY (RoomNumber)REFERENCES Room(RoomNumber);

ALTER TABLE humaneSociety.Animals
ADD CONSTRAINT FK_RoomID 
FOREIGN KEY (RoomNumber)REFERENCES Room(RoomNumber);

ALTER TABLE humaneSociety.Animals
ADD CONSTRAINT RoomID 
FOREIGN KEY (RoomID)REFERENCES humaneSociety.Room(RoomNumber);

ALTER TABLE humaneSociety.Room
ADD CONSTRAINT AnimalID 
FOREIGN KEY (AnimalID)REFERENCES humaneSociety.Animals(ID);

// There were some issues that required going back an altering these as the databases were created.