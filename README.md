# 📚 System Zarządzania Książkami

Aplikacja webowa stworzona w technologii ASP.NET Core MVC, umożliwiająca zarządzanie książkami, zamówieniami i użytkownikami. Projekt powstał w ramach studiów na kierunku **Programowanie Internetowych Aplikacji Biznesowych**.

## 🔧 Technologie

- ASP.NET Core MVC (.NET 8)
- C#
- Entity Framework Core
- SQL Server (z gotowym skryptem bazy danych)
- Bootstrap 5
- Razor Pages (.cshtml)
- Architektura warstwowa:
  - `AppData` – warstwa dostępu do danych (EF Core)
  - `AppServices` – logika biznesowa
  - `AppInterfaces` – interfejsy i kontrakty
- Git

## 🧩 Struktura projektu

- `KlientApp` – aplikacja dla użytkowników (klientów)
- `PracownikApp` – aplikacja dla pracowników/admina
- `AppData`, `AppServices`, `AppInterfaces` – backend z logiką biznesową i dostępem do danych

## 📌 Główne funkcje

- Przeglądanie książek
- Rejestracja i logowanie
- Składanie zamówień
- Panel pracownika:
  - Dodawanie/edycja/usuwanie książek
  - Zarządzanie użytkownikami
  - Obsługa zamówień i stanów realizacji
- Walidacja danych
- Bezpieczne uwierzytelnianie (Identity, hashowanie haseł)
- Obsługa ról i autoryzacja (użytkownik / pracownik)

## ▶️ Jak uruchomić lokalnie

### 🔹 Wymagania:
- Visual Studio 2022+  
- SQL Server lub SQL Server Express  
- .NET 8 SDK  

### 🔹 Krok po kroku:

1. Sklonuj repozytorium:

```bash
git clone https://github.com/Example7/SystemZarzadzaniaKsiazkami.git
```

2. Otwórz projekt AplikacjaInternetowaKK.sln w Visual Studio.

3. Przywróć bazę danych:

- Wejdź do folderu database/
- Otwórz plik script2.sql w SQL Server Management Studio
- Uruchom skrypt na nowej bazie danych o nazwie (AppContext-2025)

4. Zmień connection string w plikach appsettings.json w KlientApp i PracownikApp, aby wskazywał na Twoją lokalną bazę danych.

5. Ustaw dwa projekty jako startowe:
- KlientApp – działa np. pod http://localhost:5174
- PracownikApp – działa np. pod https://localhost:7222

6. Uruchom aplikację

## 💾 Baza danych

W repozytorium znajduje się gotowy skrypt SQL:

📁 database/script2.sql

Zawiera tabele:
- Książki
- Użytkownicy
- Zamówienia
- SzczegółyZamówień
- Role
- Loginy itd.

## 👨‍💻 Autor
Kacper Kałużny (Example7)
