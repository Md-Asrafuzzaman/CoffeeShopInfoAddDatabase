CREATE DATABASE CoffeeShop
USE CoffeeShop

CREATE TABLE Items(
ID INT IDENTITY(1,1),
Name VARCHAR(50),
Price FLOAT
)


CREATE TABLE Customer(
CustomerId INT IDENTITY(1,1),
CustomerName VARCHAR(50),
CustomerAddress VARCHAR(150),
CustomerContact VARCHAR(15)
)


CREATE TABLE Orders(
IteamId INT IDENTITY(1,1),
CustomerName VARCHAR(50),
IteamName VARCHAR(50),
OrderQuantity INT,
TotalPrice FLOAT
)

select * from Orders





