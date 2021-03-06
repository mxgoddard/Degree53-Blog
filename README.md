# Degree 53 Blog Tech Test

Create a .NET Core C# solution for a simple blog.

## Notes

Should work straight out the box provided the ASP.NET workload and SQL Server Express LocalDB (in the ASP.NET workload) are installed. Database seeding is done automatically.

### Requirements

* The application must be a .Net Core MVC solution.
* The application must use a database. Use SQL Server Express LocalDB to ensure the complete solution is self contained.
* There must be an admin interface in order to add new blog articles.
* Each blog article must have its own detail page.
* Use Dependency Injection
* The site must not use bootstrap for styles, however there should be at the very least basic styles. Be as creative as you wish, but don’t spend too long.

### Notes

* The application should utilise best practices for code that you write
* The submitted application must be the complete solution, with database, and not a compiled version of the site.
* Please provide instructions, if you feel they’re necessary
* Use your initiative wherever possible, and have fun with it.

### Database

* Database name is 'db_degree53-blog'.
* Running the application seeds the database.
* The Admin has an id of 1 in the User table however admin permissions will need to be enabled in the settings page on the site.

### TODO

* ~~Setup basic app~~
* ~~Integrate Database (SQL Server Express LocalDB)~~
* ~~Seed database on app start~~
* ~~Read articles from database~~
* ~~Create new articles~~
* ~~Clicking article takes to article page~~
* Conditionally render Add button
* ~~Delete articles~~
* ~~Unit Tests~~
* More meaningful unit tests
* ~~Error handling and logging~~
* ~~Sticky footer~~
* ~~Add settings page~~
* ~~Form validation~~
* ~~I'm an admin checkbox~~
* ~~When article added route to the page for that article~~
* ~~Split out CSS classes~~
* ~~Basic web design (CSS)~~
* Filter by time created
* ~~Split out controllers~~
* Split out repositories
* ~~Seed automatically creates the db~~
* Global exception handler
* 404 Page
* Better user feedback
