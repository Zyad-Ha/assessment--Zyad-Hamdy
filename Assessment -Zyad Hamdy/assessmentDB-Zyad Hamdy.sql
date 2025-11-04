create table [User]
(
	U_id			int primary key identity(1,1),
	DepartmentID	int references Department(D_id),
	Uname			nvarchar(max),
	password		nvarchar(max),
	Email			nvarchar(max),	
	address			nvarchar(max),
	jop_title		nvarchar(max),
	salary			nvarchar(max),
	role			nvarchar(max),
);
go
drop table [User]
go

insert into [User]
values
(1,'admin','1','admin@gmail.com','address1','manager', '15000','admin'),
(1,'e1','2','emp1@gmail.com','address2','frontend', '10000' ,'emp'),
(2,'e2','3','emp2@gmail.com','address3','backend', '10000' ,'emp');
go

create table Department
(
	D_id			int primary key identity(1,1),
	Dname			nvarchar(max),
);
go

drop table Department
go

insert into Department
values
('Department 1'),
('Department 2');
go

--02-11-2025

create table LeaveRequest 
(
	R_id			int primary key identity(1,1),
	UserID			int references [User](U_id),
	startDate		date,
	endDate			date,
	LeaveType		nvarchar(max),
	status			nvarchar(max),
);
go
drop table LeaveRequest
go

	insert into LeaveRequest
	values
	(2,'02-11-2025','04-11-2025','Annual','Pending');
	go

select * from [User]
go
select * from Department
go
select * from LeaveRequest
go