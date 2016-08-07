using NUnit.Framework;

namespace TrafficLights.Tests {

    [TestFixture]
    public class TrafficIntersectionSimulationTests {
        [TestCase(1 * 60, Result = TrafficIntersectionModel.LightStates.NorthSouthGreenEastWestRed)]
        [TestCase(4 * 60 + 50, Result = TrafficIntersectionModel.LightStates.NorthSouthYellowEastWestRed)]
        [TestCase(6 * 60, Result = TrafficIntersectionModel.LightStates.NorthSouthRedEastWestGreen)]
        [TestCase(30 * 60, Result = TrafficIntersectionModel.LightStates.NorthSouthRedEastWestYellow)]
        public TrafficIntersectionModel.LightStates ShouldRunSimulationForSeconds(int numberOfSeconds) {
            var context = new TrafficIntersectionContext(
                redLightDurationSeconds: 5 * 60,
                yellowLightDurationSeconds: 30,
                timeProvider: TimeProvider.PrecalculatedTimeTickGeneratorPerSecond(numberOfSeconds));

            var simulation = new TrafficIntersectionController(context);

            simulation.StartSimulation();
            simulation.StopSimulation();

            return simulation.State.LightState;
        }
    }
}