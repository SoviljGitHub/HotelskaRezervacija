# Aplikacija za evidenciju gostiju u hotelu

Web aplikacija za registraciju gostiju i upravljanje rezervacijama u hotelu.
Sistem omogućava gostima registraciju i rezervaciju soba, dok administrator
ima mogućnost upravljanja sobama i evidencijom gostiju.

## Tehnologije

- C#
- ASP.NET Web Forms
- Microsoft SQL Server
- HTML / CSS
- JavaScript
- XML
- Microsoft Visual Studio 2022
- SQL Server Management Studio

## Funkcionalnosti

- Registracija gostiju
- Prijava gostiju
- Provera punoletstva prilikom registracije
- Rezervacija hotelskih soba
- Automatski obračun cene i popusta
- Provera zauzetosti sobe
- Pregled sopstvenih rezervacija
- Štampanje rezervacije
- Administratorska prijava
- Upravljanje hotelskim sobama
- Pregled registracija gostiju
- Filtriranje registracija
- Brisanje registracija
- Štampanje podataka o gostima
- Parametarska štampa

## Poslovna logika

Aplikacija primenjuje poslovna pravila za:
- Minimalnu starost gosta
- Dozvoljeno trajanje boravka
- Popuste na osnovu dužine boravka
- Obračun ukupne cene
- Proveru zauzetosti sobe

## Arhitektura

Aplikacija koristi višeslojnu arhitekturu koja obuhvata:

- Prezentacioni sloj
- Sloj poslovne logike
- Sloj za pristup podacima
