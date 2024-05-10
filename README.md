# CatWorx Badge Maker

A simple C# application to automate employee badge creation. This app can generate a CSV file and create badge images based on employee data collected either manually or from an API.

## Table of Contents
- [Features](#features)
- [Requirements](#requirements)
- [Setup](#setup)
- [Usage](#usage)
- [Example Output](#example-output)
- [Further Improvements](#further-improvements)
- [Contributing](#contributing)
- [License](#license)

## Features
- **Manual Data Entry:** Collect employee data via prompts in the console.
- **API Integration:** Fetch employee data from an API (`randomuser.me`).
- **CSV Generation:** Create a CSV file containing all employee information.
- **Badge Generation:** Generate badge images using `SkiaSharp`.

## Requirements
- [.NET SDK 6.0 or later](https://dotnet.microsoft.com/download)
- [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json) (for JSON handling)
- [SkiaSharp](https://www.nuget.org/packages/SkiaSharp) (for image processing)

## Setup
1. Clone the repository:
    ```bash
    git clone https://github.com/your-username/CatWorx.BadgeMaker.git
    cd CatWorx.BadgeMaker
    ```

2. Install required packages:
    ```bash
    dotnet add package Newtonsoft.Json
    dotnet add package SkiaSharp
    ```

3. Place a badge background image (`badge.png`) in the project directory:
    ```
    CatWorx.BadgeMaker/
    └── badge.png
    ```

4. Build the project:
    ```bash
    dotnet build
    ```

## Usage
1. Run the application:
    ```bash
    dotnet run
    ```

2. Choose the data collection method:
    - **API (randomuser.me)**: Type `yes` and press Enter.
    - **Manual Entry**: Type `no` and press Enter.

3. Enter the employee data manually if prompted.

4. The following will be generated in the `data` folder:
    - `employees.csv`: CSV file with employee details.
    - Badge images for each employee.

## Further Improvements
- **Upload Images to Cloud Storage:** Integrate Google Drive or Imgur for badge image storage.
- **Database Integration:** Save employee data to a MySQL or other database.
- **Company Name Customization:** Allow users to customize the company name per badge.

## Contributing
Contributions are welcome! Please fork the repository and submit a pull request.

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
