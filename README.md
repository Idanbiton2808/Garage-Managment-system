# Garage Management System

The Garage Management System is a C# application designed to assist in the management of vehicles in a garage setting. It provides functionality for adding new vehicles, performing maintenance tasks, and generating reports.

## Features

- Add new vehicles to the garage, including petrol cars, electric cars, petrol motorcycles, electric motorcycles, and petrol trucks.
- Perform maintenance tasks such as refueling, recharging, and inflating tires.
- View and update vehicle information, including model, license plate, and current status.
- Generate reports on vehicle statistics, maintenance history, and revenue.

## Technologies Used

- C# programming language
- .NET Framework
- Console-based user interface

## Usage

To use the Garage Management System:
1. Clone the repository to your local machine.
2. Open the solution in your preferred IDE.
3. Build the solution and run the application.
4. Follow the on-screen instructions to navigate the menu and perform various tasks.

### Inheritance

The project utilizes inheritance to create a hierarchy of vehicle classes. The `AbstractVehicle` class serves as the base class for all vehicle types, while specific vehicle types such as `AbstractCar`, `AbstractMotorcycle`, and `AbstractTruck` inherit from it. This allows for code reuse and promotes modularity.

### Composition

Composition is used to model the relationship between vehicles and their components. Each vehicle contains components such as engines, batteries, and tires, which are composed within the vehicle objects. This approach allows for flexibility in defining the properties and behavior of each component independently.

### Factory Design Pattern

The factory design pattern is employed to create instances of concrete vehicle objects. The `Factory` class provides a method for creating vehicles based on user input. This decouples the client code from the concrete vehicle classes, making it easier to add new vehicle types in the future without modifying existing code.

## Contributing

Contributions to the project are welcome! If you find any bugs or have suggestions for new features, please open an issue or submit a pull request following our contribution guidelines.



## About

The Garage Management System project was created as part of a software engineering course in C# .Net assignment . It aims to provide a simple yet effective solution for managing vehicles in a garage environment.

