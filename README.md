Created on .Net core v5.0

Completely .Net Core API project, so no views are there.
I have performed customer crud operation by using postman.

Implemented Identity for login and registration.

Token I'm using for Authentication and Authorization is JWT Token.

I have used code first approach in this project. For database connection I have used Entity Framework.

Design pattern I have used is Repository Pattern and used Unit Of Work.

I have implemented global exception handling by using custom middleware. Logging also used there.

For encrypt the customer table Email and PhoneNumber as mentioned in document I have used Aes Encryption.

For email functionality I have used MailKit, also created seperate interface and repository for implementation.
By using dependency injection we can call sendEmail method in any controller or repository.
