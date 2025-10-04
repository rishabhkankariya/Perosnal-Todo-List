# Todo List Application

A modern, feature-rich Todo List application built with C# WinForms using a 3-tier architecture pattern.

## Features

### 🎨 Modern UI/UX
- **Responsive Design**: Adapts to different window sizes gracefully
- **Light/Dark Theme**: Toggle between light and dark themes
- **Smooth Animations**: Button hovers, form transitions, and list updates
- **Intuitive Navigation**: Left-side navigation panel with clear categories

### 📋 Task Management
- **CRUD Operations**: Create, Read, Update, Delete tasks
- **Task Categories**: Organize tasks by custom categories
- **Due Dates**: Set and track task deadlines
- **Status Tracking**: Pending, In Progress, Done
- **Smart Filtering**: Filter by status, category, or search terms
- **Overdue Detection**: Automatically identify overdue tasks

### 🔍 Advanced Features
- **Search Functionality**: Search across titles, descriptions, and categories
- **Export Options**: Export tasks to CSV or Excel formats
- **Data Validation**: Comprehensive input validation
- **Async Operations**: Non-blocking database operations
- **GitHub Integration**: Direct link to your GitHub profile

### 🏗️ Architecture
- **3-Tier Architecture**: Clean separation of concerns
  - **Presentation Layer**: WinForms UI with modern design
  - **Business Logic Layer**: Validation, business rules, and service logic
  - **Data Access Layer**: SQLite database with Repository pattern
- **SOLID Principles**: Clean, maintainable, and extensible code
- **Dependency Injection**: Loose coupling between layers

## Project Structure

```
TodoList/
├── TodoList.sln                 # Solution file
├── TodoList.Models/             # Data models and entities
│   ├── TodoTask.cs
│   ├── TaskStatus.cs
│   └── ThemeSettings.cs
├── TodoList.DataAccess/         # Data access layer
│   ├── IDatabaseContext.cs
│   └── SqliteDatabaseContext.cs
├── TodoList.BusinessLogic/      # Business logic layer
│   ├── ITodoService.cs
│   └── TodoService.cs
├── TodoList.Presentation/       # Presentation layer
│   ├── Program.cs
│   ├── Forms/
│   │   ├── MainForm.cs
│   │   ├── MainForm.Designer.cs
│   │   ├── TaskForm.cs
│   │   └── TaskForm.Designer.cs
│   └── Managers/
│       ├── ThemeManager.cs
│       └── AnimationManager.cs
└── README.md
```

## Getting Started

### Prerequisites
- .NET 8.0 or later
- Visual Studio 2022 or Visual Studio Code
- Windows OS (WinForms requirement)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/todo-list-app.git
   cd todo-list-app
   ```

2. **Open the solution**
   - Open `TodoList.sln` in Visual Studio 2022
   - Or use Visual Studio Code with C# extension

3. **Restore packages**
   ```bash
   dotnet restore
   ```

4. **Build the solution**
   ```bash
   dotnet build
   ```

5. **Run the application**
   ```bash
   dotnet run --project TodoList.Presentation
   ```

### First Run
- The application will automatically create a SQLite database in your AppData folder
- Database location: `%APPDATA%\TodoList\todolist.db`
- Theme settings are saved to: `%APPDATA%\TodoList\theme.json`

## Usage

### Adding Tasks
1. Click the "➕ Add Task" button
2. Fill in the task details:
   - **Title** (required): Task name
   - **Description** (optional): Detailed description
   - **Category** (optional): Task category
   - **Status**: Pending, In Progress, or Done
   - **Due Date** (optional): Set a deadline
3. Click "Create Task"

### Managing Tasks
- **View Tasks**: Use the navigation panel to filter by status
- **Edit Tasks**: Double-click on any task in the list
- **Search**: Use the search box to find specific tasks
- **Export**: Use CSV or Excel export buttons to save your data

### Navigation
- **📋 All Tasks**: View all tasks
- **⏳ Pending**: Tasks not yet started
- **🔄 In Progress**: Tasks currently being worked on
- **✅ Completed**: Finished tasks
- **⚠️ Overdue**: Tasks past their due date
- **📅 Due Today**: Tasks due today

### Themes
- Click the theme toggle button (🌙/☀️) to switch between light and dark themes
- Your preference is automatically saved

## Technical Details

### Database
- **SQLite**: Lightweight, serverless database
- **Repository Pattern**: Clean data access abstraction
- **Async Operations**: Non-blocking database calls
- **Automatic Schema**: Database tables created on first run

### Dependencies
- **Microsoft.Data.Sqlite**: SQLite database provider
- **CsvHelper**: CSV export functionality
- **EPPlus**: Excel export functionality

### Performance
- **Async/Await**: All database operations are asynchronous
- **Lazy Loading**: Tasks loaded on demand
- **Efficient Queries**: Optimized database queries
- **Memory Management**: Proper disposal of resources

## Customization

### Adding New Features
1. **Models**: Add new properties to `TodoTask.cs`
2. **Database**: Update `SqliteDatabaseContext.cs` for schema changes
3. **Business Logic**: Extend `TodoService.cs` with new operations
4. **UI**: Add new forms or controls in the Presentation layer

### Theming
- Modify `ThemeManager.cs` to customize colors and styles
- Add new theme options in `ThemeSettings.cs`
- Update UI controls to support new theme properties

### Database
- Change database provider by implementing `IDatabaseContext`
- Modify connection string in `SqliteDatabaseContext.cs`
- Add new tables or columns as needed

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Built with .NET 8.0 and WinForms
- Icons from Unicode emoji characters
- Modern UI design inspired by Fluent Design principles
- Architecture patterns from Clean Architecture principles

## Support

If you encounter any issues or have questions:
1. Check the [Issues](https://github.com/yourusername/todo-list-app/issues) page
2. Create a new issue with detailed information
3. Include steps to reproduce any bugs

---

**Happy Task Managing! 🎉**
