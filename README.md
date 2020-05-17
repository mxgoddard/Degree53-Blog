# Degree 53 Blog Tech Test

Create a .NET Core C# solution for a simple blog.

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
* The Admin has an id of 1 in the User table however admin permissions will need to be enabled in the settings.

### TODO

* Setup basic app                                       [x]
* Integrate Database (SQL Server Express LocalDB)       [x]
* Seed database on app start                            [x]
* Read articles from database                           [x]
* Unit Tests                                            [ ]
* Sticky footer                                         [x]
* Add settings page                                     [x]
* Form validation                                       [ ]
* Delete articles                                       [ ]
* Clicking article takes to article page                [x]
* I'm an admin checkbox                                 [x]
* When article added route to the page for that article [x]
* Web Design (CSS)                                      [ ]
* If no articles appear show something                  [ ]
* Limit how many articles appear?                       [ ]
* Try catches and add logging                           [ ]
* Filter by time created                                [ ]
* Split out controllers and repositories                [ ]
* Seed automatically creates the db                     [ ]
* Global exception handler                              [ ]
* Conditional render Add button                         [ ]
* Update favicon.ico                                    [ ]
