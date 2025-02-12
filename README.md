# 📚 Bookstore

Welcome to the **Bookstore** application.

---

## 🚀 How to Run the Application

### 📌 1. Prerequisites

Before running the application, make sure you have installed:

- [.NET SDK](https://dotnet.microsoft.com/download)
- PostgreSQL Database (not required if you have a URL for a database running online)

Ensure that you have a `.env` file in the project folder with the following structure:

```sh
# PostgreSQL database connection string
CONNECTION_STRING=Host=localhost;Port=5432;Database=bookstore;Username=postgres;Password=123456

# Secret key used for signing the token
PrivateJwtKey=t2v5y8/A1DfGhJkLmNqRsTuXwVzYb4C9E6HjKpO0QiMnP7Wa
```

Ensure that you have run the migrations before starting the application:

```sh
dotnet ef database update
```

---

### ▶️ 2. Running the Application

Open the terminal and run the following commands:

```sh
# Navigate to the project folder
cd path/to/bookstore

# Restore dependencies
dotnet restore

# Build the project
dotnet build

# Run the application
dotnet run
```

### 🐞 3. Running in Debug Mode

To run the application in debug mode, use:

```sh
dotnet run --configuration Debug
```

### ✅ 4. Documentation

The documentation is available at:

```sh
https://url/scalar
```

### 📜 License

This project is open-source and can be freely modified.

💻 Developed by Lorenzo Marques
