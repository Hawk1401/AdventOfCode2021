
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

|      Method  |               Mean |             Median |      Gen 0 |      Gen 1 |     Gen 2 |     Allocated |
|------------- |-------------------:|-------------------:|-----------:|-----------:|----------:|--------------:|
| Day1PartOne  |           1.947 μs |           1.945 μs |          - |          - |         - |             - |
| Day1PartTwo  |           2.493 μs |           2.494 μs |          - |          - |         - |             - |
| Day2PartOne  |          14.977 μs |          14.985 μs |          - |          - |         - |             - |
| Day2PartTwo  |          15.481 μs |          15.467 μs |          - |          - |         - |             - |
| Day3PartOne  |          49.117 μs |          49.080 μs |          - |          - |         - |          72 B |
| Day3PartTwo  |          32.077 μs |          32.067 μs |    13.3667 |     0.7324 |         - |        111 Kb |
| Day4PartOne  |         124.997 μs |         125.280 μs |    11.8408 |     2.5635 |         - |         99 Kb |
| Day4PartTwo  |         324.572 μs |         324.331 μs |    18.5547 |     3.4180 |         - |        158 Kb |
| Day5PartOne  |       2,959.807 μs |       2,942.440 μs |   789.0625 |   367.1875 |         - |          6 Mb |
| Day5PartTwo  |       5,791.244 μs |       5,800.543 μs |  1125.0000 |   562.5000 |  109.3750 |          9 Mb |
| Day6PartOne  |           5.495 μs |           5.489 μs |     0.0916 |          - |         - |         784 B |
| Day6PartTwo  |          11.738 μs |          11.692 μs |     0.0916 |          - |         - |         784 B |
| Day7PartOne  |         281.941 μs |         281.856 μs |     7.3242 |     0.4883 |         - |         64 Kb |
| Day7PartTwo  |          48.278 μs |          48.350 μs |     7.6294 |     0.6104 |         - |         64 Kb |
| Day8PartOne  |          28.676 μs |          28.664 μs |     6.2561 |          - |         - |         52 Kb |
| Day8PartTwo  |       5,678.014 μs |       5,673.985 μs |  1000.0000 |          - |         - |          8 Mb |
| Day9PartOne  |          66.607 μs |          66.637 μs |     0.2441 |          - |         - |          2 Kb |
| Day9PartTwo  |       3,306.705 μs |       3,306.549 μs |   121.0938 |    70.3125 |   39.0625 |          1 Mb |
| Day10PartOne |          89.390 μs |          89.300 μs |     2.5635 |          - |         - |         22 Kb |
| Day10PartTwo |          93.179 μs |          93.354 μs |     2.6855 |          - |         - |         23 Kb |
| Day11PartOne |         681.309 μs |         683.382 μs |          - |          - |         - |          4 Kb |
| Day11PartTwo |       1,766.330 μs |       1,767.817 μs |          - |          - |         - |          8 Kb |
| Day12PartOne |       5,853.634 μs |       5,861.913 μs |   585.9375 |   273.4375 |         - |          4 Mb |
| Day12PartTwo |     338,279.287 μs |     339,260.400 μs | 16000.0000 |  7000.0000 | 3000.0000 |        137 Mb |
| Day13PartOne |          27.330 μs |          27.357 μs |     4.1199 |     0.3357 |         - |         34 Kb |
| Day13PartTwo |         178.038 μs |         178.093 μs |    25.6348 |     1.9531 |         - |        216 Kb |
| Day14PartOne |         193.024 μs |         192.913 μs |     5.3711 |          - |         - |         46 Kb |
| Day14PartTwo |         891.054 μs |         891.379 μs |    21.4844 |          - |         - |        185 Kb |
| Day15PartOne |      24,293.812 μs |      24,517.312 μs |   218.7500 |    93.7500 |   93.7500 |          1 Mb |
| Day15PartTwo |   1,609,838.165 μs |   1,613,470.300 μs |  3000.0000 |  2000.0000 | 1000.0000 |         35 Mb |
| Day16PartOne |          99.704 μs |          99.680 μs |    11.7188 |     1.2207 |         - |         98 Kb |
| Day16PartTwo |          88.107 μs |          88.013 μs |    10.1318 |     1.0986 |         - |         84 Kb |
|     Year2021 |   2,103,318.633 μs |   2,098,189.100 μs | 24000.0000 | 11000.0000 | 4000.0000 |        205 Mb |