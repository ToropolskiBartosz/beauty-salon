-----    Klienci
create table Klienci(
	ID_Klienta serial primary key,
	Imie varchar(20) not null,
	Nazwisko varchar(30) not null,
	Telefon varchar(12) check (Telefon SIMILAR TO '[0-9]{9,12}'), 
	Email varchar(30),
	Plec varchar(1) check (Plec in('M','K'))	
);
insert into Klienci(Imie,Nazwisko,Telefon,Email,Plec)
values('Anna','Biega','123321219','Anna.B@interia.pl','K');
insert into Klienci(Imie,Nazwisko,Telefon,Email,Plec)
values('Wioletta','Pontus','908789608','Wioletta.P@interia.pl','K');
insert into Klienci(Imie,Nazwisko,Telefon,Email,Plec)
values('Diana','Biała','670923012','Diaba.Biała@wp.pl','K');

------    Gabinet
create table Gabinety(
	ID_Gabinetu serial primary key,
	Wielkosc_m2 smallint,
	Pomieszczenia smallint
);

insert into Gabinety(Wielkosc_m2,Pomieszczenia)
values(7,3);
insert into Gabinety(Wielkosc_m2,Pomieszczenia)
values(10,4);
insert into Gabinety(Wielkosc_m2,Pomieszczenia)
values(5,2);

-----     Pracownicy
create table Pracownicy(
	ID_Pracownika serial primary key,
	Imie varchar(20) not null,
	Nazwisko varchar(30) not null,
	Telefon varchar(12) check (Telefon SIMILAR TO '[0-9]{9,12}') unique,
	Pesel varchar(11) check (Pesel SIMILAR TO '[0-9]{11}')  not null unique,
	Data_zatrudnienia Date Default CURRENT_DATE
);
insert into Pracownicy(Imie,Nazwisko,Telefon,Pesel)
values('Grażyna','Kowalska','123456789','12345678910');
insert into Pracownicy(Imie,Nazwisko,Telefon,Pesel)
values('Jolanta','Prawicka','798142356','42354724610');
insert into Pracownicy(Imie,Nazwisko,Telefon,Pesel)
values('Aneta','Wrubel','678654678','42300024610');

-----   Produkty
create table Produkty(
	ID_Produktu serial primary key,
	Nazwa varchar(20) not null,
	Cena decimal(4,2) not null,
	Producent varchar(20) not null
);
insert into Produkty(Nazwa,Cena,Producent)
values('Lakier',45.75,'Szwarceneger');
insert into Produkty(Nazwa,Cena,Producent)
values('Lakier kolor',51.75,'Szwarceneger');
insert into Produkty(Nazwa,Cena,Producent)
values('Żel pielegnacyjny ',45.75,'Szwarceneger');

-----     Typ_Zabiegu
create table Typ_Zabiegu(
	ID_Zabiegu serial primary key,
	Nazwa varchar(20) not null unique,
	Typ varchar(20) not null,
	CzasTrwania smallint not null,
	Cena decimal(5,2) not null,
	Pracownik int references Pracownicy(ID_Pracownika),
	Gabinety  int references Gabinety(ID_Gabinetu)
);

insert into Typ_Zabiegu(Nazwa,Typ,CzasTrwania,Cena,Pracownik,Gabinety )
values('Pedicure','Zabieg_Paznokcie',30,80.30,1,1);
insert into Typ_Zabiegu(Nazwa,Typ,CzasTrwania,Cena,Pracownik,Gabinety )
values('Renowacja paznokci','Zabieg_Paznokcie',60,130.20,2,1);
insert into Typ_Zabiegu(Nazwa,Typ,CzasTrwania,Cena,Pracownik,Gabinety )
values('Pedicure Złotem','Zabieg_Paznokcie',60,130.20,2,1);
insert into Typ_Zabiegu(Nazwa,Typ,CzasTrwania,Cena,Pracownik,Gabinety )
values('Usuwanie naskórka','Pielegnacja',45,50.20,2,2);

-----       Zabieg
create table Zabiegi(
	ID_Zabiegu serial primary key,
	Klient int references Klienci(ID_Klienta),
	Zabieg int references Typ_Zabiegu(ID_Zabiegu),
	Termin timestamp,	
	Wykonano varchar(3) check (Wykonano in('TAK','NIE')) DEFAULT 'NIE'
);
ALTER TABLE Zabiegi
 ADD CONSTRAINT uq_yourtablename UNIQUE(Zabieg, Termin);

  
insert into Zabiegi(Klient,Zabieg,Termin)
values(1,1,'2020-01-12 14:05');
insert into Zabiegi(Klient,Zabieg,Termin)
values(2,3,'2020-01-12 09:05');
insert into Zabiegi(Klient,Zabieg,Termin)
values(3,2,'2020-01-12 10:05');
insert into Zabiegi(Klient,Zabieg,Termin)
values(3,2,'2020-01-12 11:05');
insert into Zabiegi(Klient,Zabieg,Termin)
values(1,4,'2020-02-22 11:05');

------     Produkty_do_Zabiegu
create table Produkty_do_Zabiegu(
	Produkt int references Produkty(ID_Produktu),
	NazwaZabiegu int references Typ_Zabiegu(ID_Zabiegu)
);
insert into Produkty_do_Zabiegu(Produkt,NazwaZabiegu)
values(1,1);
insert into Produkty_do_Zabiegu(Produkt,NazwaZabiegu)
values(1,2);
insert into Produkty_do_Zabiegu(Produkt,NazwaZabiegu)
values(3,3);