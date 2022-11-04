# Next Steps: Getting Top Marks for your next assignment
## Ace your next assignment with .NET and test driven development tips and techniques

- This session will require [Visual Studio](https://visualstudio.microsoft.com?WT.mc_id=academic-78652-leestott)
- Instruction are provided for [Visual Studio for Windows](https://visualstudio.microsoft.com/vs/?WT.mc_id=academic-78652-leestott)
- All Students can get Visual Studio Enterprise for FREE with [Azure for Student](http://aka.ms/azure4student)
- We will dive into the beauty of [Test driven design](https://www.agilealliance.org/glossary/tdd) and the amazing universe of [Roslyn refactoring](https://learn.microsoft.com/dotnet/csharp/roslyn-sdk/?WT.mc_id=academic-78652-leestott) and [code analysers](https://learn.microsoft.com/dotnet/framework/code-analyzers/?WT.mc_id=academic-78652-leestott).

---
## what do you need

 * [Visual Studio for Windows](https://visualstudio.microsoft.com/vs/?WT.mc_id=academic-78652-leestott)
 * [.NET SDK 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0/?WT.mc_id=academic-78652-leestott)

## How to get started

You will need to turn on `Live Unit Testing` (`LUT` for friends, [read more here](https://learn.microsoft.com/visualstudio/test/live-unit-testing?view=vs-2022?WT.mc_id=academic-78652-leestott)) to follow the session. First let's follow these steps:
 * open the solution file `Ace your next assignment with .NET.sln`
 * perform a ful build (common shortcut will be `CTRL+SHIFT+B` )
 * turn on *Live Unit Testing* using the menu `Test->live Unit Testing Window`
 * in the `Live Unit Testing` wundow hit the start (play) button, on first run will ask for setup
  * pick a directory to store the workspace 
  * click on `Finish`

    
  Now the `Live Unit Testing` will go on building the solution and discovering the test cases. Once is all done you can see that there are few tests defined and not working.

## Test implementation
We will cover two kind of assignment:
 * the implementation of a class to filter data
 * the implementation of web api to serve resume

While working we will take advantage of refactoring gestures ( you can read more [here](https://learn.microsoft.com/en-us/visualstudio/ide/refactoring-in-visual-studio?view=vs-2022?WT.mc_id=academic-78652-leestott)).

The projects are using [`XUnit` framework](https://xunit.net/) to declare our tests while [`FluentAssertion`](https://fluentassertions.com/) is our choice to provide meaninful feedback on our expectations.

In the `Resume-backend` assignment we are also taking advantage of [HTML Agility Pack](https://html-agility-pack.net/) to analyze the html context serverd from our api.

Make sure to check out the full session [Add a backend to your website](https://github.com/microsoft/dotnetconf-studentzone/tree/main/Add%20a%20backend%20to%20your%20website) to understand more about `minimal api`, `asp.net core`, and `Entity FRamework`. The `Resume-backend` is a a simplified version focusing on the testing aspect.
With `.NET` is easy to test web api thanks to the `Microsoft.AspNetCore.Mvc.Testing` nuget package, see more details about using `WebApplicationFactory` to test your app [here](https://learn.microsoft.com/aspnet/core/test/integration-tests?view=aspnetcore-6.0?WT.mc_id=academic-78652-leestott).

## Next then ..
Look for `README.ms` files in the folder `SignalProcessing` and `Resume-backend`, they describe the requirements that will help you implementing the tests that will drive your design process. Keep an eye for any hint from `Visual Studio`! Levergage quick fixes by clicking on icons or jsut use `CRTL+.` (that is the default setting in the IDE) to access refactoring tools, will be using a lot of those to help us create methods, classes, and update signatures.
