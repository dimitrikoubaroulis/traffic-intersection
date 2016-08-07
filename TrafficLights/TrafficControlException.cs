using System;
using System.Runtime.Serialization;

namespace TrafficLights {
    [Serializable]
    internal class TrafficControlException : Exception {
        public TrafficControlException() {
        }

        public TrafficControlException(string message) : base(message) {
        }

        public TrafficControlException(string message, Exception innerException) : base(message, innerException) {
        }

        protected TrafficControlException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}