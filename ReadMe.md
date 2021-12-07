
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
| Day5PartOne | 11,018.950 μs | 108.3608 μs | 144.6585 μs | 1093.7500 | 812.5000 | 765.6250 |        11 Mb |
| Day5PartTwo | 20,679.200 μs | 153.4410 μs | 182.6606 μs | 1468.7500 | 906.2500 | 843.7500 |        23 Mb |
| Day6PartOne |      5.825 μs |   0.1326 μs |   0.3888 μs |    0.0916 |        - |        - |        784 B |
| Day6PartTwo |     11.436 μs |   0.1547 μs |   0.4562 μs |    0.0916 |        - |        - |        784 B |
| Day7PartOne |  4,164.617 μs |  41.2745 μs |  53.6685 μs |   15.6250 |        - |        - |       158 Kb |
| Day7PartTwo | 20,223.807 μs | 179.9576 μs | 295.6755 μs |         - |        - |        - |       158 Kb |


