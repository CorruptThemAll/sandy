namespace sandy
{
    public class Junction
    {
        public event EventHandler<EventArgs> eventHandle;

        List<Road> ConnectedRoads = new();
        public enum TrafficLight
        {
            MainRoad,
            SideRoad,
        }
        public TrafficLight CurrentState = TrafficLight.MainRoad;
        public void SwitchLight()
        {
            switch (CurrentState)
            {
                case TrafficLight.MainRoad:
                    CurrentState = TrafficLight.SideRoad;
                    break;
                case TrafficLight.SideRoad:
                    CurrentState = TrafficLight.MainRoad;
                    break;
            }
        }
    }
}


