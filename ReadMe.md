
# Advent Of Code 2021 with C#

## Solved Challenges
| Day | Part 1 | Part 2 |
|-----|--------|--------|
|1    | ✔️     |    ✔️ |
|2    | ✔️     |    ✔️ |
|3    | ✔️     |    ✔️ |


## Perfomance (Measured with BenchmarkDotNet)
 |          Method |         Mean |      Error |     StdDev |       Median |   Gen 0 |  Gen 1 | Allocated |
|---------------- |-------------:|-----------:|-----------:|-------------:|--------:|-------:|----------:|
| Day1PartOneTest |     12.69 ns |   0.405 ns |   1.195 ns |     13.60 ns |       - |      - |         - |
|     Day1PartOne |  2,240.84 ns |  78.784 ns | 232.298 ns |  2,346.28 ns |       - |      - |         - |
| Day1PartTwoTest |     14.03 ns |   0.488 ns |   1.439 ns |     13.99 ns |       - |      - |         - |
|     Day1PartTwo |  5,304.40 ns | 105.601 ns | 309.708 ns |  5,467.06 ns |       - |      - |         - |
| Day2PartOneTest |     75.06 ns |   0.327 ns |   0.290 ns |     75.06 ns |       - |      - |         - |
|     Day2PartOne | 15,290.72 ns |  73.569 ns |  68.817 ns | 15,283.84 ns |       - |      - |         - |
| Day2PartTwoTest |     80.21 ns |   0.411 ns |   0.384 ns |     80.22 ns |       - |      - |         - |
|     Day2PartTwo | 15,489.79 ns |  70.635 ns |  55.147 ns | 15,484.50 ns |       - |      - |         - |
| Day3PartOneTest |     90.31 ns |   0.351 ns |   0.274 ns |     90.44 ns |  0.0057 |      - |      48 B |
|     Day3PartOne | 49,309.76 ns | 561.439 ns | 525.170 ns | 49,485.89 ns |       - |      - |      72 B |
| Day3PartTwoTest |    755.01 ns |   2.763 ns |   2.449 ns |    754.61 ns |  0.2460 |      - |   2,064 B |
|     Day3PartTwo | 33,448.94 ns | 508.492 ns | 450.765 ns | 33,335.03 ns | 13.3667 | 0.7935 | 111,960 B |
