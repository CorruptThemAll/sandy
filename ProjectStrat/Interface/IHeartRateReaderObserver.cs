using ProjectStrat.Abstract;
using ProjectStrat.IndependentObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStrat.Interface
{
    public interface IHeartRateReaderObserver
    {
        public HeartReaderConsumer HeartReader { get; }
        public void Update();
    }
}
