using System;
using System.Reactive;

namespace TrafficLights {

    /// Supplies configuration and timing context to the simulation
    public class TrafficIntersectionContext {

        public TrafficIntersectionContext(
            int redLightDurationSeconds,
            int yellowLightDurationSeconds,
            IObservable<Timestamped<long>> timeProvider) {

            RedLightDurationSeconds = redLightDurationSeconds;
            YellowLightDurationSeconds = yellowLightDurationSeconds;
            TimeProvider = timeProvider;

            Validate();
        }

        private void Validate() {
            if (RedLightDurationSeconds < 1) {
                throw new TrafficControlException(
                    $"Invalid traffic light automatic switch interval {RedLightDurationSeconds}.");
            }

            if (YellowLightDurationSeconds < 1) {
                throw new TrafficControlException(
                    $"Invalid traffic light yellow light duration interval {YellowLightDurationSeconds}.");
            }

            if (YellowLightDurationSeconds >= RedLightDurationSeconds) {
                throw new TrafficControlException(
                    $"Yellow light duration {YellowLightDurationSeconds} must be shorter than automatic switch interval {RedLightDurationSeconds}.");
            }

            if (TimeProvider == null) {
                throw new TrafficControlException("Must supply a valid time event provider.");
            }
        }

        internal int RedLightDurationSeconds;
        internal int YellowLightDurationSeconds;
        internal IObservable<Timestamped<long>> TimeProvider { get; }
    }
}
