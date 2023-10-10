using ProjectStrat.Events;

namespace ProjectStrat
{
    public class UserInput
    {
        public event EventHandler<KeyPressEventArgs>? KeyEvent;
        private char _press;
        public bool exitKey = false;
        
        public void ButtonPress(char press)
        {
            _press = press;
            NotifyChildren();
        }

        private void NotifyChildren()
        {
            var theEvent = new KeyPressEventArgs() { Key = _press };
            KeyEvent?.Invoke(this, theEvent);
        }

        internal void CloseProgram(object? sender, KeyPressEventArgs e)
        {
            if (e.Key == 'e')
            {
                Console.Clear();
                exitKey = true;
            }
        }
    }
}