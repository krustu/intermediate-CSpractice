# Dependency Injection – IServiceProvider

A simple C# project demonstrating **Dependency Injection 
(DI)** using `IServiceProvider` and `Microsoft.Extensions.DependencyInjection`.
The application registers services, resolves dependencies automatically through constructors, 
and uses **Singleton lifetime** to ensure that the same instances are reused throughout the application.
It simulates placing orders, 
saving them in an in-memory repository, and sending notifications via email or console.