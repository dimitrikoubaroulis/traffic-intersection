using System;
using NUnit.Framework;

namespace TrafficLights.Tests {

    [TestFixture]
    public class TrafficIntersectionControllerTests {

        [Test]
        public void ShouldConstructWithValidContext() {
            var controller = CreateSampleSimulation();
        }

        [Test]
        [ExpectedException(typeof(TrafficControlException))]
        public void ShouldNotConstructWithInvalidContext() {
            var controller = new TrafficIntersectionController(null);
        }

        [Test]
        public void ShouldNotAllowConcurrentSimulations() {
            var controller = CreateSampleSimulation();
            Assert.True(controller.StartSimulation());
            Assert.False(controller.StartSimulation());
        }

        [Test]
        public void ShouldStartAndStopSimulation() {
            var controller = CreateSampleSimulation();
            Assert.True(controller.StartSimulation());
            controller.StopSimulation();
            Assert.True(controller.StartSimulation());
            controller.StopSimulation();
        }

        [Test]
        public void ShouldCorrectlyDetermineStateTransitionTimeout() {
            var controller = CreateSampleSimulation();
            Assert.That(
                controller.TimeWaitCorrespondingTo(TrafficIntersectionModel.LightStates.NorthSouthGreenEastWestRed),
                Is.EqualTo(controller.Context.RedLightDurationSeconds - controller.Context.YellowLightDurationSeconds));

            Assert.That(
                controller.TimeWaitCorrespondingTo(TrafficIntersectionModel.LightStates.NorthSouthRedEastWestGreen),
                Is.EqualTo(controller.Context.RedLightDurationSeconds - controller.Context.YellowLightDurationSeconds));

            Assert.That(
                controller.TimeWaitCorrespondingTo(TrafficIntersectionModel.LightStates.NorthSouthYellowEastWestRed),
                Is.EqualTo(controller.Context.YellowLightDurationSeconds));

            Assert.That(
                controller.TimeWaitCorrespondingTo(TrafficIntersectionModel.LightStates.NorthSouthRedEastWestYellow),
                Is.EqualTo(controller.Context.YellowLightDurationSeconds));
        }

        [Test]
        public void ShouldTransitionStatesCorrectly() {
            var controller = CreateSampleSimulation();
            Assert.That(controller.State, Is.Null);
            controller.UpdateModel(DateTime.Now);
            Assert.That(controller.State.LightState, Is.EqualTo(TrafficIntersectionController.InitialLightState));
            controller.UpdateModel(DateTime.Now);
            Assert.That(controller.State.LightState, Is.EqualTo(TrafficIntersectionModel.LightStates.NorthSouthYellowEastWestRed));
            controller.UpdateModel(DateTime.Now);
            Assert.That(controller.State.LightState, Is.EqualTo(TrafficIntersectionModel.LightStates.NorthSouthRedEastWestGreen));
            controller.UpdateModel(DateTime.Now);
            Assert.That(controller.State.LightState, Is.EqualTo(TrafficIntersectionModel.LightStates.NorthSouthRedEastWestYellow));
            controller.UpdateModel(DateTime.Now);
            Assert.That(controller.State.LightState, Is.EqualTo(TrafficIntersectionModel.LightStates.NorthSouthGreenEastWestRed));
        }

        [Test]
        [ExpectedException(typeof(TrafficControlException))]
        public void ShouldOnlyAllowIncreasingTimestamps() {
            var controller = CreateSampleSimulation();
            controller.UpdateModel(DateTime.Now.AddHours(1));
            Assert.That(controller.State.LightState, Is.EqualTo(TrafficIntersectionController.InitialLightState));
            controller.UpdateModel(DateTime.Now);
        }

        [Test]
        public void ShouldCorrectlyDetermineStateTimedOut() {
            var controller = CreateSampleSimulation();
            Assert.True(controller.ShouldTransitionStateAt(DateTime.Now));
            controller.OnStateTransitionRequestedAt(DateTime.Now);
            Assert.False(controller.ShouldTransitionStateAt(DateTime.Now));
        }

        private static TrafficIntersectionController CreateSampleSimulation() {
            var ctx = new TrafficIntersectionContext(
                10, 5, TimeProvider.PrecalculatedTimeTickGeneratorPerSecond(1000));
            var controller = new TrafficIntersectionController(ctx);
            return controller;
        }


    }
}