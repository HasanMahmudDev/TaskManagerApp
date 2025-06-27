
# 📋 Task Management System

A simple yet powerful **Task Management System** built with **ASP.NET Core MVC**, following **Clean Architecture**, using **Entity Framework Core** and styled with **Bootstrap 5**.

![UI Preview](https://user-images.githubusercontent.com/your-screenshot.png)

---

## 🏗 Architecture

This project follows **Clean Architecture**:

```
TaskManager.Web (Presentation Layer)
│
├── TaskManager.Application (Service Layer)
│   └── ITaskService, ViewModels, Interfaces
│
├── TaskManager.Domain (Entities Layer)
│   └── TaskItem, TaskPriority Enum, etc.
│
└── TaskManager.Infrastructure (Persistence Layer)
    └── AppDbContext, TaskRepository
```

---

## 🚀 Features

✅ Add, Edit, Delete, View Tasks  
✅ Assign task to users or team  
✅ Set priority & status (Pending, InProgress, Done)  
✅ File upload with each task  
✅ Bootstrap 5 responsive UI  
✅ MSSQL Database  
✅ Clean Code, Repository Pattern  
✅ Easy to extend and maintain  

---

## 🖼 UI Screenshots

| Dashboard | Task Entry |
|-----------|------------|
| ![Dashboard](https://user-images.githubusercontent.com/dashboard.png) | ![TaskEntry](https://user-images.githubusercontent.com/taskentry.png) |

---

## 🧰 Technologies

- ASP.NET Core 8 MVC
- Entity Framework Core
- MS SQL Server
- Bootstrap 5
- Clean Architecture
- Repository Pattern

---

## 🛠 Getting Started

### 1️⃣ Clone the Repo

```bash
git clone https://github.com/your-username/TaskManagementSystem.git
cd TaskManagementSystem
```

### 2️⃣ Setup Database

Create database `TaskManagerDB` manually or use EF Core migration:

```bash
PM> Add-Migration InitialCreate
PM> Update-Database
```

### 3️⃣ Update appsettings.json

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=HASAN\SQL_2019;Database=TaskManagerDB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True"
}
```

### 4️⃣ Run the App

```bash
Ctrl + F5 (from Visual Studio)
```

App will run on: `https://localhost:5001`

---

## 📁 Folder Structure

```
TaskManager.Web           // UI & Controllers
TaskManager.Application   // Business Logic
TaskManager.Infrastructure// Data Access Layer
TaskManager.Domain        // Entity Models
```

---

## 📦 Packages Used

- `Microsoft.EntityFrameworkCore.SqlServer`
- `Microsoft.EntityFrameworkCore.Tools`
- `Microsoft.EntityFrameworkCore.Design`
- `Bootstrap 5 (CDN)`
- `System.ComponentModel.DataAnnotations`

---

## 🤝 Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss.

---

## 📄 License

MIT License © 2025 [Hasan Mahmud](https://github.com/your-profile)

---

## 📬 Contact

📧 Email: hasan@example.com  
🌐 Portfolio: [your-website.com](https://your-website.com)

---

⭐ If you found this project helpful, give it a star on GitHub!
