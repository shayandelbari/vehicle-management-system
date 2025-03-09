# Vehicle Management System 🚗✈️🚢

## Overview

The **Vehicle Management System** is a C# console application designed to demonstrate Object-Oriented Programming (OOP) concepts, including inheritance, exception handling, file operations, sorting algorithms, and logical problem-solving.

This project is structured to manage various types of vehicles, implement tax calculations, handle exceptions, and perform data analysis on vehicle attributes.

## Features

✅ Object-Oriented Programming (OOP) with **inheritance** and **polymorphism**  
✅ **Custom exception handling** for invalid values (e.g., price, speed, cargo capacity)  
✅ **File operations** for saving and loading vehicle data  
✅ **Sorting algorithms** (custom sorting by price, speed, type)  
✅ **Data analysis using LINQ** (finding fastest vehicles, average prices, and type counts)  
✅ **Object array implementation** for managing multiple vehicle instances  
✅ **Command-line interface** for adding, sorting, and displaying vehicles  
✅ Bonus: Extendable for **GUI implementation** (if desired)  

## Project Structure

📂 **VehicleManagementSystem**  
├── 📁 **Vehicles** *(All vehicle-related classes)*  
│   ├── Vehicle.cs *(Abstract base class)*  
│   ├── Train.cs, Airplane.cs, Car.cs, Boat.cs *(Derived vehicle types)*  
│   ├── CargoAirplane.cs, RaceCar.cs, LuxuryYacht.cs *(Specialized vehicles)*  
│
├── 📁 **IndependentClasses** *(Utility classes)*  
│   ├── VehicleComparer.cs *(Implements sorting algorithms)*  
│   ├── TaxCalculator.cs *(Tax calculation logic based on vehicle type)*  
│   ├── VehicleStatistics.cs *(Data analysis functions using LINQ)*  
│
├── 📁 **Exceptions** *(Custom exception handling)*  
│   ├── VehicleException.cs *(Base exception class)*  
│   ├── InvalidPriceException.cs, InvalidSpeedException.cs, InvalidCargoCapacityException.cs  
│
├── 📁 **Services** *(File handling & vehicle management)*  
│   ├── FileHandler.cs *(Handles saving/loading of vehicles from file)*  
│   ├── VehicleManager.cs *(Manages vehicle array operations)*  
│
├── Program.cs *(Main execution logic & menu system)*  

## Installation & Setup

### Prerequisites

- .NET SDK (Latest version)  
- Visual Studio / VS Code / Any C# IDE  

### Steps to Set Up the Project

1. **Clone the Repository**

   ```bash
   git clone https://github.com/shayandelbari/VehicleManagementSystem.git
   cd VehicleManagementSystem
   ```

2. **Build the Project**

   ```bash
   dotnet build
   ```

3. **Run the Application**

   ```bash
   dotnet run
   ```

## Usage

### Adding a Vehicle

The program allows users to add a vehicle by providing details such as name, price, speed, and type. Custom exceptions are thrown if invalid values are entered.

### Sorting Vehicles

- **By Price** (Ascending or Descending)
- **By Speed** (Ascending or Descending)
- **By Type** (Alphabetical Order)

### Data Analysis

- Find **all vehicles faster than 200 km/h**
- Find **the most expensive vehicle**
- Find **trucks with Load Capacity > 5000 kg**

### Exception Handling

The program properly handles exceptions such as:

- **Negative price values**
- **Speed values that are 0 or negative**
- **Unrealistic cargo capacity values**

## File Operations

- **Saving Data**: The vehicle list is stored in a `vehicles.txt` file.
- **Loading Data**: The application loads previously saved vehicle data upon startup.

## Future Enhancements

- [ ] Implement a **Graphical User Interface (GUI)**
- [ ] Add a **search feature** to find vehicles by name
- [ ] Expand sorting options with more criteria

## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository
2. Create a new branch (`feature-branch`)
3. Commit your changes
4. Push to the branch
5. Submit a Pull Request

## License

This project is licensed under the **MIT License**.

---
🚀 Happy Coding!
