## FullyExternalCS2

### Description

FullyExternalCS2 is an external cheat for Counter-Strike 2 **that does not write to the game memory**. \
It was created for the _purpose_ of _improving_ Windows API skills.

![Demo](/assets/photo.jpg)

#### Features

- Aim Crosshair
- AimBot on key with RCS (default = LBUTTON)
- Esp Skeleton
- Trigger Bot on key (default = LAlt)
- BunnyHop (Read [this](https://github.com/sweeperxz/FullyExternalCS2/blob/31f90c2fe4825ac86ba6862531dc633ab6d3aef0/Data/Player.cs#L60))

### Getting started

**Dependencies**

```cs
    <ItemGroup>
        <PackageReference Include="GameOverlay.Net" Version="4.3.1"/>
        <PackageReference Include="InputSimulator" Version="1.0.4"/>
        <PackageReference Include="Overlay.NET" Version="1.0.2"/>
        <PackageReference Include="PresentationFramework" Version="4.6.0"/>
        <PackageReference Include="SharpDX.Direct3D9" Version="4.2.0"/>
        <PackageReference Include="SharpDX.DXGI" Version="4.2.0"/>
    </ItemGroup>
```

**Installation**

```bash
git clone https://github.com/sweeperxz/FullyExternalCS2.git
cd FullyExternalCS2
```

### Starting the program

```bash
dotnet build
dotnet run
```

### Help

If you have issues or have questions, check out the Issues section of the GitHub project page.

### Authors

- sweeperxz - Developer/Engineer

### Acknowledgements

- Inspired by [Martynas Apanavicius](https://www.linkedin.com/in/martynas-apanavicius/).
- [unknowncheats.me](https://www.unknowncheats.me/)
- [yougame.biz](https://yougame.biz/threads/191134/)
- [cs-dumper](https://github.com/a2x/cs2-dumper)
