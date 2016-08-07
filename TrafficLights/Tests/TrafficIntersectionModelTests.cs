using System;
using NUnit.Framework;

namespace TrafficLights.Tests {
    [TestFixture]
    public class TrafficIntersectionModelTests {

        [Test]
        public void ShouldConstructWithSensibleDefaultState() {
            var timeBeforeConstructingModel = DateTime.Now;

            var model = new TrafficIntersectionModel(
                TrafficIntersectionModel.LightStates.NorthSouthGreenEastWestRed,
                DateTime.Now);

            var timeAfterConstructingModel = DateTime.Now;

            Assert.That(model.LightState, Is.EqualTo(TrafficIntersectionModel.LightStates.NorthSouthGreenEastWestRed));

            Assert.True(model.LastStateTransitionAt >= timeBeforeConstructingModel &&
                model.LastStateTransitionAt <= timeAfterConstructingModel);
        }

        [Test]
        public void ShouldConstructWithStateAndTimestamp() {
            ValidateConstructionWithState(TrafficIntersectionModel.LightStates.NorthSouthGreenEastWestRed);
            ValidateConstructionWithState(TrafficIntersectionModel.LightStates.NorthSouthYellowEastWestRed);
            ValidateConstructionWithState(TrafficIntersectionModel.LightStates.NorthSouthRedEastWestGreen);          
            ValidateConstructionWithState(TrafficIntersectionModel.LightStates.NorthSouthRedEastWestYellow);
        }

        private static void ValidateConstructionWithState(TrafficIntersectionModel.LightStates state) {
            var timeStamp = DateTime.Now;
            var model = new TrafficIntersectionModel(state, timeStamp);
            ExpectModelState(model, state, timeStamp);
        }

        private static void ExpectModelState(
            TrafficIntersectionModel model,
            TrafficIntersectionModel.LightStates expectedState,
            DateTime expectedTimeStamp) {
            Assert.That(model.LightState, Is.EqualTo(expectedState));
            Assert.That(model.LastStateTransitionAt, Is.EqualTo(expectedTimeStamp));
        }

    }
}