using System.IO.Pipes;

namespace sandy.codewars
{
    public class PersistentBugger
    {
        public int Bugger(int num)
        {
            int persistence = 0;
            while (num > 10) 
            {
                string snum = num.ToString();
                int startValue = 1;
                foreach (char c in snum) 
                {
                    
                    startValue = (int)char.GetNumericValue(c) * startValue;
                }
                num = startValue;
                persistence++;
            }

            return persistence;
        }
    }
}