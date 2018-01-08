``` ini

BenchmarkDotNet=v0.10.11, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.192)
Processor=Intel Core i7-4720HQ CPU 2.60GHz (Haswell), ProcessorCount=8
Frequency=2533207 Hz, Resolution=394.7565 ns, Timer=TSC
.NET Core SDK=2.1.2
  [Host]     : .NET Core 2.0.3 (Framework 4.6.25815.02), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.3 (Framework 4.6.25815.02), 64bit RyuJIT


```
|                      Method |             String1 |           String2 |          Mean |       Error |      StdDev | Scaled |      Gen 0 |    Gen 1 |    Gen 2 |   Allocated |
|---------------------------- |-------------------- |------------------ |--------------:|------------:|------------:|-------:|-----------:|---------:|---------:|------------:|
|         **LevenshteinDistance** | **RandomString[10000]** | **RandomString[100]** |  **8,261.118 us** |  **83.8376 us** |  **74.3198 us** |   **0.23** |   **992.1875** | **992.1875** | **992.1875** |  **3965.54 KB** |
| LevenshteinDistanceBaseline | RandomString[10000] | RandomString[100] | 35,506.764 us | 227.1435 us | 212.4702 us |   1.00 | 21062.5000 | 875.0000 | 812.5000 | 66465.62 KB |
|         **LevenshteinDistance** |  **RandomString[1000]** | **RandomString[100]** |    **866.979 us** |   **7.5294 us** |   **6.6746 us** |   **0.24** |   **124.0234** | **124.0234** | **124.0234** |   **397.18 KB** |
| LevenshteinDistanceBaseline |  RandomString[1000] | RandomString[100] |  3,585.358 us |  45.1899 us |  42.2706 us |   1.00 |  2035.1563 | 128.9063 | 125.0000 |  6647.18 KB |
|         **LevenshteinDistance** |   **RandomString[100]** | **RandomString[100]** |     **89.174 us** |   **1.0989 us** |   **1.0279 us** |   **0.24** |    **13.0615** |        **-** |        **-** |    **40.34 KB** |
| LevenshteinDistanceBaseline |   RandomString[100] | RandomString[100] |    364.125 us |   4.8533 us |   4.5398 us |   1.00 |   216.3086 |        - |        - |   665.34 KB |
|         **LevenshteinDistance** |    **RandomString[10]** | **RandomString[100]** |      **7.996 us** |   **0.0664 us** |   **0.0555 us** |   **0.23** |     **1.5106** |        **-** |        **-** |     **4.66 KB** |
| LevenshteinDistanceBaseline |    RandomString[10] | RandomString[100] |     35.245 us |   0.3588 us |   0.3356 us |   1.00 |    21.8506 |        - |        - |    67.16 KB |
