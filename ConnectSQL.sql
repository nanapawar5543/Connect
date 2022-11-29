create database DBconnect
use DBconnect

Create table Users(
UserID uniqueidentifier primary key,
MobileNumber numeric(10) not null,
Passwords nvarchar(max) not null,
FirstName nvarchar(max) not null,
LastName nvarchar(max) not null,
EmailID nvarchar(max),
IsActive bit,
IsDeleted bit,
JoiningDateAndTime datetime)

alter table Users add JoiningDateAndTime nvarchar(max)
alter table users alter column JoiningDateAndTime datetime

delete from messages
select * from Users

Create table	 Messages(
MessageID uniqueidentifier primary key,
UserID uniqueidentifier foreign key references Users(UserID),
MessageText nvarchar(max),
IsDeleted bit,
SenderID uniqueidentifier,
MessageDateAndTime nvarchar(max))

alter table Messages add MessageDateAndTime nvarchar(max)

select * from Messages

truncate table Messages

drop table messages
drop table users