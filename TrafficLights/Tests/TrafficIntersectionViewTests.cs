using NUnit.Framework;

namespace TrafficLights.Tests {
    [TestFixture]
    public class TrafficIntersectionViewTests {

        [Test]
        public void ShouldConstructCorrectlyGivenModelState() {
            ExpectLightColour(TrafficIntersectionModel.LightStates.NorthSouthGreenEastWestRed,
                TrafficLightColour.Green, TrafficLightColour.Red);

            ExpectLightColour(TrafficIntersectionModel.LightStates.NorthSouthYellowEastWestRed,
                 TrafficLightColour.Yellow, TrafficLightColour.Red);

            ExpectLightColour(TrafficIntersectionModel.LightStates.NorthSouthRedEastWestGreen,
                TrafficLightColour.Red, TrafficLightColour.Green);

            ExpectLightColour(TrafficIntersectionModel.LightStates.NorthSouthRedEastWestYellow,
                TrafficLightColour.Red, TrafficLightColour.Yellow);
        }

        [Test]
        public void ShouldUpdateCorrectlyGivenModelState() {
            var view = new TrafficIntersectionView(TrafficIntersectionModel.LightStates.NorthSouthGreenEastWestRed);

            view.Update(TrafficIntersectionModel.LightStates.NorthSouthYellowEastWestRed);
            ExpectLightColour(view, TrafficLightColour.Yellow, TrafficLightColour.Red);

            view.Update(TrafficIntersectionModel.LightStates.NorthSouthRedEastWestGreen);
            ExpectLightColour(view, TrafficLightColour.Red, TrafficLightColour.Green);

            view.Update(TrafficIntersectionModel.LightStates.NorthSouthRedEastWestYellow);
            ExpectLightColour(view, TrafficLightColour.Red, TrafficLightColour.Yellow);

            view.Update(TrafficIntersectionModel.LightStates.NorthSouthGreenEastWestRed);
            ExpectLightColour(view, TrafficLightColour.Green, TrafficLightColour.Red);
        }

        private static void ExpectLightColour(
            TrafficIntersectionModel.LightStates state,
            TrafficLightColour expectedNorthSouthColour,
            TrafficLightColour expectedEastWestColour) {
            var view = new TrafficIntersectionView(state);
            ExpectLightColour(view, expectedNorthSouthColour, expectedEastWestColour);
        }

        private static void ExpectLightColour(
            TrafficIntersectionView view,
            TrafficLightColour expectedNorthSouthColour,
            TrafficLightColour expectedEastWestColour) {
            Assert.That(view.NorthSouthTrafficeLight.Colour, Is.EqualTo(expectedNorthSouthColour));
            Assert.That(view.EastWestTrafficLight.Colour, Is.EqualTo(expectedEastWestColour));
        }
    }
}