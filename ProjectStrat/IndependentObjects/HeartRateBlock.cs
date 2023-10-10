namespace ProjectStrat
{
    public class HeartRateBlock
    {
        private int _value;
        //object _lock = new();
        public int Value {
            get 
            {
                return _value;
                //lock (_lock) { return _value; }
            }
            set 
            {
                _value = value;
                //lock(_lock) { _value = value; }
            }
        }
    }
}