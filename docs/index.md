---
title: Home
layout: default
---

# Game Dialog Script Language

A simple language for writing game dialogs with integrated logic. Write dialogs as plain text with a bit of logic, and the interpreter does the rest.

[Get Started](installation.md) · [Syntax](syntax.md) · [Examples](examples.md) · [GitHub](https://github.com/bitpatch/game-dialog)

---

## What It Looks Like

```python
reputation = 75

<< "Welcome, traveler!"

if reputation > 50
    << "Good to see you again, friend!"
    << "I have a special discount for you."
else
    << "I don't know you."
    << "Regular prices."
```

That's it! No complex configurations, JSON files, or XML markup. Just write text and add a bit of logic.

## Why Use Game Dialog Script?

- **Simple syntax** — plain text with minimal markup
- **Works with C#** — integrates seamlessly with Unity and Godot
- **Git-friendly** — scripts are just text files, easy to track changes
- **AI-friendly** — neural networks understand this language perfectly

## Quick Example with C#

```csharp
using BitPatch.DialogLang;

var script = @"
playerName = ""Arthur""
<< ""Hello, "" + playerName + ""!""
";

var dialog = new Dialog();
foreach (var line in dialog.Execute(script))
{
    Console.WriteLine(line);
}
```

Output:
```
Hello, Arthur!
```
