## Before we start
1. https://docs.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/tutorials/


## Assignments
1. **Loops:** Print following patterns in console

     ```
     #
     ##
     ###
     ####
     #####
     ```
     ```
     1
     12
     123
     1234
     12345
     123456
     ```
     ```
          #
         ###
        #####
       #######
      #########
      ```
1. **Methods**
     * Write a C# method that accepts 3 numbers and return maximum of all three.
     * Write a C# method that accepts 3 floating point numbers and returns product of all. Users should have flexibility of not to supply third parameter.
     * Write a C# method to that accepts user first-name and last-name and returns initials. E.g. "Bihsnu Rawal" returns "BR".
1. **Inheritance**
     * Think of a real world example where you can write:
          1. One base class having
               * one field
               * two methods
               * two properties
          2. Create derived class inherited from base class above.
               * Add one readonly property in it
               * Add one static method
          3. Create one interface with
               * Add two methods in it
               * Derived class on 2 should implement this interface
1. **LINQ**
     * In-memory collection we have:
     `List<float> bills = new() { 23.5f, 56.2f, 45.1f, 90.34f, 12.23f, 78.65f };`
          * Queries:
               * Select all bills higher or equal to 50$
               * Round all bills to nereast integer
 1. **Movie Management**
     * Add bootstrap cards on movies index table
     * On movies list (index page) 
         * Apply sorting on columns "Movie Name", "Release Date" and "LengthinMin", clicking on a column header should toggle sorting order of data respectively.
         * Apply filtering (searching) on movie list table with search box on top of table, searching should be on movie name and description.
         * Note: Follow this tutorial to complete above - https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/sort-filter-page?view=aspnetcore-6.0
         
       
