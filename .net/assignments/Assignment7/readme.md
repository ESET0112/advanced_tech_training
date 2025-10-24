Assignment 2 : Repository Pattern in .NET Web API (DB First Approach)

Topic : Online Product Inventory Management System
The database already exists with two tables:
•	Products
•	Categories

Database Structure
Table: Categories
Column Name	Data Type	Constraints
CategoryId	int	Primary Key, Identity
CategoryName	nvarchar(100)	Not Null
Table: Products
Column Name	Data Type	Constraints
ProductId	int	Primary Key, Identity
ProductName	nvarchar(150)	Not Null
Price	decimal(10,2)	Not Null
StockQuantity	int	Not Null
CategoryId	int	Foreign Key → Categories(CategoryId)



Note:
Implement Repository Pattern
🔹 Generic Repository Interface
public interface IGenericRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Add(T entity);
    void Update(T entity);
    void Delete(int id);
    void Save();
}





Do---------------------------------------------------------------------------------------------
1. Create Database "Inventory" in SSMS and Create 2 tables "Categories" and "Products" 
2. In WebApI project Add Install Required NuGet Packages Entity,Tools,SQL
3. Scaffold DbContext and Models from Existing Database
3.1 Scaffold-DbContext "Data Source=LAPTOP-K4RJ04BL;Initial Catalog=demoDb;Integrated Security=True;Trust Server Certificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
(Change the path accordingly)
4. Shift InventoryContext.cs to Data folder
5. Create Repository Folder in Data folder
5.1 Create IinventoryRepository.cs and InventoryRepository.cs
6. Create ProductDTO and CategoryDTO if needed
7. Create InventoryApp under Controller Folder
8. Run