namespace Vulcan.Domain.OnlineMetrics
{
    interface IBasicStats
    {
        double Max { get;  }
        double Variance { get;  }
        double Mean { get;  }
        double Min { get;  }
        int CurrentNumberOfDataPoints { get;  }
        void AddDataPoint(double newNumber); 
    }
}
