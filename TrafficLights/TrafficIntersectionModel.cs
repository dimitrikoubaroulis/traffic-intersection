using System;

namespace TrafficLights {
    public class TrafficIntersectionModel {
        public enum LightStates {
            NorthSouthRedEastWestGreen,
            NorthSouthRedEastWestYellow,
            NorthSouthGreenEastWestRed,
            NorthSouthYellowEastWestRed
        }

        public TrafficIntersectionModel() {
            LightState = LightStates.NorthSouthGreenEastWestRed;
            LastStateTransitionAt = DateTime.Now;
        }

        public TrafficIntersectionModel(LightStates lightState, DateTime lastTransitionAt) {
            LightState = lightState;
            LastStateTransitionAt = lastTransitionAt;
        }

        internal LightStates LightState { get; set; }

        internal DateTime LastStateTransitionAt { get; set; }
    }
}