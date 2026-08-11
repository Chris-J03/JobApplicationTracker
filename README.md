# JobApplicationTracker
This program is designed to track current job applications and the progress of them. It will eventually be able to provide detailed analysis of roles applied for.


Further improvements that will be made in future commits - 
Suggested best-practice improvements:

- Separate UI from data access
  - keep `Menu` only responsible for menu flow
  - move database logic into a repository/service layer like `IJobRepository` / `JobRepository`

- Avoid direct `Console`/`Thread.Sleep` in services
  - inject `IConsole` into `ViewApps`/`DeleteApp` if they need I/O
  - move delay logic into one helper or UI layer rather than calling `Thread.Sleep` directly between lines

- Use a single source of truth for the DB connection
  - put the SQLite connection string in configuration
  - avoid hard-coded `"Data Source=Database/Jobs.db"` everywhere

- Improve error handling
  - catch DB exceptions and show user-friendly messages
  - validate that delete IDs exist before saying “deleted successfully”

- Remove unused and duplicate `using` directives
  - `ViewApps.cs` has duplicate `using System.Collections.Generic;`
  - `System.Runtime.Serialization` is unused

- Use async I/O for database operations if the app may grow
  - `DeleteApp` can be `Task DeleteApplicationAsync()` and call `ExecuteNonQueryAsync()`
  - `ViewApps` can read asynchronously too

- Make classes more testable
  - avoid `Console.ReadLine` / `Console.WriteLine` directly in business classes
  - inject abstractions and test behavior without console interaction

- Consolidate repeated logic
  - use helper methods for printing lists with delay
  - centralize menu option handling and validation

- Add persistence initialization / schema checks
  - ensure `Jobs.db` exists and the `Jobs` table is created before use
  - implement a small database initializer

- Improve naming and structure
  - maybe rename `ViewApps` / `DeleteApp` to `ApplicationViewer` / `ApplicationRemover`
  - use more descriptive names for methods and classes

These changes will make the codebase cleaner, safer, and easier to extend/test.
