# Contacts Management Application

## Overview
- This is the backend part of the Contacts Management Application. 
- The backend is built using .NET Core 6+ and uses a local JSON file as a mock database to manage contact information.

## Setup Instructions

1. Use Visual studio 2022 or above 
1. Clone the Repository
2. git clone <repository_url>cd <repository_directory>/backend
 
### Prerequisites
- .NET Core SDK (v6.0 (long term support))

### Backend Setup
1. Navigate to the backend project directory.
2. Run `dotnet restore` to install dependencies.
3. Install .nuget\packages\ `microsoft.aspnetcore.mvc.newtonsoftjson\6.0.0.`
4. Run `dotnet run` to start the backend server.


### Running the Application
- Open your browser and navigate to `https://localhost:7265`.
- Swagger is default to call .NET web Api
- We can use Postman ` https://localhost:7265/api/contacts/1 `.

## Design Decisions
- ASP.NET Core for robust and scalable backend.
- Local JSON file for simple data storage.

## Application Structure
- **Backend:** ASP.NET Core Web API
- **Data Storage:** Local JSON file
- 
## Application Structure
The application follows a layered architecture with the following key components:

### API Architecture
The application follows a RESTful architecture to provide a stateless and scalable service.
Each endpoint is designed to perform a specific operation on the resource, in this case, contacts.

### Controllers
- Controllers handle HTTP requests and return responses.
- They interact with services to perform business logic and data operations.
- process them using services, and return appropriate HTTP responses. 
- This keeps the application modular and maintainable.




