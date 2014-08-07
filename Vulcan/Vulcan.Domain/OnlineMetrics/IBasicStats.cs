using System.Diagnostics.Contracts;

namespace Vulcan.Domain.OnlineMetrics
{
    [ContractClass(typeof(BasicStatsContracts))]
    public interface IBasicStats
    {
        double Max { get;  }
        double Variance { get;  }
        double Mean { get;  }
        double Min { get;  }
        int CurrentNumberOfDataPoints { get;  }
        void AddDataPoint(double newNumber);
    }
}
