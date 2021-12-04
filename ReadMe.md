
# Advent Of Code 2021 with C#

## Solved Challenges
| Day | Part 1 | Part 2 |
|-----|--------|--------|
|1    | ✔️     |    ✔️ |
|2    | ✔️     |    ✔️ |
|3    | ✔️     |    ✔️ |
|4    | ✔️     |    ✔️ |

## Perfomance (Measured with BenchmarkDotNet)
|          Method |          Mean |        Error |       StdDev |        Median |   Gen 0 |  Gen 1 | Allocated |
|---------------- |--------------:|-------------:|-------------:|--------------:|--------:|-------:|----------:|
| Day1PartOneTest |      12.86 ns |     0.428 ns |     1.261 ns |      13.50 ns |       - |      - |         - |
| Day1PartTwoTest |      13.73 ns |     0.442 ns |     1.304 ns |      12.90 ns |       - |      - |         - |
|     Day1PartOne |   2,163.28 ns |    73.876 ns |   217.826 ns |   2,116.62 ns |       - |      - |         - |
|     Day1PartTwo |   3,043.61 ns |    65.430 ns |   192.923 ns |   3,089.54 ns |       - |      - |         - |
| Day2PartOneTest |      74.18 ns |     0.753 ns |     0.896 ns |      73.97 ns |       - |      - |         - |
| Day2PartTwoTest |      78.49 ns |     0.362 ns |     0.302 ns |      78.45 ns |       - |      - |         - |
|     Day2PartOne |  15,945.80 ns |   125.146 ns |   104.503 ns |  15,963.14 ns |       - |      - |         - |
|     Day2PartTwo |  15,325.78 ns |   112.456 ns |    93.906 ns |  15,346.05 ns |       - |      - |         - |
| Day3PartOneTest |     102.55 ns |     0.741 ns |     0.657 ns |     102.26 ns |  0.0057 |      - |      48 B |
| Day3PartTwoTest |     724.39 ns |     7.097 ns |    10.622 ns |     721.62 ns |  0.2460 |      - |   2,064 B |
|     Day3PartOne |  48,956.77 ns |   399.059 ns |   373.280 ns |  48,832.59 ns |       - |      - |      72 B |
|     Day3PartTwo |  31,874.26 ns |   313.122 ns |   687.309 ns |  31,762.81 ns | 13.3667 | 0.7935 | 111,960 B |
| Day4PartOneTest |   3,486.86 ns |    33.144 ns |    25.876 ns |   3,495.62 ns |  0.3815 |      - |   3,208 B |
| Day4PartTwoTest |   4,821.14 ns |    46.350 ns |    38.704 ns |   4,819.74 ns |  0.5341 |      - |   4,504 B |
|     Day4PartOne | 130,352.31 ns | 1,296.685 ns | 2,735.148 ns | 130,108.89 ns | 11.7188 | 2.6855 |  99,432 B |
|     Day4PartTwo | 328,981.90 ns | 2,365.368 ns | 2,096.837 ns | 329,584.94 ns | 18.5547 | 3.4180 | 158,424 B |
