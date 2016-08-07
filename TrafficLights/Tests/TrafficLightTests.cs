using NUnit.Framework;

namespace TrafficLights.Tests {
    [TestFixture]
    public class TrafficLightTests {

        [Test]
        public void ShouldInitialiseWithRedLight() {
            Assert.That(new TrafficLight().Colour, Is.EqualTo(TrafficLightColour.Red));
        }

        [Test]
        public void ShouldBeAbleToChangeTheLightColour() {
            var light = new TrafficLight {Colour = TrafficLightColour.Yellow};
            Assert.That(light.Colour, Is.EqualTo(TrafficLightColour.Yellow));
        }
    }
}