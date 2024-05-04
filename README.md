# Welcome to the AdventureWorks API Project! 🚀

Hello there! Thank you for checking out our API project, built with .NET 7 and Entity Framework. This project is designed to interact efficiently with the AdventureWorks2022 database and is perfect for handling data related to products, sales, and employees. Whether you're looking to contribute or just explore, we're glad you're here!

## 🛠 Requirements

To get started, make sure you have the following installed:

- .NET 7 SDK
- SQL Server
- Visual Studio or Visual Studio Code

## 🚀 Getting Started

Here’s how you can run the project on your local machine:

1. **Clone the repository:**

   ```bash
   git clone https://github.com/Ezejosue/RSMFinalChallenge.git
   cd RSMFinalChallenge
   ```

2. **Set up the database:**

   - Ensure SQL Server is up and running.
   - Create the `AdventureWorks2022` database.
   - Navigate to the `SQLCTEs` folder and run the SQL scripts to set up the necessary stored procedures.

3. **Install dependencies:**

   ```bash
   dotnet restore
   ```

4. **Build the project:**

   ```bash
   dotnet build
   ```

5. **Launch the project:**
   ```bash
   dotnet run
   ```

## 📁 Folder Structure

Here’s what our project folder structure looks like:

- **Controllers/**: Home to our API controllers that handle requests.
- **Domain/**
  - **Interfaces/**: Defines the interfaces used throughout the application.
  - **Models/**: Contains the entity models.
- **DTOs/**: Data Transfer Objects for handling data operations.
- **Infrastructure/**
  - **Configuration/**: Contains Entity Framework configurations.
  - **Repositories/**: Our data access layer.
  - **DbContext/**: Configuration settings for the database context.
- **Services/**: Contains the business logic of our application.
- **SQLCTEs/**: SQL scripts for initializing stored procedures.

## 🌐 API Usage

Explore our API using Swagger documentation available at:
`https://localhost:7099/swagger` after you run the project.

### Available Endpoints

- **Product Categories:** `GET https://localhost:7099/api/ProductCate`
- **Sales Territories:** `GET https://localhost:7099/api/SalesTerritory`
- **Sales by Employee:** `GET https://localhost:7099/api/SalesByEmployee?startDate=YYYY-MM-DD&endDate=YYYY-MM-DD&employee=NAME&product=PRODUCT&page=N&pageSize=N`
- **Sales Report:** `GET https://localhost:7099/api/SalesReport?categoryFilter=CATEGORY&regionFilter=REGION&StartDate=YYYY-MM-DD&EndDate=YYYY-MM-DD&page=N&pageSize=N`

## 🛠 Technologies and Libraries

We use a variety of technologies and libraries:

- **Entity Framework Core**: Our ORM for SQL Server interactions.
- **Swagger**: For documenting and testing the API.
- **Papa Parse**: Helps in generating CSV files.
- **jsPDF**: For creating PDF files.
- **Axios**: Used as our HTTP client to consume APIs.
- **Bootstrap 5**: For styling and responsive design.

## 🤝 Contributing

We love contributions! If you'd like to help improve the project, please fork the repository and submit a pull request with your changes. Let's make something great together!
