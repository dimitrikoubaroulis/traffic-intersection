using System;
using System.Reactive;

namespace TrafficLights {

    public class TrafficIntersectionController : IDisposable {

        public TrafficIntersectionController(
            TrafficIntersectionContext trafficIntersectionContext) {
            Context = trafficIntersectionContext;

            // Could inject these as constructor dependencies
            State = null;
            View = new TrafficIntersectionView(InitialLightState);

            ValidatePreconditions();

            GreenLightDurationSeconds = Context.RedLightDurationSeconds - Context.YellowLightDurationSeconds;
        }

        public bool StartSimulation() {
            if (_timeProviderListener != null) {
                Console.WriteLine("Simulation is already running. Please stop it first.");
                return false;
            }

            Console.WriteLine("Starting traffic intersection simulation");
            _timeProviderListener = Context.TimeProvider.Subscribe(OnTimeEventReceived);
            return true;
        }

        public void StopSimulation() {
            Console.WriteLine("Completed traffic intersection simulation");
            _timeProviderListener.Dispose();
            _timeProviderListener = null;
        }

        public void Dispose() {
            _timeProviderListener.Dispose();
        }


        private void ValidatePreconditions() {
            if (Context == null) {
                throw new TrafficControlException("Must provide a valid context to initialise the traffic intersection.");
            }
        }

        internal int TimeWaitCorrespondingTo(TrafficIntersectionModel.LightStates state) {
            return state == TrafficIntersectionModel.LightStates.NorthSouthGreenEastWestRed ||
                   state == TrafficIntersectionModel.LightStates.NorthSouthRedEastWestGreen ?
                GreenLightDurationSeconds :
                Context.YellowLightDurationSeconds;
        }

        internal void OnTimeEventReceived(Timestamped<long> timeStamp) {
            var timeTick = timeStamp.Timestamp.DateTime;

            if (ShouldTransitionStateAt(timeTick)) {
                OnStateTransitionRequestedAt(timeTick);
            }
        }

        internal void OnStateTransitionRequestedAt(DateTime timeStamp) {
            var state = UpdateModel(timeStamp);
            StateTransitionTimeoutSeconds = TimeWaitCorrespondingTo(state.LightState);
            View.Update(state.LightState);
            LogState(state);
        }

        internal TrafficIntersectionModel UpdateModel(DateTime timeStamp) {
            if (State != null && timeStamp < State.LastStateTransitionAt) {
                throw new TrafficControlException("Time stamps must be in increasing order.");
            }

            var newLightState = State == null ?
                InitialLightState :
                (TrafficIntersectionModel.LightStates)(((int)State.LightState + 1) % 4);


            var newState = new TrafficIntersectionModel(newLightState, timeStamp);

            State = newState;
            return State;
        }

        internal bool ShouldTransitionStateAt(DateTime timestamp) {
            return State == null || State.LastStateTransitionAt.AddSeconds(StateTransitionTimeoutSeconds) <= timestamp;
        }

        private static void LogState(TrafficIntersectionModel state) {
            Console.WriteLine($"{state.LastStateTransitionAt} : {state.LightState}");
        }


        internal int GreenLightDurationSeconds { get; }
        internal int StateTransitionTimeoutSeconds { get; set; }

        private IDisposable _timeProviderListener;

        // chosen arbitrarily
        internal const TrafficIntersectionModel.LightStates InitialLightState =
            TrafficIntersectionModel.LightStates.NorthSouthGreenEastWestRed;

        public TrafficIntersectionView View;

        public TrafficIntersectionContext Context { get; set; }

        internal TrafficIntersectionModel State { get; set; }
    }
}