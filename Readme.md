REQUIREMENTS

Binary Windows executable is:
<Git checkout root>\TrafficLights\bin\Debug\TrafficLights.exe

To run the unit tests install NUnit 2.6.4 from
https://github.com/nunit/nunitv2/releases/download/2.6.4/NUnit-2.6.4.msi

TO RUN A LIVE SIMULATION

From a command prompt run

> <Git checkout root>\TrafficLights\bin\Debug\TrafficLights.exe

TO RUN THE UNIT TESTS

> cd <Git checkout root>\TrafficLights\bin\Debug
> "C:\Program Files (x86)\NUnit 2.6.4\bin\nunit-console-x86.exe" TrafficLights.exe

To run only the full simulation tests do

> "C:\Program Files (x86)\NUnit 2.6.4\bin\nunit-console-x86.exe" TrafficLights.exe /run:TrafficLights.Tests.TrafficIntersectionSimulationTests

which prints (among other tests) the output of a 30-minute simulation as follows:

Starting traffic intersection simulation
8/08/2016 12:51:14 AM : NorthSouthGreenEastWestRed
8/08/2016 12:55:44 AM : NorthSouthYellowEastWestRed
8/08/2016 12:56:14 AM : NorthSouthRedEastWestGreen
8/08/2016 1:00:44 AM : NorthSouthRedEastWestYellow
8/08/2016 1:01:14 AM : NorthSouthGreenEastWestRed
8/08/2016 1:05:44 AM : NorthSouthYellowEastWestRed
8/08/2016 1:06:14 AM : NorthSouthRedEastWestGreen
8/08/2016 1:10:44 AM : NorthSouthRedEastWestYellow
8/08/2016 1:11:14 AM : NorthSouthGreenEastWestRed
8/08/2016 1:15:44 AM : NorthSouthYellowEastWestRed
8/08/2016 1:16:14 AM : NorthSouthRedEastWestGreen
8/08/2016 1:20:44 AM : NorthSouthRedEastWestYellow
Completed traffic intersection simulation


