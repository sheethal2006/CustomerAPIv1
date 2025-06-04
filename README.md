# Customer API

## Overview
This project provides a RESTful API for managing customer data, utilizing **Microsoft.EntityFrameworkCore.Sqlite** for an embedded database (`customer.db`). The application includes authentication via JWT and a CI/CD pipeline using GitHub Actions.

## Features
- Embedded SQLite database for customer records
- JWT authentication for secure API access
- Unit tests using `xUnit` and `Moq`
- CI/CD pipeline for automated builds and deployments

## Authentication
To delete a customer, authenticate using the following credentials:

**Endpoint:**  
`POST http://localhost:5065/api/auth/login`

**Payload:**  
```json
{
  "username": "admin",
  "password": "password"
}
API Endpoints
Get All Customers GET http://localhost:5065/api/Customer

Unit Testing --
Unit test logic has been implemented for:
GetCustomer_Returns_Customer_WhenExists()
TestCustomerCreation()
Using:
using Xunit;
using Moq;

CI/CD Pipeline
A YAML-based GitHub Actions workflow has been added for automated testing and deployment.

https://github.com/sheethal2006/CustomerAPIv1.git

Let me know if you'd like any modifications!

Thank You
Sheethal Lloyd
