# Interview Task - ASP.NET Core MVC

This project is developed as part of the Software Trainee Technical Assessment using **ASP.NET Core MVC (.NET 8)**.

The application consists of two required tasks and one optional bonus task.

---

# Features

## Task 1 - Authentication

- User Login
- Cookie-Based Authentication
- Protected Secure Page
- Logout Functionality
- Credentials stored in `appsettings.json`

### Sample Credentials

| Username | Password |
|----------|----------|
| admin | 123456 |

---

## Task 2 - Currency Converter

- Convert currency using a public exchange rate API
- Source Currency Selection
- Destination Currency Selection
- Amount Input
- Converted Result Display
- Error Handling
- Service-based API integration using HttpClient

Public API Used:

https://api.frankfurter.app/

---

## Bonus Task

### Google OAuth Login

Implemented Google OAuth 2.0 Authentication.

Features:

- Login with Google
- Redirect to Secure Page
- Display Logged-in User Name
- Display User Email
- Logout Support

---

# Technologies Used

- ASP.NET Core MVC (.NET 8)
- C#
- Razor Views
- Cookie Authentication
- Google OAuth 2.0
- HttpClient
- Bootstrap
- Dependency Injection

---

# Project Structure

```
Interview_task
│
├── Controllers
│     ├── AccountController.cs
│     ├── CurrencyController.cs
│     └── HomeController.cs
│
├── Models
│
├── Services
│     └── CurrencyService.cs
│
├── Views
│
├── wwwroot
│
├── appsettings.json
│
└── Program.cs
```

---

# Project Setup Instructions

## 1. Clone the Repository

```bash
git clone https://github.com/YOUR_USERNAME/Interview_task.git
```

---

## 2. Open the Project

Open the solution using **Visual Studio 2022**.

---

## 3. Restore Packages

Visual Studio restores packages automatically.

Or run:

```bash
dotnet restore
```

---

## 4. Configure Google OAuth

Open

```
appsettings.json
```

Replace:

```json
"GoogleAuth": {
  "ClientId": "YOUR_CLIENT_ID",
  "ClientSecret": "YOUR_CLIENT_SECRET"
}
```

with your own Google OAuth credentials.

---

## 5. Run the Application

Press

```
F5
```

or

```bash
dotnet run
```

---

# Authentication Credentials

Login using:

Username:

```
admin
```

Password:

```
123456
```

Or use

```
Login with Google
```

for OAuth authentication.

---

# Application Screenshots

## Login Page

> Add screenshot here

```
screenshots/login.png
```

---

## Secure Page

> Add screenshot here

```
screenshots/secure.png
```

---

## Currency Converter

> Add screenshot here

```
screenshots/currency.png
```

---

## Google Login

> Add screenshot here

```
screenshots/google-login.png
```

---

# API Information

Public Currency Exchange API

https://api.frankfurter.app/

Example Request

```
https://api.frankfurter.app/latest?amount=100&from=USD&to=BDT
```

---

# Security

- Cookie Authentication
- Protected Routes using `[Authorize]`
- Configuration stored in `appsettings.json`
- Google OAuth 2.0 Authentication

---

# Author
GitHub:

https://github.com/mahinfah

LinkedIn:

https://www.linkedin.com/in/kazi-fahad-mahin/

---
