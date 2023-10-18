using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace ClientProj
{
    public class BloodPressureSensor
    {
        Random rand;
        private double _pastPressure = 100;
        private bool _peakP = false;
        private bool _buttomP = true;
        public BloodPressureSensor()
        {
            rand = new Random();
        }

        public double Sample()
        {
            var chance = rand.Next(0, 100);

            if (chance > 80)
            {
                return Pressure(chance);
            }
            else if (chance < 20)
            {
                return Pressure(-chance);
            }
            else
            {
                return Pressure(chance);
            }
        }
        private double Pressure(int chance)
        {
            var pressureVarians = 1 + chance/100;
            if(_pastPressure < 200 || _pastPressure > 85)
            {
                _pastPressure += pressureVarians;
            } else
            {
                _pastPressure--;
            }
            return _pastPressure;
        }
    }
}