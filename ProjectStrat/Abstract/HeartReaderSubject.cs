using ProjectStrat.Interface;
namespace ProjectStrat.Abstract;
public abstract class HeartReaderSubject
{
    private readonly List<IHeartRateReaderObserver> _observers = new();
    public void Attach(IHeartRateReaderObserver observer) => _observers.Add(observer);
    public void Detach(IHeartRateReaderObserver observer) => _observers?.Remove(observer);
    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update();
        }
    }
}