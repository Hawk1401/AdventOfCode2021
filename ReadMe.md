
# Advent Of Code 2021 with C#

The goal is to play around and try new concepts in c#
 

 
## Solved Challenges
| Day | Part 1 | Part 2 |
|-----|--------|--------|
|1    | ✔️     |    ✔️ |
|2    | ✔️     |    ✔️ |
|3    | ✔️     |    ✔️ |
|4    | ✔️     |    ✔️ |
|5    | ✔️     |    ✔️ |

## Add session token

A session token is required to fetch the puzzle input. 
There are two different ways to provide the session token 

### Add session token in source code


Store the session token in the static variable "session",
This variable can be found in the "DayRunner" class in the "Core" namespace.




### Add session token as environment variable

It is also possible to store the session token as an environment variable. The name of the variable must be "SessionAdventofcode".



### Find the session token:

To find the session token you have to login to "adventofcode.com", open the dev tool, then Application → Cookies → https://adventofcode.com and finally copy the value of "Session".




### Get started

To start a riddle, the static method "run" of the class "DayRunner" must be called. This method gets an instance of the desired day. The days classes are in the namespace Year2021.Days.

As an example, to solve the problem of day 4, the code would have to look like this :
<pre><code class='language-cs'>
DayRunner.Run(new Day4());
</code></pre>


## Perfomance (Measured with BenchmarkDotNet)
|      Method |          Mean |       Error |      StdDev |     Gen 0 |    Gen 1 |    Gen 2 |    Allocated |
|------------ |--------------:|------------:|------------:|----------:|---------:|---------:|-------------:|
| Day1PartOne |      2.017 μs |   0.0186 μs |   0.0266 μs |         - |        - |        - |            - |
| Day1PartTwo |      4.875 μs |   0.0374 μs |   0.0292 μs |         - |        - |        - |            - |
| Day2PartOne |     15.516 μs |   0.0934 μs |   0.0780 μs |         - |        - |        - |            - |
| Day2PartTwo |     17.239 μs |   0.1386 μs |   0.1228 μs |         - |        - |        - |            - |
| Day3PartOne |     48.564 μs |   0.2319 μs |   0.2056 μs |         - |        - |        - |         72 B |
| Day3PartTwo |     33.469 μs |   0.2570 μs |   0.2278 μs |   13.3667 |   0.7324 |        - |       111 Kb |
| Day4PartOne |    124.170 μs |   0.5284 μs |   0.4943 μs |   11.7188 |   2.4414 |        - |        99 Kb |
| Day4PartTwo |    326.003 μs |   2.1746 μs |   2.0342 μs |   18.5547 |   3.4180 |        - |       158 Kb |
| Day5PartOne |      10.90 ms |    0.108 ms |    0.171 ms | 1093.7500 | 812.5000 | 765.6250 |        11 Mb |
| Day5PartTwo |      20.66 ms |    0.182 ms |    0.249 ms | 1468.7500 | 906.2500 | 843.7500 |        23 Mb |

