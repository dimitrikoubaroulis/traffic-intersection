using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;


namespace TrafficLights {
    public class TimeProvider {

        public static IObservable<Timestamped<long>> PrecalculatedTimeTickGeneratorPerSecond(int numberOfTicks) {
            var ticks = new List<Timestamped<long>>();

            var now = DateTime.Now;

            ticks.AddRange(
                Enumerable.Range(0, numberOfTicks)
                .Select(x => new Timestamped<long>(x, now.AddSeconds(x))));

            return ticks.ToObservable();
        }

        public static IObservable<Timestamped<long>> TimeTickGeneratorPerSecond() {
            return Observable.Timer(
                TimeSpan.FromSeconds(0),
                TimeSpan.FromSeconds(1))
                .Timestamp();
        }
    }
}
