namespace Functional
{
    public class Functional
    {
        static readonly Func<string, string>[] _display =
        {
            display => (!string.IsNullOrEmpty(display)).ToString() + " Empty String",
        };
        public string Display(string display)
        {
            var _this = _display
                .Select(func => func(display))
                .First();
            return _this;
        }
    }
}