# League Ranking Calculator

This is a command-line application written in C# that calculates the ranking table for a league based on the results of games.

## Installation

### Install the .NET SDK

To run this application, you'll need to install the .NET framework. You can install it using the `dotnet-install.sh` script provided by Microsoft.

1. Download the script from [here](https://dot.net/v1/dotnet-install.sh).
2. Open a terminal and navigate to the directory where you downloaded `dotnet-install.sh`.
3. Run the following command to make the script executable:
   ```bash
   chmod +x dotnet-install.sh
   ```
4. Run the script to install the .NET framework:
   ```bash
   ./dotnet-install.sh
   ```

Follow the on-screen instructions to complete the installation.

## Compilation

To compile the program, follow these steps:

1. Clone this repository to your local machine or download the source code.
2. Open a terminal and navigate to the root directory of the project.
3. Run the following command to compile the program:
   ```bash
   dotnet build
   ```

## Running the Program

Once the program is compiled, you can run it with the following steps:

1. Navigate to the directory containing the compiled executable or the project root directory.
2. Run the following command to execute the program, replacing `<input_file_path>` with the path to your input file:
   ```bash
    dotnet run --project LeagueCalc <input_file_path>
   ```

For example:

```bash
dotnet run --project LeagueCalc ./input/input.txt
```

You can also run the program without the input file argument. In this case, the program will ask for the input data in the terminal, you can paste or write each line manually; make sure to leave an empty line and the end and press `ENTER` to process the data. To do so, run the following command:

```bash
dotnet run --project LeagueCalc
```

## Builing & Running in Docker

You can also run the application inside a Docker container. To do so, follow these steps:

1. Make sure you have Docker installed on your system.
2. Open a terminal and navigate to the root directory of the project.
3. Run the following command to build the Docker image:
   ```bash
   docker build -t dotnet-test . && docker run -d --name dotnet-test dotnet-test:latest
   ```

## Testing

Run your tests with the following command:

```bash
dotnet test
```
