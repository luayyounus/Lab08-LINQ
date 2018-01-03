# Manhattan Properties with LINQ

**Author**: Luay Younus
**Version**: 1.0

## Overview
A property output console application that present queries to the user based on different conditons.

## Requirements to run the Application
- [Visual Studio 2017 Community with .NET Core 2.0 SDK](https://www.microsoft.com/net/core#windowscmd)
- [GitBash / Terminal](https://git-scm.com/downloads) or [GitHub Extension for Visual Studio](https://visualstudio.github.com)

## Getting Started
1. Clone the repository to your local machine.
2. Cd into the application directory where the `AppName.sln` exist.
3. Open the application using `Open/Start AppName.sln`.
4. Once Visual Studio is opened, you can Run the application by clicking on the Play button <img src="https://github.com/luayyounus/Lab02-Unit-Testing/blob/Lab02-Luay/WarCardGame/play-button.jpg" width="16"> .

### An interface will be presented to the user asking for an entry to print out the properties available.

### Packages used in the application
- [NewtonSoftJson](https://www.newtonsoft.com/json)
- [JSON2Csharp Classes Maker](http://json2csharp.com/)

## Project Explanation

###### Provided a Data.Json file with a list of properties, the following are performed to retrieve data
1. Define Classes using JSON2Csharp tool each with their own properties
- RootObject
- Feature
- Geometry
- Properties

2. Class JsonDeserializer is where NewtonSoft Json tool is used to de-serializing the data in file using the `RootObjectClass`.
```C#
string json = sr.ReadToEnd();

RootObject featuresCollection = JsonConvert.DeserializeObject<RootObject>(json);
```

3. Next, the neighborhood are filtered based on the query performed
- Query to get All Neighborhoods
```C#
IEnumerable<Feature> allNeighborhoods = from obj in rootObject.Features
                                        where obj.Properties.Neighborhood != null
                                        select obj;
```
- Query to get Neighborhoods without empty name fields
```C#
var filteredNeighborhoods = allNeighborhoods.Where(n => n.Properties.Neighborhood != "");
```

- Query to find the first apperance of every neighborhood and group them into a collection
```C#
var uniqueNeighborhoods = filteredNeighborhoods.GroupBy(p => p.Properties.Neighborhood).Select(m => m.First());
```

- Query to sum up all the previous queries in one single line
```C#
var allInOne = rootObject.Features.Where(j => j.Properties.Neighborhood != "").GroupBy(p => p.Properties.Neighborhood).Select(m => m.First());
```

## Architecture
 - C# Console Core application.
