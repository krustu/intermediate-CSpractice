# Order Management System

A simple C# console application demonstrating basic **Object-Oriented Programming (OOP)**, **Repository Pattern**, and **Dependency Injection**.

## Features
- Place orders with product names and prices.
- Validate order data (empty names and invalid prices are rejected).
- Store orders in an in-memory repository.
- Calculate the total price of all orders.
- Display all saved orders with unique IDs.

## Architecture
- **Order** – Model representing an order.
- **IOrderRepository** – Repository interface.
- **InMemoryOrderRepository** – Stores orders in a list.
- **OrderService** – Handles business logic and validation.
- **ApplicationEntryPoint** – Configures dependencies and runs the application.


## Concepts Practiced
- Interfaces and abstraction.
- Dependency Injection through constructor injection.
## Storage
Orders are stored in memory and are not persisted after the application closes.