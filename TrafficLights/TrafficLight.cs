namespace TrafficLights {
    public enum TrafficLightColour {
        Green,
        Yellow,
        Red
    }

    public class TrafficLight {

        public TrafficLight() {
            Colour = TrafficLightColour.Red;
        }

        public TrafficLightColour Colour { get; set; }
    }
}