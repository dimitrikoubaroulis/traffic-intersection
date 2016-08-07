namespace TrafficLights {
    public class TrafficIntersectionView {
        public TrafficIntersectionView(TrafficIntersectionModel.LightStates state) {
            NorthSouthTrafficeLight = new TrafficLight();
            EastWestTrafficLight = new TrafficLight();
            Update(state);
        }

        public void Update(TrafficIntersectionModel.LightStates state) {
            switch (state) {
                case TrafficIntersectionModel.LightStates.NorthSouthRedEastWestGreen: {
                        NorthSouthTrafficeLight.Colour = TrafficLightColour.Red;
                        EastWestTrafficLight.Colour = TrafficLightColour.Green;
                        break;
                    }
                case TrafficIntersectionModel.LightStates.NorthSouthRedEastWestYellow: {
                        EastWestTrafficLight.Colour = TrafficLightColour.Yellow;
                        break;
                    }
                case TrafficIntersectionModel.LightStates.NorthSouthGreenEastWestRed: {
                        EastWestTrafficLight.Colour = TrafficLightColour.Red;
                        NorthSouthTrafficeLight.Colour = TrafficLightColour.Green;
                        break;
                    }
                case TrafficIntersectionModel.LightStates.NorthSouthYellowEastWestRed: {
                        NorthSouthTrafficeLight.Colour = TrafficLightColour.Yellow;
                        break;
                    }
                default:
                    throw new TrafficControlException("Invalid light state.");
            }
        }

        public TrafficLight NorthSouthTrafficeLight { get; }
        public TrafficLight EastWestTrafficLight { get; }
    }
}