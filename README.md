# pipelinestraining1

# -------------------------------------------------------------------
# App Solution File structure
# -------------------------------------------------------------------
<!-- 

root
  myApp
  myApp.Tests
  TrainProject.sln 

-->

# -------------------------------------------------------------------
# Commands to create the app "myApp" inside "TrainProject" Solution:
# -------------------------------------------------------------------
<!-- 

# Create a new folder and navigate into it
mkdir myApp
cd myApp

# Create a solution
dotnet new sln -n TrainProject

# Create a console app
dotnet new console -n myApp

# Add the console app to the solution
dotnet sln add myApp/myApp.csproj

# Add Figgle package to the "myApp" app
dotnet add myApp package Figgle

 -->

# -------------------------------------------------------------------
# Commands to add unit tests for "myApp" app inside "TrainProject" Solution:
# -------------------------------------------------------------------
<!-- 

# From the root of your solution, create "myApp" test project
dotnet new mstest -n myApp.Tests

# Add the "myApp" project reference to "myApp.Test" project
dotnet add myApp.Tests/myApp.Tests.csproj reference myApp/myApp.csproj

 -->

# -------------------------------------------------------------------
# Commands to Install and Use Required tools and packages:
# -------------------------------------------------------------------
<!-- 

# Code inspection
- cd myApp
- mkdir reports
- dotnet tool install JetBrains.ReSharper.GlobalTools --tool-path $DOTNET_TOOLS_PATH
- ."$DOTNET_TOOLS_PATH\jb.exe" inspectcode ./TrainProject.sln -o=reports/report

# Code inspection validation
- cd "../scripts"
- ./validate_report.ps1

# Unit tests and code coverage
- cd ../myApp.Tests
- mkdir reports
- dotnet add package coverlet.msbuild --package-directory $NUGET_PATH
- dotnet test -p:CollectCoverage=true -p:CoverletOutputFormat=cobertura -p:CoverletOutput=reports/coverage

# Code Coverage validation
- cd "../scripts"
- ./validate_coverage.ps1

# Unit tests report generation
- cd ../myApp.Tests
- dotnet tool install dotnet-reportgenerator-globaltool --tool-path $DOTNET_TOOLS_PATH
- ."$DOTNET_TOOLS_PATH\reportgenerator.exe" -reports:reports\coverage.cobertura.xml -targetdir:reports\coveragereport -reporttypes:Html

 -->
 