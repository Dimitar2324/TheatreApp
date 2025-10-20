# 🎭 Theatre Management Web Application

> ⚠️ **Status:** This project is currently under active development.  
> Some features are incomplete or in progress — expect updates and improvements in future versions.

A web application project built with **ASP.NET Core**, **Entity Framework Core**, **HTML, CSS and Bootstrap**, designed to help users browse plays, manage favourites, view performances, and purchase tickets — all in one place.

---

## 🚀 Features

### 🎬 Plays Management
- **View all plays**
- **Add new plays**
- **Edit play details**
- **Delete or restore plays**
- **View details about each play**

### ❤️ Favourites
- **Add plays** to your personal favourites list
- **Remove plays** from favourites

### 🎟️ Performances & Tickets
- **View all available performances**
- **Buy tickets** for specific performances
- **View purchased tickets**

### 👥 User Management
- **View all registered users**
- **Assign role to a user**
- **Remove role from a user**
- **Delete user**

---

## 🔐 Roles

The system uses **Role-Based Authorization** to restrict access.

| Role | Description |
|------|-------------|
| **User** | Default role with access to browsing plays, viewing their details, adding and removing favourites, and purchasing tickets |
| **Manager** | Has the same opportunities as the basic User, but can also edit play's information |
| **Admin** | Full access, including Play and User Management |

---

## 🧩 Tech Stack

| Layer | Technology |
|--------|-------------|
| **Backend** | ASP.NET Core 8.0 |
| **Frontend** | HTML, CSS, Bootstrap 5 |
| **Database** | Microsoft SQL Server (MSSQL) |
| **ORM** | Entity Framework Core |
| **Language** | C# |
| **Architecture** | MVC-inspired structure |
