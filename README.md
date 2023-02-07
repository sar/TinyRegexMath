# Tiny Regex Math Compiler in C#

This repository is an example of writing a small C# compiler for string-based arithmetic operations in less than 30 lines of code. Function uses `System.Regex` to parse input string expression and match `(int[] numbers, string[] tokens)` to a `Dictionary<int, Func<int, int, int>>` operations in computing a mathematical result. 

### Usage

In the following example, the expression `"125 + 8 / 3 ^ 2 - 5 / 2"` computes sequentially, a limitation of the program.

```
EXPRESSION="125 + 8 / 3 ^ 2 - 5 / 2"
dotnet run $EXPRESSION
[char]::+::3
[char]::/::5
[char]::^::7
[char]::-::9
[char]::/::5
[expr]::125 + 8
[expr]::133 / 3
[expr]::44 ^ 2
[expr]::1936 - 5
[expr]::1931 / 2
[calc]::965
```

String literals can be parsed for `int.operation` using libraries like `System.DataTable` but the goal of this project is to replicate calculation purely in C# without additional dependencies except for regex parser.

## LICENSE

Project available under GPLv3 license, refer to [LICENSE](LICENSE). 
