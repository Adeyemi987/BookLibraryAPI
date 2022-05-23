# BookLibraryAPI
This application is a simple book library  which contains Book and Category entities. The design pattern used was Clean architecture.
This project is build with .Net Core, EntityFramework Core, visual studio inbuild SQL Server database for persisting data.
Other features included pagination and the use of automapper.

HOW TO RUN THIS PROJECT
- Clone the project repository
- Open the project with visual studio
- Open Package Manager Console (PMC) Run the following commands
- Add-Migration InitialDb
- Update-Database

Run the codes and test the API endpoint using swagger or postman.

No seeded data, therefore realtime data will beused to test the application.

How To Test The Endpoints
- Create Category first using POST method to get the category Id
- Use the category Id from the above step to add a book using POST method.

Other CRUD operations can be tested as well.

This project can be extended by including JWT Authentication And Giving room for AppUser using Identity.

Link to the project Entity Relationship Diagram (ERD)
https://lucid.app/lucidchart/d6e92b72-066f-4f91-8723-3086b53609fa/edit?invitationId=inv_4e7728c5-7ce4-4387-8aa3-5a1b77f027b0&page=0_0#
