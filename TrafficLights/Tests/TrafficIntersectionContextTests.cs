using NUnit.Framework;

namespace TrafficLights.Tests {

    [TestFixture]
    public class TrafficIntersectionContextTests {

        [TestCase(5 * 60, 30)]
        public void ShouldConstructContextWitValidParameters(
            int redLightDurationSeconds, int yellowLightDurationSeconds) {
            var ctx = new TrafficIntersectionContext(
                redLightDurationSeconds,
                yellowLightDurationSeconds,
                TimeProvider.TimeTickGeneratorPerSecond());
        }

        [TestCase(-1, 0, ExpectedException = typeof(TrafficControlException))]
        [TestCase(0, -1, ExpectedException = typeof(TrafficControlException))]
        [TestCase(0, 0, ExpectedException = typeof(TrafficControlException))]
        [TestCase(1, 2, ExpectedException = typeof(TrafficControlException))]
        public void ShouldNotConstructContextWithInvalidDurations(
            int redLightDurationSeconds, int yellowLightDurationSeconds) {
            var ctx = new TrafficIntersectionContext(
                redLightDurationSeconds,
                yellowLightDurationSeconds,
                TimeProvider.TimeTickGeneratorPerSecond());
        }

        [Test]
        [ExpectedException(typeof(TrafficControlException))]
        public void ShouldNotConstructContextWithInvalidTimeProvider() {
            var ctx = new TrafficIntersectionContext(
                10,
                20,
                null);
        }
    }
}
