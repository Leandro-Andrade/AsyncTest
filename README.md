# Evision Test
### This solution covers Problems #1, #2 and #3 for the given test

---
**CI - Build status**

*You can click and access the build history at Wercker*

[![wercker status](https://app.wercker.com/status/22014aec7513eb3f25bd89464d694e5d/m/master "wercker status")](https://app.wercker.com/project/byKey/22014aec7513eb3f25bd89464d694e5d)


### **Requirements**
* .NET Core 2.x
* Bash client (if you are on Windows) - to run the build/test/pack script locally


### **Build**
* Build script is composed of 3 steps
	1. `dotnet build` - builds the entire solution
	2. `dotnet test` - Run the test project using XUnit
	3. `dotnet pack` - Produces a NuGet package
* Using a bash console, cd to /tools
* Execute the script with `./build` command

### **Tests**
* There is a unit unit test for AccountInfo that mocks the service with NSubstitute and asserts it behaves as expected.
* There is also an integration/acceptance test using xBehave and cucumber just to make it clear when running that this is testing the call are in fact asyncronously.
* If you wish, you can also trigger a new build at the CI (wercker) and it will run the tests as part of the build process.

### **Packing**
* The build script explained above(build section) will generate a NuGet Package of the class library under `./package` folder.

