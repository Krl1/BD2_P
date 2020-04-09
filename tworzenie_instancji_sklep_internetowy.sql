--------------------------------------------------------
--  DROP VIEW 
--------------------------------------------------------

DROP VIEW dostepne_produkty;
DROP VIEW male_produkty;

--------------------------------------------------------
--  DROP TABLE 
--------------------------------------------------------

DROP TABLE IF EXISTS klienci CASCADE;
DROP TABLE IF EXISTS karty_platnicze CASCADE;
DROP TABLE IF EXISTS adresy CASCADE;
DROP TABLE IF EXISTS klienci_adresy CASCADE;
DROP TABLE IF EXISTS zamowienia CASCADE;
DROP TABLE IF EXISTS produkty CASCADE;
DROP TABLE IF EXISTS zamowienia_produkty CASCADE;
DROP TABLE IF EXISTS zdjecia CASCADE;
DROP TABLE IF EXISTS stan_produktow CASCADE;
DROP TABLE IF EXISTS producenci CASCADE;

--------------------------------------------------------
--  CREATE TABLE klienci
--------------------------------------------------------

CREATE TABLE klienci (
    id_klient SERIAL NOT NULL PRIMARY KEY,
    login VARCHAR(20) NOT NULL UNIQUE,
    haslo VARCHAR(30) NOT NULL CHECK (LENGTH(haslo) >= 4),
    email VARCHAR(30) NOT NULL CHECK (LENGTH(haslo) >= 4)
);

--------------------------------------------------------
--  CREATE TABLE karty_platnicze
--------------------------------------------------------

CREATE TABLE karty_platnicze (
    id_karta_platnicza SERIAL NOT NULL PRIMARY KEY,
    id_klient INT,
    nr_karty NUMERIC(16,0) NOT NULL UNIQUE CHECK (nr_karty >= 1000000000000000),
    miesiac NUMERIC(2,0) NOT NULL CHECK (miesiac > 0 AND miesiac <= 12),
    rok NUMERIC(2,0) NOT NULL,
    cvv_kod NUMERIC(3,0) NOT NULL CHECK (cvv_kod >= 100),
    FOREIGN KEY (id_klient) REFERENCES klienci (id_klient)
    	ON DELETE CASCADE
		ON UPDATE CASCADE
);

--------------------------------------------------------
--  CREATE TABLE adresy
--------------------------------------------------------

CREATE TABLE adresy (
    id_adres SERIAL NOT NULL PRIMARY KEY,
	adres VARCHAR(63) NOT NULL,
	miasto VARCHAR(63) NOT NULL,
	wojewodztwo VARCHAR(63) NOT NULL,
	kraj VARCHAR(63) NOT NULL	
);

--------------------------------------------------------
--  CREATE TABLE klienci_adresy
--------------------------------------------------------

CREATE TABLE klienci_adresy (
	id_klient SERIAL REFERENCES klienci(id_klient) NOT NULL, 
	id_adres SERIAL REFERENCES adresy(id_adres) NOT NULL, 
	PRIMARY KEY (id_klient, id_adres)
);

--------------------------------------------------------
--  CREATE TABLE zamowienia
--------------------------------------------------------

CREATE TABLE zamowienia (
    id_zamowienie SERIAL NOT NULL PRIMARY KEY,
    id_klient INT,
	data_zamowienia DATE, 
	data_wysylki DATE CHECK(data_wysylki >= data_platnosci), 
	status_wysylki VARCHAR(50), 
	data_platnosci DATE CHECK(data_platnosci >= data_zamowienia), 
	kwota NUMERIC(10, 2)  CHECK(kwota >= 0.00) DEFAULT(0.00), 
	status_platnosci VARCHAR(50),
	FOREIGN KEY (id_klient) REFERENCES klienci (id_klient)
    	ON DELETE SET NULL
		ON UPDATE CASCADE
);

--------------------------------------------------------
--  CREATE TABLE producenci
--------------------------------------------------------

CREATE TABLE producenci (
	id_producent SERIAL NOT NULL, 
	nazwa VARCHAR(20) NOT NULL, 
	strona_producenta VARCHAR(50), 
	PRIMARY KEY (id_producent)
);

--------------------------------------------------------
--  CREATE TABLE produkty
--------------------------------------------------------

CREATE TABLE produkty (
	id_produkt SERIAL NOT NULL PRIMARY KEY, 
	id_producent INT, 
	kategoria VARCHAR(20) NOT NULL, 
	nazwa VARCHAR(50), 
	rozmiar VARCHAR(8) CHECK(rozmiar IN ('duzy', 'sredni', 'maly', 'duza', 'srednia', 'mala', 'duze', 'srednie', 'male')) NOT NULL, 
	ilosc_na_stanie INT NOT NULL,
	cena NUMERIC(10, 2) CHECK(cena >= 0.00),
	ocena NUMERIC(2, 1) CHECK(ocena >= 0.0 AND ocena <= 6.0) DEFAULT(0.0),
	FOREIGN KEY (id_producent) REFERENCES producenci(id_producent)
		ON DELETE SET NULL
		ON UPDATE CASCADE
);

--------------------------------------------------------
--  CREATE TABLE zamowienia_produkty
--------------------------------------------------------

CREATE TABLE zamowienia_produkty (
	id_zamowienie SERIAL REFERENCES zamowienia(id_zamowienie) NOT NULL, 
	id_produkt SERIAL NOT NULL, 
	ilosc INT CHECK(ilosc > 0) NOT NULL, 
	PRIMARY KEY (id_zamowienie, id_produkt),
	FOREIGN KEY (id_produkt) REFERENCES produkty(id_produkt)
		ON DELETE RESTRICT
		ON UPDATE CASCADE
);

--------------------------------------------------------
--  CREATE TABLE zdjecia
--------------------------------------------------------

CREATE TABLE zdjecia (
	id_zdjecie SERIAL NOT NULL PRIMARY KEY, 
	id_produkt INT, 
	nazwa varchar(50), 
	data_dodania DATE,
	FOREIGN KEY (id_produkt) REFERENCES produkty(id_produkt)
		ON DELETE SET NULL
		ON UPDATE CASCADE
);

--------------------------------------------------------
--  INSERT INTO klienci
--------------------------------------------------------

INSERT INTO klienci (login, haslo, email) VALUES ('krzysztof', 'krzysztof_123', 'krzysztof@123.com');
INSERT INTO klienci (login, haslo, email) VALUES ('piotr', 'piotr_123', 'piotr@123.com');
INSERT INTO klienci (login, haslo, email) VALUES ('ewa', 'ewa_123', 'ewa@123.com');
INSERT INTO klienci (login, haslo, email) VALUES ('ada', 'ada_123', 'ada@123.org');
INSERT INTO klienci (login, haslo, email) VALUES ('anna', 'anna_123', 'anna@123.com');
INSERT INTO klienci (login, haslo, email) VALUES ('jadwiga', 'jadwiga_321', 'jadwiga@321.com');
INSERT INTO klienci (login, haslo, email) VALUES ('natalia', 'natalia_321', 'natalia@321.com');
INSERT INTO klienci (login, haslo, email) VALUES ('jakub', 'jakub_321', 'jakub@321.org');
INSERT INTO klienci (login, haslo, email) VALUES ('karol', 'karol_321', 'karol@321.pl');
INSERT INTO klienci (login, haslo, email) VALUES ('wiktor', 'wiktor_321', 'wiktor@321.com');

--------------------------------------------------------
--  INSERT INTO karty_platnicze
--------------------------------------------------------

INSERT INTO karty_platnicze (id_klient, nr_karty, miesiac, rok, cvv_kod) VALUES (1, 1111222233334444, 02, 21, 123);
INSERT INTO karty_platnicze (id_klient, nr_karty, miesiac, rok, cvv_kod) VALUES (1, 2222333344445555, 10, 22, 234);
INSERT INTO karty_platnicze (id_klient, nr_karty, miesiac, rok, cvv_kod) VALUES (3, 3333444411112222, 04, 20, 132);
INSERT INTO karty_platnicze (id_klient, nr_karty, miesiac, rok, cvv_kod) VALUES (4, 4444111122223333, 02, 23, 654);
INSERT INTO karty_platnicze (id_klient, nr_karty, miesiac, rok, cvv_kod) VALUES (5, 2233111122334444, 07, 24, 523);
INSERT INTO karty_platnicze (id_klient, nr_karty, miesiac, rok, cvv_kod) VALUES (5, 3333222233334444, 02, 21, 123);
INSERT INTO karty_platnicze (id_klient, nr_karty, miesiac, rok, cvv_kod) VALUES (5, 4444333344445555, 10, 22, 234);
INSERT INTO karty_platnicze (id_klient, nr_karty, miesiac, rok, cvv_kod) VALUES (8, 3333444411114444, 04, 23, 132);
INSERT INTO karty_platnicze (id_klient, nr_karty, miesiac, rok, cvv_kod) VALUES (9, 2222111122223333, 02, 23, 525);
INSERT INTO karty_platnicze (id_klient, nr_karty, miesiac, rok, cvv_kod) VALUES (10, 2233111122331111, 07, 24, 523);

--------------------------------------------------------
--  INSERT INTO adresy
--------------------------------------------------------

INSERT INTO adresy (adres, miasto, wojewodztwo, kraj) VALUES ('Nowowiejska 2', 'Wroclaw', 'dolnoslaskie', 'Polska');
INSERT INTO adresy (adres, miasto, wojewodztwo, kraj) VALUES ('Niedzwiedzia 12', 'Wroclaw', 'dolnoslaskie', 'Polska');
INSERT INTO adresy (adres, miasto, wojewodztwo, kraj) VALUES ('Swietego Mikolaja 42', 'Wroclaw', 'dolnoslaskie', 'Polska');
INSERT INTO adresy (adres, miasto, wojewodztwo, kraj) VALUES ('Helleny Madrej 11', 'Poznan', 'wielkopolskie', 'Polska');
INSERT INTO adresy (adres, miasto, wojewodztwo, kraj) VALUES ('Upadla 232', 'Wroclaw', 'dolnoslaskie', 'Polska');
INSERT INTO adresy (adres, miasto, wojewodztwo, kraj) VALUES ('Nowa 131', 'Wroclaw', 'dolnoslaskie', 'Polska');
INSERT INTO adresy (adres, miasto, wojewodztwo, kraj) VALUES ('Niedzwiedzia 12', 'Wroclaw', 'dolnoslaskie', 'Polska');
INSERT INTO adresy (adres, miasto, wojewodztwo, kraj) VALUES ('Stara 42', 'Wroclaw', 'dolnoslaskie', 'Polska');
INSERT INTO adresy (adres, miasto, wojewodztwo, kraj) VALUES ('Helleny Madrej 43', 'Poznan', 'wielkopolskie', 'Polska');
INSERT INTO adresy (adres, miasto, wojewodztwo, kraj) VALUES ('Upadla 131', 'Wroclaw', 'dolnoslaskie', 'Polska');
INSERT INTO adresy (adres, miasto, wojewodztwo, kraj) VALUES ('Upadla 111', 'Wroclaw', 'dolnoslaskie', 'Polska');

--------------------------------------------------------
--  INSERT INTO klienci_adresy
--------------------------------------------------------

INSERT INTO klienci_adresy (id_klient, id_adres) VALUES (1,1);
INSERT INTO klienci_adresy (id_klient, id_adres) VALUES (2,2);
INSERT INTO klienci_adresy (id_klient, id_adres) VALUES (3,2);
INSERT INTO klienci_adresy (id_klient, id_adres) VALUES (4,4);
INSERT INTO klienci_adresy (id_klient, id_adres) VALUES (5,4);
INSERT INTO klienci_adresy (id_klient, id_adres) VALUES (5,6);
INSERT INTO klienci_adresy (id_klient, id_adres) VALUES (7,7);
INSERT INTO klienci_adresy (id_klient, id_adres) VALUES (8,7);
INSERT INTO klienci_adresy (id_klient, id_adres) VALUES (9,7);
INSERT INTO klienci_adresy (id_klient, id_adres) VALUES (10,9);

--------------------------------------------------------
--  INSERT INTO zamowienia
--------------------------------------------------------

INSERT INTO zamowienia (id_klient, data_zamowienia, data_platnosci, data_wysylki, status_wysylki, kwota, status_platnosci) VALUES (1, '2018-02-23', '2018-02-23', NULL, 'pakowanie', 59.99, 'oplacona');
INSERT INTO zamowienia (id_klient, data_zamowienia, data_platnosci, data_wysylki, status_wysylki, kwota, status_platnosci) VALUES (2, '2018-02-25', '2018-02-25', '2018-02-26', 'wyslana', 99.98, 'oplacona');
INSERT INTO zamowienia (id_klient, data_zamowienia, data_platnosci, data_wysylki, status_wysylki, kwota, status_platnosci) VALUES (2, '2018-02-26', '2018-02-26', '2018-02-27', 'wyslana', 49.99, 'oplacona');
INSERT INTO zamowienia (id_klient, data_zamowienia, data_platnosci, data_wysylki, status_wysylki, kwota, status_platnosci) VALUES (3, '2018-04-26', '2018-04-27', '2018-04-30', 'wyslana', 115.99, 'oplacona');
INSERT INTO zamowienia (id_klient, data_zamowienia, data_platnosci, data_wysylki, status_wysylki, kwota, status_platnosci) VALUES (3, '2018-05-26', '2018-05-27', '2018-05-30', 'wyslana', 115.99, 'oplacona');
INSERT INTO zamowienia (id_klient, data_zamowienia, data_platnosci, data_wysylki, status_wysylki, kwota, status_platnosci) VALUES (6, '2018-06-11', '2018-06-11', '2018-06-14', 'wyslana', 10.00, 'oplacona');
INSERT INTO zamowienia (id_klient, data_zamowienia, data_platnosci, data_wysylki, status_wysylki, kwota, status_platnosci) VALUES (7, '2018-08-01', '2018-08-01', '2018-08-05', 'pakowanie', 10.00, 'oplacona');
INSERT INTO zamowienia (id_klient, data_zamowienia, data_platnosci, data_wysylki, status_wysylki, kwota, status_platnosci) VALUES (7, '2018-09-01', '2018-09-01', '2018-09-05', 'pakowanie', 50.00, 'oplacona');
INSERT INTO zamowienia (id_klient, data_zamowienia, data_platnosci, status_wysylki, kwota, status_platnosci) VALUES (9, '2018-11-21', '2018-11-21', 'oczekiwanie na zatwierdzenie', 75.00, 'oplacona');
INSERT INTO zamowienia (id_klient, data_zamowienia, data_platnosci, data_wysylki, status_wysylki, kwota, status_platnosci) VALUES (10, '2019-01-17', NULL, NULL, 'oczekiwanie na zatwierdzenie', 75.00, 'oczekiwanie na wplate');

--------------------------------------------------------
--  INSERT INTO producenci
--------------------------------------------------------

INSERT INTO producenci (nazwa, strona_producenta) VALUES ('Fatz','fatz.com');
INSERT INTO producenci (nazwa, strona_producenta) VALUES ('Skyba','skyba.com');
INSERT INTO producenci (nazwa, strona_producenta) VALUES ('Eire','eire.com');
INSERT INTO producenci (nazwa, strona_producenta) VALUES ('Tavu','tavu.com');
INSERT INTO producenci (nazwa, strona_producenta) VALUES ('Skima','skima.com');
INSERT INTO producenci (nazwa, strona_producenta) VALUES ('Miboo','miboo.com');
INSERT INTO producenci (nazwa, strona_producenta) VALUES ('Meembee','meembee.com');
INSERT INTO producenci (nazwa, strona_producenta) VALUES ('Kazu','kazu.com');
INSERT INTO producenci (nazwa, strona_producenta) VALUES ('Lazzy','lazzy.com');
INSERT INTO producenci (nazwa, strona_producenta) VALUES ('Skinix','skinix.com');

--------------------------------------------------------
--  INSERT INTO produkty
--------------------------------------------------------
INSERT INTO produkty (id_producent, kategoria, nazwa, rozmiar, ilosc_na_stanie, cena) VALUES (1, 'Przewody', 'Ethernet', 'duzy', 31, 1.99);
INSERT INTO produkty (id_producent, kategoria, nazwa, rozmiar, ilosc_na_stanie, cena, ocena) VALUES (1, 'Przewody', 'HDMI', 'maly', 44, 0.99, 4.4);
INSERT INTO produkty (id_producent, kategoria, nazwa, rozmiar, ilosc_na_stanie, cena, ocena) VALUES (1, 'Przewody', 'USB', 'sredni', 40, 4.99, 4.8);
INSERT INTO produkty (id_producent, kategoria, nazwa, rozmiar, ilosc_na_stanie, cena, ocena) VALUES (1, 'Diody', 'LED', 'srednia', 4, 3.49, 2.7);
INSERT INTO produkty (id_producent, kategoria, nazwa, rozmiar, ilosc_na_stanie, cena, ocena) VALUES (2, 'Czujniki', 'Nacisku', 'duzy', 32, 3.99, 3.2);
INSERT INTO produkty (id_producent, kategoria, nazwa, rozmiar, ilosc_na_stanie, cena) VALUES (2, 'Czujniki', 'Prądu', 'duzy', 10, 1.99);
INSERT INTO produkty (id_producent, kategoria, nazwa, rozmiar, ilosc_na_stanie, cena) VALUES (2, 'Czujniki', 'Magnetyczne', 'maly', 0, 19.99);
INSERT INTO produkty (id_producent, kategoria, nazwa, rozmiar, ilosc_na_stanie, cena, ocena) VALUES (4, 'Mikrokontrolery', 'AVR', 'maly', 10, 79.99, 5.9);
INSERT INTO produkty (id_producent, kategoria, nazwa, rozmiar, ilosc_na_stanie, cena, ocena) VALUES (4, 'Glosniki', 'Komputerowy', 'maly', 10, 79.99, 5.3);
INSERT INTO produkty (id_producent, kategoria, nazwa, rozmiar, ilosc_na_stanie, cena) VALUES (4, 'Glosniki', 'Bluetooth', 'srednia', 5, 99.99);

--------------------------------------------------------
--  INSERT INTO zdjecia
--------------------------------------------------------

INSERT INTO zdjecia (id_produkt, nazwa, data_dodania) VALUES (1, 'Ehternet', '2018-01-31');
INSERT INTO zdjecia (id_produkt, nazwa, data_dodania) VALUES (1, 'HDMI w naturalnym srodowisku', '2018-02-01');
INSERT INTO zdjecia (id_produkt, nazwa, data_dodania) VALUES (2, 'Dioda LED zgaszona', '2018-01-31');
INSERT INTO zdjecia (id_produkt, nazwa, data_dodania) VALUES (2, 'Dioda LED zapalona', '2018-02-01');
INSERT INTO zdjecia (id_produkt, nazwa, data_dodania) VALUES (3, 'Czujnik nacisku', '2018-01-31');
INSERT INTO zdjecia (id_produkt, nazwa, data_dodania) VALUES (3, 'Głośnik Sony', '2018-02-01');
INSERT INTO zdjecia (id_produkt, nazwa, data_dodania) VALUES (4, 'Głośnik LG', '2018-01-31');
INSERT INTO zdjecia (id_produkt, nazwa, data_dodania) VALUES (4, 'USB białe', '2018-02-01');
INSERT INTO zdjecia (id_produkt, nazwa, data_dodania) VALUES (10, 'USB czarne', '2018-06-03');
INSERT INTO zdjecia (id_produkt, nazwa, data_dodania) VALUES (10, 'USB szare', '2018-06-13');

--------------------------------------------------------
--  INSERT INTO stan_produktow
--------------------------------------------------------

INSERT INTO stan_produktow (id_produkt, rozmiar, ilosc_na_stanie, cena) VALUES (1, 'duzy', 31, 1.99);
INSERT INTO stan_produktow (id_produkt, rozmiar, ilosc_na_stanie, cena) VALUES (1, 'maly', 44, 0.99);
INSERT INTO stan_produktow (id_produkt, rozmiar, ilosc_na_stanie, cena) VALUES (2, 'srednia', 40, 4.99);
INSERT INTO stan_produktow (id_produkt, rozmiar, ilosc_na_stanie, cena) VALUES (3, 'sredni', 4, 3.49);
INSERT INTO stan_produktow (id_produkt, rozmiar, ilosc_na_stanie, cena) VALUES (4, 'duze', 32, 3.99);
INSERT INTO stan_produktow (id_produkt, rozmiar, ilosc_na_stanie, cena) VALUES (5, 'duza', 10, 19.99);
INSERT INTO stan_produktow (id_produkt, rozmiar, ilosc_na_stanie, cena) VALUES (5, 'mala', 0, 19.99);
INSERT INTO stan_produktow (id_produkt, rozmiar, ilosc_na_stanie, cena) VALUES (6, 'male', 10, 79.99);
INSERT INTO stan_produktow (id_produkt, rozmiar, ilosc_na_stanie, cena) VALUES (6, 'maly', 10, 79.99);
INSERT INTO stan_produktow (id_produkt, rozmiar, ilosc_na_stanie, cena) VALUES (7, 'srednia', 5, 99.99);
INSERT INTO stan_produktow (id_produkt, rozmiar, ilosc_na_stanie, cena) VALUES (8, 'srednie', 100, 2.99);
INSERT INTO stan_produktow (id_produkt, rozmiar, ilosc_na_stanie, cena) VALUES (9, 'duzy', 75, 5.99);
INSERT INTO stan_produktow (id_produkt, rozmiar, ilosc_na_stanie, cena) VALUES (10, 'duza', 200, 1.99);


--------------------------------------------------------
--  INSERT INTO zamowienia_produkty
--------------------------------------------------------


INSERT INTO zamowienia_produkty (id_zamowienie, id_produkt, ilosc) VALUES (1, 1, 2);
INSERT INTO zamowienia_produkty (id_zamowienie, id_produkt, ilosc) VALUES (1, 2, 3);
INSERT INTO zamowienia_produkty (id_zamowienie, id_produkt, ilosc) VALUES (1, 3, 1);
INSERT INTO zamowienia_produkty (id_zamowienie, id_produkt, ilosc) VALUES (1, 10, 6);
INSERT INTO zamowienia_produkty (id_zamowienie, id_produkt, ilosc) VALUES (2, 6, 2);
INSERT INTO zamowienia_produkty (id_zamowienie, id_produkt, ilosc) VALUES (2, 7, 1);
INSERT INTO zamowienia_produkty (id_zamowienie, id_produkt, ilosc) VALUES (2, 5, 3);
INSERT INTO zamowienia_produkty (id_zamowienie, id_produkt, ilosc) VALUES (3, 8, 10);
INSERT INTO zamowienia_produkty (id_zamowienie, id_produkt, ilosc) VALUES (3, 9, 2);
INSERT INTO zamowienia_produkty (id_zamowienie, id_produkt, ilosc) VALUES (4, 4, 4);

--------------------------------------------------------
--  CREATE VIEW ... AS
--------------------------------------------------------

CREATE VIEW dostepne_produkty AS
SELECT p.kategoria, p.nazwa, p.ocena, s.rozmiar, s.ilosc_na_stanie, s.cena FROM produkty p JOIN stan_produktow s USING (id_produkt) WHERE s.ilosc_na_stanie >0;

CREATE VIEW male_produkty AS
SELECT p.kategoria, p.nazwa, p.ocena, s.rozmiar, s.ilosc_na_stanie, s.cena FROM produkty p JOIN (SELECT * FROM stan_produktow WHERE rozmiar LIKE 'ma%') s USING (id_produkt);

SELECT *
FROM klienci k
JOIN (
	SELECT * 
	FROM adresy a
	JOIN klienci_adresy ka USING (id_adres)
) AS dodana
USING (id_klient)
WHERE miasto LIKE 'Wroclaw';
