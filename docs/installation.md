---
title: Installation
layout: default
---

# Installation

## CLI Tool (gdialog)

### NuGet (Global .NET Tool)

Install `gdialog` as a global .NET tool:

```bash
dotnet tool install -g gdialog
```

### Homebrew (macOS)

Install via Homebrew:

```bash
brew tap bitpatch/tools
brew install gdialog
```

### Usage

Run a dialog script:

```bash
gdialog script.gds
```

---

## Library (DialogLang)

### NuGet Package

Add to your .NET project:

```bash
dotnet add package DialogLang
```

Or via Package Manager:

```powershell
Install-Package DialogLang
```

### Unity

1. Download the latest release from [GitHub Releases](https://github.com/bitpatch/game-dialog/releases)
2. Copy the `DialogLang` folder to your Unity project's `Assets` folder
3. The `GameDialogScript.asmdef` is already included for proper compilation

### Godot (with Mono)

1. Add the `DialogLang` NuGet package to your Godot C# project
2. Or copy the source files directly into your project

---

## Basic Usage

```csharp
using BitPatch.DialogLang;

// Create a dialog interpreter
var dialog = new Dialog();

// Execute a script
foreach (var line in dialog.Execute("playerName = \"Arthur\"\n<< \"Hello, \" + playerName + \"!\""))
{
    Console.WriteLine(line);
}
```
