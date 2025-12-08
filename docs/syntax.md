---
title: Syntax
layout: default
nav_order: 3
---

# Syntax Reference

## Dialog Output

Use `<<` to output dialog lines:

```python
<< "Hello, traveler!"
<< "How can I help you?"
```

---

## Variables

Assign values to variables:

```python
playerName = "Arthur"
gold = 100
isVIP = true
```

Supported types:
- **Strings**: `"Hello"`, `"Arthur"`
- **Numbers**: `42`, `3.14`, `-10`
- **Booleans**: `true`, `false`

---

## String Concatenation

Combine strings with `+`:

```python
name = "Arthur"
<< "Hello, " + name + "!"
```

---

## Arithmetic

Basic math operations:

```python
a = 10
b = 3

sum = a + b       // 13
diff = a - b      // 7
product = a * b   // 30
quotient = a / b  // 3.33...
remainder = a % b // 1
```

---

## Comparisons

Compare values:

```python
a = 10
b = 5

a == b  // false (equal)
a != b  // true  (not equal)
a > b   // true  (greater than)
a < b   // false (less than)
a >= b  // true  (greater or equal)
a <= b  // false (less or equal)
```

---

## Boolean Logic

Logical operators:

```python
isVIP = true
hasGold = gold > 50

if isVIP and hasGold
    << "Welcome, valued customer!"

if not isVIP or hasGold
    << "You can still shop here."
```

---

## Conditionals (if/else)

```python
reputation = 75

if reputation > 50
    << "Good to see you, friend!"
else
    << "I don't know you."
```

Nested conditions:

```python
if gold > 100
    if isVIP
        << "Premium discount applied!"
    else
        << "Regular discount."
else
    << "Not enough gold."
```

---

## Loops (while)

```python
count = 3

while count > 0
    << "Countdown: " + count
    count = count - 1

<< "Go!"
```

---

## Indentation

Use consistent indentation (spaces or tabs) for code blocks:

```python
if condition
    << "This is inside the if block"
    << "This too"
<< "This is outside"
```

{: .warning }
> Mix of spaces and tabs will cause an error. Pick one style and stick with it.
