# Requirements

Windows OS

To run the unit tests install NUnit 2.6.4 console runner:

https://github.com/nunit/nunitv2/releases/download/2.6.4/NUnit-2.6.4.msi

Solution and binaries provided are built with Visual Studio 2015.

# Running a live simulation

From a command prompt run

GIT-CHECKOUT-ROOT\TrafficLights\bin\Debug\TrafficLights.exe

# Running the unit test suite

cd GIT-CHECKOUT-ROOT\TrafficLights\bin\Debug

"C:\Program Files (x86)\NUnit 2.6.4\bin\nunit-console-x86.exe" TrafficLights.exe

# Running only the full simulation run tests

cd GIT-CHECKOUT-ROOT\TrafficLights\bin\Debug


"C:\Program Files (x86)\NUnit 2.6.4\bin\nunit-console-x86.exe" TrafficLights.exe /run:TrafficLights.Tests.TrafficIntersectionSimulationTests

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
