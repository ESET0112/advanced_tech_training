Assignment 1: Repository Pattern in ASP.NET Core Web API for Library Management

Steps: 
1.	Create a Web API Project
Project Name: LibraryManagementAPI
2.	Create Model Classes
In the Models folder, create two classes — Author and Book.
Author Model Structure  AuthorID,Name,Country, ICollection<Book>? Books
Book Model Structure BookId,Title,Genre,AuthorId, Author? Author
3.	Create the Database Context
In the Data folder, create a LibraryDbContext class.
4.	Create the Repository Interfaces
In the Repository folder, create two interfaces:
IAuthorRepository.cs and IBookRepository.cs.
5.	Implement the Repositories
In the same folder, create AuthorRepository.cs and BookRepository.cs.
6.	Register Repositories in Program.cs
7.	Create The Controllers
AuthorsController.cs
BooksController.cs
8.	Add Connection String (appsettings.json)
9.	Run and test 




Do---------------------------------------------------------------------------------------------
1.Create Models folder 
1.1 Created Author.js
1.2 Created Book.js
2.Create Data folder
2.1 Created LibraryDbContext.cs
2.2 Created Config folder
2.2.1 Created AuthorConfig.cs
2.2.2 Created BookConfig.cs
3. In appsettings.json after AllowedHosts put the connection string
3.1 "ConnectionStrings": {
  "ConnectionDB": "Data Source=LAPTOP-OHCI8RBS\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;Trust Server Certificate=True"
}
4. In Program.cs add 
builder.Services.AddDbContext<LibraryDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDB"));
});

5. Run Migration
  Command1: Add-Migration Lib1
  Command2: Update-Database
6. Created Repository folder under Data
6.1 Created ILibraryRepository Interface
6.2 Created LibraryRepository Class with Generics
7.Under Controller folder added LibraryApp class for GET,PUT,POST,etc.
8. Added 
   builder.Services.AddScoped<ILibraryRepository<Author>, LibraryRepository<Author>>();
   builder.Services.AddScoped<ILibraryRepository<Book>, LibraryRepository<Book>>();
   in Program.cs .
9.Run