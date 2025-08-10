# **Finora — Personal Finance Tracker**

*Phase 1: Manual Tracking & Basic Insights*

## 📌 Overview

Finora is a personal finance tracking app that helps users manage their income, expenses, budgets, and savings goals. Phase 1 focuses on **manual input** of transactions, goal setting, and basic insights — providing the foundation for future automation and bank integrations.

---

## 🚀 Features (Phase 1)

* **User Authentication**

  * Secure registration and login
  * JWT-based session management
* **Transactions** ✅

  * CRUD for income & expense transactions
  * Soft deletion support
  * Categories & notes
* **Categories & Budgets**

  * Manage spending categories
  * Set monthly category budgets
* **Goal Setting**

  * Create savings goals with target amounts & deadlines
  * Track progress towards goals
* **Dashboard & Insights**

  * Net income calculation
  * Monthly spend overview
  * Total savings
  * Static rule-based financial advice

---

## 🛠 Tech Stack

**Backend:**

* .NET 9
* Entity Framework Core
* MediatR (CQRS)
* PostgreSQL / SQLite (local development)

**Frontend:**

* Vite + React + TypeScript
* ShadCN UI + TailwindCSS
* ts-rest for API communication
* React Hook Form + Zod for form handling

---

## 📂 Project Structure

```
finora/
├── backend/         # .NET 8 API
│   ├── Finora.Application/   # Application logic (CQRS, Handlers)
│   ├── Finora.Domain/        # Entities & domain models
│   ├── Finora.Infrastructure # EF Core, persistence
│   └── Finora.WebApi/        # Controllers & API setup
└── frontend/        # Vite + React app
    ├── src/components/       # UI components
    ├── src/routes/            # Pages & routing
    ├── src/services/          # API clients (ts-rest)
    └── src/styles/            # Global styles
```

---

## 📦 Installation & Setup

### 1️⃣ Clone the repository

```bash
git clone https://github.com/usuu03/finora.git
cd finora
```

### 2️⃣ Backend Setup

```bash
cd backend
dotnet restore
dotnet ef database update
dotnet run --project Finora.WebApi
```

Backend runs by default on: `https://localhost:5001`

### 3️⃣ Frontend Setup

```bash
cd frontend
pnpm install
pnpm dev
```

Frontend runs by default on: `http://localhost:3000`

---

## ✅ Phase 1 Progress

* [x] Backend CRUD for Transactions
* [ ] User Authentication
* [ ] Transactions UI (list, add, edit, delete)
* [ ] Categories & Budgets
* [ ] Goal Setting
* [ ] Dashboard & Insights

---

## 📅 Next Steps (Phase 2 & Beyond)

* **Phase 2:** Bank API integration (TrueLayer, Plaid, etc.)
* **Phase 3:** Financial advice engine (rule-based + ML)
* **Phase 4:** Automation & AI assistant

