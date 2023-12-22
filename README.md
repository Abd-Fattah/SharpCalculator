# SharpCalculator
A calculator application written in C# and Fusion.
Using Avalonia to draw GUI.

## Building
1. ensure that [FusionCalculator](https://github.com/Timerix22/FusionCalculator) submodule is up-to-date.
    ```shell
    git submodule init && git submodule update
    ```
2. Translate FusionCalculator to C#
    ```shell
    cd FusionCalculator
    ./build_cs.sh --translate-only
    cd ..
    ```
3. Build graphical application
    ```shell
    dotnet build -c release SharpCalculator.Avalonia/SharpCalculator.Avalonia.csproj 
    ```
