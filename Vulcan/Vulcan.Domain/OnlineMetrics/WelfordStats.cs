using System;

namespace Vulcan.Domain.OnlineMetrics
{
    class WelfordStats: IBasicStats
    {
        public double Max { get; private set; }
        public double Variance { get; private set; }
        public double Mean { get; private set; }
        public double Min { get; private set; }
        public int CurrentNumberOfDataPoints { get; private set; }

        private event Action<double> ReceivedNewDataPoint;

        public WelfordStats()
        {
            Max = double.NegativeInfinity;
            Min = double.PositiveInfinity;
            ReceivedNewDataPoint += UpdateMax;
            ReceivedNewDataPoint += UpdateMin;
            ReceivedNewDataPoint += UpdateMeanAndVariance; 

        }
        public void AddDataPoint(double newNumber)
        {
            CurrentNumberOfDataPoints++;
            ReceivedNewDataPoint(newNumber); 
        }

        private void UpdateMin(double newNumber)
        {
            Min = Math.Min(Min, newNumber); 
        }

        private void UpdateMax(double newNumber)
        {
            Max = Math.Max(Max, newNumber); 
        }

        private void UpdateMeanAndVariance(double newNumber)
        {
            if (CurrentNumberOfDataPoints == 1)
            {
                Mean = newNumber;
                Variance = 0; 
                return;
            }

            int previousNumberOfDataPoints = CurrentNumberOfDataPoints - 1;
            double previousMean = Mean;
            double previousVariance = Variance; 
            
            Mean = previousMean + (newNumber - previousMean) / CurrentNumberOfDataPoints ;
            Variance = (previousVariance + (newNumber - previousMean) * (newNumber - Mean)) / previousNumberOfDataPoints;
        }
    }
}
