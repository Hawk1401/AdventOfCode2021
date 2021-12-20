
# Advent Of Code 2021 with C#

My personal goal is to have fun and try new concepts in C#.
 

 
## Solved Challenges
| Day | Part 1 | Part 2 |
|-----|--------|--------|
|1    | ✔️     |    ✔️ |
|2    | ✔️     |    ✔️ |
|3    | ✔️     |    ✔️ |
|4    | ✔️     |    ✔️ |
|5    | ✔️     |    ✔️ |
|6    | ✔️     |    ✔️ |
|7    | ✔️     |    ✔️ |
|8    | ✔️     |    ✔️ |
|9    | ✔️     |    ✔️ |
|10   | ✔️     |    ✔️ |
|11   | ✔️     |    ✔️ |
|12   | ✔️     |    ✔️ |
|13   | ✔️     |    ✔️ |
|14   | ✔️     |    ✔️ |
|15   | ✔️     |    ✔️ |
|16   | ✔️     |    ✔️ |
|17   | ✔️     |    ✔️ |
|18   | ✔️     |    ✔️ |
|19   | ❌     |    ❌ |
|20   | ✔️     |    ✔️ |


## Add session token

 A session token is required to fetch the puzzle input. There are two different ways to provide the session token.

### Add session token in source code


You can store the session token in the static variable "session". This variable can be found in the "DayRunner" class in the "Core" namespace.




### Add session token as environment variable

It is also possible to store the session token as an environment variable. The name of the variable must be "SessionAdventofcode".



### Find the session token:

To find the session token you have to log in to the website "adventofcode.com", then open the dev tool, go to Application → Cookies → https://adventofcode.com and finally copy the value of "Session".




### Get started

To start, the static method "run" of the class "DayRunner" must be called. This method gets an instance of the desired day. The days classes are in the namespace Year2021.Days.

As an example, to solve the problem of day 4, the code would have to look like this :
<pre><code class='language-cs'>
DayRunner.Run(new Day4());
</code></pre>


## Perfomance (Measured with BenchmarkDotNet)

|      Method  |               Mean |      Gen 0 |      Gen 1 |     Gen 2 |     Allocated |
|------------- |-------------------:|-----------:|-----------:|----------:|--------------:|
| Day1PartOne  |           1.947 μs |          - |          - |         - |               - |
| Day1PartTwo  |           2.493 μs |          - |          - |         - |               - |
| Day2PartOne  |          14.977 μs |          - |          - |         - |               - |
| Day2PartTwo  |          15.481 μs |          - |          - |         - |               - |
| Day3PartOne  |          49.117 μs |          - |          - |         - |         72 Bit  |
| Day3PartTwo  |          32.077 μs |    13.3667 |     0.7324 |         - |        111 Kbit |
| Day4PartOne  |         124.997 μs |    11.8408 |     2.5635 |         - |         99 Kbit |
| Day4PartTwo  |         324.572 μs |    18.5547 |     3.4180 |         - |        158 Kbit |
| Day5PartOne  |       2,959.807 μs |   789.0625 |   367.1875 |         - |          6 Mbit |
| Day5PartTwo  |       5,791.244 μs |  1125.0000 |   562.5000 |  109.3750 |          9 Mbit |
| Day6PartOne  |           5.495 μs |     0.0916 |          - |         - |        784 Bit  |
| Day6PartTwo  |          11.738 μs |     0.0916 |          - |         - |        784 Bit  |
| Day7PartOne  |         281.941 μs |     7.3242 |     0.4883 |         - |         64 Kbit |
| Day7PartTwo  |          48.278 μs |     7.6294 |     0.6104 |         - |         64 Kbit |
| Day8PartOne  |          28.676 μs |     6.2561 |          - |         - |         52 Kbit |
| Day8PartTwo  |       5,678.014 μs |  1000.0000 |          - |         - |          8 Mbit |
| Day9PartOne  |          66.607 μs |     0.2441 |          - |         - |          2 Kbit |
| Day9PartTwo  |       3,306.705 μs |   121.0938 |    70.3125 |   39.0625 |          1 Mbit |
| Day10PartOne |          89.390 μs |     2.5635 |          - |         - |         22 Kbit |
| Day10PartTwo |          93.179 μs |     2.6855 |          - |         - |         23 Kbit |
| Day11PartOne |         681.309 μs |          - |          - |         - |          4 Kbit |
| Day11PartTwo |       1,766.330 μs |          - |          - |         - |          8 Kbit |
| Day12PartOne |       5,853.634 μs |   585.9375 |   273.4375 |         - |          4 Mbit |
| Day12PartTwo |     338,279.287 μs | 16000.0000 |  7000.0000 | 3000.0000 |        137 Mbit |
| Day13PartOne |          27.330 μs |     4.1199 |     0.3357 |         - |         34 Kbit |
| Day13PartTwo |         178.038 μs |    25.6348 |     1.9531 |         - |        216 Kbit |
| Day14PartOne |         193.024 μs |     5.3711 |          - |         - |         46 Kbit |
| Day14PartTwo |         891.054 μs |    21.4844 |          - |         - |        185 Kbit |
| Day15PartOne |       2,540.127 μs |   246.0938 |   121.0938 |  121.0938 |         2  Mbit |
| Day15PartTwo |      66,183.922 μs |  6125.0000 |  1125.0000 | 1000.0000 |         55 Mbit |
| Day16PartOne |          93.584 μs |    11.7188 |     1.3428 |         - |         98 Kbit |
| Day16PartTwo |          85.712 μs |    10.1318 |     1.0986 |         - |         84 Kbit |
| Day17PartOne |         112.255 μs |     4.5166 |     0.2441 |         - |         38 Kbit |
| Day17PartTwo |         706.317 μs |    14.6484 |          - |         - |        123 Kbit |
| Day18PartOne |      21,727.019 μs |  1656.2500 |   500.0000 |         - |         13 Mbit |
| Day18PartTwo |     385,695.040 μs | 34000.0000 |          - |         - |        287 Mbit |
|     Year2021 |             855 ms | 62000.0000 | 11000.0000 | 4000.0000 |        528 Mbit |