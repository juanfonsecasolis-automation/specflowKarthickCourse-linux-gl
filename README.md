# karthickSpecflowCourse-linux-gl
Juan M. Fonseca-Solís 2021. Repository for storing the code of the Karthick's Specflow's course.

## 1 Prerequisites
* Download and install [.NET Core for linux](https://dotnet.microsoft.com/download)
* If using VS code install extension "Gherkin Indent", and optionally, "Awesome DotNetCore Pack".
* Local REST server: `npm install -g json-server`
## 2 Project set-up
* Tell .NET to create a new nUnit project using `dotnet new nunit`
* Create three folders: src, features, steps
* Add specflow dependencies using `dotnet add package SpecFlow.NUnit`
* Add nUnit dependencies using `dotnet add package nunit`
* Add xUnit dependencies using `dotnet add package xunit` and `dotnet add package xUnit.runner.visualstudio`
* Add Restsharp dependencies using `dotnet add package Restsharp`
* Add PACT dependencies using `dotnet add package PactNet.linux.x64`
* Add PACT dependencies using `dotnet add package PactNet.linux.x64`
* Add Configuration dependencies using `dotnet add package Microsoft.Extensions.Configuration` and `dotnet add package Microsoft.Extensions.Configuration.Json `
* Add automatic feature class generation dependency using `dotnet add package SpecFlow.Tools.MsBuild.Generation`.

### 2.1 Contract testing employee API
```
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.InMemory
dotnet add ContactTesting/ContactTesting.csproj reference EmployeeAPI/EmployeeAPI.csproj
```

## 3 Run
```
dotnet clean
dotnet build
json-server ./db.json
dotnet test
```

REST service at:
```
http://localhost:3000/posts/1
http://localhost:3000/comments/1
http://localhost:3000/profile/1
```

Remember that you can add more endpoints by modifying the db.json file. So, for instance, adding an entry like this:
```
"employee":{
      "Id": "",
      "EmployeeName":"",
      "Email": "",
      "City":""
    }
```
the endpoint `http://localhost:3000/employee` will be created.

## 4 Theory
### 4.1 Limitations
* The steps skeleton is not implemented automatically as in VS.

### 4.2 Contract testing
Testing is composed of three layers:
* Unit testing (fast, reliable)
* Integration testing (slow, not reliable)
* End-to-end testing (slow, not reliable)

Contract testing is applicable when two components need to comunicate each other (consumer vs. provider). The main idea is that a mock is created to formalize the specifications and the "mock response" is compared against the real response.

### 4.3 Paralelization
[Used feature level paralelization](https://docs.specflow.org/projects/specflow/en/latest/Execution/Parallel-Execution.html).
## 5 References
1. Learn Dash Academy. Setting up Specflow on a dotnet core project using Visual Studio code with Linux OS. [URL](https://testautomation.org/setting-up-specflow-on-a-dotnet-core-project-using-visual-studio-code-with-linux-os/)
2. Specflow. Gherkin Reference. [URL](https://gorillalogic.udemy.com/course/api-testing-with-restsharp-and-specflow-in-csharp)
