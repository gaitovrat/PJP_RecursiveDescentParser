# Recursive Descent Parser
## Input specification
The first line of the input contains a number `N`. It defines the number of expressions your program should evaluate. These expressions are on next `N` lines. Each line contains exactly one expression.

## Output specification
For each expression write one line containing numbers of grammar rules, that are used for parsing during the recursive descent and calculated result next line. If there is any error in the input, write text `ERROR` instead.

## Example
* Input
```
2
2 * (3+5)
15 - 2**7
```
* Output
```
1 5 10 6 9 1 5 10 8 2 5 10 8 4 8 4
16
ERROR
```
