``` ini

BenchmarkDotNet=v0.10.11, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.192)
Processor=Intel Core i7-4720HQ CPU 2.60GHz (Haswell), ProcessorCount=8
Frequency=2533207 Hz, Resolution=394.7565 ns, Timer=TSC
.NET Core SDK=2.1.2
  [Host]     : .NET Core 2.0.3 (Framework 4.6.25815.02), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.3 (Framework 4.6.25815.02), 64bit RyuJIT

```


|              Method |             String1 |           String2 |         Mean |       Error |      StdDev |      Gen 0 |    Gen 1 |    Gen 2 |  Allocated |
|-------------------- |-------------------- |------------------ |-------------:|------------:|------------:|-----------:|---------:|---------:|-----------:|
| **LevenshteinDistance** | **RandomString[10000]** | **RandomString[100]** | **35,775.90 us** | **601.6207 us** | **533.3210 us** | **21062.5000** | **875.0000** | **812.5000** | **66465.6 KB** |
| **LevenshteinDistance** |  **RandomString[1000]** | **RandomString[100]** |  **3,469.71 us** |  **34.6071 us** |  **28.8985 us** |  **2035.1563** | **128.9063** | **125.0000** | **6647.18 KB** |
| **LevenshteinDistance** |   **RandomString[100]** | **RandomString[100]** |    **362.57 us** |   **4.7108 us** |   **4.1760 us** |   **216.3086** |        **-** |        **-** |  **665.34 KB** |
| **LevenshteinDistance** |    **RandomString[10]** | **RandomString[100]** |     **34.65 us** |   **0.2365 us** |   **0.2097 us** |    **21.8506** |        **-** |        **-** |   **67.16 KB** |
