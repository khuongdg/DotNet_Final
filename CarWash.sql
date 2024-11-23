CREATE DATABASE CarWash
USE CarWash;

--drop table Employee
--select * from Employee
-- Tạo bảng Employee
CREATE TABLE Employee (
    id INT IDENTITY(1,1) PRIMARY KEY,         
    name VARCHAR(50) NOT NULL,               
    phone VARCHAR(50) NOT NULL UNIQUE,         
    address TEXT NOT NULL,            
    dob DATE NOT NULL,    
	gender VARCHAR(50) NOT NULL,
    role VARCHAR(50) NOT NULL,                 
    salary DECIMAL(18, 2) NOT NULL,            
    password VARCHAR(50) NOT NULL             
);

INSERT INTO Employee VALUES ('admin', '0123456789', 'TP HCM', '11-19-2024', 'Male', 'Manager', '100000', '123');

CREATE TABLE VehicleType (
    id INT IDENTITY(1,1) PRIMARY KEY,         
    name VARCHAR(50) NOT NULL,               
    class VARCHAR(50) NOT NULL
);
--DROP TABLE CostofGood
CREATE TABLE CostofGood (
    id INT IDENTITY(1,1) PRIMARY KEY,         
    costname VARCHAR(50) NOT NULL,               
    cost DECIMAL(18, 2) NOT NULL, 
	date DATE NOT NULL
);

--select * from Company
CREATE TABLE Company (
    name VARCHAR(50) NOT NULL,         
    address VARCHAR(50) NOT NULL,               
);

CREATE TABLE Customer (
    id INT IDENTITY(1,1) PRIMARY KEY, 
	vid INT NOT NULL,
	name VARCHAR(50) NOT NULL,
	phone VARCHAR(50) NOT NULL,
	carno VARCHAR(50) NOT NULL,
	carmodel VARCHAR(50) NOT NULL,
	address TEXT NOT NULL,
	points INT NOT NULL
);

CREATE TABLE Service (
	id INT IDENTITY(1,1) PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	price DECIMAL(18, 2) NOT NULL
);

--select * from Cash
CREATE TABLE Cash (
	id INT IDENTITY(1,1) PRIMARY KEY,
	transno VARCHAR(50) NOT NULL,
	cid INT NOT NULL,
	sid INT NOT NULL,
	vid INT NOT NULL,
	price DECIMAL(18, 2) NOT NULL,
	date DATE NOT NULL,
	status VARCHAR(50) DEFAULT 'Pending'
);

