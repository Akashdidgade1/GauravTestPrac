create database GauravTest

use GauravTest

create table information
(
	id int Primary key identity,
	Fullname varchar(50),
	gender varchar(10),
	DateOfBirth datetime,
	Nationality varchar(20),
	Country varchar(20),
	State varchar(20),
	Photo varchar(100),	
	Details varchar(20),
	Address varchar(100),
	Hobby varchar(20),
)
