using System;

namespace TrafficLights {

    public class Program {
        public static void Main(string[] args) {

            var context = new TrafficIntersectionContext(
                redLightDurationSeconds: 5 * 60,
                yellowLightDurationSeconds: 30,
                timeProvider: TimeProvider.TimeTickGeneratorPerSecond());

            var simulation = new TrafficIntersectionController(context);

            simulation.StartSimulation();
            Console.ReadKey();
            simulation.StopSimulation();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
