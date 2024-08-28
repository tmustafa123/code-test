# CarSpeedAPI

This project implements a RESTful API that returns the hourly average speed of a car based on an input JSON file. The application is built using C#, runs in memory, and does not require any external database. The application is accompanied by tests to validate its functionality.

## Getting Started

### Prerequisites

- [.NET 6.0 or later](https://dotnet.microsoft.com/download/dotnet) SDK installed on your machine.
- A command line interface (CLI) or terminal to run commands.


### Running the API

Clone the Repository
```plaintext
git clone https://github.com/your-repository-url.git
cd CarSpeedAPI
```

Run the API
```plaintext
dotnet run -- ./Data/input.json
```

Access the API
```plaintext
http://localhost:5000/CarSpeed/average-speed
```

### Running the Tests
```plaintext
dotnet test
```