using LINQ;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;

//Employee Data
var employees = new List<Employee>
            {
                new Employee{ Id=1, Name="Ravi", Department="IT", Salary=85000, Experience=5, Location="Bangalore"},
                new Employee{ Id=2, Name="Priya", Department="HR", Salary=52000, Experience=4, Location="Pune"},
                new Employee{ Id=3, Name="Kiran", Department="Finance", Salary=73000, Experience=6, Location="Hyderabad"},
                new Employee{ Id=4, Name="Asha", Department="IT", Salary=95000, Experience=8, Location="Bangalore"},
                new Employee{ Id=5, Name="Vijay", Department="Marketing", Salary=68000, Experience=5, Location="Mumbai"},
                new Employee{ Id=6, Name="Deepa", Department="HR", Salary=61000, Experience=7, Location="Delhi"},
                new Employee{ Id=7, Name="Arjun", Department="Finance", Salary=82000, Experience=9, Location="Bangalore"},
                new Employee{ Id=8, Name="Sneha", Department="IT", Salary=78000, Experience=4, Location="Pune"},
                new Employee{ Id=9, Name="Rohit", Department="Marketing", Salary=90000, Experience=10, Location="Delhi"},
                new Employee{ Id=10, Name="Meena", Department="Finance", Salary=66000, Experience=3, Location="Mumbai"}
            };

//Product Data

var products = new List<Product>
            {
                new Product{ Id=1, Name="Laptop", Category="Electronics", Price=75000, Stock=15 },
                new Product{ Id=2, Name="Smartphone", Category="Electronics", Price=55000, Stock=25 },
                new Product{ Id=3, Name="Tablet", Category="Electronics", Price=30000, Stock=10 },
                new Product{ Id=4, Name="Headphones", Category="Accessories", Price=2000, Stock=100 },
                new Product{ Id=5, Name="Shirt", Category="Fashion", Price=1500, Stock=50 },
                new Product{ Id=6, Name="Jeans", Category="Fashion", Price=2200, Stock=30 },
                new Product{ Id=7, Name="Shoes", Category="Fashion", Price=3500, Stock=20 },
                new Product{ Id=8, Name="Refrigerator", Category="Appliances", Price=45000, Stock=8 },
                new Product{ Id=9, Name="Washing Machine", Category="Appliances", Price=38000, Stock=6 },
                new Product{ Id=10, Name="Microwave", Category="Appliances", Price=12000, Stock=12 }
            };

//Student Data

var students = new List<Student>
            {
                new Student{ Id=1, Name="Asha", Course="C#", Marks=92, City="Bangalore"},
                new Student{ Id=2, Name="Ravi", Course="Java", Marks=85, City="Pune"},
                new Student{ Id=3, Name="Sneha", Course="Python", Marks=78, City="Hyderabad"},
                new Student{ Id=4, Name="Kiran", Course="C#", Marks=88, City="Delhi"},
                new Student{ Id=5, Name="Meena", Course="Python", Marks=95, City="Bangalore"},
                new Student{ Id=6, Name="Vijay", Course="C#", Marks=82, City="Chennai"},
                new Student{ Id=7, Name="Deepa", Course="Java", Marks=91, City="Mumbai"},
                new Student{ Id=8, Name="Arjun", Course="Python", Marks=89, City="Hyderabad"},
                new Student{ Id=9, Name="Priya", Course="C#", Marks=97, City="Pune"},
                new Student{ Id=10, Name="Rohit", Course="Java", Marks=74, City="Delhi"}
            };

//Order Data

var orders = new List<Order>
            {
                new Order{ OrderId=1001, CustomerId=1, Amount=2500, OrderDate=new DateTime(2025,5,12)},
                new Order{ OrderId=1002, CustomerId=2, Amount=1800, OrderDate=new DateTime(2025,5,13)},
                new Order{ OrderId=1003, CustomerId=1, Amount=4500, OrderDate=new DateTime(2025,5,20)},
                new Order{ OrderId=1004, CustomerId=3, Amount=6700, OrderDate=new DateTime(2025,6,01)},
                new Order{ OrderId=1005, CustomerId=4, Amount=2500, OrderDate=new DateTime(2025,6,02)},
                new Order{ OrderId=1006, CustomerId=2, Amount=5600, OrderDate=new DateTime(2025,6,10)},
                new Order{ OrderId=1007, CustomerId=5, Amount=3100, OrderDate=new DateTime(2025,6,12)},
                new Order{ OrderId=1008, CustomerId=3, Amount=7100, OrderDate=new DateTime(2025,7,01)},
                new Order{ OrderId=1009, CustomerId=4, Amount=4200, OrderDate=new DateTime(2025,7,05)},
                new Order{ OrderId=1010, CustomerId=5, Amount=2900, OrderDate=new DateTime(2025,7,10)}
            };




////Employee Tasks 
Console.WriteLine("1.Display all employees working in the IT department.");

var emp = employees.Where(n => n.Department == "IT");

foreach (var value in emp)
{
    Console.WriteLine(value.Name);
}



Console.WriteLine("2.List names and salaries of employees who earn more than 70,000.");
var emp1 = employees.Where(n => n.Salary > 70000);

foreach (var value in emp1)
{
    Console.WriteLine($"{value.Name} : {value.Salary}" );
}


Console.WriteLine("3.Find all employees located in Bangalore.");
var emp3 = employees.Where(n => n.Location == "Bangalore");

foreach (var value in emp3)
{
    Console.WriteLine($"{value.Name}");
}

Console.WriteLine("4.Display employees having more than 5 years of experience.");

var emp4 = employees.Where(n => n.Experience >5);

foreach (var value in emp4)
{
    Console.WriteLine($"{value.Name}");
}

Console.WriteLine("5.Show names of employees and their salaries in ascending order of salary.");
var emp5 = employees.OrderBy(n => n.Salary);

foreach (var value in emp5)
{
    Console.WriteLine($"{value.Name} : {value.Salary}");
}

Console.WriteLine("6.Group employees by location and count how many employees are in each location.");
var emp6 = employees.GroupBy(n => n.Location)
                    .Select(g => new
                    {
                        Location = g.Key,
                        Count = g.Count()
                    });

foreach (var value in emp6)
{
    Console.WriteLine($"{value.Location} : {value.Count}");
}

Console.WriteLine("7.Display employees whose salary is above the average salary.");

var avgSalary = employees.Average(n => n.Salary);
var emp7 = employees.Where(n => n.Salary>avgSalary);

foreach (var value in emp7)
{
    Console.WriteLine($"{value.Name}");
}


Console.WriteLine("8.Show top 3 highest-paid employees.");
var emp8 = employees.OrderByDescending(n => n.Salary)
                        .Take(3);
foreach (var value in emp8)
{
    Console.WriteLine($"{value.Name}: {value.Salary}");
}



Console.WriteLine("-------------------------------------------------------");


////Product Tasks
Console.WriteLine("1. Display all products with stock less than 20.");
var product1 = products.Where(n => n.Stock < 20);

foreach (var value in product1)
{
    Console.WriteLine($"{value.Name} : {value.Stock}");
}


Console.WriteLine("2. Show all products belonging to the 'Fashion' category.");

var product2 = products.Where(n => n.Category =="Fashion");

foreach (var value in product2)
{
    Console.WriteLine($"{value.Name} : {value.Category}");
}

Console.WriteLine("3. Display product names and prices where price is greater than 10,000.");

var product3 = products.Where(n => n.Price > 10000);

foreach (var value in product3)
{
    Console.WriteLine($"{value.Name} : {value.Price}");
}

Console.WriteLine("4. List all product names sorted by price (descending).");

var product4 = products.OrderByDescending(n => n.Price);

foreach (var value in product4)
{
    Console.WriteLine($"{value.Name} : {value.Price}");
}

Console.WriteLine("5. Find the most expensive product in each category.");

var product5 = products.GroupBy(n => n.Category)
                            .Select(g => new
                            {
                                Category = g.Key,
                                MostExpensive = g.OrderByDescending(p=>p.Price).First()
                            });

foreach (var value in product5)
{
    Console.WriteLine($"{value.Category}:{value.MostExpensive.Name} : {value.MostExpensive.Price}");
}


Console.WriteLine("6. Show total stock per category.");

var product6 = products.GroupBy(n => n.Category)
                            .Select(g => new
                            {
                                Category = g.Key,
                                Total = g.Sum(p => p.Stock)
                            });

foreach (var value in product6)
{
    Console.WriteLine($"{value.Category} : {value.Total}");
}

Console.WriteLine("7. Display products whose name starts with 'S'.");


var product7 = products.Where(n => n.Name.StartsWith("S"));

foreach (var value in product7)
{
    Console.WriteLine($"{value.Name}");
}

Console.WriteLine("8. Show average price of products in each category.");

var product8 = products.GroupBy(n => n.Category)
                            .Select(g => new
                            {
                                Category = g.Key,
                                Avg = g.Average(p => p.Stock)
                            });

foreach (var value in product8)
{
    Console.WriteLine($"{value.Category} : {value.Avg}");
}


Console.WriteLine("-------------------------------------------------------");


////Student Tasks
Console.WriteLine("1. Find the highest scorer in each course.");
var student1 = students.GroupBy(n => n.Course)
                       .Select(g => new
                       {
                           Course = g.Key,
                           HighestScorer = g.OrderByDescending(p => p.Marks).First()
                       });
foreach (var value in student1)
{
    Console.WriteLine($"{ value.Course}->{value.HighestScorer.Name}");
}


Console.WriteLine("2. Display average marks of all students city-wise.");

var student2 = students.GroupBy(n => n.City)
                            .Select(g => new
                            {
                                City = g.Key,
                                Avg = g.Average(p => p.Marks)
                            });

foreach (var value in student2)
{
    Console.WriteLine($"{value.City} : {value.Avg}");
}

Console.WriteLine("3. Display names and marks of students ranked by marks.");

var student3 = students.OrderByDescending(n => n.Marks);

foreach (var value in student3)
{
    Console.WriteLine($"{value.Name} : {value.Marks}");
}



Console.WriteLine("-------------------------------------------------------");

////Order Tasks
Console.WriteLine("1. Find total order amount per month.");
var order1 = orders.GroupBy(n => n.OrderDate.Month)
                   .Select(g => new
                   {
                       Month = g.Key,
                       TotalAmount = g.Sum(p => p.Amount)

                    });
foreach (var item in order1)
{
    Console.WriteLine($"Month {item.Month}: {item.TotalAmount}");
}



Console.WriteLine("2. Show the customer who spent the most in total.");


var order2 = orders.GroupBy(n => n.CustomerId)
                   .Select(g => new
                   {
                       Id = g.Key,
                       TotalAmount = g.Sum(p => p.Amount)

                   })
                   .OrderByDescending(x => x.TotalAmount)
                   .First();

Console.WriteLine($"Customer Id {order2.Id}: {order2.TotalAmount}");


Console.WriteLine("3. Display orders grouped by customer and show total amount spent.");
var order3 = orders.GroupBy(n => n.CustomerId)
                   .Select(g => new
                   {
                       Id = g.Key,
                       TotalAmount = g.Sum(p => p.Amount)

                   });
                   
foreach (var items in order3)
{
   Console.WriteLine($"Customer Id {items.Id}: Total Amount {items.TotalAmount}");
}

Console.WriteLine("4. Display the top 2 orders with the highest amount.");

var order4 = orders.OrderByDescending(n => n.Amount)
                   .Take(2);

foreach (var items in order4)
{
    Console.WriteLine($"Customer Id {items.CustomerId}: Amount {items.Amount}");
}
