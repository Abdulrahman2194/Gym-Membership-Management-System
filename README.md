# 🏋️ Gym Membership Management System

> **Course:** Database Systems  
> **Grade:** 19 / 20 ✅  
> **Language:** C# (Windows Forms) + SQL Server  
> **Author:** Abdulrahman Baher — ID: 24P0263

---

## 📋 Project Overview

A full-stack database application for managing gym operations, including memberships, trainers, nutrition plans, subscription plans, and member classes. The project was delivered in two phases:

- **Phase 1** — Database design: ERD, normalization, and relational schema
- **Phase 2** — SQL implementation and a C# Windows Forms GUI connected to the database

---

## 🗂️ Project Structure

```
├── bin/Debug/net8.0-windows/   # Compiled application output
├── obj/                        # Build artifacts
│
├── Classes.cs                  # Member/entity class definitions
├── Classes.Designer.cs
├── Classes.resx
│
├── Dashboard.cs                # Main dashboard screen
├── Dashboard.Designer.cs
├── Dashboard.resx
│
├── Members.cs                  # Member management screen
├── Members.Designer.cs
├── Members.resx
│
├── Nutrition.cs                # Nutrition plans screen
├── Nutrition.Designer.cs
├── Nutrition.resx
│
├── PlanForm.cs                 # Subscription plan management
├── PlanForm.Designer.cs
├── PlanForm.resx
│
├── TrainerForm.cs              # Trainer management screen
├── TrainerForm.Designer.cs
├── TrainerForm.resx
│
├── GymGUI.csproj               # Project file
├── GymGUI.sln                  # Solution file
└── Program.cs                  # Application entry point
```

---

## 🗄️ Phase 1 — Database Design

### Entities

| Entity | Description |
|---|---|
| **Member** | Gym subscribers with personal details and membership info |
| **Trainer** | Staff who manage and coach members |
| **Subscription Plan** | Available membership tiers and durations |
| **Class** | Gym classes offered (yoga, cardio, weights, etc.) |
| **Nutrition Plan** | Diet/nutrition programs assigned to members |

### ERD
The Entity-Relationship Diagram covers:
- All entities and their attributes
- Primary and foreign key relationships
- One-to-many and many-to-many relationships (e.g. Members ↔ Classes)

### Normalization
The database was normalized through all three normal forms:

- **1NF** — All attributes are atomic; no repeating groups. Each table has a primary key.
- **2NF** — No partial dependencies; all non-key attributes depend on the full primary key (applied to junction tables).
- **3NF** — No transitive dependencies; attributes depend only on the primary key, not on other non-key attributes.

### Relational Schema
Key tables in the schema:

```
Member       (MemberID, Name, Phone, Email, JoinDate, PlanID)
Trainer      (TrainerID, Name, Specialization, Phone)
Plan         (PlanID, PlanName, DurationMonths, Price)
Class        (ClassID, ClassName, TrainerID, Schedule)
Nutrition    (NutritionID, PlanName, Calories, Description, MemberID)
MemberClass  (MemberID, ClassID)   -- junction table
```

---

## 💻 Phase 2 — SQL & GUI Implementation

### SQL Script Includes
- `CREATE TABLE` statements with all constraints (PK, FK, NOT NULL, UNIQUE)
- `INSERT INTO` sample data for all tables
- `SELECT` queries with `JOIN`, `GROUP BY`, `ORDER BY`
- Stored procedures and functions for common operations
- Constraint definitions to ensure data integrity

### GUI — Windows Forms Application
Built with **C# WinForms (.NET 8)** connected to a **SQL Server** backend.

#### Screens & Features

| Screen | Functionality |
|---|---|
| **Dashboard** | Overview and navigation hub |
| **Members** | Add, view, update, and delete gym members |
| **Trainers** | Manage trainer profiles and specializations |
| **Plans** | Create and manage subscription plans and durations |
| **Nutrition** | Assign and manage nutrition plans per member |
| **Classes** | View and manage available gym classes |

Each screen supports full **CRUD operations** (Create, Read, Update, Delete) connected live to the database.

---

## 🚀 How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/Abdulrahman2194/GymMembershipSystem.git
   ```

2. Set up the database:
   - Open **SQL Server Management Studio (SSMS)**
   - Run the provided SQL script to create tables and insert sample data

3. Configure the connection string:
   - Open `Program.cs` or the relevant config file
   - Update the connection string to match your SQL Server instance:
     ```
     Server=YOUR_SERVER_NAME; Database=GymDB; Trusted_Connection=True;
     ```

4. Open `GymGUI.sln` in **Visual Studio 2022+**

5. Build and run (`Ctrl + F5`)

---

## 🛠️ Technologies Used

- **C#** — Windows Forms GUI (.NET 8)
- **SQL Server** — Database backend
- **Visual Studio** — IDE
- **SSMS** — Database management

---

## 📌 Notes

- Database fully normalized to **3NF**
- All screens are connected live to the SQL Server backend
- Sample data included in the SQL script for testing
