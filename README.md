# karthickSpecflowCourse-linux-gl
* Repository for storing the code of the Karthick's Specflow's course.
* Author: Juan M. Fonseca-Solís 2021, CR.

# Prerequisites
* Download and install [.NET Core for linux](https://dotnet.microsoft.com/download)
* If using VS code install extension "Gherkin Indent", and optionally, "Awesome DotNetCore Pack".
# Create a new project (one time setup)
* Tell .NET to create a new nUnit project using `dotnet new nunit`
* Create three folders: src, features, steps
* Add specflow dependencies using `dotnet add package SpecFlow.NUnit`
* Add nUnit dependencies using `dotnet add package nunit`
* Add xUnit dependencies using `dotnet add package xunit`
* Add Restsharp dependencies using `dotnet add package Restsharp`
* Add PACT dependencies using `dotnet add package PactNet.Windows`
* Add Configuration dependencies using `dotnet add package Microsoft.Extensions.Configuration` and `dotnet add package Microsoft.Extensions.Configuration.Json `
* Add automatic feature class generation dependency using `dotnet add package SpecFlow.Tools.MsBuild.Generation`.

# Clean-build-run project
Can be done using the commands:
```
dotnet clean
dotnet build
dotnet test
```

# Run the local REST service
* Install `npm install -g json-server`
* Execute `json-server ./db.json`
* Find on:
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
# Limitations
* The steps skeleton is not implemented automatically as in VS.

# Contract testing
Testing is composed of three layers:
* Unit testing (fast, reliable)
* Integration testing (slow, not reliable)
* End-to-end testing (slow, not reliable)

Contract testing is applicable when two components need to comunicate each other (consumer vs. provider).

The main idea is that a mock is created to formalize the specifications and the mock response is compared against the real response.

## Paralelization
[Used feature level paralelization](https://docs.specflow.org/projects/specflow/en/latest/Execution/Parallel-Execution.html).

## PACT
A consumer-driven contract testing tool.

# References
1. Learn Dash Academy. Setting up Specflow on a dotnet core project using Visual Studio code with Linux OS. [URL](https://testautomation.org/setting-up-specflow-on-a-dotnet-core-project-using-visual-studio-code-with-linux-os/)
2. Specflow. Gherkin Reference. [URL](https://gorillalogic.udemy.com/course/api-testing-with-restsharp-and-specflow-in-csharp)