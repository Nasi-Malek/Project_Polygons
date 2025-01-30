## **Project Description**

This multi-project console application is built using Entity Framework Core with the Code First approach to manage the database. The goal is to create an application that handles several features using the same SQL database.

1. ShapeApp Project  
2. CalculatorApp Project   
3. RSPGameApp Project   
4. ClassLibrary Project   
5.  Project –Polygons  

## **Technologies**

* Visual Studio  
* SQL Database

## **Nuget packages**

* Autofac  
* Spectre.Console  
* Microsoft.EntityFrameworkCore.SqlServerr  
* Microsoft.EntityFrameworkCore.Tools  
* Microsoft.Extensions.Configuration.Design

---

## **Shapes :**

1. ## Calculate area and perimeter for various geometric shapes.

2. ## Supports Rectangle, Parallelogram, Triangle, and Rhombus.

3. ## Save and view calculation history.

4. ## Perform CRUD operations for all shape calculations.

   

## **Calculator :**

1. ## Perform basic mathematical operations (+, \-, \*, /).

2. ## Includes advanced features such as square root (√) and modulus (%).

3. ## View and manage the history of calculations.

4. ## Update or delete existing calculations.

   

## **Rock, Scissors, Paper Game :**

1. ## Play against the computer.

2. ## View detailed game history with statistics.

3. ## Automatically calculates win rates.

4. ## Displays results with color-coded messages for clarity.

---

## **Design Patterns**

In my project, I utilized several design patterns to ensure the code is modular, maintainable, and scalable.

* Factory Pattern: I implemented the Factory Pattern in the ShapeApp to dynamically create geometric objects based on user input. This approach provides flexibility and extensibility, allowing the application to easily accommodate new shapes in the future.  
* Repository Pattern: The Repository Pattern was used to abstract database queries and organize data access. By centralizing data access logic, this pattern makes the code more modular and testable, ensuring that changes to the database structure have minimal impact on the rest of the application.  
* Dependency Injection: I used Autofac for dependency injection to manage dependencies between classes. This pattern improves modularity and testability by allowing classes to be easily swapped out or modified without affecting other parts of the application.  
* SOLID Principles: Throughout the project, I adhered to SOLID principles to ensure that each class has a clear, single responsibility. This approach makes the codebase more maintainable and scalable, as it promotes separation of concerns and reduces the likelihood of introducing bugs when making changes.

---

## **Installation Instructions**

1. ## https://github.com/Nasi-Malek/Project\_Polygons.git

2. ## Open the solution in Visual Studio.

3. ## Restore NuGet packages.

4. ## Update the connection string in appsettings.json to match your SQL Server setup.

5. ## Run the application.

---

## **Lessons Learned and Reflections**

* I learned how to use design patterns like Factory Pattern and Repository Pattern to create flexible and scalable code.  
* Implementing Entity Framework Core and managing databases with the Code First approach gave me deeper insights into database technology.  
* Structuring the project with clear folders and following SOLID principles made the codebase easier to manage and extend.  
* I also gained experience in using Git and branching.  
  