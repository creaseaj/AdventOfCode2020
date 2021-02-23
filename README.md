
# AdventOfCode2020
Advent of code 2020 solutions
## Day 1
### Part 1
This challenge needed me to find two numbers within a list that sum to 2020 and then to multiply those numbers.

### Part 2
The 2nd part needed me to find 3 numbers this time which summed to 2020 and then to multiply them together.

## Day 2
### Part 1
This challenge gives a requirement for a string and then the string to check it against. It details the letter and the number of times it may appear in the string. I need to then check if the string follows that requirement and then return the total number of valid passwords.

### Part 2
The requirements have changed! Now for the requirements the numbers detailed show that that character must show up in either of those positions in the string, not the amount of times that character appears. Then the number of valid strings it needed to be returned once again.

## Day 3
### Part 1
The input is a 'map' which is a 2d array that consists of '#' and '.'. The '#' represents a tree while the other character represents empty space. As a pointer travels through this 2d array the amount of times a pointer lands on a tree needs to be recorded. The 2d array can be repeated horizontally forever. Input is a distance down and right to travel every iteration. 

### Part 2
Multiple distances down and right are now provided. The tree count from each one is needed and then those results multiplied is the answer.

## Day 4
### Part 1
Provided in each line of the input is a series of fields. Each passport field is found using regex and the switch function. Checks are made to ensure that each passport has all fields apart from the optional one. The number of valid passports are then returned. 
### Part 2
Then from that each field now has it's own requirements that it checks for, and if it fails any of those requirements it's marked as invalid. Regex is used in a couple of the fields where hex codes and long number strings are present. The number of valid passports are then returned. 

## Day 5
### Part 1
The input is a string of letters including F,B,L, and R. First the string of Fs and Bs can be used as a binary search to find a number between 0 and 127. Then L and R is used to find a number between 0 and 7. A seat ID is performing a basic funtion on the two numbers found. The highest seat ID is then returned.
### Part 2
From the list of all IDs the gap is needed to be found. This missing ID is then returned.

## Day 6
### Part 1
The puzzle input is a series of letters on each line. lines are grouped into groups divided by blank lines. In each group, the total number of individual letters are checked. That number is then added to a running total and returned as the answer.
### Part 2
The input is the same. However, now the number of cases where the same character appears on every line in a group is now recorded. This number is counted and then returned.

## Day 7
### Part 1
The input is multiple lines which follow the format of 'x bags contain  y bags, z bags.'. This format needs to be broken down using regex into finding what x, y, and z are and then bags are inserted into a dictionary. This dictionary is used to check which bags can contain a shiny gold bag. A recursive function that repeated calls itself is used to perform this task and counts all the bags used along the way. This total number is returned as the answer.
### Part 2
The number of bags which can be held within a shiny gold bag are now needed. This is found in a similar way to the previous task. Iterating through each bag, checking how many they can contain and repeating until the end is reached.

## Day 8
### Part 1

### Part 2

## Day 9
### Part 1

### Part 2

## Day 10
### Part 1

### Part 2

## Day 11
### Part 1

### Part 2

## Day 12
### Part 1

### Part 2

## Day 13
### Part 1

### Part 2

## Day 14
### Part 1

### Part 2

## Day 15
### Part 1

### Part 2

## Day 16
### Part 1

### Part 2

## Day 17
### Part 1

### Part 2
