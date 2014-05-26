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

create table Emplacement (
	IdPlace int not null identity (1,1) primary key,
	Name nvarchar(20) not null,
	Adresse nvarchar(40) not null,
	Phone nvarchar(15) not null
);
create table Cinema (
	IdCinema int not null identity (1,1) primary key,
	Name nvarchar(20) not null,
	Nb_Places int not null,
	Emplacement int not null references Emplacement
);

create table Projection (
	IdProjectiondatetime int not null identity (1,1) primary key,
	LangVersion nvarchar(4) not null default 'VO',
	MovieId int not null references Movie,
	CinemaId int not null references Cinema,
	DateHeure smalldatetime not null,
);

create table UserTable (
	IdUser int not null identity (1,1) primary key,
	UserLogin nvarchar(20) not null,
	UserPassword nvarchar(MAX) not null,
	FirstName nvarchar(20) not null,
	LastName nvarchar(20) not null,
	IsAdmin bit not null default 0,
);

create table Reservation (
	IdReservation int not null identity (1,1) primary key,
	nbPlaces int not null,
	Projection int not null references Projection,
	UserId int not null references UserTable,
);



insert into Movie_category (Title) values ('drame');
insert into Movie_category (Title) values ('policier');
insert into Movie_category (Title) values ('mauvaise comédie française');
insert into Movie_category (Title) values ('incroyable');

insert into Movie (Title, Synopsis, Producer, Category) values (
'Dans la peau de John Malkovich',
'"Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
 tempor incididunt ut labore et dolore magna aliqua. Econsectetur 
adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore 
magna aliqua."',
'Monsieur Jean LeProd',
4
);
insert into Movie (Title, Synopsis, Producer, Category) values (
'96 heures',
'"Carré est le patron de la BRB (Brigade de Répression du Banditisme). 3 
ans plus tôt, il a fait tomber un grand truand, Kancel. Aujourd’hui, à 
la faveur d’une extraction, Kancel kidnappe le flic. Il a 96 heures pour
 lui soutirer une seule information : savoir qui l’a balancé."',
 'Frédéric Schoendoerffer',
 2
);

insert into Emplacement (Name, Adresse, Phone) values ('Vevey','Rue du milieu 1','0211231111');
insert into Emplacement (Name, Adresse, Phone) values ('Lausanne','Route de genève 10','0214562222');
insert into Emplacement (Name, Adresse, Phone) values ('Vevey','Rue du milieu 1','0211231111');

insert into Cinema (Name, Nb_Places, Emplacement) values ('Rex 1',250,1);
insert into Cinema (Name, Nb_Places, Emplacement) values ('Rex 2',250,2);
insert into Cinema (Name, Nb_Places, Emplacement) values ('Rex 3',300,3);
insert into Cinema (Name, Nb_Places, Emplacement) values ('Rex 4',200,1);

insert into Projection (MovieId, CinemaId, DateHeure) values (1,2,'2014-02-13 20:45:00');
insert into Projection (LangVersion, MovieId, CinemaId, DateHeure) values ('VF',2,3,'2014-02-13 20:45:00');

insert into UserTable (UserLogin, UserPassword, FirstName, LastName, IsAdmin) values ('Cinephile1234','1234','George','Baumann',1);
insert into UserTable (UserLogin, UserPassword, FirstName, LastName, IsAdmin) values ('Bob','1234','Dider','Burkhalter',0);
insert into UserTable (UserLogin, UserPassword, FirstName, LastName, IsAdmin) values ('BillyTheKid','1234','Christoph','Burkhalter',0);

insert into Reservation (nbPlaces, Projection,UserId) values (1,1,1);
insert into Reservation (nbPlaces, Projection,UserId) values (2,1,2);
insert into Reservation (nbPlaces, Projection,UserId) values (1,1,3);
insert into Reservation (nbPlaces, Projection,UserId) values (4,2,1);
insert into Reservation (nbPlaces, Projection,UserId) values (1,2,2);
insert into Reservation (nbPlaces, Projection,UserId) values (5,2,3);
