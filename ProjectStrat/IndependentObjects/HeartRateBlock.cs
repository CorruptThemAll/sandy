using System.Diagnostics;

namespace ProjectStrat
{
    public class HeartRateBlock
    {
        private int _value;
        //object _lock = new();
        public int Value {
            get 
            {
                Debug.WriteLine("HeartRateBlock getted");
                return _value;
                //lock (_lock) { return _value; }
            }
            set 
            {
                Debug.WriteLine("HeartRateBlock setted");
                _value = value;
                //lock(_lock) { _value = value; }
            }
        }
    }
}