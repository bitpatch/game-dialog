---
title: Examples
layout: default
nav_order: 4
---

# Examples

## Merchant Dialog

A merchant that greets players differently based on their reputation:

```python
playerName = "Arthur"
reputation = 75
gold = 150

<< "Welcome to my shop!"

if reputation > 50
    << "Ah, " + playerName + "! Good to see you again."
    << "I have some special items for you today."
    
    if gold > 100
        << "And with that gold, you can afford the best!"
    else
        << "Though you might need more gold for the rare items."
else
    << "I don't think we've met before."
    << "Browse around, but no touching the expensive stuff."
```

---

## Quest Giver

A quest giver that checks player level:

```python
playerLevel = 15
hasQuest = false

<< "Greetings, adventurer!"

if playerLevel >= 10
    << "You look experienced enough for a task I have."
    << "There's a dragon terrorizing the village..."
    hasQuest = true
else
    << "Come back when you're stronger."
    << "You need to be at least level 10."

if hasQuest
    << "Do you accept this quest?"
```

---

## Countdown Timer

A simple countdown using a while loop:

```python
seconds = 5

<< "Prepare yourself..."

while seconds > 0
    << seconds + "..."
    seconds = seconds - 1

<< "GO!"
```

---

## Inventory Check

Check if player has required items:

```python
hasSword = true
hasShield = false
hasPotion = true

<< "Let me check your equipment..."

if hasSword and hasShield
    << "You're fully equipped for battle!"
else
    if hasSword
        << "You have a weapon, but no defense."
    else
        << "You need a weapon first!"

if not hasPotion
    << "You should buy some potions before you go."
else
    << "Good, you have healing supplies."
```

---

## C# Integration Example

```csharp
using BitPatch.DialogLang;

public class DialogRunner
{
    public void RunMerchantDialog(int playerReputation, int playerGold)
    {
        var script = $@"
reputation = {playerReputation}
gold = {playerGold}

<< ""Welcome to my shop!""

if reputation > 50
    << ""Good to see you, valued customer!""
    if gold > 100
        << ""I see you can afford the premium items.""
";

        var dialog = new Dialog();
        foreach (var line in dialog.Execute(script))
        {
            // Display line in your game UI
            ShowDialogLine(line);
        }
    }
}
```
