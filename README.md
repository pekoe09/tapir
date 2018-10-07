# tapir

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/c7eaa475b8a642bfbd3e994a713bea5c)](https://app.codacy.com/app/juha-kangas/tapir?utm_source=github.com&utm_medium=referral&utm_content=pekoe09/tapir&utm_campaign=Badge_Grade_Dashboard)

System for logging and reporting occupational accidents

Tapir enables an organization to store data on occupational accidents and report them directly to its insurance company.

Tapir's backend provides a REST API for the front-end to call. 
The backend is built using ASP.NET Core 2 and the database is run on SQL Server, with Entity Framework providing mapping between domain objects and the database.
The frontend in this project is React-based, utilizing Redux for storing data locally.

The project is in a very early stage, with only project structure in place an basic CRUD for Companies realized as a Proof of Concept. 
A demo version of Tapir will be hosted on Azure fairly soon.
