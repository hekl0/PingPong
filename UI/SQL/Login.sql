Create database loginDB
Use loginDB

Create table Ulogin --create table Ulogin is my table name
(
    UserId varchar(50) primary key not null,
    --primary key not accept null value
    Password varchar(100) not null
)
insert into  Ulogin
values
    ('Krish', 'kk@321')     --insert value in Ulogin table