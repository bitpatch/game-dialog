# GitHub Copilot Instructions

## Language Guidelines

- **All commit messages must be written in English**
- **All code comments must be written in English**
- This ensures consistency and maintainability across the codebase for all contributors

## Project Structure

### DialogLang (Active Development)

The **DialogLang** project is the main implementation of the Game Dialog Script Language interpreter. All current script interpreter development should focus on this project.

The interpreter follows a classic three-stage pipeline architecture: Lexer → Parser → Interpreter, with streaming at each stage using `IEnumerable<T>` and `yield return`.

## Architecture Guidelines

### Streaming Architecture

- Interpreter, parser, and lexer must operate in streaming mode
- Data should be passed between components using `yield` (C# iterator pattern)
- Avoid buffering entire input; process tokens, AST nodes, and dialog lines as streams
- Use `IEnumerable<T>` and `yield return` for all stages
- Ensure each stage can consume and produce data incrementally

### Nullable Reference Types

- **TreatWarningsAsErrors** is enabled - all nullable warnings are compilation errors
- **Internal/private classes and methods**: Do NOT add null checks for non-nullable parameters - the compiler enforces null safety at compile time
- **Public API classes and methods** (including public constructors and methods of internal classes): ALWAYS add explicit null checks with `ArgumentNullException` for non-nullable parameters, as external consumers may have different nullable settings or use reflection

## Code Style

- Follow C# naming conventions
- Keep code clean and well-documented
- Write meaningful variable and function names
