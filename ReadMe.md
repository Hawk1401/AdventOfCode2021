
# Advent Of Code 2021 with C#

My personal goal is to have fun at finding new concepts in C#.
 

 
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
|      Method |          Mean |       Error |      StdDev |        Median |     Gen 0 |    Gen 1 |    Gen 2 |    Allocated |
|------------ |--------------:|------------:|------------:|--------------:|----------:|---------:|---------:|-------------:|
| Day1PartOne |      1.947 μs |   0.0153 μs |   0.0135 μs |      1.945 μs |         - |        - |        - |            - |
| Day1PartTwo |      2.493 μs |   0.0107 μs |   0.0100 μs |      2.494 μs |         - |        - |        - |            - |
| Day2PartOne |     14.977 μs |   0.0925 μs |   0.0909 μs |     14.985 μs |         - |        - |        - |            - |
| Day2PartTwo |     15.481 μs |   0.0701 μs |   0.0622 μs |     15.467 μs |         - |        - |        - |            - |
| Day3PartOne |     49.117 μs |   0.2349 μs |   0.2083 μs |     49.080 μs |         - |        - |        - |         72 B |
| Day3PartTwo |     32.077 μs |   0.2228 μs |   0.1975 μs |     32.067 μs |   13.3667 |   0.7324 |        - |       111 Kb |
| Day4PartOne |    124.997 μs |   1.2346 μs |   1.6054 μs |    125.280 μs |   11.8408 |   2.5635 |        - |        99 kB |
| Day4PartTwo |    324.572 μs |   2.7034 μs |   2.7762 μs |    324.331 μs |   18.5547 |   3.4180 |        - |       158 Kb |
| Day5PartOne | 10,873.637 μs | 100.6407 μs |  94.1393 μs | 10,889.230 μs | 1093.7500 | 812.5000 | 765.6250 |        11 Mb |
| Day5PartTwo | 20,302.755 μs | 200.4214 μs | 222.7678 μs | 20,261.881 μs | 1468.7500 | 906.2500 | 843.7500 |        23 Mb |
| Day6PartOne |      5.495 μs |   0.0356 μs |   0.0316 μs |      5.489 μs |    0.0916 |        - |        - |        784 B |
| Day6PartTwo |     11.738 μs |   0.1146 μs |   0.1177 μs |     11.692 μs |    0.0916 |        - |        - |        784 B |
| Day7PartOne |  4,302.013 μs |  44.7845 μs | 129.2135 μs |  4,347.446 μs |   15.6250 |        - |        - |       158 Kb |
| Day7PartTwo | 19,827.239 μs | 195.3842 μs | 286.3916 μs | 19,908.728 μs |         - |        - |        - |       158 Kb |
| Day8PartOne |     28.676 μs |   0.1525 μs |   0.1352 μs |     28.664 μs |    6.2561 |        - |        - |        52 Kb |
| Day8PartTwo |  5,678.014 μs |  21.3962 μs |  18.9672 μs |  5,673.985 μs | 1000.0000 |        - |        - |         8 Mb |

