using System;
using System.Diagnostics.Contracts;

namespace Vulcan.Domain.OnlineMetrics
{
    [ContractClassFor(typeof(IBasicStats))]
    public abstract class BasicStatsContracts : IBasicStats
    {
        public double Max { get; private set; }
        public double Variance { get; private set; }
        public double Mean { get; private set; }
        public double Min { get; private set; }
        public int CurrentNumberOfDataPoints { get; private set; }

        void IBasicStats.AddDataPoint(double dataPoint)
        {
            Contract.Requires<ArgumentOutOfRangeException>(
                dataPoint > double.NegativeInfinity & dataPoint < double.PositiveInfinity,
                "Infinity cannot be added to the data collecation because we'd then lose all the previous data points."
                );


        }
    }
}