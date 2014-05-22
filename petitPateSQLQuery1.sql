use master
go

drop database petitPateBDD
go

create database petitPateBDD
go

use petitPateBDD
go


create table Movie_category (
	IdMovieCategory int not null identity (1,1) primary key,
	Title nvarchar(50) not null,
);

create table Movie (
	IdFilm int not null identity (1,1) primary key,
	Title nvarchar(50) not null,
	Synopsis nvarchar(100) not null,
	Producer DateTime not null,
	Poster image,
	Category int not null references Movie_Category,
);

create table Cinema (
	IdCinema int not null identity (1,1) primary key,
	Name nvarchar(20) not null,
	Nb_Places int not null
);

create table Projection (
	IdProjectiondatetime int not null identity (1,1) primary key,
	LangVersion nvarchar(4) not null default 'VO',
	MovieId int not null references Movie,
	CinemaId int not null references Cinema,
);

create table UserTable (
	IdUser int not null identity (1,1) primary key,
	UserLogin nvarchar(20) not null,
	UserPassword nvarchar(MAX) not null,
	FirstName nvarchar(20) not null,
	LastName nvarchar(20) not null,
	IsAdmin bit not null default 0,
);


create table Place (
	IdPlace int not null identity (1,1) primary key,
	Name nvarchar(20) not null,
	Adresse nvarchar(40) not null,
	Phone nvarchar(15) not null,
	CinemaId int not null references Cinema,
);

create table Reservation (
	IdReservation int not null identity (1,1) primary key,
	AvailablePlaces nvarchar(20) not null,
	ProjectionId int not null references Projection,
	UserId int not null references UserTable,
);



insert into Movie_category (IdMovieCategory, Title) values (1, 'drame');
insert into Movie_category (IdMovieCategory, Title) values (2, 'policier');
insert into Movie_category (IdMovieCategory, Title) values (3, 'mauvaise comédie française');
insert into Movie_category (IdMovieCategory, Title) values (4, 'incroyable');
