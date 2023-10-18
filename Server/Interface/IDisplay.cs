namespace Server.Interface
{
    public interface IDisplay
    {
        public void Log(object? o, BloodPressureSampleEventArgs e);
    }
}